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
            while (input != "done")
            {
                Console.WriteLine(Visitor.VisitOrder(order));
                Console.WriteLine("[new | done]");
                input = Console.ReadLine();
            }
        }

        public void DisplayOrders()
        {
            Console.WriteLine(Visitor.VisitPizzeria(Pizzeria));
        }
    }
}
