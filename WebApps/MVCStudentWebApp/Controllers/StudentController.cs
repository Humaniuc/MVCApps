using MVCStudentWebApp.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStudentWebApp.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> students = new List<Student>
            {
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
            };
        // GET: Student
        public ActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            if(!ModelState.IsValid)
            {
                return View("Edit", std);
            }
            else
            {
                var editedStudent = students.Find(s => s.StudentId == std.StudentId);
                editedStudent.StudentName = std.StudentName;
                editedStudent.Age = std.Age;
                editedStudent.isNewlyEnrolled = std.isNewlyEnrolled;
                editedStudent.Password = std.Password;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            students.Remove(students.Find(s => s.StudentId == id));
            return RedirectToAction("Index");
        }
    }
}