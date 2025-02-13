using E_commerce.Domain.Entities.Customers;
using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities.Carts
{
    // Represents a shopping cart
    public class Cart : BaseEntity<int>
    {

        public override int Id { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public bool IsCheckedOut { get; set; } = false;

        public ICollection<CartItem> CartItems { get; set; }
    }
}

