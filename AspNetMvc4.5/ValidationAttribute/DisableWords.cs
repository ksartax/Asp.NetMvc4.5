using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvc4._5.ValidationAttributes
{
    public class DisableWords : ValidationAttribute
    {
        private readonly string[] DisableWordsList;

        public DisableWords(string errorMessage, string[] disabledWords) : base(errorMessage)
        {
            DisableWordsList = disabledWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();

                if (DisableWordsList.Any(d => d.CompareTo(valueAsString) == 1))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}