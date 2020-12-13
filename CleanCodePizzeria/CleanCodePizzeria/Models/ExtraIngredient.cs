namespace CleanCodePizzeria.Types
{
    public class ExtraIngredient : Ingredient
    {
        public ExtraIngredient(string title, int price) : base(title)
        {
            Price = price;
        }

        public int Price { get; set; }
    }
}
