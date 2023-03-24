using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClass.Model
{
    public class PriceCounter : INotifyPropertyChanged
    {
        private double overallPrice;
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public double OverallPrice
        {
            get => overallPrice;
            set
            {
                overallPrice = value;
                NotifyPropertyChanged(nameof(OverallPrice));
            }
        }
        public PriceCounter(double price)
        {
            overallPrice = price;
            NotifyPropertyChanged(nameof(OverallPrice));
        }
    }
}
