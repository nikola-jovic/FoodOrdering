using System.Collections.Generic;
using FoodOrdering.DAL.DB;

namespace FoodOrdering.BLL.Responses.DTO
{
	public class Meal
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int Category { get; set; }
		public string Description { get; set; }
		public byte[] Image { get; set; }
		public decimal Price { get; set; }
		public IList<MenuMeal> Menus { get; set; }
	}
}