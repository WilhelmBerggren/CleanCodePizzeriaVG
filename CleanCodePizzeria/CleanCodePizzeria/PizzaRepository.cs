using CleanCodePizzeria.Types;
using System.Collections.Generic;

namespace CleanCodePizzeria
{
    public class PizzaRepository
    {
        private List<Pizza> Pizzas { get; }
        private List<Drink> Drinks { get; }
        private List<ExtraIngredient> Extras { get; }

        public List<Pizza> GetPizzas() => Pizzas;

        public List<Drink> GetDrinks() => Drinks;

        public List<ExtraIngredient> GetExtras() => Extras;

        public PizzaRepository()
        {
            var ost = new Ingredient("ost");
            var tomatsås = new Ingredient("tomatsås");
            var tomat = new Ingredient("tomat");
            var skinka = new Ingredient("skinka");
            var ananas = new Ingredient("ananas");
            var kebab = new Ingredient("kebab");
            var champinjoner = new Ingredient("champinjoner");
            var lök = new Ingredient("lök");
            var räkor = new Ingredient("räkor");
            var musslor = new Ingredient("musslor");
            var kronärtskocka = new Ingredient("kronärtskocka");
            var feferoni = new Ingredient("feferoni");
            var isbergssallad = new Ingredient("isbergssallad");
            var kebabsås = new Ingredient("kebabsås");

            Pizzas = new List<Pizza>()
            {
                new Pizza("Margerita", new List<Ingredient> { ost, tomatsås }, 85),
                new Pizza("Hawaii", new List<Ingredient> { ost, tomatsås, skinka, ananas }, 95),
                new Pizza("Kebabpizza", new List<Ingredient> { ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomat, kebabsås }, 105),
                new Pizza("Quatro Stagioni", new List<Ingredient> {  ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka }, 115),
            };

            Drinks = new List<Drink>()
            {
                new Drink("Coca cola", 20),
                new Drink("Fanta", 20),
                new Drink("Sprite", 25),
            };

            Extras = new List<ExtraIngredient>()
            {
                new ExtraIngredient("Skinka", 10),
                new ExtraIngredient("Ananas", 10),
                new ExtraIngredient("Champinjoner", 10),
                new ExtraIngredient("Lök", 10),
                new ExtraIngredient("Kebabsås", 10),
                new ExtraIngredient("Räkor", 15),
                new ExtraIngredient("Musslor", 15),
                new ExtraIngredient("Kronärtskocka", 15),
                new ExtraIngredient("Kebab", 20),
                new ExtraIngredient("Koriander", 20),
            };
        }
    }
}
