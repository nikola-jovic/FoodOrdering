using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.DAL.DB;
using Menu = FoodOrdering.BLL.Responses.DTO.Menu;

namespace FoodOrdering.BLL.Adapters
{
	public interface IMenusAdapter
	{
		IList<Menu> Adapt(IList<DAL.DB.Menu> menus);

		Menu Adapt(DAL.DB.Menu menu);

		IList<MenuMeal> AdaptMenuMeals(IList<Requests.DTO.MenuMeal> menuMeals);
	}
}
