using System.Collections.Generic;

namespace CleanCodePizzeria.Types
{
    public class Pizza : MenuItem
    {
        public List<Ingredient> Ingredients { get; }

        public Pizza(string title, List<Ingredient> ingredients, int price) : base(title, price)
        {
            Ingredients = ingredients;
        }

        public void AddExtra(ExtraIngredient extra)
        {
            Ingredients.Add(extra);
            Price += extra.Price;
        }
    }
}
