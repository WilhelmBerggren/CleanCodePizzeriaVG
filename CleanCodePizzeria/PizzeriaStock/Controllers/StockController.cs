using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CleanCodePizzeria;
using CleanCodePizzeria.Models;
using PizzeriaStock.Models;

namespace PizzeriaStock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private static PizzaRepository repository = new PizzaRepository();
        private readonly StockContext _context;
        public StockController(StockContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<StockItem> GetStockItems() {
            return _context.Items.ToList();
        }

        [HttpPost]
        public ActionResult<StockItem> UpdateStockItem(StockItem item) 
        {
            var itemToChange = _context.Items.Find(item.Id);
            if (itemToChange != null) {
                itemToChange.Stock = item.Stock;
                _context.SaveChanges();
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPost("MassDelivery")]
        public ActionResult<IEnumerable<StockItem>> UpdateAllStockItems() {
            foreach(var item in _context.Items) {
                item.Stock = item.Stock + 10;
            }
            _context.SaveChanges();
            return _context.Items.ToList();
        }
    }
}
