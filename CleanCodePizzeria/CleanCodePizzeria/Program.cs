using CleanCodePizzeria.Types;
using System;
using System.Linq;

namespace CleanCodePizzeria
{
    enum UserState {ChoosingUser, ChoosingMenuItem, ChoosingDrink, ChoosingPizza, ChoosingExtra, ChoosingOrder, UpdatingOrder}
    public class Program
    {
        static UserState userState;
        static void Main(string[] args)
        {
            var pizzeria = Pizzeria.GetPizzeria();
            var orderManager = new OrderManager(pizzeria);
            var visitor = new PizzeriaVisitor();
            userState = UserState.ChoosingUser;

            var order = orderManager.CreateOrder();
            var input = "";
            while (true)
            {
                switch (userState)
                {
                    case UserState.ChoosingUser:
                        Console.WriteLine("Choose user type: \n[user | admin]");
                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "user") userState = UserState.ChoosingMenuItem;
                        if (input == "admin") userState = UserState.ChoosingOrder;
                        break;

                    case UserState.ChoosingOrder:
                        foreach (var item in pizzeria.Orders.Where(i => !i.Value.Completed))
                        {
                            Console.WriteLine(visitor.VisitItem(item.Value));
                        }
                        Console.WriteLine("Choose order by id: \n[id]");
                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "cancel") 
                        {
                            userState = UserState.ChoosingUser;
                            break; 
                        } 
                        order = pizzeria.Orders[int.Parse(input)];
                        userState = UserState.UpdatingOrder;
                        break;

                    case UserState.UpdatingOrder:
                        Console.WriteLine("Choose action: \n[complete | remove]");
                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "complete") 
                        {
                            order.Completed = true;
                            orderManager.UpdateOrder(order);
                            Console.WriteLine("Order completed");
                        } 
                        if(input == "remove")
                        {
                            orderManager.RemoveOrder(order);
                            Console.WriteLine("Order removed");
                        }
                        userState = UserState.ChoosingOrder;
                        break;

                    case UserState.ChoosingMenuItem:
                        Console.WriteLine(visitor.VisitItem(order));
                        Console.WriteLine("What would you like to add? \n [drink | pizza | submit | cancel]");
                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "pizza") userState = UserState.ChoosingPizza;
                        if (input == "drink") userState = UserState.ChoosingDrink;
                        if (input == "cancel") userState = UserState.ChoosingUser;
                        if (input == "submit")
                        {
                            orderManager.SubmitOrder(order);
                            userState = UserState.ChoosingUser;
                        }
                        break;

                    case UserState.ChoosingDrink:
                        var drinks = pizzeria.Drinks.ToArray();
                        Console.WriteLine("Add drink:");
                        for(int i = 0; i < drinks.Length; i++)
                        {
                            Console.WriteLine($"[{i}] {visitor.VisitItem(drinks[i])}");
                        }
                        input = Console.ReadLine();
                        Console.Clear();
                        orderManager.AddDrink(order, drinks[int.Parse(input)]);
                        userState = UserState.ChoosingMenuItem;
                        break;

                    case UserState.ChoosingPizza:
                        var pizzas = pizzeria.Pizzas.ToArray();
                        Console.WriteLine("Add pizza:");
                        for (int i = 0; i < pizzas.Length; i++)
                        {
                            Console.WriteLine($"[{i}] {visitor.VisitItem(pizzas[i])}");
                        }
                        input = Console.ReadLine();
                        Console.Clear();
                        orderManager.AddPizza(order, pizzas[int.Parse(input)]);
                        userState = UserState.ChoosingExtra;
                        break;

                    case UserState.ChoosingExtra:
                        Console.WriteLine(visitor.VisitItem(order));
                        var extras = pizzeria.Extras.ToArray();
                        Console.WriteLine("Add extra:");
                        for (int i = 0; i < extras.Length; i++)
                        {
                            Console.WriteLine($"[{i}] {visitor.VisitItem(extras[i])}");
                        }
                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "done")
                        {
                            userState = UserState.ChoosingMenuItem;
                            break;
                        }
                        orderManager.AddExtra((Pizza)order.MenuItems.Last(), extras[int.Parse(input)]);
                        userState = UserState.ChoosingExtra;
                        break;
                }
            }
        }
    }
}
