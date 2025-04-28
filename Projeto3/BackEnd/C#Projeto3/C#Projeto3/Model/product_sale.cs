using System.ComponentModel.DataAnnotations;

namespace C_Projeto3.Model
{
    public class product_sale
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public Guid sale_id { get; set; }

        [Required]
        public Guid product_id { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}
