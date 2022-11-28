using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schoolProject.Domain.Entities.Common;
using schoolProject.Domain.Enums;

namespace schoolProject.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }


    }
}
