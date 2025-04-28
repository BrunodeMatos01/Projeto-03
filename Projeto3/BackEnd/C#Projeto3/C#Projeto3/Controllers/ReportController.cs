using C_Projeto3.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_Projeto3.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly SaleRepository _saleRepository;

    // public RelatorioController(SeuDbContext context)
    // {
    //     _context = context;
    // }
}