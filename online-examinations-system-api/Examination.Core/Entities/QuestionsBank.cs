using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Entities
{
  public  class QuestionsBank:Base
    {
        public int QNum { get; set; }
        public string QTitle { get; set; }

        public int TotalQuestions { get; set; }
        public List<Question> Questions1 { get => Questions; set => Questions = value; }

        //public List<Question> Questions { get => Questions; set => Questions = value; }
        List<Question> Questions = new List<Question>();
    }









    
}
