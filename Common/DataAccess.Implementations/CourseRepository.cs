using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class CourseRepository : Repository<Course, int>
    {
        public CourseRepository(DbContext context) : base(context) { }
    }
}
