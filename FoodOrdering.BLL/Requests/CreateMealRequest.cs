namespace FoodOrdering.BLL.Requests
{
	public class CreateMealRequest : Request
	{
		public string Name { get; set; }
		public int Category { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}