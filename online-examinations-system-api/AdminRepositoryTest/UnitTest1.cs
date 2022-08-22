using Examinations.Core.Entities;
using Examinations.Core.Repository;
using NUnit.Framework;

namespace OnlineLearningSystemTest
{
    public class AdminRepositoryTest
    {
        AdminRepository adminRepository = new AdminRepository();

        [Test]
        public void AddNewAdmin_ValidData_ReturnsAdmin()
        {
            //Arrange
            Admin admin = new Admin();
            admin.Email = "bill@gmail.com";
            admin.Name = "bill";

            //Act
            var newAdmin = adminRepository.Add(admin);

            //Assert
            Assert.IsNotNull(newAdmin);
            Assert.IsTrue(newAdmin.Id > 0);
        }

        [Test]
        public void FindById_ValidData_ReturnsAdmin()
        {
            //Arrange
            int id = 1;

            //Act
            var admin = adminRepository.FindAdminById(id);

            //Assert
            Assert.NotNull(admin);
            Assert.That(admin.Id, Is.EqualTo(id));
        }

        [Test]
        public void GetAllAdmins_ValidData_ReturnsListAdmins()
        {
            //Arrange 

            //Act
            var Admins = adminRepository.GetAdmin();

            //Assert
            Assert.That(Admins.Count > 0);
        }

    }
}