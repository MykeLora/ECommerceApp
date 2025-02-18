using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTos.CustomerDTos
{
    public class CustomerUpdateDTO
    {
        [Required(ErrorMessage = "Customer Id is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "First Name must be at most 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Last Name must be at most 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Phone Number is not valid")] 
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
