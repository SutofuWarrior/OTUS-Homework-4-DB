using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class StudentCoursesRepository : Repository<StudentCourses, int>
    {
        public StudentCoursesRepository(DbContext context) : base(context) { }
    }
}
