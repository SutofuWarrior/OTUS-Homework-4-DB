using System.Collections.Generic;
using DataAccess.Abstractions;

namespace DataAccess.Entities
{
    public class Student : IDbEntity<int>
    {
        public int Id { get; set; }

        public string Fio { get; set; }

        public virtual List<StudentCourses> Courses { get; set; }

    }
}
