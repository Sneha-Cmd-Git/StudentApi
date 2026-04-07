using EntityApi.DTOs;
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

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var students = await _service.GetAllStudents();

            var result = students.Select(s => new StudentResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Course = s.Course
            });

            return Ok(result);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreateStudentDTO dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.Now
            };

            await _service.AddStudent(student);
            return Ok("Student added");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateStudentDTO dto)
        {
            var student = await _service.GetStudentById(id);

            if (student == null)
                return NotFound("Student not found");

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _service.UpdateStudent(student);

            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetStudentById(id);

            if (student == null)
                return NotFound("Student not found");

            await _service.DeleteStudent(id);

            return Ok("Student deleted successfully");
        }
    }
}
