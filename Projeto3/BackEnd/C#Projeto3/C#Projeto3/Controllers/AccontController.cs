using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C_Projeto3.Infra.Data;
using C_Projeto3.Model;
using C_Projeto3.Controllers.Objects;
using C_Projeto3.Utils; 

namespace C_Projeto3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {

            if (request.Senha != request.ConfirmarSenha)
            {
                return BadRequest(new { message = "A senha e a confirmação de senha não coincidem." });
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Email já cadastrado." });
            }

            var hashedPassword = CriptografiaSenha.CriptografarSenha(request.Senha);

            var newUser = new User
            {
                Nome = request.Nome,
                Email = request.Email,
                SenhaHash = hashedPassword
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Conta criada com sucesso!" });
        }
    }
}
