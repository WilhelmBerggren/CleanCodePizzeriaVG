using System.Collections.Generic;

namespace CleanCodePizzeria.Models
{
    public class Pizza : MenuItem
    {
        public List<Ingredient> Ingredients { get; }

        public Pizza(string title, List<Ingredient> ingredients, int price) : base(title, price)
        {
            Ingredients = ingredients;
        }
    }
}
