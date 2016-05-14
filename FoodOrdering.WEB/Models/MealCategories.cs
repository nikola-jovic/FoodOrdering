using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.WEB.Models
{
	public enum MealCategories
	{
		[Display(Name = "Glavno jelo")]
		MainCourse = 0,
		[Display(Name = "Supe i čorbe")]
		Soup = 1,
		[Display(Name = "Desert")]
		Dessert = 2
	}
}