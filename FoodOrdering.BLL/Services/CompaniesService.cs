using FoodOrdering.BLL.Adapters;
using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses;
using FoodOrdering.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company = FoodOrdering.DAL.DB.Company;

namespace FoodOrdering.BLL.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly IFoodOrderingRepository _foodOrderingRepository;
        private readonly ICompaniesAdapter _companiesAdapter;

        public CompaniesService(IFoodOrderingRepository foodOrderingRepository, ICompaniesAdapter companiesAdapter)
        {
            _foodOrderingRepository = foodOrderingRepository;
            _companiesAdapter = companiesAdapter;
        }

        public async Task<GetCompaniesResponse> GetCompanies()
        {
            IList<Company> companies = null;
            try
            {
                companies = await _foodOrderingRepository.GetCompaniesAsync();
            }
            catch (Exception)
            {
                //TODO: do something
            }

            return new GetCompaniesResponse { Companies = _companiesAdapter.Adapt(companies) };
        }

        public async Task<GetCompanyResponse> GetCompanyById(GetCompanyRequest request)
        {
            Company company = null;
            try
            {
                company = await _foodOrderingRepository.GetCompanyByIdAsync(request.CompanyId);
            }
            catch (Exception)
            {
                //TODO: do something
            }

            return new GetCompanyResponse { Company = _companiesAdapter.Adapt(company) };
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            try
            {
                await _foodOrderingRepository.CreateCompanyAsync(request.Name, request.CompanyCode);
            }
            catch (Exception)
            {
                //TODO: do something
            }
        }

        public async Task UpdateCompany(UpdateCompanyRequest request)
        {
            try
            {
                await _foodOrderingRepository.UpdateCompanyAsync(request.CompanyId, request.Name, request.CompanyCode);
            }
            catch (Exception)
            {
                //TODO: do something
            }
        }

        public async Task DeleteCompany(DeleteCompanyRequest request)
        {
            try
            {
                await _foodOrderingRepository.DeleteCompanyAsync(request.CompanyId);
            }
            catch (Exception)
            {
                //TODO: do something
            }
        }
    }
}