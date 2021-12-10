using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationadmin2.Models;

namespace WebApplicationadmin2.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.ServiceClient obj = new ServiceReference1.ServiceClient();
       
        public ActionResult Index()
        {
            List<Eleve> eleves = new List<Eleve>();
            var list = obj.GetEleves();
                foreach (var item in list)
                {
                    Eleve e = new Eleve();
                    e.ID_Eleve = item.ID_Eleve;
                    e.CNE = item.CNE;
                    e.Prenom = item.Prenom;
                    e.Nom = item.Nom;
                    e.Email = item.Email;
                    //string result = System.Text.Encoding.UTF8.GetString(e.Photo);
                    e.Photo = item.Photo;
                    e.Tel = item.Tel;
                    eleves.Add(e);
                }
                return View(eleves);
            }

        public ActionResult IndexSearch(string searchTerm)
        {
            var list = obj.GetStudentByCNE(searchTerm);
            Eleve e = new Eleve();
            e.ID_Eleve = list.ID_Eleve;
            e.CNE = list.CNE;
            e.Prenom = list.Prenom;
            e.Nom = list.Nom;
            e.Email = list.Email;
            e.Photo = list.Photo;
            e.Tel = list.Tel;
            return View(e);
        }
        public ActionResult Details(int id)
        {
            var list = obj.GetStudentById(id);
            Eleve e = new Eleve();
            e.ID_Eleve = list.ID_Eleve;
            e.CNE = list.CNE;
            e.Prenom = list.Prenom;
            e.Nom = list.Nom;
            e.Email = list.Email;
            e.Photo = list.Photo;
            e.Tel = list.Tel;
            return View(e);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Eleve e)
        {
            Eleve E = new Eleve();
            E.ID_Eleve = e.ID_Eleve;
            E.CNE = e.CNE;
            E.Prenom = e.Prenom;
            E.Nom = e.Nom;
            E.Email = e.Email;
            E.Photo = e.Photo;
            E.Tel = e.Tel;
            obj.AddStudent(E.ID_Eleve, E.CNE, E.Prenom, E.Nom, E.Email, E.Photo, E.Tel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteStudent(int id)
        {
            int res = obj.DeleteById(id);
            if (res > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Update(int id)
        {
            var list = obj.GetStudentById(id);
            Eleve e = new Eleve();
            e.ID_Eleve = list.ID_Eleve;
            e.CNE = list.CNE;
            e.Prenom = list.Prenom;
            e.Nom = list.Nom;
            e.Email = list.Email;
            e.Photo = list.Photo;
            e.Tel = list.Tel;
            return View(e);
        }
        [HttpPost]
        public ActionResult Update(Eleve e)
        {
            Eleve E = new Eleve();
            E.ID_Eleve = e.ID_Eleve;
            E.CNE = e.CNE;
            E.Prenom = e.Prenom;
            E.Nom = e.Nom;
            E.Email = e.Email;
            E.Photo = e.Photo;
            E.Tel = e.Tel;
            obj.UpdateStudent(E.ID_Eleve, E.CNE, E.Prenom, E.Nom, E.Email, E.Photo, E.Tel);
            int res = obj.UpdateStudent(E.ID_Eleve, E.CNE, E.Prenom, E.Nom, E.Email, E.Photo, E.Tel);
            if (res > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}