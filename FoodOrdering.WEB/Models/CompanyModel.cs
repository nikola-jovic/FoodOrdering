using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.WEB.Models
{
    public class CompanyModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Company Code")]
        public string CompanyCode { get; set; }

        public bool Errors { get; set; }
        public string ErrorMessage { get; set; }
    }
}