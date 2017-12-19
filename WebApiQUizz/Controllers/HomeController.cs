using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiQUizz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            //using (var context = new QuizzContext())
            //{
            //    //    var profiles = new List<Profile>
            //    //{
            //    //    new Profile { Libelle="Administrateur" },
            //    //      new Profile { Libelle="SUperAdmin" },
            //    //        new Profile { Libelle="Utilisateur" },
            //    //};


            //    //    profiles.ForEach(p => context.Profiles.Add(p));
            //    //    context.SaveChanges();

            //    var liste = context.Profiles.ToList();
            //      var nbre = liste.Count;
            //}



            return View();
        }
    }
}
