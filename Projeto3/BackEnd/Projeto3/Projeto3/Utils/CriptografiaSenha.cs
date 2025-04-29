using System.Security.Cryptography;
using System.Text;

namespace C_Projeto3.Utils
{
    public class CriptografiaSenha
    {
        public static string CriptografarSenha(string senha)
        {
            using var sha256 = SHA256.Create();
            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
            byte[] hashSenha = sha256.ComputeHash(bytesSenha);
            return Convert.ToBase64String(hashSenha);
        }

        public static bool VerificarSenha(string senha, string hashArmazenado)
        {
            using var sha256 = SHA256.Create();
            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
            byte[] hashSenha = sha256.ComputeHash(bytesSenha);
            string senhaHash = Convert.ToBase64String(hashSenha);
            return senhaHash == hashArmazenado;
        }
    }
}
