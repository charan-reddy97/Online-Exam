using Examination.Core;
using Examination.Core.Entities;
using Examination.Core.Repository;
using Examinations.Core.Repository;
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
    public class TestAnswerController : ControllerBase
    {
        private readonly ITestAnswerRepository testAnswerRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IStudentRepository studentRepository;
        //IOptionsRepository OptionsRepository;

        public TestAnswerController(ITestAnswerRepository testAnswerRepository, IQuestionRepository questionRepository, IStudentRepository studentRepository, IOptionsRepository optionsRepository)
        {
            this.testAnswerRepository = testAnswerRepository;
            this.questionRepository = questionRepository;
            this.studentRepository = studentRepository;
            this.optionsRepository = optionsRepository;
        }

        private readonly IOptionsRepository optionsRepository;

        [HttpPost]
        public IActionResult Post(TestAnswerModel testAnswer)
        {
            Question question = questionRepository.FindById(testAnswer.QuestionId);
            Option option = question.Options.First(d => d.Id == testAnswer.OptionsId);
            Student student = studentRepository.FindByStudentId(testAnswer.StudentId);


            TestAnswer t = new TestAnswer();
            t.Options = option;
            t.Question = question;
            t.Student = student;

            testAnswerRepository.Add(t);

            return Created($"/api/testAnswer/{testAnswer.StudentId}", testAnswer);
        }


        

      
    }
}
