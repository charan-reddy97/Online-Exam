using Examination.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinations.Core.Repository
{
    public class StudentRepository : IStudentRepository
    {
        AdminDbContext dbContext;

        public StudentRepository(AdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StudentRepository()
        {
        }

        public Student Add(Student student)
        {

            student.CreatedDate = DateTime.Now;
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return student;
        }


        public Student Update(Student student)
        {
            Student currentStudent = dbContext.Students.FirstOrDefault(d => d.Id == student.Id);
            currentStudent.UserName = student.UserName;
            currentStudent.Password = student.Password;
            currentStudent.LastModifiedDate = DateTime.Now;

            dbContext.Update(currentStudent);
            dbContext.SaveChanges();

            return currentStudent;
        }

        public void Delete(int id)
        {
            Student student = dbContext.Students.FirstOrDefault(d => d.Id == id);
            student.DeletedDate = DateTime.Now;

            dbContext.Update(student);
            dbContext.SaveChanges();
        }

        public Student FindByStudentId(int studentid)
        {
            return dbContext.Students.FirstOrDefault(d => d.Id == studentid);
        }

        public Student FindByStudentName(string studentusername, string password)
        {
            var student = dbContext.Students.FirstOrDefault(d => d.Email == studentusername
                                                    && d.Password == password
                                                    && d.DeletedDate == null);

            if (student == null)
                throw new Exception($"student does not exist");

            return student;
        }
        public List<Student> GetStudent()
        {
            return dbContext.Students.Where(d => d.DeletedDate == null).ToList();
        }





    }
}