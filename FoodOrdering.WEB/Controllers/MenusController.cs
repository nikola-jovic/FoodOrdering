using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FoodOrdering.BLL.Services;
using FoodOrdering.WEB.Models;

namespace FoodOrdering.WEB.Controllers
{
    public class MenusController : Controller
    {
	    private readonly IMenusService _menusService;

	    public MenusController(IMenusService menusService)
	    {
		    _menusService = menusService;
	    }

        // GET: Menus
        public async Task<ActionResult> List()
        {
			var model = new MenuModel();
	        var response = await _menusService.GetMenus();

            return View(model.Adapt(response.Menus));
        }

        //// GET: Menus/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Menus/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Menus/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Menus/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Menus/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Menus/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Menus/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
