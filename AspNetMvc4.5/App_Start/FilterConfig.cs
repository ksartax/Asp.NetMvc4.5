using AspNetMvc4._5.Filters;
using System.Web.Mvc;

namespace AspNetMvc4._5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogFilter());
        }
    }
}
