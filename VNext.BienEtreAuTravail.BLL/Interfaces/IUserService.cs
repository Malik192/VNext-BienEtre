using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Models.DTO;

namespace VNext.BienEtreAuTravail.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Employee> GetUsers();
        void UpdateUser(Employee value);
        void AddUser(Employee user);
        IEnumerable<Employee> GetAllUsers();
        bool Authentification(string pseudo, string password);

        ClaimsPrincipal GetPrincipal(Employee value, string authScheme);

        IEnumerable<Employee> DisplayById(int employee);
        

        IEnumerable<Employee> DeleteEmp(int person);

    }
}
