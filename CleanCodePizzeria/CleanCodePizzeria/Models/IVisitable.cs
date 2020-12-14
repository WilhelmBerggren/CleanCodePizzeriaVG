using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria.Models
{
    public interface IVisitable
    {
        public string Accept(PizzeriaVisitor visitor);
    }
}
