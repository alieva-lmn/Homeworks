using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.Classes
{
    public abstract class WashingMachine
    {
        public void Perform(uint minutes, uint revolutions)
        {
            TurnOn();
            Wash(minutes);
            Centrifuge(revolutions);
            TurnOff();
        }

        protected virtual void TurnOn()
        {
            Console.WriteLine("Turning on...");
        }
        protected abstract void Wash(uint minutes);
        protected abstract void Centrifuge(uint revolutions);
        protected virtual void TurnOff()
        {
            Console.WriteLine("Turning off...");
        }
    }
}
