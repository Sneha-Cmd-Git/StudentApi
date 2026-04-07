using EntityApi.Models;

namespace EntityApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task AddStudent(Student student);
    }
}
