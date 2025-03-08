using E_commerce.Domain.Entities.Payments;
using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Domain.Entities.Payments
{
    public abstract class BaseTransaction : BaseEntity<int>
    {
        public override int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [StringLength(100, ErrorMessage = "Transaction ID cannot exceed 100 characters.")]
        public string? TransactionId { get; set; } // From payment gateway

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }
    }
}

