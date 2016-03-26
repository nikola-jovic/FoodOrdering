using System.Threading.Tasks;
using FoodOrdering.BLL.Requests;

namespace FoodOrdering.BLL.Services
{
    public interface IMealTagsService
    {
        Task BulkAddMealTags(BulkAddMealTagsRequest request);
    }
}