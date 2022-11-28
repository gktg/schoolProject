using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schoolProject.Application.Repositories;
using schoolProject.Domain.Entities;
using schoolProject.Persistence.Contexts;

namespace schoolProject.Persistence.Repositories
{
    public class StudentWriteRepository : WriteRepository<Student>, IStudentWriteRepository
    {
        public StudentWriteRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
