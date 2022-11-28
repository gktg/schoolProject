﻿using schoolProject.Domain.Entities.Common;
using schoolProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string TeacherId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
