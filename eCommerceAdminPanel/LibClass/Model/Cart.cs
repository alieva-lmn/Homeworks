using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibClass.Model
{
    public class Cart : INotifyPropertyChanged
    {
        private double itemPrice;
        private uint itemCount = 1;

        public Book? SingleBook { get; set; } = new();
        public double ItemPrice 
        { 
            get => ItemPrice  = SingleBook.Price * ItemCount;
            set 
            { 
                itemPrice = value;
                OnPropertyChanged(nameof(ItemPrice));
            } 
        }
        public uint ItemCount
        {
            get => itemCount;
            set
            {
                itemCount = value;
                OnPropertyChanged(nameof(ItemCount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
