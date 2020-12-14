using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodePizzeria
{
    class UserInputOutput : IUserInputOutput
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        public string WriteLine(string input)
        {
            Console.WriteLine(input);
            return input;
        }
    }
}
