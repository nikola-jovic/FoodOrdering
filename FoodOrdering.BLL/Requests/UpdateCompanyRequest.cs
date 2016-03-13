namespace FoodOrdering.BLL.Requests
{
    public class UpdateCompanyRequest : Request
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string CompanyCode { get; set; }
    }
}