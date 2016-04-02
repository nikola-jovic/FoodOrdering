using System.Web;
using System.Web.Mvc;

namespace FoodOrdering.WEB
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
