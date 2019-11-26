using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelTakip15.Enum
{
    public enum SilinecekEnum
    {
        [Description("Evet")]
        Evet = 1,
        [Description("Çıkış")]
        Cikis= 0,
        

    }
}