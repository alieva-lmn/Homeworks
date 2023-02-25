using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    public class GasStation
    {
        public List<Gasoline>? GasolineOption { get; set; } = new();
        public List<MenuItem>? Menu { get; set; } = new();
        public GasStation()
        {
            GasolineOption.Add(new Gasoline { Type = "А-98", Price = 1.90 });
            GasolineOption.Add(new Gasoline { Type = "А-95", Price = 1.60 });
            GasolineOption.Add(new Gasoline { Type = "А-92", Price = 1.30 });
            GasolineOption.Add(new Gasoline { Type = "А-80", Price = 1.10 });

            Menu.Add(new MenuItem { Name = "Хот-дог", Price = 1.80, Count = 0 });
            Menu.Add(new MenuItem { Name = "Гамбургер", Price = 2.20, Count = 0 });
            Menu.Add(new MenuItem { Name = "Картошка-фри", Price = 1.10, Count = 0 });
            Menu.Add(new MenuItem { Name = "Спрайт", Price = 0.70, Count = 0 });

        }
    }
}
