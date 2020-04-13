using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VNext.BienEtreAuTravail.BLL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;

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
        public void AddDepartment(Departement departement)
        {
             _userRepository.AddDepartment(departement);
           
        }
        public bool Authentification(string pseudo,string password)
        {
            bool validation = false;
            var emp = _userRepository.GetAllUsers();
            foreach (var item in emp)
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
           
            IEnumerable<Claim> claims = new List<Claim>
      {
          new Claim(ClaimTypes.Name, value.Pseudo),
          new Claim(ClaimTypes.Authentication, value.Password),
      };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, authScheme));
        }

        public IEnumerable<Employee> UpdateUser(Employee value)
        {
            return  _userRepository.UpdateUser(value);
        }
        public IEnumerable<Employee> DeleteEmp(int person) {
            return _userRepository.DeleteEmp(person);
        }
        //
      
        public Employee DisplayById(int employee)
        {
            var person = _userRepository.GetAllUsers();
            Employee Emp =null;
            var EmployeeById = from E in person
                                       where E.IdEmployee == employee
                                       select E;
            foreach (var item in EmployeeById)
            {
                Emp = item;
            }
            return Emp;
        }

        public IEnumerable<Employee> GetAllUsers()

        {

            return _userRepository.GetAllUsers();

        }
       /* public IEnumerable<EmployeeDTO> GetAllUsers()
        {
            
           var emp= _userRepository.GetAllUsers();
            var MapEntities = _mapper.Map <IEnumerable<EmployeeDTO>>(emp);
            var e = MapEntities.ToList();
            
            return MapEntities;
        }
        */
        public IEnumerable<Employee> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        public IEnumerable<Departement> GetDepartment()
        {
            return _userRepository.GetDepartment();
        }
        
    }
}
