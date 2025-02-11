﻿using System.ComponentModel.DataAnnotations;
namespace E_commerce.Domain.Entities.Status
{
    // Represents the status master
    public class Status
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
