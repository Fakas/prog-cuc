using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum EGenre
    {
        [Description("Dráma")]
        Drama = 1,
        [Description("Akció")]
        Action,
        [Description("Kaland")]
        Adventure,
        [Description("Romantikus")]
        Romantic,
        [Description("Természet")]
        Nature,
        [Description("Dokumentum")]
        Document,
        [Description("Sci-fi")]
        SciFi,
        [Description("Fantázia")]
        Fantasy,
        [Description("Családi")]
        Family,
        Thriller,
        Horror
    }
}
