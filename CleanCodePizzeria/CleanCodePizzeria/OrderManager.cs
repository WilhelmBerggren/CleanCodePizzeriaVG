using CleanCodePizzeria.Types;
using System.Linq;
using System.Collections.Generic;

namespace CleanCodePizzeria
{
    public class OrderManager
    {
        int _IdAccumulator { get; set; }
        public Pizzeria Pizzeria { get; }
        public PizzeriaVisitor Visitor { get; }

        public OrderManager(Pizzeria pizzeria)
        {
            Pizzeria = pizzeria;
            Visitor = new PizzeriaVisitor();
        }

        public Dictionary<int, Order> GetOrders()
        {
            return Pizzeria.Orders;
        }

        public Order CreateOrder()
        {
            return new Order();
        }

        public Order SubmitOrder(Order order)
        {
            order.ID = _IdAccumulator++;
            Pizzeria.Orders[order.ID.Value] = order;
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            Pizzeria.Orders[order.ID.Value] = order;
            return order;
        }

        public void RemoveOrder(Order order) => Pizzeria.Orders.Remove(order.ID.Value);

        public Order AddPizza(Order order, Pizza pizza)
        {
            order.MenuItems.Add(pizza);
            return order;
        }

        public Order AddDrink(Order order, Drink drink)
        {
            order.MenuItems.Add(drink);
            return order;
        }

        public Pizza AddExtra(Pizza pizza, ExtraIngredient extra)
        {
            pizza.Ingredients.Add(extra);
            pizza.Price += extra.Price;
            return pizza;
        }
    }
}
