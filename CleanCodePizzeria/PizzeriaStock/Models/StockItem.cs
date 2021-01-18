using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaStock.Models
{
  public class StockItem
  {
    [Key]
    public string Name { get; set; }
    public int Stock { get; set; }
  }
}