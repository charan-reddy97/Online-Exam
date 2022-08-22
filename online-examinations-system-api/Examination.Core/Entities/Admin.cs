using Examination.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinations.Core.Entities
{
    public enum Role
    {
        Reader = 0,
        Admin = 1,
        SystemAdmin = 1
    }

    public class Admin : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }


        public string Password { get; set; }

        public Role Role { get; set; }
        public DateTime CreatedAt { get; internal set; }
    }

}
