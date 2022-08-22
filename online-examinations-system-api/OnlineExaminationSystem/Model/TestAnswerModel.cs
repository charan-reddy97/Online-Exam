using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamination.Model
{
    public class TestAnswerModel
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public int OptionsId { get; set; }
    }
}

