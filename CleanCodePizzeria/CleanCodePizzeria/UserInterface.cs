using CleanCodePizzeria.Models;
using System;
using System.Linq;

namespace CleanCodePizzeria
{
    public class State
    {
        public UserState UserState { get; set; }
        public Order Order { get; set; }
    }
    public enum UserState { ChoosingUser, ChoosingMenuItem, ChoosingDrink, ChoosingPizza, ChoosingExtra, ChoosingOrder, UpdatingOrder }
    public class UserInterface
    {
        Pizzeria Pizzeria { get; }
        OrderManager OrderManager { get; }
        PizzeriaVisitor Visitor { get; }
        IUserInputOutput UserInputOutput { get; }

        public UserInterface(IUserInputOutput userInputOutput)
        {
            Pizzeria = Pizzeria.GetPizzeria();
            OrderManager = new OrderManager(Pizzeria);
            Visitor = new PizzeriaVisitor();
            UserInputOutput = userInputOutput;
        }

        public void RunInterface()
        {
            State state = new State
            {
                UserState = UserState.ChoosingUser,
                Order = OrderManager.CreateOrder(),
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

        public State ChooseExtra(State state)
        {
            UserInputOutput.WriteLine(state.Order.Accept(Visitor));
            var extras = Pizzeria.Extras.ToArray();
            UserInputOutput.WriteLine("Add extra:");
            for (int i = 0; i < extras.Length; i++)
            {
                UserInputOutput.WriteLine($"[{i}] {extras[i].Accept(Visitor)}");
            }
            var input = UserInputOutput.ReadLine();
            if (input == "done") 
            {
                state.UserState = UserState.ChoosingMenuItem;
            }
            else
            {
                var receivedValidNumber = int.TryParse(input, out var validNumber);
                if (!receivedValidNumber) return state;
                OrderManager.AddExtra((Pizza)state.Order.MenuItems.Last(), extras[validNumber]);
            }
            return state;
        }

        public State ChoosePizza(State state)
        {
            var pizzas = Pizzeria.Pizzas.ToArray();
            UserInputOutput.WriteLine("Add pizza:");
            for (int i = 0; i < pizzas.Length; i++)
            {
                UserInputOutput.WriteLine($"[{i}] {pizzas[i].Accept(Visitor)}");
            }
            var input = UserInputOutput.ReadLine();
            var receivedValidNumber = int.TryParse(input, out var validNumber);
            if (!receivedValidNumber) return state;
            OrderManager.AddPizza(state.Order, pizzas[validNumber]);

            state.UserState = UserState.ChoosingExtra;
            return state;
        }

        public State ChooseDrink(State state)
        {
            var drinks = Pizzeria.Drinks.ToArray();
            UserInputOutput.WriteLine("Add drink:");
            for (int i = 0; i < drinks.Length; i++)
            {
                UserInputOutput.WriteLine($"[{i}] {drinks[i].Accept(Visitor)}");
            }
            var input = UserInputOutput.ReadLine();
            var receivedValidNumber = int.TryParse(input, out var validNumber);
            if (!receivedValidNumber) return state;
            OrderManager.AddDrink(state.Order, drinks[validNumber]);
            state.UserState = UserState.ChoosingMenuItem;
            return state;
        }

        public State ChooseMenuItem(State state)
        {
            UserInputOutput.WriteLine(state.Order.Accept(Visitor));
            UserInputOutput.WriteLine("What would you like to add? \n [drink | pizza | submit | cancel]");
            var input = UserInputOutput.ReadLine();
            if (input == "pizza") state.UserState = UserState.ChoosingPizza;
            if (input == "drink") state.UserState = UserState.ChoosingDrink;
            if (input == "cancel") state.UserState = UserState.ChoosingUser;
            if (input == "submit")
            {
                OrderManager.SubmitOrder(state.Order);
                state.UserState = UserState.ChoosingUser;
            }
            return state;
        }

        public State UpdateOrder(State state)
        {
            UserInputOutput.WriteLine("Choose action: \n[complete | remove]");
            var input = UserInputOutput.ReadLine();
            if (input == "complete")
            {
                state.Order.Completed = true;
                OrderManager.UpdateOrder(state.Order);
                UserInputOutput.WriteLine("Order completed");
            }
            if (input == "remove")
            {
                OrderManager.RemoveOrder(state.Order);
                UserInputOutput.WriteLine("Order removed");
            }
            state.UserState = UserState.ChoosingOrder;
            return state;
        }

        public State ChooseOrder(State state)
        {
            foreach (var item in Pizzeria.Orders.Where(i => !i.Value.Completed))
            {
                UserInputOutput.WriteLine(item.Value.Accept(Visitor));
            }
            UserInputOutput.WriteLine("Choose order by id: \n[id]");
            var input = UserInputOutput.ReadLine();
            if (input == "cancel" || input == "done")
            {
                state.UserState = UserState.ChoosingUser;
                return state;
            }
            var receivedValidNumber = int.TryParse(input, out var validNumber);
            if (!receivedValidNumber) return state;
            state.Order = Pizzeria.Orders[validNumber];
            state.UserState = UserState.UpdatingOrder;
            return state;
        }

        public State ChooseUser(State state)
        {
            UserInputOutput.WriteLine("Choose user type: \n[user | admin]");
            var input = UserInputOutput.ReadLine();
            if (input == "user") state.UserState = UserState.ChoosingMenuItem;
            if (input == "admin") state.UserState = UserState.ChoosingOrder;
            return state;
        }
    }
}
