using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.DAL;
using EFTesting.Model;
using EFTesting.App.Helper;
using Microsoft.Data.Entity;


namespace EFTesting.App.CourseManagement
{
    public class CourseManagement
    {
        public static List<Course> List()
        {
            using (var context = new EFTestingContext())
            {
                var courses = context.Course
                    .ToList();
                return courses;
            }
        }

        public static Course GetCourseByID(int courseID)
        {
            using (var context = new EFTestingContext())
            {
                var course = context.Course
                    .Include(c => c.StudentCourses).ThenInclude(s => s.Student)
                    .Where(c => c.ID == courseID)
                    .FirstOrDefault();

                return course;
            }
        }

        public static void DeleteAll()
        {
            using (var context = new EFTestingContext())
            {
                context.Course.Clear();
                context.SaveChanges();
            }
        }

        public static void AddCourse(Course course)
        {
            using (var context = new EFTestingContext())
            {
                if (course != null)
                {
                    context.Course.Add(course);
                    context.SaveChanges();
                }
            }
        }               
    }
}
