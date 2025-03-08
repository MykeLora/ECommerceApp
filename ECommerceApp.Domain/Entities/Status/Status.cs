using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace E_commerce.Domain.Entities.Status
{
    // Represents the status master
    public class Status : BaseEntity<int>
    {
        [Required]
        public override int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
