using System.ComponentModel.DataAnnotations;
namespace ECommerceApp.DTOs.CategoryDTOs
{
    // DTO for creating a new category
    public class CategoryCreateDTO
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; }
        public bool isActive { get; set; } = true;
    }
}


