using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Responses
{
	public class GetMenusResponse : Response
	{
		public IList<Menu> Menus { get; set; }
	}
}
