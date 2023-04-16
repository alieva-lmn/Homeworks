using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class AppearanceBuilder
    {
        public AppearanceBuilder CreateAppearance()
        {
            Console.WriteLine("Some manipulations with appearance");
            return new AppearanceBuilder();
        }
    }
}
