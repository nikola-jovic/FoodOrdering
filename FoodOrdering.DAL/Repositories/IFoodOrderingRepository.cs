using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrdering.DAL.Repositories
{
    public interface IFoodOrderingRepository : IDisposable
    {
        Task<IList<Company>> GetCompanies();

        Task SaveAsync();
    }
}