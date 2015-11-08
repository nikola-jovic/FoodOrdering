using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.BLL.Adapters
{
    public class GetCompaniesAdapter : IGetCompaniesAdapter
    {
        public IList<Responses.Company> Adapt(IList<Company> companies)
        {
            if (companies == null) throw new ArgumentNullException("companies");

            return companies.Select(company => new Responses.Company
            {
                Id = company.Id,
                Name = company.Name,
                CompanyCode = company.CompanyCode
            }).ToList();
        }
    }
}