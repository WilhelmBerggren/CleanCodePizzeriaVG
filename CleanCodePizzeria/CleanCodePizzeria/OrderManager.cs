using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public void Start()
        {
            var input = "";
            while (input != "done")
            {
                DisplayOrders();
                Console.WriteLine("[new | done]");
                input = Console.ReadLine();
                if (input == "new")
                {
                    CreateOrder();
                }
            }
        }

        public void CreateOrder()
        {
            var input = "";
            var order = Pizzeria.StartOrder();
            while(input != "done")
            {
                Console.WriteLine("[0] Add pizza\n[1] Add drink");
                input = Console.ReadLine();
                if(input == "0")
                {
                    var n = 0;
                    foreach (var item in Pizzeria.Pizzas)
                    {
                        Console.WriteLine($"[{n}] {item}");
                        n++;
                    }
                    Pizza pizza = EditPizza(Pizzeria.Pizzas.ToArray()[int.Parse(Console.ReadLine())]);
                    order.AddItem(pizza);
                }
                if(input == "1")
                {

                }
            }
            while (input != "done")
            {
                Console.WriteLine(Visitor.VisitOrder(order));
                Console.WriteLine("[new | done | exit]");
                input = Console.ReadLine();
            }
        }

        private Pizza EditPizza(Pizza pizza)
        {
            var input = "";
            while(input != "done")
            {
                Console.WriteLine("Add Extras:");
                var n = 0;
                foreach (var item in Pizzeria.Extras)
                {
                    Console.WriteLine($"[{n}] {item}");
                    n++;
                }
                input = Console.ReadLine();
                if(input != "done")
                {
                    var index = int.Parse(input);
                    var extra = Pizzeria.Extras.ToArray()[index];
                    pizza.Ingredients.Add(extra);
                    pizza.Price += extra.Price;
                }
            }
            return pizza;
        }

        public void DisplayOrders()
        {
            Console.WriteLine(Visitor.VisitPizzeria(Pizzeria));
        }
    }
}
