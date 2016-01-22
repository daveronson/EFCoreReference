using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRef.DAL;
using EFCoreRef.Model;
using EFCoreRef.App.Helper;
using Microsoft.Data.Entity;


namespace EFCoreRef.App.CourseManagement
{
    public class CourseManagement
    {
        public static List<Course> List()
        {
            using (var context = new EFCoreRefContext())
            {
                var courses = context.Course
                    .ToList();
                return courses;
            }
        }

        public static Course GetCourseByID(int courseID)
        {
            using (var context = new EFCoreRefContext())
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
            using (var context = new EFCoreRefContext())
            {
                context.Course.Clear();
                context.SaveChanges();
            }
        }

        public static void AddCourse(Course course)
        {
            using (var context = new EFCoreRefContext())
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
