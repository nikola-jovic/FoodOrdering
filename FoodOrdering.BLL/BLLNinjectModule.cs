using FoodOrdering.BLL.Adapters;
using FoodOrdering.BLL.Services;
using Ninject.Modules;

namespace FoodOrdering.BLL
{
    public class BLLNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICompaniesService>().To<CompaniesService>().InSingletonScope();
            Bind<ICompaniesAdapter>().To<CompaniesAdapter>().InSingletonScope();
	        Bind<IMealsService>().To<MealsService>().InSingletonScope();
			Bind<IMealsAdapter>().To<MealsAdapter>().InSingletonScope();
            Bind<IMealTagsService>().To<MealTagsService>().InSingletonScope();
        }
    }
}