using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClass.Model;

namespace LibClass.Services.Interfaces
{
    public interface IBookManageService
    {
        public void Add(Book book);
        public void Replace(Book book);
        public ObservableCollection<Book> DownloadData();
        public void SendData(ObservableCollection<Book> books);
    }
}
