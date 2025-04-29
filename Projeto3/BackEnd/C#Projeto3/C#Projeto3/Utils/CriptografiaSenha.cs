using System.Security.Cryptography;
using System.Text;

namespace C_Projeto3.Utils
{
    public class CriptografiaSenha
    {
        public static string CriptografarSenha(string senha)
        {
            using var sha1 = SHA1.Create();
            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
            byte[] hashSenha = sha1.ComputeHash(bytesSenha);
            StringBuilder sb = new StringBuilder();

            foreach (var t in hashSenha)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        internal static bool VerificarSenha(string password, string storedHash)
        {
            throw new NotImplementedException();
        }
    }
}
