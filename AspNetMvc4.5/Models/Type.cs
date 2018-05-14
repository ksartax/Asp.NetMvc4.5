using AspNetMvc4._5.ModelViews;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc4._5.Models
{
    public class Type
    {
        [
            Key, 
            DatabaseGenerated(DatabaseGeneratedOption.Identity)
        ]
        public int ID { get; set; }

        [
            Required(ErrorMessage = "Pole wymagane"),
            MaxLength(250, ErrorMessage = "Pole musi miec max 250 znaków"),
            MinLength(5, ErrorMessage = "Pole musi mieć min 5 znaków")
        ]
        public string Description { get; set; }

        public Type() { }

        public Type(TypesCreateModel typesCreate)
        {
            Description = typesCreate.Description;
        }

        public void Update(TypesUpdateModel typesCreate)
        {
            Description = typesCreate.Description;
        }
    }
}