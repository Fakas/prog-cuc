﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum ECategory
    {
        [Description("Szuper hősös")]
        Superhero,
        [Description("Vígjáték")]
        Comedy,
        [Description("Egyéb")]
        Other
    }
}
