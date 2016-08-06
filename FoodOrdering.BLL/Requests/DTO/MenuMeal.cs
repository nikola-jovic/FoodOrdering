using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.BLL.Requests.DTO
{
	public class MenuMeal
	{
		public long MenuId { get; set; }
		public long MealId { get; set; }
		public string DayOfWeek { get; set; }
	}
}
