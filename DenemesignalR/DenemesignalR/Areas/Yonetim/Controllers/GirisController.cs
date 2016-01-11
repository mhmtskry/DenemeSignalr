using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemesignalR.Areas.Yonetim.Controllers
{
    public class GirisController : Controller
    {
        // GET: Yonetim/Giris
        public SignalRDenemeEntities db = new SignalRDenemeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Kad, string Sifre)
        {
            bool varmi = false;
            if (!string.IsNullOrEmpty(Kad) && !string.IsNullOrEmpty(Sifre))
            {

                if (db.tbl_Users.FirstOrDefault(x => x.Email == Kad.TrimEnd() && x.Sifre == Sifre.TrimEnd()) != null) varmi = true;


                if (varmi)
                {

                    var user = db.tbl_Users.FirstOrDefault(x => x.Email == Kad.TrimEnd() && x.Sifre == Sifre.TrimEnd());
                    Session["Yid"] = user.id;
                    Session["Yad"] = user.AdSoyad;


                }
                return RedirectToAction("Index", "Hata");
            }

            return RedirectToAction("Index", "Giris");



        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
