using FoodOrdering.BLL.Responses.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FoodOrdering.WEB.Models
{
	public class MealModel
	{
		public long Id { get; set; }

		[Required(ErrorMessage = @"Ime jela je obavezno.")]
		[StringLength(100, ErrorMessage = @"{0} mora imati između {2} i {1} karaktera.", MinimumLength = 6)]
		[Display(Name = @"Ime jela")]
		public string Name { get; set; }

		[Display(Name = @"Opis jela")]
		public string Description { get; set; }

		[Display(Name = @"Cena jela")]
		[Required(ErrorMessage = @"Cena jela je obavezna.")]
		public decimal Price { get; set; }

		public MealCategories Category { get; set; }

		//public byte[] Image { get; set; }

		#region Helpers

		public string CategoryDisplay(int mealCategory)
		{
			var correspondingEnum = (MealCategories)mealCategory;
			return correspondingEnum.GetType()
						.GetMember(correspondingEnum.ToString())
						.First()
						.GetCustomAttribute<DisplayAttribute>()
						.GetName();
		}

		public MealModel Adapt(Meal mealToAdapt)
		{
			if (mealToAdapt == null) throw new ArgumentNullException("mealToAdapt");

			return new MealModel
			{
				Id = mealToAdapt.Id,
				Name = mealToAdapt.Name,
				Category = (MealCategories)mealToAdapt.Category,
				Description = mealToAdapt.Description,
				Price = mealToAdapt.Price
			};
		}

		public IList<MealModel> Adapt(IList<Meal> mealsToAdapt)
		{
			if (mealsToAdapt == null) throw new ArgumentNullException("mealsToAdapt");

			return mealsToAdapt.Select(Adapt).ToList();
		}

		#endregion Helpers

		#region Other

		public bool ErrorsOccured { get; set; }
		public string ErrorMessage { get; set; }

		#endregion Other
	}
}