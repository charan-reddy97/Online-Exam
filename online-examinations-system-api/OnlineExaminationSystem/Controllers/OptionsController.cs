using Examination.Core.Entities;
using Examination.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        IQuestionRepository question;

        public OptionsController(IQuestionRepository question)
        {
            this.question = question;
        }
       [HttpPost]
        public IActionResult Post(List<OptionsModel> options)
        {

            var questionId = options.First().QuestionId;
            Question q = question.FindQuestionByQNo(questionId);
          

            q.Options.Clear();

            foreach (var op in options)
                q.Options.Add(new Option { Title = op.Title, IsCorrectAns = op.IsCorrectAns });

            question.Update(q)
;

            //return Ok();
            // return Created($"/api/options/{options.QuestionId}", options);
            return Created($"/api/options/", options);
        }
    }
}
