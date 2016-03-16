using System.Web.Mvc;

namespace FoodOrdering.WEB.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult NotFound()
        {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (!Request.IsAjaxRequest())
            {
                result = View(model);
            }
            else
            {
                result = PartialView("_NotFound", model);
            }

            return result;
        }
    }
}