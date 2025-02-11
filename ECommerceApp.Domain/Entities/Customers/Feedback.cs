using E_commerce.Domain.Base;
using E_commerce.Domain.Entities.Orders;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace E_commerce.Domain.Entities.Customers
{
    // Represents customer feedback for a product
    public class Feedback : BaseEntity<int>
    {

        public override int Id { get; set; }
        // Foreign key to Customer
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Foreign key to Product
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Foreign key to OrderItem to verify purchase
        [Required]
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }

        // Rating between 1 and 5
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        // Optional comment with maximum length
        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
        public string? Comment { get; set; }



    }
}

