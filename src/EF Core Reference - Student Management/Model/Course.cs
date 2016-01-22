using System.Collections.Generic;

namespace EFCoreRef.Model
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
