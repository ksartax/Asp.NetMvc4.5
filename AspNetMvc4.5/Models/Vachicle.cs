using AspNetMvc4._5.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc4._5.Models
{
    public class Vachicle
    {
        [
            Key, 
            DatabaseGenerated(DatabaseGeneratedOption.Identity)
        ]
        public int ID { get; set; }

        [
            Required(ErrorMessage = "Pole wymagane")
            MaxLength(250, ErrorMessage = "Pole musi miec max 250 znaków"), 
            MinLength(5, ErrorMessage = "Pole musi mieć min 5 znaków")
        ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }

        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public virtual Type Type { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public Vachicle() { }

        public Vachicle(VachicleCreateModel vachicleCreateModel)
        {
            Name = vachicleCreateModel.Name;
            Price = vachicleCreateModel.Price;
            DateCreated = DateTime.Now;
            TypeID = vachicleCreateModel.Type;
        }

        public void Update(VachicleUpdateModel vachicle)
        {
            Name = vachicle.Name;
            Price = vachicle.Price;
            TypeID = vachicle.Type;
        }
    }
}