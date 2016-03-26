using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Responses
{
	public class GetMealResponse : Response
	{
		public Meal Meal { get; set; }
	}
}