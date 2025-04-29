using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using projeto3.api.Infra.Data;
using projeto3.api.Models;
using projeto3.api.Models.Repository.Interfaces;

namespace projeto3.api.Controllers
{
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(template: "api/Produtos")]
        public IActionResult GetProdutos()
        {
            var consultaProdutos = _repository.Listar().Result;

            return Ok(consultaProdutos);
        }

        [HttpGet(template: "api/Produtos/{id}")]
        public IActionResult GetProdutoById(int id) 
        {
            var consultaProdutos = _repository.GetById(id).Result;

            if (consultaProdutos == null)
            {
                return NotFound();
            }

            return Ok(consultaProdutos);
        }

        [HttpPost(template: "api/Produtos")]
        public IActionResult Salvar(Produto produto)
        {
            var consultaProdutos = _repository.Salvar(produto).Result;

            return Ok(consultaProdutos);
        }

        [HttpDelete("api/Produtos/{id}")]
        public IActionResult excluir(int id)
        {
            try
            {
                var retorno = _repository.Excluir(id).Result;
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
