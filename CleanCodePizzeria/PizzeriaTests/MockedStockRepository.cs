using System.Collections.Generic;
using PizzeriaStock.Models;
using PizzeriaStock.Services;
using System.Linq;

namespace PizzeriaTests
{
  public class MockedStockRepository : IStockRepository
  {
    StockItem[] stockItems { get; set; }
    public MockedStockRepository(StockItem[] items)
    {
      stockItems = items;
    }
    public StockItem GetStockItem(string name)
    {
      return stockItems.Where(i => i.Name == name).FirstOrDefault();
    }

    public IEnumerable<StockItem> GetStockItems()
    {
      return stockItems;
    }

    public StockItem UpdateStockItem(StockItem item)
    {
      var oldItem = GetStockItem(item.Name);
      oldItem.Stock = item.Stock;
      return oldItem;
    }
  }
}