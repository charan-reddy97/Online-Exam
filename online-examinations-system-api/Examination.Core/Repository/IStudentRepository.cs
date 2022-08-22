using Examination.Core;
using System.Collections.Generic;

namespace Examinations.Core.Repository
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        void Delete(int id);
        Student FindByStudentName(string studentname, string password);
        Student FindByStudentId(int studentid);
        List<Student> GetStudent();
        Student Update(Student student);
    }
}