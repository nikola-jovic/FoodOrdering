namespace FoodOrdering.DAL.DB
{
    public class FoodOrderingDbFactory : IFoodOrderingDbFactory
    {
        public FoodOrderingEntities GetDatabase()
        {
            return new FoodOrderingEntities();
        }
    }
}