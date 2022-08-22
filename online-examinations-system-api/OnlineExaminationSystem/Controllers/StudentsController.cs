using Examination.Core;
using Examinations.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using OnlineExamination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;


        public StudentsController(IStudentRepository studentRepository)
        {

            this.studentRepository = studentRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var students = studentRepository.GetStudent();
            return Ok(students);
        }


        [HttpGet("byid/{id}")]
        public IActionResult Get(int id)
        {
            //if (id > 0)
            //{
            var student = studentRepository.FindByStudentId(id);

            if (student != null)
                return Ok(student);
            else
                return NotFound($"Student with the id:{id} cannot be found");

            //}
            //else
            //    return BadRequest($"Invalid Student Id");
        }

       

        [HttpPost]
        public IActionResult Post(Student student)
        {
            studentRepository.Add(student);


            return Created($"/api/students/{student.Id}", student);
        }


        [HttpPut]
        public IActionResult Put(Student student)
        {
            if (student.Id > 0)
            {
                studentRepository.Update(student);
                return Ok();
            }
            else
                return BadRequest($"Invalid Student Id");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                studentRepository.Delete(id);
                return Ok();
            }
            else
                return BadRequest($"Invalid Student Id");
        }

    }
}



