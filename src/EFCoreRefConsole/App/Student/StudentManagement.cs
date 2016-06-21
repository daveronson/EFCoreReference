using EFCoreRef.DAL;
using EFCoreRef.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreRef.App.StudentManagement
{
    public class StudentManagement
    {
        public static List<Student> List()
        {
            
            using (var context = new EFCoreRefContext())
            {
                var students = context.Student
                    .ToList();
                return students;
            }
        }

        public static Student GetStudentByID(int studentID)
        {
            using (var context = new EFCoreRefContext())
            {
                var student = context.Student
                    .Include(s => s.StudentCourses).ThenInclude(c => c.Course)
                    .Where(s => s.ID == studentID)
                    .FirstOrDefault();

                return student;             
            }
        }

        public static List<Course> ListCourses(int studentID)
        {
            using (var context = new EFCoreRefContext())
            {
                //Get courses where the studentID is in the StudentCourses join table
                var StudentCourses = context.Course
                        .Where(s => s.StudentCourses.Any(sc => sc.Student.ID == studentID))
                        .ToList();
                return StudentCourses;
            }
        }

        public static void DeleteAll()
        {
            using (var context = new EFCoreRefContext())
            {
                context.Student.Clear();
                context.SaveChanges();
            }
        }

        public static void AddStudent(Student student)
        {
            using (var context = new EFCoreRefContext())
            {
                if (student != null)
                {
                    context.Student.Add(student);
                    context.SaveChanges();
                }
            }
        }
    }
}
