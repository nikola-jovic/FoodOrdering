using System.Collections.Generic;

namespace FoodOrdering.BLL.Requests
{
    public class BulkAddMealTagsRequest : Request
    {
        public IList<string> MealTags { get; set; }
    }
}