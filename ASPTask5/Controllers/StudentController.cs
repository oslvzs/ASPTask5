using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPTask5.Models;

namespace ASPTask5.Controllers
{
    public class StudentController : Controller
    {
        static List<Models.StudentModel> listOfStudents = new List<Models.StudentModel>();
        // GET: Student
        public ActionResult Index()
        {
            return View(listOfStudents);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(listOfStudents[id]);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create([FromForm] StudentModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                listOfStudents.Add(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(listOfStudents[id]);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [FromForm] StudentModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                listOfStudents[id] = model;
                return RedirectToAction("Details", id);
            }
            else
            {
                return View(model);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(listOfStudents[id]);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                listOfStudents.Remove(listOfStudents[id]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}