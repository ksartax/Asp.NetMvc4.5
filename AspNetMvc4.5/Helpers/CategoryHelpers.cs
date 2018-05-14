using AspNetMvc4._5.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;

namespace AspNetMvc4._5.Helpers
{
    public class CategoryHelpers
    {
        public static List<SelectListItem> DropDownList(ICollection<int> selected = null)
        {
            var category = (new CategoryRepository()).GetList();
            List<SelectListItem> items = new List<SelectListItem>();

            category.ForEach(
                t => {
                    var sli = new SelectListItem { Text = t.Description, Value = "" + t.ID };
                    if (selected != null && selected.Any(s => s == t.ID))
                    {
                        sli.Selected = true;
                    }
                    
                    items.Add(sli);
                }
            );

            return items;
        }
    }
}