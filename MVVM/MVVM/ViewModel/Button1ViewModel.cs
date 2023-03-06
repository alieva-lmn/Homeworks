using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Interfaces;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;

namespace MVVM.ViewModel
{
    public class Button1ViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public Button1ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
