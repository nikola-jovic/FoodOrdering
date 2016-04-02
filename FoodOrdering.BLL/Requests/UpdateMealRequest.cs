namespace FoodOrdering.BLL.Requests
{
	public class UpdateMealRequest : Request
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Category { get; set; }
		public decimal Price { get; set; }
	}
}