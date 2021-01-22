using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarışDemiray.Controllers
{
    public class DepartmanlarController : Controller
    {
        [Obsolete]
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var departmanlar = session.Query<Models.Departmanlar>().Fetch(x => x.Calisanlar).ToList();
                return View(departmanlar);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var departman = session.Query<Models.Departmanlar>().FirstOrDefault(x => x.Departman_ID == id);
                session.Delete(departman);
                session.Flush();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Departmanlar departman)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(departman);
                session.Flush();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var departman = session.Query<Models.Departmanlar>().FirstOrDefault(x => x.Departman_ID == id);
                return View(departman);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Models.Departmanlar departman)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yeniDepartman = session.Query<Models.Departmanlar>().FirstOrDefault(x => x.Departman_ID == id);
                yeniDepartman.Departman_Ad = departman.Departman_Ad;
                yeniDepartman.Telefon = departman.Telefon;
                session.SaveOrUpdate(yeniDepartman);
                session.Flush();
            }
            return RedirectToAction("Index");
        }
    }
}