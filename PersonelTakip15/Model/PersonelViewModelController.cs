using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personel.Model
{
    public class PersonelViewModel
    {

        public int PersonellId { get; set; }
        public int İzinGunu { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Departman { get; set; }
        public string DepartmanAd { get; set; }
        public bool IsSilinecek { get; set; }

    }

}


