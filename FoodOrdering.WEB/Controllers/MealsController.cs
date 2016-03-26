using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using FoodOrdering.BLL.Services;
using FoodOrdering.WEB.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodOrdering.WEB.Controllers
{
	public class MealsController : Controller
	{
		private readonly IMealsService _mealsService;

		public MealsController(IMealsService mealsService)
		{
			_mealsService = mealsService;
		}

		// GET: Meals
		public async Task<ActionResult> List()
		{
			var model = new MealModel();
			var response = await _mealsService.GetMeals();

			return View(model.Adapt(response.Meals));
		}

		// GET: Meals/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Meals/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Meals/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("List");
			}
			catch
			{
				return View();
			}
		}

		// GET: Meals/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Meals/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("List");
			}
			catch
			{
				return View();
			}
		}

		// GET: Meals/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Meals/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("List");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult UploadFileForm()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> UploadFile()
		{
			var listOfTags = new List<string>();
			var listOfMeals = new List<MealModel>();
			if (Request.Files.Count > 0)
			{
				var file = Request.Files[0];
				if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
				{
					try
					{
						var sr = new StreamReader(file.InputStream);
						var readToEnd = sr.ReadToEnd();
						var jObject = JObject.Parse(readToEnd);
						foreach (var obj in jObject)
						{
							listOfTags.Add(obj.Key);
							foreach (var token in obj.Value)
							{
								var token2 = (JProperty) token;
								listOfMeals.Add(new MealModel
								{
									Name = token2.Name,
									Description = token2.Value.ToString()
								});
							}
						}
					}
					catch (Exception ex)
					{
						//TODO: do something
					}
				}
			}
			return RedirectToAction("List");
		}
	}
}