using FoodOrdering.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using Company = FoodOrdering.BLL.Responses.DTO.Company;

namespace FoodOrdering.BLL.Adapters
{
    public class CompaniesAdapter : ICompaniesAdapter
    {
        public IList<Company> Adapt(IList<DAL.DB.Company> companies)
        {
            if (companies == null) throw new ArgumentNullException("companies");

            return companies.Select(company => new Company
            {
                Id = company.Id,
                Name = company.Name,
                CompanyCode = company.CompanyCode
            }).ToList();
        }

        public Company Adapt(DAL.DB.Company company)
        {
            if (company == null) throw new ArgumentNullException("company");

            return new Company
            {
                Id = company.Id,
                CompanyCode = company.CompanyCode,
                Name = company.Name
            };
        }
    }
}