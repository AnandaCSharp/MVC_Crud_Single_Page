using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaCrudNew24.Models;

namespace SpaCrudNew24.ViewModels
{
	public class StudentViewModel
	{
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string MobileNo { get; set; }
        public decimal RegFee { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsEnrolled { get; set; }
        public string ImageUrl { get; set; }
        public int CourseId { get; set; }
        public int CourseModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
        public HttpPostedFileBase ProfileFile { get; set; }
        public string CourseName { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
    }
}