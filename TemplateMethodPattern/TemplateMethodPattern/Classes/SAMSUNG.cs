using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.Classes
{
    public class SAMSUNG : WashingMachine
    {
        protected override void Centrifuge(uint revolutions)
        {
            Console.WriteLine($"SAMSUNG spin speed: {revolutions} RPM");
        }
        protected override void Wash(uint minutes)
        {
            Console.WriteLine($"SAMSUNG wash time: {minutes} minutes");
        }
    }
}
