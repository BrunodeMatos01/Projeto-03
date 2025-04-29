namespace C_Projeto3.Model.Repository.Interfaces
{
    public interface IRelatorioRepository
    {
        // Task<List<ProdutoEstoqueDto>> BuscarEstoqueAtualAsync();
        // Task<List<ProdutoVendaDto>> BuscarProdutosVendidosPorDataAsync(DateTime dataInicio, DateTime dataFim);
        Task<List<ProdutoVendaDto>> BuscarProdutosMaisVendidosAsync();
    }
}