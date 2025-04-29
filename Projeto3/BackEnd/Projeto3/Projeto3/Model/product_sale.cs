using System.ComponentModel.DataAnnotations;

namespace C_Projeto3.Model
{
    public class product_sale
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int sale_id { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}
