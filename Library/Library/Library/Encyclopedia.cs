using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Encyclopedia : Book
    {
        public int Version { get; set; }
        public ESubject Subject { get; set; }
    }
}
