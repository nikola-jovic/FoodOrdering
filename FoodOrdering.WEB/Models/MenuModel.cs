using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrdering.BLL.Requests.DTO;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.WEB.Models
{
	public class MenuModel
	{
		private readonly string[] _availableDays = new[] { "Ponedeljak", "Utorak", "Sreda", "Cetvrtak", "Petak", "Subota" };

		public long Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IList<MenuMeal> MenuMeals { get; set; }

		public string DisplayName
		{
			get { return "Nedeljni jelovnik " + StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString(); }
		}

		public MenuModel Adapt(Menu menuToAdapt)
		{
			if (menuToAdapt == null) throw new ArgumentNullException("menuToAdapt");

			return new MenuModel
			{
				Id = menuToAdapt.Id,
				StartDate = menuToAdapt.StartDate,
				EndDate = menuToAdapt.EndDate,
			};
		}

		public IList<MenuModel> Adapt(IList<Menu> menusToAdapt)
		{
			if (menusToAdapt == null) throw new ArgumentNullException("menusToAdapt");

			return menusToAdapt.Select(Adapt).ToList();
		}

		public IEnumerable<SelectListItem> AvailableMeals { get; set; }

		public IEnumerable<SelectListItem> AvailableDays
		{
			get
			{
				return _availableDays.Select(d => new SelectListItem { Value = d, Text = d });
			}
		}

		public long SelectedMealId { get; set; }
		public string SelectedDay { get; set; }
	}
}