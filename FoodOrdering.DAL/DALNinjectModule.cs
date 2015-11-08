using FoodOrdering.DAL.DB;
using FoodOrdering.DAL.Repositories;
using Ninject.Modules;

namespace FoodOrdering.DAL
{
    public class DALNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFoodOrderingDbFactory>().To<FoodOrderingDbFactory>().InSingletonScope();
            Bind<IFoodOrderingRepository>().To<FoodOrderingRepository>().InSingletonScope();
        }
    }
}