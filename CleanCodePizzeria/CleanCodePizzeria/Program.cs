using CleanCodePizzeria.Models;
using System;
using System.Linq;

namespace CleanCodePizzeria
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface(new UserInputOutput());
            userInterface.RunInterface();
        }
    }
}
