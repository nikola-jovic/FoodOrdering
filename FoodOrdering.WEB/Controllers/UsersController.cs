using FoodOrdering.DAL.DB;
using FoodOrdering.WEB.Models;
using FoodOrdering.WEB.Models.Identity;
using FoodOrdering.WEB.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace FoodOrdering.WEB.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IFoodOrderingDbFactory _foodOrderingDb;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
            _foodOrderingDb = new FoodOrderingDbFactory();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user;
                Company company = _foodOrderingDb.GetDatabase().Companies.FirstOrDefault(x => x.CompanyCode.Equals(model.CompanyCode));
                if (company != null)
                {
                    var companyId = company.Id;
                    user = new ApplicationUser { UserName = model.Email, Email = model.Email, CompanyId = companyId };
                }
                else
                {
                    user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                }
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var selectedRole = model.Role.ToString();
                    if (string.IsNullOrEmpty(selectedRole))
                    {
                        await UserManager.AddToRolesAsync(user.Id, "RegularUser");
                    }
                    else
                    {
                        await UserManager.AddToRolesAsync(user.Id, "RegularUser", selectedRole);
                    }
                    return RedirectToAction("List");
                }
            }

            return View(model);
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