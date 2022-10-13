using StudentsDetails.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsDetails.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentDetailsEntities Std = new StudentDetailsEntities();
        public ActionResult Student(tblStudentInfo obj)
        {
            if (obj != null)
                return View(obj);
            else
                return View();
        }
        [HttpPost]
        public ActionResult AddStudent(tblStudentInfo model)
        {
            if (ModelState.IsValid)
            {
                tblStudentInfo obj = new tblStudentInfo();
                obj.StudentId = model.StudentId;
                obj.StudentName = model.StudentName;
                obj.StudentMobile = model.StudentMobile;
                obj.StudentDept = model.StudentDept;
                obj.StudentAddress = model.StudentAddress;

                if(model.StudentId==0)
                {

                    Std.tblStudentInfoes.Add(obj);
                    Std.SaveChanges();
                }
                else
                {
                    Std.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    Std.SaveChanges();
                }

            }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = Std.tblStudentInfoes.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = Std.tblStudentInfoes.Where(x => x.StudentId == id).First();
            Std.tblStudentInfoes.Remove(res);
            Std.SaveChanges();

            var list = Std.tblStudentInfoes.ToList();


            return View("StudentList", list);
        }
    }
}