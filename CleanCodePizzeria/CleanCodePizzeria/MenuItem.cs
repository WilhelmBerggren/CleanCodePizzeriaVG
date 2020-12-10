using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    public abstract class MenuItem
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public MenuItem(string title, int price)
        {
            Title = title;
            Price = price;
        }
    }
}
