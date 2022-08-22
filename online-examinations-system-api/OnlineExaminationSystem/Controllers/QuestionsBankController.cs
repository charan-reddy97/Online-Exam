using Examination.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examination.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsBankController : ControllerBase
    {
        private readonly IQuestionsBankRepository QuestionsBankRepository;


        public QuestionsBankController(IQuestionsBankRepository questionsBankRepository)
        {

            this.QuestionsBankRepository = questionsBankRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var questionsBank = QuestionsBankRepository.GetQuestionBank();
            return Ok(questionsBank);
        }

        [HttpGet("byid/{id}")]
        public IActionResult GetById(int id)
        {
            //if (id > 0)
            //{
            var questionsBank = QuestionsBankRepository.FindById(id);

            if (questionsBank != null)
                return Ok(questionsBank);
            else
                return NotFound($"questionsBank with the qnum:{id} cannot be found");

            //}
            //else
            //    return BadRequest($"Invalid QuestionsBank QNum");
        }


        [HttpGet("byqnum/{qnum}")]
        public IActionResult Get(int qnum)
        {
            //if (id > 0)
            //{
            var questionsBank = QuestionsBankRepository.FindQuestionsByQNum(qnum);

            if (questionsBank != null)
                return Ok(questionsBank);
            else
                return NotFound($"questionsBank with the qnum:{qnum} cannot be found");

            //}
            //else
            //    return BadRequest($"Invalid QuestionsBank QNum");
        }

        [HttpGet("byqtitle/{title}")]
        public IActionResult Get(string qtitle)
        {
            if (!string.IsNullOrEmpty(qtitle))
            {
                var questionsBanksByQTitle = QuestionsBankRepository.FindByQuestionsTitle(qtitle);

                if (questionsBanksByQTitle.QNum > 0)
                    return Ok(questionsBanksByQTitle);
                else
                    return NotFound($"No questionsBank found for the QTitle : {qtitle}");
            }
            else
                return BadRequest($"Invalid QuestionsBank QTitle");

        }


        [HttpPost]
        public IActionResult Post(QuestionsBank questionsBank)
        {
            QuestionsBankRepository.Add(questionsBank);


            return Created($"/api/qustionsBanks/{questionsBank.QNum}", questionsBank);
        }


        [HttpPut]
        public IActionResult Put(QuestionsBank questionsBank)
        {
            if (questionsBank.Id > 0)
            {
                QuestionsBankRepository.Update(questionsBank);
                return Ok();
            }
            else
                return BadRequest($"Invalid questionsBank Id");
        }


        [HttpDelete("{qnum}")]
        public IActionResult Delete(int qnum)
        {
            if (qnum > 0)
            {
                QuestionsBankRepository.Delete(qnum);
                return Ok();
            }
            else
                return BadRequest($"Invalid questionsBank qnum");
        }
    }
}