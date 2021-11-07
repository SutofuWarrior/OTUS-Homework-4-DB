using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class LessonRepository : Repository<Lesson, int>
    {
        public LessonRepository(DbContext context) : base(context) { }
    }
}
