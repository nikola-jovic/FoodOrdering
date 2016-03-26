using System.Collections.Generic;
using Meal = FoodOrdering.BLL.Responses.DTO.Meal;

namespace FoodOrdering.BLL.Adapters
{
	public interface IMealsAdapter
	{
		IList<Meal> Adapt(IList<DAL.DB.Meal> meals);

		Meal Adapt(DAL.DB.Meal meal);
	}
}