using schoolProject.Application.Repositories;
using schoolProject.Domain.Entities;
using schoolProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject.Persistence.Repositories
{
    public class TeacherReadRepository : ReadRepository<Teacher>, ITeacherReadRepository
    {
        public TeacherReadRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
