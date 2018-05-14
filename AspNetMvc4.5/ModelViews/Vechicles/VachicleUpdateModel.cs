using AspNetMvc4._5.Models;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvc4._5.ModelViews
{
    public class VachicleUpdateModel
    {
        public int ID { get; set; }

        [
            Required(ErrorMessage = "Pole wymagane")
            MaxLength(250, ErrorMessage = "Pole musi miec max 250 znaków"), 
            MinLength(5, ErrorMessage = "Pole musi mieć min 5 znaków")
        ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole wymagane"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public int Type { get; set; }
        public ICollection<int> Categories { get; set; } = new List<int>();

        public VachicleUpdateModel() { }

        public VachicleUpdateModel(Vachicle vachicle)
        {
            ID = vachicle.ID;
            Name = vachicle.Name;
            Price = vachicle.Price;
            Type = vachicle.Type.ID;

            if (vachicle.Categories != null)
            {
                vachicle.Categories.ToList().ForEach(c => Categories.Add(c.ID));
            }
        }
    }
}