using FoodOrdering.BLL.Adapters;
using FoodOrdering.BLL.Responses;
using FoodOrdering.DAL.DB;
using FoodOrdering.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodOrdering.BLL.Requests;

namespace FoodOrdering.BLL.Services
{
	public class MealsService : IMealsService
	{
		private readonly IFoodOrderingRepository _foodOrderingRepository;
		private readonly IMealsAdapter _mealsAdapter;

		public MealsService(IFoodOrderingRepository foodOrderingRepository, IMealsAdapter mealsAdapter)
		{
			_foodOrderingRepository = foodOrderingRepository;
			_mealsAdapter = mealsAdapter;
		}

		public async Task<GetMealsResponse> GetMeals()
		{
			IList<Meal> meals = null;
			try
			{
				meals = await _foodOrderingRepository.GetMealsAsync();
			}
			catch (Exception)
			{
				//TODO: do something
			}
			return new GetMealsResponse { Meals = _mealsAdapter.Adapt(meals) };
		}

		public async Task<GetMealResponse> GetMealById(GetMealRequest request)
		{
			Meal meal = null;
			try
			{
				meal = await _foodOrderingRepository.GetMealByIdAsync(request.MealId);
			}
			catch (Exception)
			{
				//TODO: do something
			}
			return new GetMealResponse { Meal = _mealsAdapter.Adapt(meal) };
		}

		public async Task CreateMeal(CreateMealRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateMeal(UpdateMealRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteMeal(DeleteMealRequest request)
		{
			try
			{
				await _foodOrderingRepository.DeleteMealAsync(request.MealId).ConfigureAwait(false);
			}
			catch (Exception)
			{
				//TODO: do something
			}
		}
	}
}