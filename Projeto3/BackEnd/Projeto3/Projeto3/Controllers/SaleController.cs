using C_Projeto3.Model;
using C_Projeto3.Model.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace C_Projeto3.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet("api/Sales")]
        public IActionResult GetSales()
        {
            var sales = _saleRepository.List().Result;
            return Ok(sales);
        }

        [HttpGet("api/Sales/{id}")]
        public IActionResult GetSalesById(int id)
        {
            var result = _saleRepository.SearchById(id).Result;
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("api/Sales")]
        public IActionResult Save(Sale sale)
        {
            var result = _saleRepository.Save(sale);
            return Ok(result);
        }

        [HttpDelete("api/Sales/{id}")]
        public IActionResult Delete([FromQuery]int id)
        {
            var result = _saleRepository.Delete(id).Result;
            return Ok(id);
        }
    }
}
