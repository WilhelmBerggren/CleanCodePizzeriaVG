using CleanCodePizzeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaTests
{
    class MockedUserInputOutput : IUserInputOutput
    {
        public MockedUserInputOutput(string returnValue)
        {
            ReturnValue = returnValue;
        }

        public string ReturnValue { get; }

        public string ReadLine()
        {
            return ReturnValue;
        }

        public string WriteLine(string input)
        {
            return input;
        }
    }
}
