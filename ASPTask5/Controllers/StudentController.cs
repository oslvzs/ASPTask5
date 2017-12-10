using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPTask5.Models;
using ASPTask5.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ASPTask5.Controllers
{
    public class StudentController : Controller
    {
        public readonly IService _service;

        public StudentController(IService service)
        {
            _service = service;
        }


        // GET: Student
        //Сервис через Inject во View
        public IActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        // Получение сервиса через параметры конструктора
        public ActionResult Details(int id)
        {
            return View(_service.GetStudent(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        //Получение сервиса через HTTPContext
        [HttpPost]
        public ActionResult Create([FromForm] StudentModel student)
        {
            var http_service =
                HttpContext.RequestServices.GetService<Service>();
            TryValidateModel(student);
            if (ModelState.IsValid)
            {
                http_service.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(student);
            }
        }

        // GET: Student/Edit/5
        // Получение сервиса через параметры метода
        public ActionResult Edit(int id, [FromServices] IService service)
        {
            return View(service.GetStudent(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [FromForm] StudentModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                _service.SetStudent(id, model);
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
            return View(_service.GetStudent(id));
        }

        // POST: Student/Delete/5
        // Через ActivatorUtilities
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var instance = ActivatorUtilities.CreateInstance(HttpContext.RequestServices, typeof(DeleteClass), id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public class DeleteClass
        {
            public DeleteClass(IService service, int id)
            {
                service.DeleteStudent(id);
            }
        }
    }
}