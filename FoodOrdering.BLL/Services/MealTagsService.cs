using System;
using System.Threading.Tasks;
using FoodOrdering.BLL.Requests;
using FoodOrdering.DAL.Repositories;

namespace FoodOrdering.BLL.Services
{
    public class MealTagsService : IMealTagsService
    {
        private readonly IFoodOrderingRepository _foodOrderingRepository;

        public MealTagsService(IFoodOrderingRepository foodOrderingRepository)
        {
            _foodOrderingRepository = foodOrderingRepository;
        }

        public async Task BulkAddMealTags(BulkAddMealTagsRequest request)
        {
            try
            {
                await _foodOrderingRepository.BulkCreateMealTagsAsync(request.MealTags);
            }
            catch (Exception)
            {
                //TODO: do something
            }
        }
    }
}