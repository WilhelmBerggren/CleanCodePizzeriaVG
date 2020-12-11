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

            var pizzeria = Pizzeria.GetPizzeria();
            var order = pizzeria.StartOrder();
            var menuVisitor = new PizzeriaVisitor();

            Console.WriteLine("updated order");
            var pizza = pizzeria.Pizzas[0];
            pizza.Ingredients.Add(pizzeria.Extras[0]);
            order.AddItem(pizza);
            pizzeria.UpdateOrder(order);
            pizzeria.CompleteOrder(order);

            Console.WriteLine("completed order");
            Console.WriteLine("Not completed: ");
            foreach(var o in pizzeria.OrdersInProgress)
            {
                Console.WriteLine(menuVisitor.VisitOrder(o));
            }
            Console.WriteLine("Completed: ");
            foreach (var o in pizzeria.OrdersCompleted)
            {
                Console.WriteLine(menuVisitor.VisitOrder(o));
            }

            //Console.WriteLine(menuVisitor.VisitOrder(order));
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
