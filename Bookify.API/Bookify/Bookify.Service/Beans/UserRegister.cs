using System.ComponentModel.DataAnnotations;

namespace Bookify.Service.Beans
{
    public class UserRegister
    {
        public Guid Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and Compare Password must be same.")]
        public string? ConfirmPassword { get; set; }
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

    }
}
