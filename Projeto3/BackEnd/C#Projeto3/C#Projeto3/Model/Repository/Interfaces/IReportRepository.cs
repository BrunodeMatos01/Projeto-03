using C_Projeto3.Model.Dtos;

namespace C_Projeto3.Model.Repository.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<ProdutoEstoqueDto>> BuscarEstoqueAtualAsync();
        Task<List<ProdutoVendaDto>> BuscarProdutosMaisVendidosAsync();
        Task<List<Sale>> BuscarVendasRecentesAsync();
    }
}