using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodePizzeria
{
    public class Program
    {
        static void Main(string[] args)
        {
            var menuVisitor = new PizzeriaVisitor();
            var pizzeria = Pizzeria.GetPizzeria();
            var orderManager = new OrderManager(pizzeria);

            Console.WriteLine("Hello!\n[0]Costumer\n[1]Employee");
            var input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    var order = pizzeria.StartOrder();
                    Console.WriteLine("Add an item:");
                    while (true)
                    {
                        orderManager.Start();
                    }
                break;

                case "1":
                    var accumulator = 0;
                    foreach (var item in pizzeria.OrdersInProgress)
                    {
                        Console.WriteLine($"[{accumulator}]{menuVisitor.VisitOrder(item)}");
                        accumulator++;
                    }
                    Console.WriteLine(Environment.NewLine + "Choose an order");
                    var orderIndex = int.Parse(Console.ReadLine());
                    var currentOrder = pizzeria.OrdersInProgress.ToArray()[orderIndex];
                    Console.WriteLine("[0]Complete order\n[1]Remove order");
                    input = Console.ReadLine();
                    if (input == "0")
                    {
                        pizzeria.CompleteOrder(currentOrder);
                        Console.WriteLine("order completed");
                    }
                    if (input == "1")
                    { 
                        pizzeria.Orders.Remove(currentOrder.ID);
                        Console.WriteLine("order removed");
                    } 
                break;
            }



            

            Console.WriteLine("updated order");
            var pizza = pizzeria.Pizzas[0];
            pizza.Ingredients.Add(pizzeria.Extras[0]);
            //order.AddItem(pizza);
            //pizzeria.UpdateOrder(order);
            //pizzeria.CompleteOrder(order);

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
