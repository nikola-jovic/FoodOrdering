using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Adapters
{
	public class MealsAdapter : IMealsAdapter
	{
		public IList<Meal> Adapt(IList<DAL.DB.Meal> meals)
		{
			if (meals == null) throw new ArgumentNullException("meals");

			return meals.Select(meal => new Meal
			{
				Id = meal.Id,
				Name = meal.Name,
				Category = meal.Category,
				Description = meal.Description,
				Image = meal.Image,
				Price = meal.Price
			}).ToList();
		}

		public Meal Adapt(DAL.DB.Meal meal)
		{
			if (meal == null) throw new ArgumentNullException("meal");

			return new Meal
			{
				Id = meal.Id,
				Name = meal.Name,
				Category = meal.Category,
				Description = meal.Description,
				Image = meal.Image,
				Price = meal.Price
			};
		}
	}
}