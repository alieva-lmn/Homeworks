using BridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BridgePattern.Classes
{
    public class Gel : Cosmetics
    {
        public Gel(ISkincare care)
        {
            this.care = care;
        }
        public override void DoChanges()
        {
            Console.Write("Gel with ");
            this.care.DoChanges();
        }
    }
}
