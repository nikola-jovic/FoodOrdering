using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FoodOrdering.DAL.Repositories
{
    public class FoodOrderingRepository : IFoodOrderingRepository
    {
        private readonly FoodOrderingEntities _foodOrderingEntities;
        private bool _disposed;

        public FoodOrderingRepository(FoodOrderingEntities foodOrderingEntities)
        {
            _foodOrderingEntities = foodOrderingEntities;
        }

        public async Task<IList<Company>> GetCompanies()
        {
            return await _foodOrderingEntities.Companies.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _foodOrderingEntities.SaveChangesAsync();
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
                    _foodOrderingEntities.Dispose();
                }
            }
            _disposed = true;
        }
    }
}