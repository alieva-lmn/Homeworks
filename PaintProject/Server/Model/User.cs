using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProject.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public string Email { get; set; }
        public ObservableCollection<Picture> PicCollection { get; set; }
    }

}
