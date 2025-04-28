using C_Projeto3.Infra.Data;
using C_Projeto3.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C_Projeto3.Model.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        // public async Task<List<ProdutoEstoqueDto>> BuscarEstoqueAtualAsync()
        // {
        //     return await _context.products
        //         .Select(p => new ProdutoEstoqueDto
        //         {
        //             ProdutoId = p.id,
        //             Nome = p.name,
        //             QuantidadeEmEstoque = p.quantity
        //         })
        //         .ToListAsync();
        // }
        //
        // public async Task<List<ProdutoVendaDto>> BuscarProdutosVendidosPorDataAsync(DateTime dataInicio, DateTime dataFim)
        // {
        //     return await _context.product_sales
        //         .Where(ps => ps.sale.date >= dataInicio && ps.sale.date <= dataFim)
        //         .GroupBy(ps => new { ps.product_id })
        //         .Select(g => new ProdutoVendaDto
        //         {
        //             ProdutoId = g.Key.product_id,
        //             QuantidadeVendida = g.Sum(x => x.quantity)
        //         })
        //         .OrderByDescending(x => x.QuantidadeVendida)
        //         .ToListAsync();
        // }

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
    }
}