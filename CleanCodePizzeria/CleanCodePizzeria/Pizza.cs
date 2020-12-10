using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    public class Pizza : MenuItem
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Pizza(string title, int price, IEnumerable<Ingredient> ingredients) : base(title, price)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            return $"{Title} - {string.Join(", ", Ingredients)} - {Price}kr";
        }
    }

    public class Ingredient
    {
        public string Title { get; set; }
    }

    public class ExtraIngredient : Ingredient
    {
        public int Price { get; set; }
    }
}
