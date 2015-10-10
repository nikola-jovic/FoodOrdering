using System.ComponentModel.DataAnnotations;
using FoodOrdering.WEB.Localization.Register;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Register), Name = "LabelEmail")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(Register), ErrorMessageResourceName = "MsgInvalidPassword", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Register), Name = "LabelPassword")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Register), Name = "LabelConfirmPassword")] //Using resource instead of plain string.
        [Compare("Password", ErrorMessageResourceType = typeof(Register), ErrorMessageResourceName = "MsgInvalidConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Display(ResourceType = typeof(Register), Name = "LabelCompanyCode")]
        public string CompanyCode { get; set; }

        [Display(Name = "User Role")]
        public Roles Role { get; set; }
    }
}