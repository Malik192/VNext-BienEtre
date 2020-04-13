using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using VNext.BienEtreAuTravail.DAL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Models.Settings;
using System.Linq;
using VNext.BienEtreAuTravail.DAL.Context;

namespace VNext.BienEtreAuTravail.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IOptions<ConnectionStrings> option) : base(option) { }
        public IEnumerable<Employee> GetUsers()
        {
            using (var connection = GetConnection())
            {
                var context = new WorkContext();

                return context.Employees;

            }


        }
        public IEnumerable<Departement> GetDepartment()
        {
            using (var connection = GetConnection())
            {
                var context = new WorkContext();

                return context.Departement;

            }


        }
        public void AddUser(Employee nom)
        {


            using (var context = new WorkContext())
            {
                

                context.Employees.Add(nom);

                context.SaveChanges();
            }



        }

          public void AddDepartment(Departement departement)
        {


            using (var context = new WorkContext())
            {
                

                context.Departement.Add(departement);

                context.SaveChanges();
            }



        }


        public IEnumerable<Employee> UpdateUser(Employee value)
        {
            using (var context = new WorkContext())
            {
                var user = context.Employees.First(a => a.IdEmployee == value.IdEmployee);
                user.Pseudo = value.Pseudo;
                user.Password = value.Password;
                context.SaveChanges(); 
            }
            return GetAllUsers();
        } 
       
        public IEnumerable<Employee> GetAllUsers()
        {
            using (var context = new WorkContext())
            {

                return context.Employees.ToList();
            }
        }
        public IEnumerable<Employee> DeleteEmp(int person)
        {
            using (var context = new WorkContext())
            {
                try
                { 
                    var author = context.Employees.Single(a => a.IdEmployee == person);
                    context.Remove(author);
                    context.SaveChanges();
                    return context.Employees.ToList(); 
                }
                catch (Exception)
                {
                     throw;
                }
            }
        }
        //var result = new List<User>();
        //result.Add(new User()
        //{
        //    Id = 1,
        //    Name = "Alice"
        //});
        //result.Add(new User()
        //{
        //    Id = 2,
        //    Name = "Bob"
        //});

        //return result;
    }

}

