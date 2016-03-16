using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodOrdering.WEB.Models.Identity
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext() : base("IdentityDbContext", throwIfV1Schema: false)
        {
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}