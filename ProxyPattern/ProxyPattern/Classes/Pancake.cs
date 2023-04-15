using ProxyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Classes
{
    public class Pancake : IRecipe
    {
        public void Recipe()
        {
            Console.WriteLine("Let's pretend here is some pancake recipe");
        }
    }
}
