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
using PizzeriaStock.Services;

namespace PizzeriaStock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _repository;
        public StockController(IStockRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<StockItem> GetStockItems() {
            return _repository.GetStockItems();
        } 

        [HttpPost]
        public ActionResult<StockItem> UpdateStockItem(StockItem item) 
        {
            var savedItem = _repository.UpdateStockItem(item);
            if (savedItem != null) {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPost("UpdateStockFromOrder")]
        public ActionResult<Order> UpdateStockItemsInOrder(Order order) {
            var ingredients = new List<string>();
            foreach(var item in order.MenuItems) {
                if (item is Drink) {
                    ingredients.Add(item.Title);
                }
                if (item is Pizza pizza) {
                    foreach (var ingredient in pizza.Ingredients) {
                        ingredients.Add(ingredient.Title);
                    }
                }
            }
            foreach(var ingredient in ingredients) {
                var oldItem = _repository.GetStockItem(ingredient);
                _repository.UpdateStockItem(new StockItem { Name = oldItem.Name, Stock = oldItem.Stock - 1 });
            }
            return Ok(order);
        }

        [HttpPost("MassDelivery")]
        public ActionResult<IEnumerable<StockItem>> MassDelivery() {
            foreach(var item in _repository.GetStockItems()) {
                _repository.UpdateStockItem(new StockItem { Name = item.Name, Stock = item.Stock + 10 });
            }
            return Ok(_repository.GetStockItems());
        }
    }
}
