using C_Projeto3.Infra.Data;
using C_Projeto3.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace C_Projeto3.Model.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;

        public SaleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var saleToRemove = _appDbContext.sales.FirstOrDefault(a => a.id == id);
                if (saleToRemove != null)
                {
                    _appDbContext.sales.Remove(saleToRemove);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                throw new Exception("Sale not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error when removing sale");
            }
        }

        public Task Edit(Sale sale)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sale>> List()
        {
            return await _appDbContext.sales.ToListAsync();
        }

        public async Task Save(Sale sale)
        {
            _appDbContext.sales.Add(sale);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Sale> SearchById(Guid id)
        {
            return await _appDbContext.sales.FindAsync(id);
        }
    }
}
