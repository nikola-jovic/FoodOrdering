using System.Collections.Generic;

namespace FoodOrdering.BLL
{
    public abstract class Response
    {
        public bool ErrorsOccured { get; set; }
        public IList<Error> Errors { get; set; }
    }
}