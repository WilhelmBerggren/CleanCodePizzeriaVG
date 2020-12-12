namespace CleanCodePizzeria
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pizzeria = Pizzeria.GetPizzeria();
            var orderManager = new OrderManager(pizzeria);

            orderManager.Start();
        }
    }
}
