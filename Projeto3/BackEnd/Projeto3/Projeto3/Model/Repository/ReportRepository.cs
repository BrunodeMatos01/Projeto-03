using C_Projeto3.Infra.Data;
using C_Projeto3.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using C_Projeto3.Model.Dtos;

namespace C_Projeto3.Model.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProdutoEstoqueDto>> BuscarEstoqueAtualAsync()
        {
            return await _context.Produtos
                .Select(p => new ProdutoEstoqueDto
                {
                    ProdutoId = p.Id,
                    Nome = p.Nome,
                    QuantidadeEmEstoque = p.Estoque
                })
                .ToListAsync();
        }

        public async Task<List<ProdutoVendaDto>> BuscarProdutosMaisVendidosAsync()
        {
            return await _context.product_sales
                .GroupBy(ps => new { ps.product_id })
                .Select(g => new ProdutoVendaDto
                {
                    ProdutoId = g.Key.product_id,
                    QuantidadeVendida = g.Sum(x => x.quantity)
                })
                .OrderByDescending(x => x.QuantidadeVendida)
                .Take(10)
                .ToListAsync();
        }
        public async Task<List<Sale>> BuscarVendasRecentesAsync()
        {
            return await _context.sales
                .OrderByDescending(s => s.date)
                .ToListAsync();
        }

    }
}