using CleanCodePizzeria.Types;
using System;
using System.Linq;

namespace CleanCodePizzeria
{
    enum UserState { ChoosingUser, ChoosingMenuItem, ChoosingDrink, ChoosingPizza, ChoosingExtra, ChoosingOrder, UpdatingOrder }
    class UserInterface
    {
        Pizzeria pizzeria;
        OrderManager orderManager;
        PizzeriaVisitor visitor;
        UserState userState;
        Order order;
        public UserInterface()
        {
            pizzeria = Pizzeria.GetPizzeria();
            orderManager = new OrderManager(pizzeria);
            visitor = new PizzeriaVisitor();
        }

        public void RunInterface()
        {
            userState = UserState.ChoosingUser;
            order = orderManager.CreateOrder();

            while (true)
            {
                switch (userState)
                {
                    case UserState.ChoosingUser:
                        ChooseUser();
                        break;

                    case UserState.ChoosingOrder:
                        ChooseOrder();
                        break;

                    case UserState.UpdatingOrder:
                        UpdateOrder();
                        break;

                    case UserState.ChoosingMenuItem:
                        ChooseMenuItem();
                        break;

                    case UserState.ChoosingDrink:
                        ChooseDrink();
                        break;

                    case UserState.ChoosingPizza:
                        ChoosePizza();
                        break;

                    case UserState.ChoosingExtra:
                        ChooseExtra();
                        break;
                }
            }
        }

        private void ChooseExtra()
        {
            Console.WriteLine(visitor.VisitItem(order));
            var extras = pizzeria.Extras.ToArray();
            Console.WriteLine("Add extra:");
            for (int i = 0; i < extras.Length; i++)
            {
                Console.WriteLine($"[{i}] {visitor.VisitItem(extras[i])}");
            }
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "done")
            {
                userState = UserState.ChoosingMenuItem;
                return;
            }
            orderManager.AddExtra((Pizza)order.MenuItems.Last(), extras[int.Parse(input)]);
            userState = UserState.ChoosingExtra;
        }

        private void ChoosePizza()
        {
            var pizzas = pizzeria.Pizzas.ToArray();
            Console.WriteLine("Add pizza:");
            for (int i = 0; i < pizzas.Length; i++)
            {
                Console.WriteLine($"[{i}] {visitor.VisitItem(pizzas[i])}");
            }
            var input = Console.ReadLine();
            Console.Clear();
            orderManager.AddPizza(order, pizzas[int.Parse(input)]);
            userState = UserState.ChoosingExtra;
        }

        private void ChooseDrink()
        {
            var drinks = pizzeria.Drinks.ToArray();
            Console.WriteLine("Add drink:");
            for (int i = 0; i < drinks.Length; i++)
            {
                Console.WriteLine($"[{i}] {visitor.VisitItem(drinks[i])}");
            }
            var input = Console.ReadLine();
            Console.Clear();
            orderManager.AddDrink(order, drinks[int.Parse(input)]);
            userState = UserState.ChoosingMenuItem;
        }

        private void ChooseMenuItem()
        {
            Console.WriteLine(visitor.VisitItem(order));
            Console.WriteLine("What would you like to add? \n [drink | pizza | submit | cancel]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "pizza") userState = UserState.ChoosingPizza;
            if (input == "drink") userState = UserState.ChoosingDrink;
            if (input == "cancel") userState = UserState.ChoosingUser;
            if (input == "submit")
            {
                orderManager.SubmitOrder(order);
                userState = UserState.ChoosingUser;
            }
        }

        private void UpdateOrder()
        {
            Console.WriteLine("Choose action: \n[complete | remove]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "complete")
            {
                order.Completed = true;
                orderManager.UpdateOrder(order);
                Console.WriteLine("Order completed");
            }
            if (input == "remove")
            {
                orderManager.RemoveOrder(order);
                Console.WriteLine("Order removed");
            }
            userState = UserState.ChoosingOrder;
        }

        private void ChooseOrder()
        {
            foreach (var item in pizzeria.Orders.Where(i => !i.Value.Completed))
            {
                Console.WriteLine(visitor.VisitItem(item.Value));
            }
            Console.WriteLine("Choose order by id: \n[id]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "cancel")
            {
                userState = UserState.ChoosingUser;
                return;
            }
            order = pizzeria.Orders[int.Parse(input)];
            userState = UserState.UpdatingOrder;
        }

        private void ChooseUser()
        {
            Console.WriteLine("Choose user type: \n[user | admin]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "user") userState = UserState.ChoosingMenuItem;
            if (input == "admin") userState = UserState.ChoosingOrder;
        }
    }
}
