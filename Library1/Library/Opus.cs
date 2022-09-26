using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // Mű osztály
    public abstract class Opus
    {
        [Description("Szerző")]
        public string Author { get; set; } // Szerző
        [Description("Cím")]
        public string Title { get; set; } // Cím
        [Description("Kiadás")]
        public int Expenditure { get; set; } // Kiadás
        [Description("Oldalszám")]
        public int Pages { get; set; } // Oldalak száma
    }
}
