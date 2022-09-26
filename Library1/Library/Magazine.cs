using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Magazine : Journal
    {
        [Description("Online elérhető")]
        public bool AvailableOnline { get; set; }
        [Description("Online URL")]
        public string? OnlineURL { get; set; }
        [Description("Kiadó")]
        public string? PressOffice { get; set; }
    }
}
