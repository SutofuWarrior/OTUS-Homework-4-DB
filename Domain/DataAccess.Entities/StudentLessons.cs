using DataAccess.Abstractions;

namespace DataAccess.Entities
{
    public class StudentLessons : IDbEntity<int>
    {
        public int Id { get; set; }

        public int StudentCourseId { get; set; }

        public int LessonId { get; set; }

        public short HomeworkGrade { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual StudentCourses StudentCourse { get; set; }
    }
}
