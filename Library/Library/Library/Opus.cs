using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // Mű osztály
    public abstract class Opus
    {
        public string Author { get; set; } // Szerző
        public string Title { get; set; } // Cím
        public int Expenditure { get; set; } // Kiadás
        public int Pages { get; set; } // Oldalak száma
    }
}
