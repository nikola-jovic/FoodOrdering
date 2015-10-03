using FoodOrdering.DAL.DB;
using FoodOrdering.WEB.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FoodOrdering.WEB.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IFoodOrderingDbFactory _foodOrderingDb;

        public UsersController()
        {
            _foodOrderingDb = new FoodOrderingDbFactory();
        }

        // GET: Users
        public ActionResult List()
        {
            var list = _foodOrderingDb.GetDatabase().AspNetUsers;
            var model = list.Select(user => new UserModel
            {
                Id = user.Id,
                Company = user.Company.Name,
                Username = user.UserName
            }).ToList();

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}