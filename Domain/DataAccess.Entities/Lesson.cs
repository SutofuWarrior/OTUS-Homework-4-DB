using System.Collections.Generic;
using DataAccess.Abstractions;

namespace DataAccess.Entities
{
    public class Lesson : IDbEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual List<StudentLessons> StudentLessons { get; set; }
    }
}
