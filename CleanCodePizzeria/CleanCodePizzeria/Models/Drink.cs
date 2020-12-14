namespace CleanCodePizzeria.Models
{
    public class Drink : MenuItem, IVisitable
    {
        public Drink(string title, int price) : base(title, price)
        {
        }
    }
}
