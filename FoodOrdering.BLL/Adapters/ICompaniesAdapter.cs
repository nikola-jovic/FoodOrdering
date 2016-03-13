using FoodOrdering.DAL.DB;
using System.Collections.Generic;

namespace FoodOrdering.BLL.Adapters
{
    public interface ICompaniesAdapter
    {
        IList<Responses.Company> Adapt(IList<Company> companies);

        Responses.Company Adapt(Company company);
    }
}