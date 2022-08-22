using Examinations.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLoginController : ControllerBase
    {
        IStudentRepository studentRepository;


        public StudentLoginController(IStudentRepository studentRepository)
        {

            this.studentRepository = studentRepository;
        }


        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(403)]
        [HttpPost]
        public IActionResult Post(StudentModel student)
        {
            var authStudent = studentRepository.FindByStudentName(student.Email, student.Password);
            if (authStudent != null)
            {

                var jwtToken = GenerateJWTToken(authStudent.Email, authStudent.Role.ToString());


                return Ok(new { Profile = authStudent, Token = jwtToken });
            }
            else
                return Unauthorized(" StudentLogin Failed");
        }


        private string GenerateJWTToken(string studentUserName, string role)
        {
            string jwtToken = string.Empty;

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my application secret"));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, studentUserName));
            claims.Add(new Claim(ClaimTypes.Role, role));

            var token = new JwtSecurityToken("myexam.com"
                                            , "myexam.com"
                                            , claims
                                            , expires: DateTime.Now.AddDays(7)
                                            , signingCredentials: credentials);

            jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

    }
}
