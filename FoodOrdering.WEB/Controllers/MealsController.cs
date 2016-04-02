using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses.DTO;
using FoodOrdering.BLL.Services;
using FoodOrdering.WEB.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using FoodOrdering.BLL.Responses;

namespace FoodOrdering.WEB.Controllers
{
	public class MealsController : Controller
	{
		private readonly IMealsService _mealsService;
		private readonly IMealTagsService _mealTagsService;

		public MealsController(IMealsService mealsService, IMealTagsService mealTagsService)
		{
			_mealsService = mealsService;
			_mealTagsService = mealTagsService;
		}

		public async Task<ActionResult> List()
		{
			var model = new MealModel();
			var response = await _mealsService.GetMeals();

			return View(model.Adapt(response.Meals));
		}

		public async Task<ActionResult> Details(int id)
		{
			if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = new MealModel();
			var getMealResponse = await _mealsService.GetMealById(new GetMealRequest
			{
				MealId = id,
				CorrelationId = Guid.NewGuid().ToString(),
				Requestor = ClaimsPrincipal.Current.Identity.Name
			});

			if (getMealResponse.Meal == null) return HttpNotFound();

			return View(model.Adapt(getMealResponse.Meal));
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Create(MealModel meal)
		{
			if (ModelState.IsValid)
			{
				await _mealsService.CreateMeal(new CreateMealRequest
				{
					Name = meal.Name,
					Description = meal.Description,
					Category = meal.Category,
					Price = meal.Price,
					CorrelationId = Guid.NewGuid().ToString(),
					Requestor = ClaimsPrincipal.Current.Identity.Name
				}).ConfigureAwait(false);
				return RedirectToAction("List");
			}

			return View(meal);
		}

		// GET: Meals/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = new MealModel();
			var getMealResponse = await _mealsService.GetMealById(new GetMealRequest
			{
				MealId = id,
				CorrelationId = Guid.NewGuid().ToString(),
				Requestor = ClaimsPrincipal.Current.Identity.Name
			}).ConfigureAwait(false);

			if (getMealResponse.Meal == null) return HttpNotFound();

			return View(model.Adapt(getMealResponse.Meal));
		}

		// POST: Meals/Edit/5
		[HttpPost]
		public async Task<ActionResult> Edit(MealModel model)
		{
			if (ModelState.IsValid)
			{
				await _mealsService.UpdateMeal(new UpdateMealRequest
				{
					Id = model.Id,
					Name = model.Name,
					Description = model.Description,
					Category = model.Category,
					Price = model.Price,
					CorrelationId = Guid.NewGuid().ToString(),
					Requestor = ClaimsPrincipal.Current.Identity.Name
				}).ConfigureAwait(false);
				return RedirectToAction("List");
			}
			return View(model);
		}

		// GET: Meals/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = new MealModel();
			var getMealResponse = await _mealsService.GetMealById(new GetMealRequest
			{
				MealId = id,
				CorrelationId = Guid.NewGuid().ToString(),
				Requestor = ClaimsPrincipal.Current.Identity.Name
			}).ConfigureAwait(false);

			if (getMealResponse.Meal == null) return HttpNotFound();

			return View(model.Adapt(getMealResponse.Meal));
		}

		// POST: Meals/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var model = new MealModel();
			var getMealResponse = await _mealsService.GetMealById(new GetMealRequest
			{
				MealId = id,
				CorrelationId = Guid.NewGuid().ToString(),
				Requestor = ClaimsPrincipal.Current.Identity.Name
			});
			if (getMealResponse.Meal.Menus.Any())
			{
				model = model.Adapt(getMealResponse.Meal);
				model.Errors = true;
				model.ErrorMessage = "There are menus associated with this company.";
				return View(model);
			}
			await _mealsService.DeleteMeal(new DeleteMealRequest
			{
				MealId = id,
				CorrelationId = Guid.NewGuid().ToString(),
				Requestor = ClaimsPrincipal.Current.Identity.Name
			}).ConfigureAwait(false);
			return RedirectToAction("List");
		}

		public ActionResult UploadFileForm()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> UploadFile()
		{
			// This method should only be used in the case of
			// loss of information and when meal and tags data
			// needs to be restored.
			var listOfTags = new List<string>();
			var listOfMeals = new List<Meal>();
			if (Request.Files.Count > 0)
			{
				var file = Request.Files[0];
				if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
				{
					try
					{
						var streamReader = new StreamReader(file.InputStream);
						var resultingString = streamReader.ReadToEnd();
						var resultingJObject = JObject.Parse(resultingString);
						foreach (var obj in resultingJObject)
						{
							listOfTags.Add(obj.Key);
							listOfMeals.AddRange(from JProperty property in obj.Value
												 select new Meal
												 {
													 Name = property.Name,
													 Description = property.Value.ToString()
												 });
						}
						await _mealTagsService.BulkAddMealTags(new BulkAddMealTagsRequest { MealTags = listOfTags });
						await _mealsService.BulkCreateMeals(new BulkCreateMealsRequest { Meals = listOfMeals });
					}
					catch (Exception)
					{
						//TODO: do something
					}
				}
			}
			return RedirectToAction("List");
		}
	}
}