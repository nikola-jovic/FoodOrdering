using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.DAL.DB;

namespace FoodOrdering.BLL.Adapters
{
	public class MenusAdapter : IMenusAdapter
	{
		public IList<Responses.DTO.Menu> Adapt(IList<Menu> menus)
		{
			if (menus == null) throw new ArgumentNullException("menus");

			return menus.Select(menu => new Responses.DTO.Menu
			{
				Id = menu.Id,
				StartDate = menu.StartDate,
				EndDate = menu.EndDate,
			}).ToList();
		}

		public Responses.DTO.Menu Adapt(Menu menu)
		{
			if (menu == null) throw new ArgumentNullException("menu");

			return new Responses.DTO.Menu
			{
				Id = menu.Id,
				StartDate = menu.StartDate,
				EndDate = menu.EndDate,
			};
		}

		public IList<MenuMeal> AdaptMenuMeals(IList<Requests.DTO.MenuMeal> menuMeals)
		{
			if (menuMeals == null) throw new ArgumentNullException("menuMeals");

			return menuMeals.Select(menuMeal => new MenuMeal
			{
				MenuId = menuMeal.MenuId,
				MealId = menuMeal.MealId,
				DayOfWeek = menuMeal.DayOfWeek
			}).ToList();

		}
	}
}
