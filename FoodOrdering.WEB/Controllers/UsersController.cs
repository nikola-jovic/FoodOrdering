using FoodOrdering.DAL.DB;
using FoodOrdering.WEB.Models;
using FoodOrdering.WEB.Models.Identity;
using FoodOrdering.WEB.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace FoodOrdering.WEB.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly FoodOrderingEntities _foodOrderingDb;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
            _foodOrderingDb = new FoodOrderingDbFactory().GetDatabase();
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
                Company company = _foodOrderingDb.Companies.FirstOrDefault(x => x.CompanyCode.Equals(model.CompanyCode));
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
                        await UserManager.AddToRolesAsync(user.Id, selectedRole);
                    }
                    return RedirectToAction("List");
                }
            }

            return View(model);
        }

        // GET: Users
        public ActionResult List()
        {
            var list = _foodOrderingDb.AspNetUsers;
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AspNetUser user = _foodOrderingDb.AspNetUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UpdateUserViewModel userModel = new UpdateUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                CompanyCode = user.Company == null ? "" : user.Company.CompanyCode,
                Role = user.AspNetRoles.Any() ? (Roles)Enum.Parse(typeof(Roles), user.AspNetRoles.Select(x => x.Name).First()) : 0
            };
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateUserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(userModel.Id);
                Company company = _foodOrderingDb.Companies.FirstOrDefault(x => x.CompanyCode.Equals(userModel.CompanyCode)); //TODO: Instead of this, lets use AttributeValidation
                if (company == null)
                {
                    user.Email = userModel.Email;
                }
                else
                {
                    user.Email = userModel.Email;
                    user.CompanyId = company.Id;
                }
                if (!string.IsNullOrWhiteSpace(userModel.Password))
                {
                    await UserManager.RemovePasswordAsync(user.Id);
                    await UserManager.AddPasswordAsync(user.Id, userModel.Password);
                }
                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    AspNetUser netUser = _foodOrderingDb.AspNetUsers.Find(user.Id);
                    var userRoles = netUser.AspNetRoles.Select(x => x.Name).ToArray();
                    await UserManager.RemoveFromRolesAsync(user.Id, userRoles);

                    var selectedRole = userModel.Role.ToString();
                    if (string.IsNullOrEmpty(selectedRole))
                    {
                        await UserManager.AddToRolesAsync(user.Id, "RegularUser");
                    }
                    else
                    {
                        await UserManager.AddToRolesAsync(user.Id, selectedRole);
                    }
                    return RedirectToAction("List");
                }
            }
            return View(userModel);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser user = _foodOrderingDb.AspNetUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserModel userModel = new UserModel
            {
                Id = user.Id,
                Username = user.UserName,
                Company = user.Company == null ? "" : user.Company.Name
            };
            return View(userModel);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser user = _foodOrderingDb.AspNetUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserModel userModel = new UserModel
            {
                Id = user.Id,
                Username = user.UserName,
                Company = user.Company == null ? "" : user.Company.Name
            };
            return View(userModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            var result = await UserManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                // TODO: Adapter
                AspNetUser aspNetUser = _foodOrderingDb.AspNetUsers.Find(id);
                UserModel userModel = new UserModel
                {
                    Id = aspNetUser.Id,
                    Username = aspNetUser.UserName,
                    Company = aspNetUser.Company == null ? "" : aspNetUser.Company.Name,
                    Errors = true,
                    ErrorMessage = result.Errors.First()
                };
                return View(userModel);
            }
            return RedirectToAction("List");
        }
}
    }