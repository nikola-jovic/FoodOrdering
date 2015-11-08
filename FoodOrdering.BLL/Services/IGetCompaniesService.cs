using System.Threading.Tasks;
using FoodOrdering.BLL.Requests;
using FoodOrdering.BLL.Responses;

namespace FoodOrdering.BLL.Services
{
    public interface IGetCompaniesService
    {
        Task<GetCompaniesResponse> GetCompanies(GetCompaniesRequest request);
    }
}
