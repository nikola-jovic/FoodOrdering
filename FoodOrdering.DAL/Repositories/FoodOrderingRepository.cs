using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FoodOrdering.DAL.Repositories
{
    public class FoodOrderingRepository : IFoodOrderingRepository
    {
        private readonly IFoodOrderingDbFactory _foodOrderingDbFactory;
        private bool _disposed;

        public FoodOrderingRepository(IFoodOrderingDbFactory foodOrderingDbFactory)
        {
            _foodOrderingDbFactory = foodOrderingDbFactory;
        }

        public async Task<IList<Company>> GetCompaniesAsync()
        {
            using (var database = _foodOrderingDbFactory.GetDatabase())
            {
                return await database.Companies.ToListAsync();
            }
        }

        public async Task<Company> GetCompanyByIdAsync(long companyId)
        {
            using (var database = _foodOrderingDbFactory.GetDatabase())
            {
                return await database.Companies.FindAsync(companyId);
            }
        }

        public async Task CreateCompanyAsync(string name, string companyCode)
        {
            using (var database = _foodOrderingDbFactory.GetDatabase())
            {
                database.Companies.Add(new Company { Name = name, CompanyCode = companyCode });
                await database.SaveChangesAsync();
            }
        }

        public async Task UpdateCompanyAsync(long companyId, string name, string companyCode)
        {
            var company = new Company { Id = companyId, Name = name, CompanyCode = companyCode };
            using (var database = _foodOrderingDbFactory.GetDatabase())
            {
                database.Companies.Attach(company);
                database.Entry(company).Property(x => x.Name).IsModified = true;
                database.Entry(company).Property(x => x.CompanyCode).IsModified = true;
                await database.SaveChangesAsync();
            }
        }

        public async Task DeleteCompanyAsync(long companyId)
        {
            var company = new Company { Id = companyId };
            using (var database = _foodOrderingDbFactory.GetDatabase())
            {
                database.Companies.Attach(company);
                database.Companies.Remove(company);
                await database.SaveChangesAsync();
            }
        }

	    public async Task<IList<Meal>> GetMealsAsync()
	    {
			using (var database = _foodOrderingDbFactory.GetDatabase())
			{
				return await database.Meals.ToListAsync();
			}
		}

	    public async Task<Meal> GetMealByIdAsync(long mealId)
	    {
		    using (var database = _foodOrderingDbFactory.GetDatabase())
		    {
				return await database.Meals.FindAsync(mealId);
			}
	    }

	    public async Task DeleteMealAsync(long mealId)
	    {
			var meal = new Meal { Id = mealId };
			using (var database = _foodOrderingDbFactory.GetDatabase())
			{
				database.Meals.Attach(meal);
				database.Meals.Remove(meal);
				await database.SaveChangesAsync();
			}
	    }

	    public async Task SaveAsync()
        {
            using (var database = _foodOrderingDbFactory.GetDatabase())
            {
                await database.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _foodOrderingDbFactory.GetDatabase().Dispose();
                }
            }
            _disposed = true;
        }
    }
}