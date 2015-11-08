using FoodOrdering.BLL.Adapters;
using FoodOrdering.BLL.Services;
using Ninject.Modules;

namespace FoodOrdering.BLL
{
    public class BLLNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGetCompaniesService>().To<GetCompaniesService>().InSingletonScope();
            Bind<IGetCompaniesAdapter>().To<GetCompaniesAdapter>().InSingletonScope();
        }
    }
}