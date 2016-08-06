using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrdering.DAL.Repositories
{
	public interface IFoodOrderingRepository : IDisposable
	{
		Task<IList<Company>> GetCompaniesAsync();

		Task<Company> GetCompanyByIdAsync(long companyId);

		Task CreateCompanyAsync(string name, string companyCode);

		Task UpdateCompanyAsync(long companyId, string name, string companyCode);

		Task DeleteCompanyAsync(long companyId);

		Task<IList<Meal>> GetMealsAsync();

		Task<Meal> GetMealByIdAsync(long mealId);

		Task DeleteMealAsync(long mealId);

		Task BulkCreateMealTagsAsync(IList<string> mealTags);

		Task BulkCreateMealsAsync(IList<Meal> meals);

		Task CreateMeal(string name, int category, string description, decimal price);

		Task UpdateMealAsync(long id, string name, string description, decimal price, int category);

		Task<IList<Menu>> GetMenus();

		Task SaveAsync();


	}
}