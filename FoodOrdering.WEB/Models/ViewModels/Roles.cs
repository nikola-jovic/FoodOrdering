using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public enum Roles
    {
        [Display(Name = "Regular User")]
        RegularUser,
        [Display(Name = "Company admin")]
        CompanyAdmin,
        [Display(Name = "Super admin")]
        SuperAdmin
    }
}