using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodOrdering.WEB.Models.Identity
{
    public class ApplicationUserRole : IdentityUserRole
    {
        public ApplicationUserRole() : base()
        {
        }

        public ApplicationRole Role { get; set; }
    }
}