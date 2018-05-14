using AspNetMvc4._5.Models;
using AspNetMvc4._5.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvc4._5.ModelViews
{
    public class VachicleCreateModel : IValidatableObject
    {
        [
            Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "Greeting")
            MaxLength(250, ErrorMessage = "Pole musi miec max 250 znaków"),
            MinLength(5, ErrorMessage = "Pole musi mieć min 5 znaków"),
            DisableWords(errorMessage: "Słowo zablokowane", disabledWords: new string[] { "Admin" })
        ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }

        public int Type { get; set; }
        public ICollection<int> Categories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name.CompareTo("Damian") == 0)
            {
                yield return new ValidationResult("Bład, Damian to imie");
            }
        }
    }
}