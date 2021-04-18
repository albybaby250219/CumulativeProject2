using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativeProject2.Models;
using System.Diagnostics;

namespace CumulativeProject2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        /// <summary>
        /// To contect the teacher datacontroller list method  with the  list view
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <returns></returns>
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        /// <summary>
        /// Connects the teacher datacontroller find teacher function to the show.html in the view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }
        /// <summary>
        /// To the users if they want to confirm the delete of a particular teacher so the delete was not a mistake
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        /// <summary>
        /// To delete the teacher from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //POST : /Author/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }
        /// <summary>
        /// To connect the new view
        /// </summary>
        /// <returns></returns>
        //GET : /Author/New
        public ActionResult New()
        {
            return View();
        }
        //GET : /Teacher/Ajax_New
        public ActionResult Ajax_New()
        {
            return View();

        }

        //GET : /Author/Create
        [HttpGet]
        public ActionResult Create(string TeacherFname, string TeacherLname, string TeacherEmployeeNum, decimal TeacherSalary)
        {
            //To check whether we get the data from the form

            Debug.WriteLine("I have accessed the data:");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(TeacherEmployeeNum);
            Debug.WriteLine(TeacherSalary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.TeacherEmployeeNum = TeacherEmployeeNum;
            NewTeacher.TeacherSalary = TeacherSalary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
    }
}