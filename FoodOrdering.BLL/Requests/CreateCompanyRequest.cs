namespace FoodOrdering.BLL.Requests
{
    public class CreateCompanyRequest : Request
    {
        public string Name { get; set; }
        public string CompanyCode { get; set; }
    }
}