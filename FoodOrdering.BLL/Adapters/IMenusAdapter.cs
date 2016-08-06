using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Adapters
{
	public interface IMenusAdapter
	{
		IList<Menu> Adapt(IList<DAL.DB.Menu> menus);

		Menu Adapt(DAL.DB.Menu menu);
	}
}
