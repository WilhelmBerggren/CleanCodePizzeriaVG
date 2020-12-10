using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    public class Pizza : MenuItem
    {
        public List<Ingredient> Ingredients { get; }

        public Pizza(string title, List<Ingredient> ingredients, int price) : base(title, price)
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
        public Ingredient(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }

    public class ExtraIngredient : Ingredient
    {
        public ExtraIngredient(string title, int price) : base(title)
        {
            Price = price;
        }

        public int Price { get; set; }
    }
}
