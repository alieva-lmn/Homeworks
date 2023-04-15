using AdapterPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdapterPattern.Classes
{
    public class NewMixture : IRenewedMixture
    {
        public void GlowingSkinNewMixture()
        {
            Console.WriteLine("New mixture");
        }
    }
}
