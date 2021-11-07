using System.Collections.Generic;
using DataAccess.Abstractions;

namespace DataAccess.Entities
{
    public class Course : IDbEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual List<Lesson> Lessons { get; set; }

        public virtual List<StudentCourses> Students { get; set; }
    }
}
