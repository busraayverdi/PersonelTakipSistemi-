using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelTakip1.Model//Bu sayfa bizim model ve view'imizin ortak sayfasıdır.
{
    public class LoginViewModel
    {
        public int KullaniciId { get; set; }
        public string Sifre { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
    }
}