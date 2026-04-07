using EntityApi.Models;
using EntityApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _service.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await _service.AddStudent(student);
            return Ok("Student added successfully");
        }
    }
}
