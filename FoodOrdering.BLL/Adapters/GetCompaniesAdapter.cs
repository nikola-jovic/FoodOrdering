using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.BLL.Adapters
{
    public class CompaniesAdapter : ICompaniesAdapter
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

        public Responses.Company Adapt(Company company)
        {
            if (company == null) throw new ArgumentNullException("company");

            return new Responses.Company
            {
                Id = company.Id,
                CompanyCode = company.CompanyCode,
                Name = company.Name
            };
        }
    }
}