using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C_Projeto3.Model.Repository.Interfaces;
using C_Projeto3.Model.Repository;

namespace C_Projeto3.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRelatorioRepository _reportRepository;

        public ReportController(IRelatorioRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("/api/report/best-selling")]
        public async Task<IActionResult> GetProdutosMaisVendidos()
        {
            var result = await _reportRepository.BuscarProdutosMaisVendidosAsync();
            return Ok(result);
        }

        [HttpGet("/api/report/stock")]
        public async Task<IActionResult> GetEstoqueAtual()
        {
            var result = await _reportRepository.BuscarEstoqueAtualAsync();
            return Ok(result);
        }
        [HttpGet("/api/report/recent-sales")]
        public async Task<IActionResult> GetVendasRecentes()
        {
            var vendas = await _reportRepository.BuscarVendasRecentesAsync();
            return Ok(vendas);
        }
    }
}
