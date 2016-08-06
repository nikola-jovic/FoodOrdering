using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.BLL.Requests.DTO;

namespace FoodOrdering.BLL.Requests
{
	public class CreateMenuRequest
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IList<MenuMeal> MenuMeals { get; set; }

	}
}
