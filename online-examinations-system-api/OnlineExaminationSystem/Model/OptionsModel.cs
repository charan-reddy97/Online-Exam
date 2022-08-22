using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamination.Model
{
    public class OptionsModel
    {
        public  int QuestionId { get; set; }
        public string Title { get; set; }
        public bool IsCorrectAns { get; set; }
    }
}
