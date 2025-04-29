namespace projeto3.api.Models.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> Listar();
        Task<Produto> GetById(Guid id);
        Task<Produto> Salvar(Produto produto);
        Task<bool> Excluir(Guid id);
    }
}
