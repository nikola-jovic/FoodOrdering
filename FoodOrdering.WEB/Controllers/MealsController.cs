using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses.DTO;
using FoodOrdering.BLL.Services;
using FoodOrdering.WEB.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

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