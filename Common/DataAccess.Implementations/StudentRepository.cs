using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class StudentRepository : Repository<Student, int>
    {
        public StudentRepository(DbContext context) : base(context) { }
    }
}
