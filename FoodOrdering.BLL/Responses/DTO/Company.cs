using System.Collections.Generic;
using FoodOrdering.DAL.DB;

namespace FoodOrdering.BLL.Responses.DTO
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CompanyCode { get; set; }
        public IList<AspNetUser> Users { get; set; }
    }
}