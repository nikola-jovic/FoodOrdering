namespace FoodOrdering.BLL.Requests
{
	public class DeleteMealRequest : Request
	{
		public long MealId { get; set; }
	}
}