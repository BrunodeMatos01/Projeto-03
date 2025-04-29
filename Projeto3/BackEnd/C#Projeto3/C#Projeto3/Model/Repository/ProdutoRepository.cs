using C_Projeto3.Infra.Data;
using Microsoft.EntityFrameworkCore;
using projeto3.api.Models.Repository.Interfaces;

namespace projeto3.api.Models.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Produto> GetById(int id)
        {
            return await _appDbContext.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> Listar()
        {
            return await _appDbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> Salvar(Produto produto) 
        {
            try
            {
                #region  ValidarDados
                if (produto.Estoque < 10)
                {
                    throw new Exception("Quantidade informado para o estoque deste produto, está abaixo do mínimo aceitável -> 10 unidades ou mais");
                }
                #endregion

                if (produto.Id > 0)
                {
                    var produtoEditar = _appDbContext.Produtos.FirstOrDefault(a => a.Id == produto.Id);

                    if (produtoEditar == null)
                    {
                        throw new Exception("Contato não encontrado!");
                    }

                    produtoEditar.Nome    = produto.Nome;
                    produtoEditar.Valor   = produto.Valor;
                    produtoEditar.Estoque = produto.Estoque;
                }
                else
                {
                    _appDbContext.Produtos.Add(produto);
                }
                await _appDbContext.SaveChangesAsync();
                return produto;
            }         
            catch (Exception ex)
            {                
                throw new Exception("Ocorreu um erro inesperado ao salvar o produto.", ex);
            }
        }

        public async Task Edit(Produto produto)
        {
            var lProduto = await _appDbContext.Produtos.FindAsync(produto.Id);

            if (lProduto == null)
                return;

            lProduto.Nome = produto.Nome;
            lProduto.Valor = produto.Valor;

            try
            {           
                await _appDbContext.SaveChangesAsync();               
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado ao salvar o produto.", ex);
            }
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var produtoExcluir = _appDbContext.Produtos.FirstOrDefault(a => a.Id == id);

                if (produtoExcluir != null)
                {
                    _appDbContext.Produtos.Remove(produtoExcluir);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }

                throw new Exception("Produto não encontrado!");

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
