using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    public class PizzeriaVisitor
    {
        public string VisitPizzeria(Pizzeria pizzeria)
        {
            var sb = new StringBuilder();

            sb.Append("Orders completed: ");
            foreach (var item in pizzeria.OrdersCompleted)
            {
                sb.Append(VisitOrder(item));
            }

            sb.Append("Orders in progress: ");
            foreach (var item in pizzeria.OrdersInProgress)
            {
                sb.Append(VisitOrder(item));
            }
            return sb.ToString();
        }

        public string VisitOrder(Order order)
        {
            var total = order.MenuItems.Sum(i => i.Price);
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append($"Order {order.ID}");
            sb.Append(Environment.NewLine);

            foreach (var item in order.MenuItems)
            {
                sb.Append(item);
                if (item is Pizza pizza)
                {
                    var included = pizza.Ingredients.Where(i => !(i is ExtraIngredient));
                    sb.Append(Environment.NewLine);
                    sb.Append("Ingredients: ");
                    sb.Append(string.Join(Environment.NewLine, included));

                    var extras = pizza.Ingredients.Where(i => (i is ExtraIngredient));
                    sb.Append(Environment.NewLine);
                    sb.Append("Extras: ");
                    sb.Append(string.Join(Environment.NewLine, extras));
                }
            }

            sb.Append(Environment.NewLine);
            sb.Append($"Total: {total}");

            return sb.ToString();
        }
    }
}
