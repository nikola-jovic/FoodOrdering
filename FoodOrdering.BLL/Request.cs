namespace FoodOrdering.BLL
{
    public abstract class Request
    {
        public string CorrelationId { get; set; }
        public string Requestor { get; set; }
    }
}