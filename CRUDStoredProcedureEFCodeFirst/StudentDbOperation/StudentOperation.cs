using CRUDStoredProcedureEFCodeFirst.Models;
using CRUDStoredProcedureEFCodeFirst.Repository.Contract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUDStoredProcedureEFCodeFirst.StudentDbOperation
{
    public class StudentOperation
    {
        private readonly StudentDbContext _studentDb;
        public StudentOperation(StudentDbContext studentDb)
        {
            _studentDb = studentDb;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            var parameters = new[]
            {
                new SqlParameter("@action","SelectAll")
            };
            var students= await _studentDb.Students.FromSqlRaw("EXEC Student_CRUD @action", parameters).ToListAsync();
            return students;
        }
        public async Task<IEnumerable<Student>> GetStudentByIdAsync(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@action","Select_Single"),
                new SqlParameter("@id",id)
            };
            var students = await _studentDb.Students.FromSqlRaw("EXEC Student_CRUD @action,@id",parameters).ToListAsync();
            return students;
        }
        public async Task<bool> CreateStudentAsync(Student student)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@action","Create"),
                new SqlParameter("@id",student.id),
                new SqlParameter("@name",student.name),
                new SqlParameter("@age",student.age),
                new SqlParameter("@address",student.saddress),
                new SqlParameter("@mobileno",student.mobileno),
                new SqlParameter("@city",student.city),
                new SqlParameter("@fee",student.fees),
                };
                var result = await _studentDb.Database.ExecuteSqlRawAsync(@"EXEC Student_CRUD @action,@id,@name,@age,@address,@mobileno,@city,@fee", parameters.ToArray());
                if (result == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@action", "Update"));
                parameters.Add(new SqlParameter("@id", student.id));
                parameters.Add(new SqlParameter("@name", student.name));
                parameters.Add(new SqlParameter("@age", student.age));
                parameters.Add(new SqlParameter("@address", student.saddress));
                parameters.Add(new SqlParameter("@mobileno", student.mobileno));
                parameters.Add(new SqlParameter("@city", student.city));
                parameters.Add(new SqlParameter("@fee", student.fees));
                var result = await _studentDb.Database.ExecuteSqlRawAsync(@"EXEC Student_CRUD @action,@id,@name,@age,@address,@mobileno,@city,@fee", parameters.ToArray());
                if (result == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@action", "Delete"));
                parameters.Add(new SqlParameter("@id", id));
                var result = await _studentDb.Database.ExecuteSqlRawAsync(@"EXEC Student_CRUD @action,@id", parameters.ToArray());
                if (result == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
