using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarışDemiray.Controllers
{
    public class CalisanlarController : Controller
    {
        public IList<int> departmanlariAl()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var departmanListe = session.CreateSQLQuery("SELECT Departman_ID FROM Departmanlar").List<int>();
                session.Flush();
                return departmanListe;
            }
        }

        [Obsolete]
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var calisanlar = session.Query<Models.Calisanlar>().ToList();
                return View(calisanlar);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var calisan = session.Query<Models.Calisanlar>().FirstOrDefault(x => x.Personel_ID == id);
                session.Delete(calisan);
                session.Flush();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var calisan = session.Query<Models.Calisanlar>().FirstOrDefault(x => x.Personel_ID == id);
                return View(calisan);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Models.Calisanlar calisan)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yeniCalisan = session.Query<Models.Calisanlar>().FirstOrDefault(x => x.Personel_ID == id);
                yeniCalisan.Ad_Soyad = calisan.Ad_Soyad;
                yeniCalisan.TC_Kimlik = calisan.TC_Kimlik;
                yeniCalisan.Unvan = calisan.Unvan;
                session.SaveOrUpdate(yeniCalisan);
                session.Flush();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Calisanlar calisan)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(calisan);
                session.Flush();
            }
            return RedirectToAction("Index");
        }

    }
}