using Examinations.Core.Entities;
using System.Collections.Generic;

namespace Examinations.Core.Repository
{
    public interface IAdminRepository
    {
        Admin Add(Admin admin);
        void Delete(int adminid);
        Admin FindAdminById(int adminid);
        Admin FindByAdminName(string adminname, string password);
        List<Admin> GetAdmin();
        Admin Update(Admin admin);
    }
}