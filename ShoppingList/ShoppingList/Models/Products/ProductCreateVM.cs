using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models.Products
{
    public class ProductCreateVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? ProductName { get; set; }
    }
}
