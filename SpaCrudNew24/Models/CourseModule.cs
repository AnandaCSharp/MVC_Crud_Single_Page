using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaCrudNew24.Models
{
	public class CourseModule
	{
        public int CourseModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}