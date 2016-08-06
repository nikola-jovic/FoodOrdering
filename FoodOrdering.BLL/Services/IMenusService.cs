using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.BLL.Responses;

namespace FoodOrdering.BLL.Services
{
	public interface IMenusService
	{
		Task<GetMenusResponse> GetMenus();
	}
}
