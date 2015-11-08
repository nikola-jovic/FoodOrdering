using FoodOrdering.DAL.DB;
using System.Collections.Generic;

namespace FoodOrdering.BLL.Adapters
{
    public interface IGetCompaniesAdapter
    {
        IList<Responses.Company> Adapt(IList<Company> companies);
    }
}