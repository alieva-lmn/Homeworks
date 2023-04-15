using ProxyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Classes
{
    public class ProxyClass : IRecipe
    {
        private readonly Pancake _pancake;

        public ProxyClass()
        {
            _pancake = new Pancake();
        }

        public void Recipe()
        {
            _pancake.Recipe();
            Console.WriteLine("Some additional information about pancake recipe from Proxy class");
        }
    }
}
