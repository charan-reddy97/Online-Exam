using Examination.Core;
using Examinations.Core.Repository;
using NUnit.Framework;
using System;

namespace StudentsRepositoryTest
{
    public class StudentRepositoryTest
    {
        StudentRepository studentRepository = new StudentRepository();

        [Test]
        public void AddNewStudent_ValidData_ReturnsStudent()
        {
            //Arrange
            Student student = new Student();
            student.Email = "johan@gmail.com";
            student.UserName = "Johan";
            student.Password = "johan@123";
           



            //Act
            var newStudent = studentRepository.Add(student);

            //Assert
            Assert.IsNotNull(newStudent);
            Assert.IsTrue(newStudent.Id > 0);
        }

        [Test]
        public void FindById_ValidData_ReturnsStudent()
        {
            //Arrange
            int id = 52;

            //Act
            var student = studentRepository.FindByStudentId(id);

            //Assert
            Assert.NotNull(student);
            Assert.That(student.Id, Is.EqualTo(id));
        }

        [Test]
        public void GetAllStudents_ValidData_ReturnsListStudents()
        {
            //Arrange 

            //Act
            var Students = studentRepository.GetStudent();

            //Assert
            Assert.That(Students.Count > 0);
        }
    }
}
