using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTos.ProductDTos
{
    public class ProductStatusUpdateDTO
    {
        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "IsAvailable is required.")]
        public bool IsAvailable { get; set; }
        public int? UpdatedBy { get; set; }
        [Required(ErrorMessage = "UpdatedAt  is required.")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    }

}
