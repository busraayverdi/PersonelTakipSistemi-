using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personel.Model
{
    public class ListViewModel : Controller
    {
        public string KullaniciAd { get; internal set; }

        // GET: ListViewModel
        public ActionResult Index()
        {
            return View();
        }
    }
}

