using System.Collections.Generic;
using Company = FoodOrdering.BLL.Responses.DTO.Company;

namespace FoodOrdering.BLL.Adapters
{
	public interface ICompaniesAdapter
	{
		IList<Company> Adapt(IList<DAL.DB.Company> companies);

		Company Adapt(DAL.DB.Company company);
	}
}