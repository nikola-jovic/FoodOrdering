namespace FoodOrdering.DAL.DB
{
    public interface IFoodOrderingDbFactory
    {
        FoodOrderingEntities GetDatabase();
    }
}