using CleanCodePizzeria.Types;
using System.Collections.Generic;

namespace CleanCodePizzeria
{
    public class Pizzeria
    {
        int _IdAccumulator { get; set; }
        static readonly Pizzeria _instance = new Pizzeria();
        PizzaRepository Repository { get; }
        public Dictionary<int, Order> Orders { get; } = new Dictionary<int, Order>();
        private Pizzeria() => Repository = new PizzaRepository();

        public Order AddOrder(Order order)
        {
            order.ID = _IdAccumulator++;
            Orders[order.ID] = order;
            return order;
        }

        public void RemoveOrder(Order order) => Orders.Remove(order.ID);
        public static Pizzeria GetPizzeria() => _instance;
        public IEnumerable<Pizza> Pizzas => Repository.GetPizzas();
        public IEnumerable<Drink> Drinks => Repository.GetDrinks();
        public IEnumerable<ExtraIngredient> Extras => Repository.GetExtras();
    }
}
