using System.Collections.Generic;
using DataAccess.Abstractions;

namespace DataAccess.Entities
{
    public class StudentCourses : IDbEntity<int>
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }

        public virtual List<StudentLessons> StudentLesson { get; set; }
    }
}
