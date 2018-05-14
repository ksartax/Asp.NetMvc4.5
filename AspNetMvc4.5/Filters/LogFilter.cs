using System;
using System.Web.Mvc;

namespace AspNetMvc4._5.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine("OnActionExecuted");
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Console.WriteLine("OnActionExecuting");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Console.WriteLine("OnResultExecuted");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Console.WriteLine("OnResultExecuting");
        }
    }
}