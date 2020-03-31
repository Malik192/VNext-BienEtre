using System.Collections.Generic;
using System.Security.Claims;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.BLL.Interfaces
{
    public interface IUserService

    {
         IEnumerable<Employee> GetUsers();
        IEnumerable<Employee> UpdateUser(Employee value);
        void AddUser(Employee user);
     //   IEnumerable<EmployeeDTO> GetAllUsers();
        IEnumerable<Employee> GetAllUsers();
        bool Authentification(string pseudo, string password);

        ClaimsPrincipal GetPrincipal(Employee value, string authScheme);

        Employee DisplayById(int employee);
        

        IEnumerable<Employee> DeleteEmp(int person);

    }
}
