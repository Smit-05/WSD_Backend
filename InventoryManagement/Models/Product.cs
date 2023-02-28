using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(150)]
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }

  


    }
}
