using System.ComponentModel.DataAnnotations;
using FoodOrdering.WEB.Localization.Register;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Register), ErrorMessageResourceName = "MsgInvalidPassword", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Register), Name = "LabelConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(Register), ErrorMessageResourceName = "MsgInvalidConfirmPassword")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}