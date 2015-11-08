using System;
using System.Web.Mvc;

namespace FoodOrdering.WEB
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //Exception ex = filterContext.Exception;
            //filterContext.ExceptionHandled = true;
            //var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            //filterContext.Result = new ViewResult()
            //{
            //    ViewName = "Error1",
            //    ViewData = new ViewDataDictionary(model)
            //};
        }
    }
}