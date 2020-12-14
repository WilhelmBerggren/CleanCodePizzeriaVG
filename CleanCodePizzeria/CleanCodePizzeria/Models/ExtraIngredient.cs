namespace CleanCodePizzeria.Models
{
    public class ExtraIngredient : Ingredient, IVisitable
    {
        public ExtraIngredient(string title, int price) : base(title)
        {
            Price = price;
        }

        public int Price { get; set; }
    }
}
