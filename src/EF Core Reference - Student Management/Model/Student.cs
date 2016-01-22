using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTesting.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
