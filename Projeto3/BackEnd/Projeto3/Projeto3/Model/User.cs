using System.ComponentModel.DataAnnotations;

namespace C_Projeto3.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SenhaHash { get; set; }
    }
}
