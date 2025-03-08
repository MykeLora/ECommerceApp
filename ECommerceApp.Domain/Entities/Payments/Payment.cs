using E_commerce.Domain.Entities.Orders;
using E_commerce.Domain.Entities.Payments;
using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Domain.Entities.Payments
{
    public class Payment : BaseTransaction
    {
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public Refund Refund { get; set; }
    }
}
