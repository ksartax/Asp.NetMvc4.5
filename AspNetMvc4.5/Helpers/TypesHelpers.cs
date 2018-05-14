using AspNetMvc4._5.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc4._5.Helpers
{
    public class TypesHelpers
    {
        public static List<SelectListItem> DropDownList(int select = -1)
        {
            var types = (new TypesRepository()).GetList();
            List<SelectListItem> items = new List<SelectListItem>();

            types.ForEach(
                    t => {
                        var sli = new SelectListItem { Text = t.Description, Value = "" + t.ID };
                        if (t.ID == select)
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