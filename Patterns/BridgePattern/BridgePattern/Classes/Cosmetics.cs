using BridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BridgePattern.Classes
{
    public abstract class Cosmetics
    {
        protected ISkincare care;
        public abstract void DoChanges();
    }
}
