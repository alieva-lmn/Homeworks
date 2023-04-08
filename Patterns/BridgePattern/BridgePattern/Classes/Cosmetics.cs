using BridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Classes
{
    public abstract class Cosmetics
    {
        protected ICare care;
        public abstract void DoChanges();
    }
}
