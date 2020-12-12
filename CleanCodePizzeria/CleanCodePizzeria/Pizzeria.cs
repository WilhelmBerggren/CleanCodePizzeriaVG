using CleanCodePizzeria.Types;
using System.Collections.Generic;

namespace CleanCodePizzeria
{
    public class Pizzeria
    {
        int _IdAccumulator { get; set; }
        static readonly Pizzeria _instance = new Pizzeria();
        PizzaRepository repository { get; set; }
        public Dictionary<int, Order> Orders { get; set; } = new Dictionary<int, Order>();
        private Pizzeria() => repository = new PizzaRepository();

        public void AddOrder(Order order)
        {
            order.ID = _IdAccumulator++;
            Orders[order.ID] = order;
        }

        public static Pizzeria GetPizzeria() => _instance;
        public IEnumerable<Pizza> Pizzas => repository.GetPizzas();
        public IEnumerable<Drink> Drinks => repository.GetDrinks();
        public IEnumerable<ExtraIngredient> Extras => repository.GetExtras();
    }
}
