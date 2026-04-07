using EntityApi.Models;
using EntityApi.Repositories;

namespace EntityApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> GetAllStudents() =>
            await _repo.GetAll();

        public async Task<Student> GetStudentById(int id) =>
            await _repo.GetById(id);

        public async Task AddStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;
            await _repo.Add(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _repo.Update(student);
        }

        public async Task DeleteStudent(int id)
        {
            await _repo.Delete(id);
        }
    }
}