using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.Models
{
    public class CustomValueAttribute : ValidationAttribute
    {
        public int CustomProperty { get; set; }
        public CustomValueAttribute()
        {
            //any custom init property
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}