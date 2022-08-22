using Examination.Core;
using Examinations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinations.Core.Repository
{
    public class AdminRepository : IAdminRepository
    {

        AdminDbContext dbContext;
        public AdminRepository(AdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AdminRepository()
        {
        }

        public Admin Add(Admin admin)
        {
            admin.CreatedAt = DateTime.Now;
            dbContext.Admins.Add(admin);
            dbContext.SaveChanges();
            return admin;

        }

        public Admin Update(Admin admin)
        {
            Admin currentAdmin = dbContext.Admins.FirstOrDefault(d => d.Id == admin.Id);
            if (currentAdmin != null)
            {
                currentAdmin.Name = admin.Name;
                currentAdmin.Email = admin.Email;
                currentAdmin.Password = admin.Password;
                currentAdmin.Role = admin.Role;
                currentAdmin.LastModifiedDate = DateTime.Now;




                dbContext.Admins.Update(currentAdmin);
                dbContext.SaveChanges();

            }

            return admin;
        }

        public void Delete(int adminid)
        {
            Admin currentAdmin = dbContext.Admins.FirstOrDefault(d => d.Id == adminid);
            if (currentAdmin != null)
            {
                currentAdmin.DeletedDate = DateTime.Now;
                dbContext.Admins.Update(currentAdmin);
                dbContext.SaveChanges();

            }
        }

        public Admin FindAdminById(int adminid)
        {
            return dbContext.Admins.FirstOrDefault(d => d.Id == adminid);
        }

        public Admin FindByAdminName(string adminname, string password)
        {
            var admin = dbContext.Admins.FirstOrDefault(d => d.Email == adminname
                                                    && d.Password == password
                                                    && d.DeletedDate == null);

            if (admin == null)
                throw new Exception($"Admin does not exist");

            return admin;
        }
        public List<Admin> GetAdmin()
        {
            return dbContext.Admins.Where(d => d.DeletedDate == null).ToList();
        }
    }
}