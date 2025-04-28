using System.ComponentModel.DataAnnotations;

namespace C_Projeto3.Model
{
    public class Sale
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public List<product_sale> items { get; set; }
    }
}
