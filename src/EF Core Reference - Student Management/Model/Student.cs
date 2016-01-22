using System.Collections.Generic;

namespace EFCoreRef.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
