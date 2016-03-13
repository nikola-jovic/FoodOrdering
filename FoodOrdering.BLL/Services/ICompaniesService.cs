using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses;
using System.Threading.Tasks;

namespace FoodOrdering.BLL.Services
{
    public interface ICompaniesService
    {
        Task<GetCompaniesResponse> GetCompanies();

        Task<GetCompanyResponse> GetCompanyById(GetCompanyRequest request);

        Task CreateCompany(CreateCompanyRequest request);

        Task UpdateCompany(UpdateCompanyRequest request);

        Task DeleteCompany(DeleteCompanyRequest request);
    }
}