namespace SpaCrudNew24.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SpaCrudNew24.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaCrudNew24.DAL.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpaCrudNew24.DAL.AppDbContext context)
        {
            var courseList = new List<Course>()
            {
                new Course(){CourseName="C#"},
                new Course(){CourseName="J2EE"},
                new Course(){CourseName="WADA"},
                new Course(){CourseName="ORACLE"},
            };
            courseList.ForEach(e => context.Courses.AddOrUpdate(c => c.CourseName, e));
            context.SaveChanges();
        }
    }
}
