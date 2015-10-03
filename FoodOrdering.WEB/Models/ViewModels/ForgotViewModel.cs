using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}