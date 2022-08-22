using Examination.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core

{
    public enum Role
    {
        Reader = 0,
        Admin = 1,
        
    }
    public class Student:Base
    {

       // public int Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }

        public string Password { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public DateTime? StartDate { get; set; }
       public int Time { get; set; }
        public int Result { get; set; }
       // public DateTime StartDate { get; internal set; }
        //public DateTime? LastModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
        //public DateTime ?CreatedDate { get;  set; }
    }
}