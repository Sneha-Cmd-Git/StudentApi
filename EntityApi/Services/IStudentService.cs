using EntityApi.Models;

namespace EntityApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task AddStudent(Student student);
        Task<Student> GetStudentById(int id);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
