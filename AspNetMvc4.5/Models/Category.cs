using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc4._5.Models
{
    public class Category
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

        public virtual ICollection<Vachicle> Vechicles { get; set; }

        public Category() { }

        public Category(CategoryCreateModel category)
        {
            Description = category.Description;
        }

        public void Update(CategoryUpdateModel category)
        {
            Description = category.Description;
        }
    }
}