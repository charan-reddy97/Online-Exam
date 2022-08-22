using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Entities
{
 public   class Question:Base
    {
        public int QNo { get; set; }
        public string Questions { get; set; }
        public List<Option> Options { get => options; set => options = value; }

        List<Option> options = new List<Option>();
    }
}
