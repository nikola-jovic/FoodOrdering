﻿using FoodOrdering.DAL.DB;
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

		Task SaveAsync();
    }
}