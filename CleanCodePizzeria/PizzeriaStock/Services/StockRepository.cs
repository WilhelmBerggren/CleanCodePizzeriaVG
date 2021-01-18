using PizzeriaStock.Models;
using CleanCodePizzeria;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaStock.Services {
  public interface IStockRepository
  {
    IEnumerable<StockItem> GetStockItems();
    StockItem GetStockItem(string name);
    StockItem UpdateStockItem(StockItem item);
  }

  public class StockRepository : IStockRepository {
    StockContext _context { get; set; }
    private static PizzaRepository repository = new PizzaRepository();

    public StockRepository (StockContext context) {
      _context = context;
    }
    
    public IEnumerable<StockItem> GetStockItems() {
      return _context.Items;
    }

    public StockItem GetStockItem(string name) {
      return _context.Items.Where(i => i.Name == name).FirstOrDefault();
    }

    public StockItem UpdateStockItem(StockItem item) {
      var entity = _context.Items.Where(i => i.Name == item.Name).FirstOrDefault();
      entity.Stock = item.Stock;
      _context.SaveChanges();
      return entity;
    }
  }
}