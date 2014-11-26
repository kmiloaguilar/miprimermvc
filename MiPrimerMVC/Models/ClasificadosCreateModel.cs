using System.ComponentModel.DataAnnotations;
using MiPrimerMVC.ValidationAttributes;

namespace MiPrimerMVC.Models
{
    public class ClasificadosCreateModel
    {
        [Required(ErrorMessage = "Title is required")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Range(0.01,1000.00,ErrorMessage = "Price must be between 0.01 and 1000.00")]
        [Required(ErrorMessage = "Price is Required")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage="Description is required")]
        [DataType(DataType.MultilineText)]
        [DescriptionValidation(MinimumAmountOfWords = 3, MaximumAmountOfCharacters = 255,
            ErrorMessage = "The description must contains a minimum of 3 words and a maximum of 255 characters.")]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl,ErrorMessage = "Url for image is not valid")]
        public string ImageUrl1 { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Url for image is not valid")]
        public string ImageUrl2 { get; set; }
        
        [DataType(DataType.ImageUrl, ErrorMessage = "Url for image is not valid")]
        public string ImageUrl3 { get; set; }
        
        [DataType(DataType.ImageUrl, ErrorMessage = "Url for image is not valid")]
        public string ImageUrl4 { get; set; }
        
        [DataType(DataType.ImageUrl, ErrorMessage = "Url for image is not valid")]
        public string ImageUrl5 { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Url for youtube is not valid")]
        public string YoutubeUrl { get; set; }

        public string Category { get; set; }
    }
}