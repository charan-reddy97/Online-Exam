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
    public class LoginController : ControllerBase
    {
        IAdminRepository adminRepository;


        public LoginController(IAdminRepository adminRepository)
        {

            this.adminRepository = adminRepository;
        }

      
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(403)]
        [HttpPost]
        public IActionResult Post(AdminModel admin)
        {
            var authAdmin = adminRepository.FindByAdminName(admin.Email, admin.Password);
            if (authAdmin != null)
            {

                var jwtToken = GenerateJWTToken(authAdmin.Email, authAdmin.Role.ToString());


                return Ok(new { Profile = authAdmin, Token = jwtToken });
            }
            else
                return Unauthorized("Login Failed");
        }


        private string GenerateJWTToken(string adminName, string role)
        {
            string jwtToken = string.Empty;

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my application secret"));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, adminName));
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
