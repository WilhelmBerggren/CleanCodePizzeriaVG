using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodePizzeria
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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

            var pizzas = new List<Pizza>()
            {
                new Pizza("Margerita", new List<Ingredient> { ost, tomatsås }, 85),
                new Pizza("Hawaii", new List<Ingredient> { ost, tomatsås, skinka, ananas }, 95),
                new Pizza("Kebabpizza", new List<Ingredient> { ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomat, kebabsås }, 105),
                new Pizza("Quatro Stagioni", new List<Ingredient> {  ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka }, 115),
            };

            var drinks = new List<MenuItem>()
            {
                new Drink("Coca cola", 20),
                new Drink("Fanta", 20),
                new Drink("Sprite", 25),
            };

            var extras = new List<ExtraIngredient>()
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

            var allItems = new List<MenuItem>();
            allItems.AddRange(pizzas);
            allItems.AddRange(drinks);
            var itemsAr = allItems.ToArray();

            var input = "";
            var order = new List<MenuItem>();
            while (input != "done")
            {
                if (order.Count > 0)
                {
                    Console.WriteLine("Your order: ");
                    foreach (var item in order)
                    {
                        Console.WriteLine(item.Title + ": " + item.Price);
                    }
                    Console.WriteLine();
                }

                var n = 0;
                Console.WriteLine("Add to order:");
                foreach (var item in pizzas)
                {
                    Console.WriteLine(n + ": " + item.Title + ": " + item.Price);
                    n++;
                }
                foreach (var item in drinks)
                {
                    Console.WriteLine(n + ": " + item.Title + ": " + item.Price);
                    n++;
                }

                input = Console.ReadLine();

                if (input == "done")
                {
                    Console.WriteLine("Completed order:");
                    foreach (var item in order)
                    {
                        Console.WriteLine(item.Title);
                    }
                    Console.WriteLine("Total cost: " + order.Sum(i => i.Price) );
                    return;
                }

                var selected = itemsAr[int.Parse(input)];
                
                if (selected is Pizza)
                {
                    var extraInput = "";
                    while (extraInput != "done")
                    {
                        var extraN = 0;
                        Console.WriteLine("Add extras:");
                        foreach (var item in extras)
                        {
                            Console.WriteLine(extraN + ": " + item.Title + ": " + item.Price);
                            extraN++;
                        }
                        extraInput = Console.ReadLine();
                        if (extraInput == "done") break;
                        var extraIngredient = extras.ToArray()[int.Parse(extraInput)];
                        ((Pizza)selected).Ingredients.Add(extraIngredient);
                        ((Pizza)selected).Price += extraIngredient.Price;

                        Console.WriteLine(selected.ToString());
                    }
                }

                order.Add(selected);

                Console.WriteLine(selected.Title);
            }
        }

        public string[] GetPizzaMenuEntries()
        {
            throw new Exception("yeet");
        }

        public string[] GetBeverageMenuEntries()
        {
            throw new Exception("no beverage here. So sad.");
        }

        public string[] GetExtraMenuEntries()
        {
            throw new NotImplementedException("not implemented yet. pls come back l8r");
        }

        public object StartOrder()
        {
            throw new NotImplementedException();
        }

        public object AddToOrder(string v)
        {
            throw new NotImplementedException();
        }
    }
}
