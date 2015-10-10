namespace FoodOrdering.WEB.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Company { get; set; }

        public bool Errors { get; set; }
        public string ErrorMessage { get; set; }
    }
}