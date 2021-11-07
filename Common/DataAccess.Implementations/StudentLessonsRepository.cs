using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class StudentLessonsRepository : Repository<StudentLessons, int>
    {
        public StudentLessonsRepository(DbContext context) : base(context) { }
    }
}
