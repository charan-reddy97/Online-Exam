using Examinations.Core.Entities;
using Examinations.Core.Repository;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository AdminRepository;


        public AdminController(IAdminRepository adminRepository)
        {

            this.AdminRepository = adminRepository;
        }


        [HttpGet("byid/{adminid}")]
        public IActionResult Get(int adminid)
        {
            if (adminid > 0)
            {
                var admin = AdminRepository.FindAdminById(adminid);

                if (User != null)
                    return Ok(admin);
                else
                    return NotFound($"Admin with the id:{adminid} cannot be found");
            }
            else
                return BadRequest($"Invalid Admin Id");
        }

       
        [HttpPost]
        public IActionResult Post(Admin admin)
        {
            AdminRepository.Add(admin);
            return Created($"/api/admin/{admin.Id}", admin);
        }

       
        [HttpPut]
        public IActionResult Put(Admin admin)
        {
            if (admin.Id > 0)
            {
                AdminRepository.Update(admin);
                return Ok();
            }
            else
                return BadRequest($"Invalid admin Id");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var admin = AdminRepository.GetAdmin();
            return Ok(admin);
        }
    }
}
