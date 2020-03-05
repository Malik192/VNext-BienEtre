using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VNext.BienEtreAuTravail.BLL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Models.DTO;
using VNext.BienEtreAuTravail.DAL.Repositories;

namespace VNext.BienEtreAuTravail.BLL.Services
{
    public class UserService : IUserService
    {
       
        protected readonly IUserRepository _userRepository;
        protected SaltedPassword passwordHash = new SaltedPassword();
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(Employee user)
        {

            if (user.Password !=null)
            {
                user.Password = passwordHash.CreateHash(user.Password);
                

                _userRepository.AddUser(user);
            }
          
        }
        public bool Authentification(string pseudo,string password)
        {
            bool validation = false;
            foreach (var item in GetAllUsers())
            {
                try
                {

                    if (pseudo == item.Pseudo)
                    {

                        validation = passwordHash.ValidatePassword(password, item.Password);

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.StackTrace);
                        
                }

            }

            return validation;
        }


        public ClaimsPrincipal GetPrincipal(Employee value, string authScheme)
        {
            // Here we are just creating a Principal for any user, 
            // using its email and a hardcoded “User” role
            IEnumerable<Claim> claims = new List<Claim>
      {
          new Claim(ClaimTypes.Name, value.Pseudo),
          new Claim(ClaimTypes.Email, value.Password),
      };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, authScheme));
        }

        public void UpdateUser(Employee value)
        {
            _userRepository.UpdateUser(value);
        }
        public IEnumerable<Employee> DeleteEmp(int person) {
            return _userRepository.DeleteEmp(person);
        }
        //
      
        public IEnumerable<Employee> DisplayById(int employee)
        {
            var person = _userRepository.DisplayById();

            var EmployeeById = from E in person
                                       where E.IdEmployee == employee
                                       select E;
            return EmployeeById;
        }
        

        public IEnumerable<Employee> GetAllUsers()
        {
            Console.WriteLine( "Liste des utilisateurs");
           return _userRepository.GetAllUsers();
        }

        public IEnumerable<Employee> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        
    }
}
