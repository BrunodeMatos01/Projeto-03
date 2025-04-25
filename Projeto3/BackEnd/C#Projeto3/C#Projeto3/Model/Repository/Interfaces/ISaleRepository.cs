namespace C_Projeto3.Model.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sale>> List();
        Task<Sale> SearchById(Guid id);

        Task Save(Sale sale);
        Task Edit(Sale sale);
        Task<bool> Delete(Guid id);
    }
}
