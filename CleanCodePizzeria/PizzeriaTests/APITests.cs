using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodePizzeria.Models;
using System.Collections.Generic;
using PizzeriaStock.Models;
using PizzeriaStock.Controllers;

namespace PizzeriaTests
{
  [TestClass]
  public class APITests
  {
    [TestMethod]
    public void TestGetStockItems()
    {
      var repository = new MockedStockRepository(
        new[] {
          new StockItem { Name = "A", Stock = 1 },
          new StockItem { Name = "B", Stock = 2 },
          new StockItem { Name = "C", Stock = 3 },
        });

      var controller = new StockController(repository);
      Assert.AreEqual(controller.GetStockItems(), repository.GetStockItems());
    }

    [TestMethod]
    public void TestUpdateStockItem()
    {
      var repository = new MockedStockRepository(
        new[] {
          new StockItem { Name = "A", Stock = 1 },
          new StockItem { Name = "B", Stock = 2 },
          new StockItem { Name = "C", Stock = 3 },
        });

      var controller = new StockController(repository);
      controller.UpdateStockItem(new StockItem { Name = "A", Stock = 2 });
      Assert.AreEqual(repository.GetStockItem("A").Stock, 2);
    }

    [TestMethod]
    public void TestMassDelivery()
    {
      var repository = new MockedStockRepository(
        new[] {
          new StockItem { Name = "A", Stock = 1 },
          new StockItem { Name = "B", Stock = 2 },
          new StockItem { Name = "C", Stock = 3 },
        });

      var controller = new StockController(repository);
      controller.MassDelivery();

      Assert.AreEqual(repository.GetStockItem("A").Stock, 11);
      Assert.AreEqual(repository.GetStockItem("B").Stock, 12);
      Assert.AreEqual(repository.GetStockItem("C").Stock, 13);
    }

    [TestMethod]
    public void TestUpdateStockItemsFromOrder()
    {
      var repository = new MockedStockRepository(
        new[] {
          new StockItem { Name = "A", Stock = 1 },
          new StockItem { Name = "B", Stock = 2 },
          new StockItem { Name = "C", Stock = 3 },
        });

      var order = new Order();
      order.AddItem(new Drink("A", 1));
      order.AddItem(new Pizza("name", new List<Ingredient>() {
          new Ingredient("B"),
          new ExtraIngredient("C", 1),
        }, 1)
      );

      var controller = new StockController(repository);
      controller.UpdateStockItemsInOrder(order);

      Assert.AreEqual(repository.GetStockItem("A").Stock, 0);
      Assert.AreEqual(repository.GetStockItem("B").Stock, 1);
      Assert.AreEqual(repository.GetStockItem("C").Stock, 2);
    }
  }
}
