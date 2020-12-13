using CleanCodePizzeria.Types;
using System.Linq;
using System.Collections.Generic;

namespace CleanCodePizzeria
{
    public class OrderManager
    {
        public Pizzeria Pizzeria { get; }
        public PizzeriaVisitor Visitor { get; }

        public OrderManager(Pizzeria pizzeria)
        {
            Pizzeria = pizzeria;
            Visitor = new PizzeriaVisitor();
        }

        //public void AcceptCommand(string command)
        //{
        //    Order currentOrder = default;

        //    while (true)
        //    {
        //        if (command == "Add order")
        //            currentOrder = new Order();

        //        else if (command.StartsWith("Add extra "))
        //        {
        //            var extraIndex = int.Parse(command.Substring(10));
        //        }
        //    }
        //}

        public Dictionary<int, Order> GetOrders()
        {
            return Pizzeria.Orders;
        }

        public Order CompleteOrder(Order order)
        {
            return Pizzeria.AddOrder(order);
        }

        public Order CreateOrder()
        {
            return new Order();
        }

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

        public Pizza AddExtraToPizza(Pizza pizza, ExtraIngredient extra)
        {
            pizza.Ingredients.Add(extra);
            pizza.Price += extra.Price;
            return pizza;
        }
    }
}
