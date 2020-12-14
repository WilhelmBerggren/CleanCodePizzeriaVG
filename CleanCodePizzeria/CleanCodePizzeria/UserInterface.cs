using CleanCodePizzeria.Models;
using System;
using System.Linq;

namespace CleanCodePizzeria
{
    class State
    {
        public UserState UserState { get; set; }
        public Order Order { get; set; }
    }
    enum UserState { ChoosingUser, ChoosingMenuItem, ChoosingDrink, ChoosingPizza, ChoosingExtra, ChoosingOrder, UpdatingOrder }
    class UserInterface
    {
        Pizzeria pizzeria;
        OrderManager orderManager;
        PizzeriaVisitor visitor;
        public UserInterface()
        {
            pizzeria = Pizzeria.GetPizzeria();
            orderManager = new OrderManager(pizzeria);
            visitor = new PizzeriaVisitor();
        }

        public void RunInterface()
        {
            State state = new State
            {
                UserState = UserState.ChoosingUser,
                Order = orderManager.CreateOrder(),
            };

            while (true)
            {
                state = state.UserState switch
                {
                    UserState.ChoosingUser => ChooseUser(state),
                    UserState.ChoosingMenuItem => ChooseMenuItem(state),
                    UserState.ChoosingDrink => ChooseDrink(state),
                    UserState.ChoosingPizza => ChoosePizza(state),
                    UserState.ChoosingExtra => ChooseExtra(state),
                    UserState.ChoosingOrder => ChooseOrder(state),
                    UserState.UpdatingOrder => UpdateOrder(state),
                    _ => throw new NotImplementedException(),
                };
            }
        }

        private State ChooseExtra(State state)
        {
            Console.WriteLine(state.Order.Accept(visitor));
            var extras = pizzeria.Extras.ToArray();
            Console.WriteLine("Add extra:");
            for (int i = 0; i < extras.Length; i++)
            {
                Console.WriteLine($"[{i}] {extras[i].Accept(visitor)}");
            }
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "done") {
                state.UserState = UserState.ChoosingMenuItem;
            }
            else
            {
                orderManager.AddExtra((Pizza)state.Order.MenuItems.Last(), extras[int.Parse(input)]);
                state.UserState = UserState.ChoosingExtra;
            }
            return state;
        }

        private State ChoosePizza(State state)
        {
            var pizzas = pizzeria.Pizzas.ToArray();
            Console.WriteLine("Add pizza:");
            for (int i = 0; i < pizzas.Length; i++)
            {
                Console.WriteLine($"[{i}] {pizzas[i].Accept(visitor)}");
            }
            var input = Console.ReadLine();
            Console.Clear();
            orderManager.AddPizza(state.Order, pizzas[int.Parse(input)]);

            state.UserState = UserState.ChoosingExtra;
            return state;
        }

        private State ChooseDrink(State state)
        {
            var drinks = pizzeria.Drinks.ToArray();
            Console.WriteLine("Add drink:");
            for (int i = 0; i < drinks.Length; i++)
            {
                Console.WriteLine($"[{i}] {drinks[i].Accept(visitor)}");
            }
            var input = Console.ReadLine();
            Console.Clear();
            orderManager.AddDrink(state.Order, drinks[int.Parse(input)]);
            state.UserState = UserState.ChoosingMenuItem;
            return state;
        }

        private State ChooseMenuItem(State state)
        {
            Console.WriteLine(state.Order.Accept(visitor));
            Console.WriteLine("What would you like to add? \n [drink | pizza | submit | cancel]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "pizza") state.UserState = UserState.ChoosingPizza;
            if (input == "drink") state.UserState = UserState.ChoosingDrink;
            if (input == "cancel") state.UserState = UserState.ChoosingUser;
            if (input == "submit")
            {
                orderManager.SubmitOrder(state.Order);
                state.UserState = UserState.ChoosingUser;
            }
            return state;
        }

        private State UpdateOrder(State state)
        {
            Console.WriteLine("Choose action: \n[complete | remove]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "complete")
            {
                state.Order.Completed = true;
                orderManager.UpdateOrder(state.Order);
                Console.WriteLine("Order completed");
            }
            if (input == "remove")
            {
                orderManager.RemoveOrder(state.Order);
                Console.WriteLine("Order removed");
            }
            state.UserState = UserState.ChoosingOrder;
            return state;
        }

        private State ChooseOrder(State state)
        {
            foreach (var item in pizzeria.Orders.Where(i => !i.Value.Completed))
            {
                Console.WriteLine(item.Value.Accept(visitor));
            }
            Console.WriteLine("Choose order by id: \n[id]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "cancel" || input == "done")
            {
                state.UserState = UserState.ChoosingUser;
                return state;
            }
            state.Order = pizzeria.Orders[int.Parse(input)];
            state.UserState = UserState.UpdatingOrder;
            return state;
        }

        private State ChooseUser(State state)
        {
            Console.WriteLine("Choose user type: \n[user | admin]");
            var input = Console.ReadLine();
            Console.Clear();
            if (input == "user") state.UserState = UserState.ChoosingMenuItem;
            if (input == "admin") state.UserState = UserState.ChoosingOrder;
            return state;
        }
    }
}
