using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.Models
{
    public class AccountRegisterModel
    {
        [DataType(DataType.EmailAddress)]
        [StringLength(100,ErrorMessage = "Email should be between 5 and 100 characters.",MinimumLength = 5)]
        [DisplayName("Email address")]
        public string Email { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "First name should be between 2 and 50 characters.", MinimumLength = 2)]
        [DisplayName("First Name")]
        [RegularExpression("[a-zA-Z]*",ErrorMessage = "First name only accepts letters")]
        public string FirstName { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Last name should be between 2 and 50 characters.", MinimumLength = 2)]
        [DisplayName("Last Name")]
        [RegularExpression("[a-zA-Z]*", ErrorMessage = "Last name only accepts letters")]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [StringLength(20, ErrorMessage = "Password should be between 8 and 20 characters.", MinimumLength = 8)]
        [Compare("ConfirmPassword",ErrorMessage = "Password and Confirm Password should be the same")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Password can only accept letters and numbers")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [StringLength(20, ErrorMessage = "Confirm Password should be between 8 and 20 characters.", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be the same")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Password can only accept letters and numbers")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Please accept the terms and conditions")]
        public bool TermsAndConditionsAccepted { get; set; }
    }
}