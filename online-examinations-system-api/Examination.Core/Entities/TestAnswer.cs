using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Entities
{
 public   class TestAnswer:Base
    {
       
        public Question Question { get; set; }
         public Student Student { get; set; }
         public Option Options { get; set; }
    }
}
