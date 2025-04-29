using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C_Projeto3.Controllers.Objects;
using C_Projeto3.Infra.Data;
using C_Projeto3.Model;
using System.Security.Cryptography;
using System.Text;


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

            if (user == null)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            if (!VerifyPassword(request.senha, user.SenhaHash))
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var response = new LoginResponse
            {
                Token = "Login bem-sucedido"
            };

            return Ok(response);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                var hashedPassword = Convert.ToBase64String(hash);
                return storedHash == hashedPassword;
            }
        }
    }
}
