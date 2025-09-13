using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaCrudNew24.Models
{
	public class Student
	{
        public Student()
        {
            this.CourseModules = new HashSet<CourseModule>();
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string MobileNo { get; set; }
        public decimal RegFee { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsEnrolled { get; set; }
        public string ImageUrl { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<CourseModule> CourseModules { get; set; }

    }
}