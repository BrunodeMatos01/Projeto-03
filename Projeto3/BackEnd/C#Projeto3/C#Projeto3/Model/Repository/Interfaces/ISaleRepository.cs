namespace C_Projeto3.Model.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sale>> List();
        Task<Sale> SearchById(int id);

        Task Save(Sale sale);
        Task Edit(Sale sale);
        Task<bool> Delete(int id);
    }
}
