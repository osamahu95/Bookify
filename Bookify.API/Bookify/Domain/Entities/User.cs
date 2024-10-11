﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Key]
        public override Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        [Required]
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? ZipCode { get; set; }
        [Required]
        public string? CardOwner { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Credit Card Number must be 16 digits")]
        public string? CreditCardNumber { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Card Verification Value must be 3 numbers only.")]
        public string? CVV { get; set; }
        [Required]
        public string? Expiration { get; set; }

        // Navigation
        /*public List<User_Book>? User_Books { get; set; }
        public List<User_Bookshop>? User_Bookshops { get; set; }
        public List<User_Author>? User_Authors { get; set; }*/


    }
}
