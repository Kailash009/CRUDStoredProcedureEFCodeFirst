using CRUDStoredProcedureEFCodeFirst.Models;
using CRUDStoredProcedureEFCodeFirst.Repository.Contract;
using CRUDStoredProcedureEFCodeFirst.StudentDbOperation;

namespace CRUDStoredProcedureEFCodeFirst.Repository.Services
{
    public class StudentService : IStudent
    {
        private readonly StudentOperation _stu;
        public StudentService(StudentOperation stu)
        {
            _stu = stu;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _stu.GetAllStudentAsync();
        }
        public async Task<bool> CreateStudentAsync(Student student)
        {
            return await _stu.CreateStudentAsync(student);
        }

        public async Task<IEnumerable<Student>> GetStudentByIdAsync(int id)
        {
            return await _stu.GetStudentByIdAsync(id);
        }
        public async Task<bool> UpdateStudentAsync(Student student)
        {
            return await _stu.UpdateStudentAsync(student);
        }
        public Task<bool> DeleteStudentAsync(int id)
        {
            return _stu.DeleteStudentAsync(id);
        }
    }
}
