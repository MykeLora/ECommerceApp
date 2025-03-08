using E_commerce.Domain.Entities.Status;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities.Payments;
using ECommerceApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Domain.Entities.Payments
{
    // Represents a refund transaction
    // Refund class inheriting from BaseTransaction
    public class Refund : BaseTransaction
    {
        [Required(ErrorMessage = "Cancellation ID is required.")]
        public int CancellationId { get; set; }

        [ForeignKey("CancellationId")]
        public Cancellation Cancellation { get; set; }

        [Required(ErrorMessage = "Payment ID is required.")]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }

        // Date when refund was completed (nullable)
        public DateTime? CompletedAt { get; set; }
    }

}
