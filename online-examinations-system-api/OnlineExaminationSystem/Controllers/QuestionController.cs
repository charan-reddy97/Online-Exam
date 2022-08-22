using Examination.Core.Entities;
using Examination.Core.Repository;
using Examinations.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository QuestionRepository;


        public QuestionController(IQuestionRepository questionRepository)
        {

            this.QuestionRepository = questionRepository;
        }


        [HttpGet("byqno/{questionqno}")]
        public IActionResult Get(int questionqno)
        {
            if (questionqno > 0)
            {
                var question = QuestionRepository.FindQuestionByQNo(questionqno);

                if (question != null)
                    return Ok(question);
                else
                    return NotFound($"question with the Qno:{questionqno} cannot be found");
            }
            else
                return BadRequest($"Invalid Admin Qno");
        }


        [HttpPost]
        public IActionResult Post(Question question)
        {
            QuestionRepository.Add(question);
            return Created($"/api/question{question.QNo}", question);
        }


        [HttpPut]
        public IActionResult Put(Question question)
        {
            if (question.QNo > 0)
            {
                QuestionRepository.Update(question);
                return Ok();
            }
            else
                return BadRequest($"Invalid question Qno");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var question = QuestionRepository.GetQuestion();
            return Ok(question);
        }
    }
}

    

