using System.Collections.Generic;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.DAL.Interfaces
{
    public interface IUserRepository
    {
        
           IEnumerable<Employee> GetUsers();
           void AddUser(Employee nom);
           IEnumerable<Employee> UpdateUser(Employee value);
           IEnumerable<Employee> GetAllUsers();
           IEnumerable<Employee> DeleteEmp(int person);
          
         


    }
}
