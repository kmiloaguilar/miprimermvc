using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.Models
{
    public class AccountLoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20,ErrorMessage = "The password must be between 8 and 20 characters.",MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}