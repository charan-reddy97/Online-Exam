using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Entities
{
  public  class Option:Base
    {
       public  string Title { get; set; }
        public bool? IsCorrectAns { get; set; }
    }
}
