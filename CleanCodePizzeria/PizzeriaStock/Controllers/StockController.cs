using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanCodePizzeria;
using CleanCodePizzeria.Models;

namespace PizzeriaStock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private static PizzaRepository repository = new PizzaRepository();

        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return repository.GetPizzas();
        }

        [HttpGet("Extras")]
        public IEnumerable<Ingredient> GetExtras() {
            return repository.GetExtras();
        }

        [HttpGet("Drinks")]
        public IEnumerable<Drink> GetDrinks() {
            return repository.GetDrinks();
        }
    }
}
