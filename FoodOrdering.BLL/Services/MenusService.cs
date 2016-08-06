using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.BLL.Adapters;
using FoodOrdering.BLL.Responses;
using FoodOrdering.DAL.DB;
using FoodOrdering.DAL.Repositories;

namespace FoodOrdering.BLL.Services
{
	public class MenusService : IMenusService
	{
		private readonly IFoodOrderingRepository _foodOrderingRepository;
		private readonly IMenusAdapter _menusAdapter;

		public MenusService(IFoodOrderingRepository foodOrderingRepository, IMenusAdapter menusAdapter)
		{
			_foodOrderingRepository = foodOrderingRepository;
			_menusAdapter = menusAdapter;
		}

		public async Task<GetMenusResponse> GetMenus()
		{
			IList<Menu> menus = null;
			try
			{
				menus = await _foodOrderingRepository.GetMenus();
			}
			catch (Exception)
			{
				//TODO: do something
			}
			return new GetMenusResponse { Menus = _menusAdapter.Adapt(menus) };
		}
	}
}
