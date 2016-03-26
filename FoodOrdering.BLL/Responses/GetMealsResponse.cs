using System.Collections.Generic;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Responses
{
	public class GetMealsResponse : Response
	{
		public IList<Meal> Meals { get; set; }
	}
}