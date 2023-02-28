using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class Dealer
    {
        public long ID { get; set; }


        [Required]
        [RegularExpression("[a-zA-Z\\s]*", ErrorMessage = "only alphabet")]
        public string? Name { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string? Email { get; set; }


        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }

     
        public ICollection<Product> Products { get; set; } = new Collection<Product>();


    }
}
