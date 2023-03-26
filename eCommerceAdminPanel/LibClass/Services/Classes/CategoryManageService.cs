using LibClass.Services.Interfaces;
using LibClass.Model;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LibClass.Services.Classes
{
    public class CategoryManageService : ICategoryManageService
    {
        private ObservableCollection<string> _cats = new();

        private readonly IBookManageService _bookService;

        public CategoryManageService(IBookManageService bookService)
        {
            _bookService = bookService;
        }
        public ObservableCollection<string> SetCategory()
        {
            var books = _bookService.DownloadData();

            foreach (var item in books)
            {
                _cats.Add(item.Genre);
            }

            HashSet<string> hashset = new();
            IEnumerable<string> no_duplicates = _cats.Where(e => hashset.Add(e));

            var cats = no_duplicates.ToList();
            _cats.Clear();

            foreach (var cat in cats)
            {
                _cats.Add(cat);
            }
            return _cats;
        }

        
    }
}
