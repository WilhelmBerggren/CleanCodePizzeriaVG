using CleanCodePizzeria.Types;
using System;

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
            Console.WriteLine("Hello!");
            var actions = new[] { "Customer", "Employee", "Exit" };
            while (true)
            {
                var action = ItemSelector<string>.SelectItem(actions);
                Console.WriteLine(action);
                if (action == actions[0])
                {
                    CreateAndPlaceOrder();
                }
                if (action == actions[1]) {
                    ManageOrders();
                }
                if (action == actions[2])
                {
                    return;
                }
            }
        }

        public void ManageOrders()
        {
            if (Pizzeria.Orders.Count == 0)
            {
                Console.WriteLine("No orders available");
                return;
            }
            var currentOrder = ItemSelector<Order>.SelectItem(Pizzeria.Orders);

            if (currentOrder == default)
            {
                Console.WriteLine("No order selected");
                return;
            }

            var actions = new string[] { "Complete order", "Remove order" };
            var action = ItemSelector<string>.SelectItem(actions);

            if (action == actions[0])
            {
                Pizzeria.AddOrder(currentOrder);
                Console.WriteLine("Order completed");
            }
            if (action == actions[1])
            {
                Pizzeria.Orders.Remove(currentOrder.ID);
                Console.WriteLine("Order removed");
            }
        }

        public void CreateAndPlaceOrder()
        {
            var actions = new[] { "New", "Done" };
            var action = ItemSelector<string>.SelectItem(actions);
            if (action == actions[0])
            {
                var order = CreateOrder();
                if (order != null)
                    Pizzeria.AddOrder(order);
            }
        }

        public Order CreateOrder()
        {
            var order = new Order();
            var actions = new[] { "Add pizza", "Add drink", "Done", "Cancel" };
            while(true)
            {
                var action = ItemSelector<string>.SelectItem(actions);
                if(action == actions[0])
                {
                    var pizza = ItemSelector<Pizza>.SelectItem(Pizzeria.Pizzas);
                    if (pizza != null)
                    {
                        pizza = EditPizza(pizza);
                        order.AddItem(pizza);
                    }
                }
                if(action == actions[1])
                {
                    var drink = ItemSelector<Drink>.SelectItem(Pizzeria.Drinks);
                    if (drink != null)
                        order.AddItem(drink);
                }
                if (action == actions[2])
                {
                    return order;
                }
                if (action == actions[3])
                {
                    return null;
                }
            }
        }

        private Pizza EditPizza(Pizza pizza)
        {
            while(true)
            {
                Console.WriteLine("Add Extras:");
                var extra = ItemSelector<ExtraIngredient>.SelectItem(Pizzeria.Extras);
                if(extra != default)
                {
                    Console.WriteLine($"Selected: {extra.Title}");
                    pizza.Ingredients.Add(extra);
                    pizza.Price += extra.Price;
                } else
                {
                    return pizza;
                }
            }
        }
    }
}
