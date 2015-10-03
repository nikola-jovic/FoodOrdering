using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.WEB.Models.ViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}