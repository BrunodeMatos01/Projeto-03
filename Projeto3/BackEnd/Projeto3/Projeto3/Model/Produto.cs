using System.ComponentModel.DataAnnotations;

namespace projeto3.api.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public double Estoque { get; set; }
    }
}
