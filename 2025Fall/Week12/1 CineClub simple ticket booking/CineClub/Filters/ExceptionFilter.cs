using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CineClub.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"[ERROR] {context.Exception.Message}");

            // Return a friendly error view
            var result = new ViewResult
            {
                ViewName = "Error"
            };

            
            //Redirect to the existing Error action
            /*context.Result = new RedirectToActionResult(
                actionName: "Error",
                controllerName: "Home",
                routeValues: null
            );*/
            

            //result.ViewData["Message"] = context.Exception.Message;
            //result.ViewData["StackTrace"] = context.Exception.StackTrace;

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
