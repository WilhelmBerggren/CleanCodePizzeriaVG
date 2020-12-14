using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria.Models
{
    public class Order: IVisitable
    {
        public int? ID { get; set; }
        public bool Completed { get; set; }
        public List<MenuItem> MenuItems { get; } = new List<MenuItem>();
        public void AddItem(MenuItem item) => MenuItems.Add(item);

        public void AcceptVisitor(PizzeriaVisitor visitor)
        {
            visitor.VisitItem(this);
        }

        public string Accept(PizzeriaVisitor visitor) => visitor.VisitItem(this);

        public int Price => MenuItems.Sum(item => item.Price);
    }
}
