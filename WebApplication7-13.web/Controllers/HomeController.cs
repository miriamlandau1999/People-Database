using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7_13.web.Models;
using WebApplication7_13.data;

namespace WebApplication7_13.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();
            PeopleRepository repository = new PeopleRepository(Properties.Settings.Default.ConStr);
            ivm.People = repository.GetPeople();
            return View(ivm);
        }

        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            PeopleRepository repository = new PeopleRepository(Properties.Settings.Default.ConStr);
            repository.Add(person);
            return Redirect("/home/index");
        }
        public ActionResult EditPerson(int Id)
        {
            PeopleRepository repository = new PeopleRepository(Properties.Settings.Default.ConStr);
            Person person = repository.GetPerson(Id);
            return View(new EditViewModel { Person= person});
        }
        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            PeopleRepository repository = new PeopleRepository(Properties.Settings.Default.ConStr);
            repository.EditPerson(person);
            return Redirect("/home/index");
        }
        public ActionResult DeletePerson(int Id)
        {
            PeopleRepository repository = new PeopleRepository(Properties.Settings.Default.ConStr);
            repository.DeletePerson(Id);
            return Redirect("/home/index");
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
    }
}