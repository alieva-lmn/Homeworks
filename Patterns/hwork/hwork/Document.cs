using hwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace hwork
{
    public class Document : ICloneable
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public uint Fontsize { get; set; } = 14;

        public Guid ID { get; set; }

        public object Clone() => new Document()
        {
            Fontsize = this.Fontsize
        };
    }
}
