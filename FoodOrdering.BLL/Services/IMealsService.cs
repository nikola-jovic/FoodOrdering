using System.Threading.Tasks;
using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses;

namespace FoodOrdering.BLL.Services
{
	public interface IMealsService
	{
		Task<GetMealsResponse> GetMeals();

		Task<GetMealResponse> GetMealById(GetMealRequest request);

		Task CreateMeal(CreateMealRequest request);

		Task UpdateMeal(UpdateMealRequest request);

		Task DeleteMeal(DeleteMealRequest request);
	}
}