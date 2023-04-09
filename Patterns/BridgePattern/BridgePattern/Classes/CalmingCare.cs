using BridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BridgePattern.Classes
{
    public class CalmingCare : ISkincare
    {
        public void DoChanges()
        {
            Console.WriteLine("Skin Calming effect");
        }
    }
}
