using Personel.Model;
using Personel.Repository;
using PersonelTakip1.Model;
using PersonelTakip1.Repository;
using PersonelTakip15.Enum;
using PersonelTakip15.EnumerationHelper;
using PersonelTakip15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PersonelTakip1.Controllers
{
    public class HomeController : Controller
    {
        public string urlID;
        public string[] IndexID;
        public ActionResult Index()
        {
          return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            KullaniciRepository kullaniciRepository = new KullaniciRepository();
            var kullanici = kullaniciRepository.FirstOrDefault(x => x.KullaniciAdi == model.UserName && x.Sifre == model.Sifre);
            if (kullanici != null)
            {
                //TempData["Y"] = "Uygun ";
                return RedirectToAction("List", "Home");

            }
            else
            {
                //ViewBag.Message="sdfg";
                TempData["alertMessage"] = "Uygundeğil ";
                //ModelState.AddModelError("", "Kullanıcı bilgileri hatalı!");
                return RedirectToAction("Index", "Home");

            }

        }

        [HttpPost]
        public ActionResult LogOut()
        {

            return RedirectToAction("Login", "Home");

        }
        [HttpGet]
        public ActionResult List(List<PersonelViewModel> list)
        {

            PersonelRepository repository = new PersonelRepository();
            List<PersonelViewModel> _list = new List<PersonelViewModel>();
            list = _list.ToList();

            IQueryable<Personell> personel = repository.GetAll();
            foreach (var item in personel)
            {
                DepartmanEnum departmanEnum = (DepartmanEnum)item.Departman;
                PersonelViewModel model = new PersonelViewModel()
                {
                    PersonellId = item.PersonellId,
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    İzinGunu = item.İzinGunu.Value,
                    Departman = item.Departman.Value,
                    DepartmanAd = EnumerationHelper.GetDescription<DepartmanEnum>(departmanEnum)

                }; list.Add(model);

            }
            return View(list);
        }
        public ActionResult CreateList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Kaydet(PersonelViewModel model)
        {
            model.Departman = 1;
            Personell personel = new Personell();
            PersonelRepository personelRepository = new PersonelRepository();
           
            personel.Ad = model.Ad;
            personel.Soyad = model.Soyad;
            personel.Departman = model.Departman;
            personel.İzinGunu = model.İzinGunu;
            personelRepository.Add(personel);
            personelRepository.Save();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            PersonelRepository personelRepository = new PersonelRepository();
            PersonelViewModel model = new PersonelViewModel();
            Personell personel = personelRepository.FirstOrDefault(x => x.PersonellId == id);

            personelRepository.Delete(personel);

            personelRepository.Save();

            return RedirectToAction("List", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonelRepository personelRepository = new PersonelRepository();
            PersonelViewModel model = new PersonelViewModel();
            Personell personel = personelRepository.FirstOrDefault(x => x.PersonellId == id);
            model.Ad = personel.Ad;
            model.Soyad = personel.Soyad;
            model.Departman = personel.Departman.Value;
            model.İzinGunu = personel.İzinGunu.Value;
            model.PersonellId = id;

            return View(model);
        }
        [HttpGet]
        public ActionResult DetayList(int id)
        {
            PersonelRepository personelRepository = new PersonelRepository();
            PersonelViewModel model = new PersonelViewModel();
            Personell personel = personelRepository.FirstOrDefault(x => x.PersonellId == id);
            DepartmanEnum departmanEnum = (DepartmanEnum)personel.Departman;
            model.DepartmanAd = EnumerationHelper.GetDescription<DepartmanEnum>(departmanEnum);

            model.Ad = personel.Ad;
            model.Soyad = personel.Soyad;
            model.Departman = personel.Departman.Value;
            model.İzinGunu = personel.İzinGunu.Value;
            model.PersonellId = id;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(PersonelViewModel model, int id)
        {
            PersonelRepository personelRepository = new PersonelRepository();
            Personell personel = personelRepository.FirstOrDefault(x => x.PersonellId == id);
            personel.Ad = model.Ad;
            personel.Soyad = personel.Soyad;
            personel.Departman = personel.Departman;
            personel.İzinGunu = personel.İzinGunu;
            personelRepository.Edit(personel);
            personelRepository.Save();
            return RedirectToAction("List", "Home", model);

        }
        private ActionResult View(Func<LoginViewModel, ActionResult> createList)
        {
            throw new NotImplementedException();
        }

        private void ValueDictionary()
        {
            throw new NotImplementedException();
        }

    }
}