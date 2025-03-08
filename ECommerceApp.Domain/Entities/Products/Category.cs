
using ECommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace E_commerce.Domain.Entities.Products
{

    public class Category  : BaseCatalog
    {
        public ICollection<Product> Products { get; set; }
    }

}
