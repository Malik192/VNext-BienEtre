using System.Collections.Generic;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.DAL.Interfaces
{
    public interface IUserRepository
    {
        
           IEnumerable<Employee> GetUsers();
           IEnumerable<Departement> GetDepartment();
           void AddUser(Employee nom);
           void AddDepartment(Departement departement);
        IEnumerable<Employee> UpdateUser(Employee value);
           IEnumerable<Employee> GetAllUsers();
           IEnumerable<Employee> DeleteEmp(int person);
          
         


    }
}
