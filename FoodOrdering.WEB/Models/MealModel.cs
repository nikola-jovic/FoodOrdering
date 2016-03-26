using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.WEB.Models
{
	public class MealModel
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public int Category { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		//public byte[] Image { get; set; }

		public MealModel Adapt(Meal mealToAdapt)
		{
			if (mealToAdapt == null) throw new ArgumentNullException("mealToAdapt");

			return new MealModel
			{
				Id = mealToAdapt.Id,
				Name = mealToAdapt.Name,
				Category = mealToAdapt.Category,
				Description = mealToAdapt.Description,
				Price = mealToAdapt.Price
			};
		}

		public IList<MealModel> Adapt(IList<Meal> mealsToAdapt)
		{
			if (mealsToAdapt == null) throw new ArgumentNullException("mealsToAdapt");

			return mealsToAdapt.Select(Adapt).ToList();
		}
	}
}