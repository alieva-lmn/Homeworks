using BridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Classes
{
    public class CalmingCare : ISkinCare
    {
        public void DoChanges()
        {
            Console.WriteLine("Skin calming effect");
        }
    }
}
