using FoodOrdering.BLL.Adapters;
using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses;
using FoodOrdering.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company = FoodOrdering.DAL.DB.Company;

namespace FoodOrdering.BLL.Services
{
    public class GetCompaniesService : IGetCompaniesService
    {
        private readonly IFoodOrderingRepository _foodOrderingRepository;
        private readonly IGetCompaniesAdapter _getCompaniesAdapter;

        public GetCompaniesService(IFoodOrderingRepository foodOrderingRepository, IGetCompaniesAdapter getCompaniesAdapter)
        {
            _foodOrderingRepository = foodOrderingRepository;
            _getCompaniesAdapter = getCompaniesAdapter;
        }

        public async Task<GetCompaniesResponse> GetCompanies(GetCompaniesRequest request)
        {
            IList<Company> companies = await _foodOrderingRepository.GetCompanies();

            return new GetCompaniesResponse { Companies = _getCompaniesAdapter.Adapt(companies) };
        }
    }
}