using System.Web.Mvc;

namespace FoodOrdering.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}