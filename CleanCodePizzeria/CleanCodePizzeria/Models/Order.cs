using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria.Types
{
    public class Order
    {
        public int? ID { get; set; }
        public bool Completed { get; set; }
        public List<MenuItem> MenuItems { get; } = new List<MenuItem>();
        public void AddItem(MenuItem item) => MenuItems.Add(item);

        public void AcceptVisitor(PizzeriaVisitor visitor)
        {
            visitor.VisitItem(this);
        }
        public int Price => MenuItems.Sum(item => item.Price);
    }
}
