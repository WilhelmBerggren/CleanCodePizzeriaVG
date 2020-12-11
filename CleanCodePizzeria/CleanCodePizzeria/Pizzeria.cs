using CleanCodePizzeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    public class Pizzeria
    {
        static readonly Pizzeria _instance = new Pizzeria();
        public Dictionary<int, Order> Orders { get; set; } = new Dictionary<int, Order>();
        public List<Pizza> Pizzas { get; set; }
        public List<MenuItem> Drinks { get; set; }
        public List<ExtraIngredient> Extras { get; set; }
        public IEnumerable<Order> OrdersCompleted => Orders.Select(o => o.Value).Where(o => o.Completed);

        public IEnumerable<Order> OrdersInProgress => Orders.Select(o => o.Value).Where(o => !o.Completed);

        private Pizzeria() 
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

            Drinks = new List<MenuItem>()
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

        public Order StartOrder()
        {
            var id = Orders.Count;
            var order = new Order(id);
            Orders.Add(id, order);
            return order;
        }

        public void UpdateOrder(Order order)
        {
            Orders[order.ID] = order;
        }

        public void CompleteOrder(Order order)
        {
            order.Completed = true;
            Orders[order.ID] = order;
        }

        public static Pizzeria GetPizzeria() => _instance;

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
    }
}

public class Order
{
    public int ID { get; }
    public bool Completed { get; set; }
    public List<MenuItem> MenuItems { get; } = new List<MenuItem>();
    public Order(int id)
    {
        ID = id;
    }
    public void AddItem(MenuItem item) => MenuItems.Add(item);

    public void AcceptVisitor(PizzeriaVisitor visitor)
    {
        visitor.VisitOrder(this);
    }
}