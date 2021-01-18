using Microsoft.EntityFrameworkCore;
using CleanCodePizzeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaStock.Models
{
  public class StockContext : DbContext
  {
    public StockContext(DbContextOptions<StockContext> options) : base(options)
    {
      Database.EnsureCreated();

      var items = new PizzaRepository()
        .GetIngredients()
        .Select(i => new StockItem { Name = i.Title, Stock = 0 });

      foreach (var item in items) {
        if (!Items.Any(i => i.Name == item.Name)) {
          System.Console.WriteLine("Adding new item: " + item.Name);
          Items.Add(item);
        }
      }

      SaveChanges();
    }
    public DbSet<StockItem> Items { get; set; }
  }
}