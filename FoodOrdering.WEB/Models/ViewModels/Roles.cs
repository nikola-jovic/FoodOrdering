using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public enum Roles
    {
        [Display(Name = "Company admin")]
        CompanyAdmin,
        [Display(Name = "Super admin")]
        SuperAdmin
    }
}