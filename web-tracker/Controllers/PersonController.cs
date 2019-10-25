using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_tracker.Models;

namespace web_tracker.Controllers
{
    public class PersonController : Controller
    {
        private webtrackerContext context = new webtrackerContext();

        //
        // GET: /Person/

        public string Index(string Ime)
        {
            Person person = context.Person.Single(x => x.Ime == Ime);
            return "Person:" + person.Ime + "|"
                + person.Longitude + "|"
                + person.Latitude;
        }

        //
        // GET: /Person/Details/5

        public ViewResult Details(int id)
        {
            Person person = context.Person.Single(x => x.PersonId == id);
            return View(person);
        }

        //
        // GET: /Person/Create

        public string Create(string Ime, string Long, string Lat)
        {
            Person person = new Person(Ime, double.Parse(Long), double.Parse(Lat));
            try
            {
                Person personRemove = context.Person.Single(x => x.Ime == Ime);
                context.Person.Remove(personRemove);
                context.SaveChanges();
            }
            catch { }

            context.Person.Add(person);
            context.SaveChanges();
            return Ime;
        }

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                context.Person.Add(person);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(int id)
        {
            Person person = context.Person.Single(x => x.PersonId == id);
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(int id)
        {
            Person person = context.Person.Single(x => x.PersonId == id);
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = context.Person.Single(x => x.PersonId == id);
            context.Person.Remove(person);
            context.SaveChanges();
            // redirect to index!
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}