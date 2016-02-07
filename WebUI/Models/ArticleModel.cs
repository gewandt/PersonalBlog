using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;

namespace WebUI.Models
{
    public class ArticleModel : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter valid name!")]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter valid text!")]
        [MinLength(3), MaxLength(2047)]
        public string Text { get; set; }
        public string Author { get; set; }
        public string BlogName { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Enter valid tag!")]
        [MinLength(2), MaxLength(49)]
        public string CurrentTag { get; set; }
        public List<BllTagEntity> Tags { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Text != null && Text.Length < 3)
                result.Add(new ValidationResult(Text));
            if (Name != null && Name.Length < 2)
                result.Add(new ValidationResult(Name));
            return result;
        }
    }
}