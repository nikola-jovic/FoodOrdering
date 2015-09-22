using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodOrdering.WEB.Startup))]
namespace FoodOrdering.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
