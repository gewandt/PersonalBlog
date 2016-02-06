using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RegisterUserModel : IValidatableObject
    {
        [Required(ErrorMessage = "Enter valid nickname!")]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter valid password")]
        [MinLength(4), MaxLength(50)]
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Captcha { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Password != null && Password != RepeatPassword)
                result.Add(new ValidationResult(Password));
            return result;
        }
    }
}