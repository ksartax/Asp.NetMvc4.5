using AspNetMvc4._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetMvc4._5.ModelViews
{
    public class VachicleViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual TypesViewModel Type { get; set; }
        public virtual ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public VachicleViewModel() { }

        public VachicleViewModel(Vachicle vachicle)
        {
            ID = vachicle.ID;
            Name = vachicle.Name;
            Price = vachicle.Price;
            DateCreated = vachicle.DateCreated;
            Type = new TypesViewModel(vachicle.Type);

            if (vachicle.Categories != null)
            {
                vachicle.Categories.ToList().ForEach(c => Categories.Add(new CategoryViewModel(c)));
            }
        }
    }
}