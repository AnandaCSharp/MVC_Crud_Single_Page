using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaCrudNew24.DAL;
using SpaCrudNew24.Models;
using System.Data.Entity;
using SpaCrudNew24.ViewModels;
using System.IO;

namespace SpaCrudNew24.Controllers
{
    public class StudentsController : Controller
    {
        AppDbContext db = new AppDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Student> students = db.Students.Include(s => s.Course).Include(s => s.CourseModules).ToList();
            return View(students);
        }
        [HttpPost]
        
        public JsonResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
            {
                var courseModule = db.CourseModules.Where(e => e.StudentId == id).ToList();
                db.CourseModules.RemoveRange(courseModule);
                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, redirectUrl = Url.Action("Index") });
            }
            return Json(new { success = false, Message = "Student Not Found" });
        }
        [HttpGet]
        public ActionResult CreatePartial() 
        {
            StudentViewModel student = new StudentViewModel();
            student.Courses = db.Courses.ToList();
            student.CourseModules.Add(new CourseModule() { CourseModuleId = 1 });
            return PartialView("_CreatePartial",student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateStudent(StudentViewModel vObj) 
        {
            if (!ModelState.IsValid) 
            {
                vObj.Courses = db.Courses.ToList();
            }
            Student obj = new Student();
            obj.StudentName = vObj.StudentName;
            obj.MobileNo = vObj.MobileNo;
            obj.RegFee = vObj.RegFee;
            obj.AdmissionDate = vObj.AdmissionDate;
            obj.IsEnrolled = vObj.IsEnrolled;
            obj.CourseId = vObj.CourseId;
            obj.CourseModules = vObj.CourseModules;
            if (vObj.ProfileFile != null) 
            {
                string uniqueFileName = GetFileName(vObj.ProfileFile);
                obj.ImageUrl = uniqueFileName;
            }
            else 
            {
                obj.ImageUrl = "noimage.png";
            }
            db.Students.Add(obj);
            try
            {
                db.SaveChanges();
                return Json(new { success = true , redirectUrl=Url.Action("Index")});
            }
            catch (Exception ex)
            {

                vObj.Courses = db.Courses.ToList();
                return Json(new { success = false});
            }
        }

        private string GetFileName(HttpPostedFileBase file)
        {
            string fileName = "";
            if (file != null) 
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/"), fileName);
                file.SaveAs(path);
            }
            return fileName;
        }
    }
}