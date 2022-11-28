using schoolProject.Application.Repositories;
using schoolProject.Persistence.Contexts;
using schoolProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject.Persistence.Repositories
{
    public class StudentReadRepository : ReadRepository<Student>, IStudentReadRepository
    {
        public StudentReadRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
