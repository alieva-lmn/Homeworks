using BridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Classes
{
    public class Cream : Cosmetics
    {
        public Cream(ISkinCare care)
        {
            this.care = care;
        }
        public override void DoChanges()
        {
            Console.Write("Cream with ");
            this.care.DoChanges();
        }
    }
}
