using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodePizzeria;
using System.Linq;
using CleanCodePizzeria.Types;

namespace PizzeriaTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddDrinkTest()
        {
            var p = Pizzeria.GetPizzeria();
            var om = new OrderManager(p);
            var d = p.Drinks.First();

            var actual = om.AddDrink(om.CreateOrder(), d);
            var expected = new Order();
            expected.AddItem(d);

            Assert.AreEqual(actual.MenuItems.First().Title, expected.MenuItems.First().Title);
            Assert.AreEqual(actual.Price, expected.Price);
        }

        [TestMethod]
        public void AddPizzaTest()
        {
            var p = Pizzeria.GetPizzeria();
            var om = new OrderManager(p);
            var d = p.Pizzas.First();

            var actual = om.AddPizza(om.CreateOrder(), d);
            var expected = new Order();
            expected.AddItem(d);

            Assert.AreEqual(actual.MenuItems.First().Title, expected.MenuItems.First().Title);
            Assert.AreEqual(actual.Price, expected.Price);
        }

        [TestMethod]
        public void CompleteOrderTest()
        {
            var p = Pizzeria.GetPizzeria();
            var om = new OrderManager(p);

            var actual = om.CompleteOrder(om.CreateOrder());
            var expected = om.GetOrders().First().Value;

            Assert.IsNotNull(actual.ID);
            Assert.AreEqual(actual.ID, expected.ID);
        }

        [TestMethod]
        public void GetAllPizzasTest()
        {
            var p = Pizzeria.GetPizzeria();
            var r = new PizzaRepository();

            var actual1 = p.Pizzas.Where(p => p.Title == "Margerita").FirstOrDefault();
            var expected1 = r.GetPizzas().Where(p => p.Title == "Margerita").FirstOrDefault();

            Assert.IsNotNull(actual1);
            Assert.AreEqual(actual1.Title, expected1.Title);
        }

        [TestMethod]
        public void AddExtraIngredientTest()
        {
            var p = Pizzeria.GetPizzeria();
            var om = new OrderManager(p);

            var extra = p.Extras.First();
            var pizza = p.Pizzas.First();
            var order = om.AddPizza(om.CreateOrder(), om.AddExtraToPizza(pizza, extra));

            var expected = extra.Title;
            var actual = ((Pizza)order.MenuItems.First()).Ingredients.Where(i => i is ExtraIngredient).First().Title;

            Assert.AreEqual(expected, actual);
        }
    }
}
