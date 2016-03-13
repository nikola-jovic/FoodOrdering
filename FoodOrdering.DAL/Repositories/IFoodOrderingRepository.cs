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

        Task SaveAsync();
    }
}