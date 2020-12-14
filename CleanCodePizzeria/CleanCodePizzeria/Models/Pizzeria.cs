using System.Collections.Generic;

namespace CleanCodePizzeria.Models
{
    public class Pizzeria: IVisitable
    {
        static readonly Pizzeria _instance = new Pizzeria();
        PizzaRepository Repository { get; }
        public Dictionary<int, Order> Orders { get; } = new Dictionary<int, Order>();
        private Pizzeria() => Repository = new PizzaRepository();
        public static Pizzeria GetPizzeria() => _instance;

        public string Accept(PizzeriaVisitor visitor) => visitor.VisitItem(this);

        public IEnumerable<Pizza> Pizzas => Repository.GetPizzas();
        public IEnumerable<Drink> Drinks => Repository.GetDrinks();
        public IEnumerable<ExtraIngredient> Extras => Repository.GetExtras();
    }
}
