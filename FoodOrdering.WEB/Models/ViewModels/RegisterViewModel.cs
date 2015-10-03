using System.ComponentModel.DataAnnotations;
using FoodOrdering.WEB.Localization.Register;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Register), Name = "LabelEmail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Register), ErrorMessageResourceName = "MsgInvalidPassword", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Register), Name = "LabelPassword")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Register), Name = "LabelConfirmPassword")] //Using resource instead of plain string.
        [Compare("Password", ErrorMessageResourceType = typeof(Register), ErrorMessageResourceName = "MsgInvalidConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(ResourceType = typeof(Register), Name = "LabelCompanyCode")]
        public string CompanyCode { get; set; }
    }
}