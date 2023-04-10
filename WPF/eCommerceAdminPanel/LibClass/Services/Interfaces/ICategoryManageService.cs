using LibClass.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClass.Services.Interfaces
{
    public interface ICategoryManageService
    {
        public ObservableCollection<string?> SetCategory();
    }
}
