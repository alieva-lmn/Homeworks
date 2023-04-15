using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.Classes
{
    public class Bosch : WashingMachine
    {
        protected override void Centrifuge(uint revolutions)
        {
            Console.WriteLine($"Bosch spin speed: {revolutions} RPM");
        }
        protected override void Wash(uint minutes)
        {
            Console.WriteLine($"Bosch wash time: {minutes} minutes");
        }
    }
}
