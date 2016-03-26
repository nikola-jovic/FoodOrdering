using System.Collections.Generic;
using FoodOrdering.BLL.Responses.DTO;

namespace FoodOrdering.BLL.Requests
{
    public class BulkCreateMealsRequest : Request
    {
        public IList<Meal> Meals { get; set; }
    }
}