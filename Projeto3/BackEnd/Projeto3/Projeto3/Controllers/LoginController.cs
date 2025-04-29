using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C_Projeto3.Controllers.Objects;
using C_Projeto3.Infra.Data;
using C_Projeto3.Model;
using C_Projeto3.Utils;

namespace C_Projeto3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.email);

            if (user == null || !CriptografiaSenha.VerificarSenha(request.senha, user.SenhaHash))
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var response = new LoginResponse
            {
                Token = "Login bem-sucedido"
            };

            return Ok(response);
        }
    }
}
