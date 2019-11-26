using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PersonelTakip15.Enum
{
    public enum DepartmanEnum
    {
        [Description("Yazılım")]       
        Yazılım =1,
        [Description("Donanım")]
        Donanım =2,
        [Description("Muhasebe")]
        Muhasebe =3,
        [Description("İnsan Kaynakları")]
        İnsanKaynakları =4,


    }
}