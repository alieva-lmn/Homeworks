using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProject.Model
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string ProjectName { get; set; } = "Untitled";
        public DateTime Date { get; set; } = DateTime.Now;
        public string PicturePath { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; } 

    }
}
