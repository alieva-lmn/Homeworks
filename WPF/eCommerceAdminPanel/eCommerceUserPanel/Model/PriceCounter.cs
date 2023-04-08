using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceUserPanel.Model
{
    public class PriceCounter : INotifyPropertyChanged
    {
        private double overallPrice;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public double OverallPrice
        {
            get => overallPrice;
            set
            {
                overallPrice = value;
                NotifyPropertyChanged(nameof(OverallPrice));
            }
        }
    }
}
