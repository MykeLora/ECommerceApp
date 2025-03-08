using E_commerce.Domain.Entities.Customers;
using E_commerce.Domain.Entities.Orders;
using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities.Products
{
    // Represents a product available for purchase
    public class Product : BaseCatalog
    {

        [Range(0.01, 10000.00, ErrorMessage = "Price must be between $0.01 and $10,000.00.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Range(0, 1000, ErrorMessage = "Stock Quantity must be between 0 and 1000.")]
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Percentage must be between 0% and 100%.")]
        public int DiscountPercentage { get; set; }

        // Foreign key to Category
        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
