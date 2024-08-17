using CRUDStoredProcedureEFCodeFirst.Models;

namespace CRUDStoredProcedureEFCodeFirst.Repository.Contract
{
    public interface IStudent
    {
        public Task<IEnumerable<Student>> GetAllStudentAsync();
        public Task<IEnumerable<Student>> GetStudentByIdAsync(int id);
        public Task<bool> CreateStudentAsync(Student student);
        public Task<bool> UpdateStudentAsync(Student student);
        public Task<bool> DeleteStudentAsync(int id);
    }
}
