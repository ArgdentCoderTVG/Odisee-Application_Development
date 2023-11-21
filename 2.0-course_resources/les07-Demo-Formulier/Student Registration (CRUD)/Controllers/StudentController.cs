using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Registration.Models;

namespace Student_Registration.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Student> students = StudentRepository.GetAll();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            Student student = StudentRepository.GetById(id);
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            Student student = StudentRepository.GetById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Update(student);
                return RedirectToAction("Details", new { id = student.ID });
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            Student toDelete = StudentRepository.GetById(id);
            return View(toDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection notUsed) /* extra parameter nodig voor overload */
        {
            Student toDelete = StudentRepository.GetById(id);
            StudentRepository.Delete(toDelete);

            return RedirectToAction("Index");
        }

    }
}
