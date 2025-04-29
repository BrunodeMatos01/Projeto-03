using C_Projeto3.Model.Repository;
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
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("mais-vendidos")]
        public async Task<IActionResult> GetProdutosMaisVendidos()
        {
            var result = await _reportRepository.ProdutosMaisVendidos();
            return Ok(result);
        }

        [HttpGet("vendas-por-data")]
        public async Task<IActionResult> GetVendasPorData([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
        {
            var result = await _reportRepository.VendasPorData(inicio, fim);
            return Ok(result);
        }

        [HttpGet("estoque-atual")]
        public async Task<IActionResult> GetEstoqueAtual()
        {
            var result = await _reportRepository.EstoqueAtual();
            return Ok(result);
        }
    }
}
