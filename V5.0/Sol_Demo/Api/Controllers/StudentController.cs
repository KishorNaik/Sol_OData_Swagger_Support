using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //[HttpGet("list")]
        [HttpPost("list")]
        [EnableQuery]
        public IActionResult StudentList()
        {
            var studentList = new List<StudentModel>();
            studentList.Add(new StudentModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Sharmila Naik",
                Score = 98
            });
            studentList.Add(new StudentModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Mahesh Naik",
                Score = 90
            });

            studentList.Add(new StudentModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Kishor Naik",
                Score = 70
            });

            return base.Ok(studentList);
        }
    }
}