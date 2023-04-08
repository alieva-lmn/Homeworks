using LibClass.Services.Interfaces;
using LibClass.Services.Classes;
using LibClass.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace LibClass.Services.Classes
{
    public class BookManageService : IBookManageService
    {
        private readonly string? path = FilePath.bookPath;
        public static ObservableCollection<Book> books { get; set; } = new();

        public ObservableCollection<Book> DownloadData()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);
            
            if (String.IsNullOrEmpty(json))
            {
                return books;
            }
            else
            {
                return books = SerializeService.DeserializeList<ObservableCollection<Book>>(json);
            }
        }

        public void SendData(ObservableCollection<Book> books)
        {
            var res = SerializeService.Serialize(books);
            FileService.WriteToFile(res, path, FileMode.Truncate);
        }
        public void Add(Book book)
        {
            book.Id = Guid.NewGuid();
            books = DownloadData();
            books.Add(book);

            SendData(books);
        }

        public void Replace(Book book)
        {
            books = DownloadData();

            for (int i = 0; i < books.Count; i++)
            {
                if (book.Id.ToString() == books[i].Id.ToString())
                {
                    books[i] = book;
                }
            }

            SendData(books);
        }
    }
}
