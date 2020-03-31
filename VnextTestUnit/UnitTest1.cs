using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VNext.BienEtreAuTravail.BLL.Services;
using VNext.BienEtreAuTravail.DAL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Models.DTO;

namespace VnextTestUnit
{
    [TestClass]
    public class UnitTest1
    {   
        Mock<IUserRepository> userRepo;
        
        UserService userService;
        
        [TestInitialize]
        public void SetUp()
        {
            // Create a new mock of the repository
            userRepo = new Mock<IUserRepository>();
           
            var emp = userRepo.Object.GetAllUsers();
     
            userRepo.Setup(x => x.GetAllUsers())
                .Returns(new List<Employee>
                {
                new Employee { IdEmployee = 160, Pseudo = "Test1" },
                new Employee { IdEmployee = 2, Pseudo = "Test2" },

                });

            // Create the service and inject the repository into the service
            userService = new UserService(userRepo.Object);
        
        }

        [TestMethod]
        public void Test_GetAllUsers()
        {

            var users = userService.GetAllUsers();

            List<Employee> asList = users.ToList();
            
            // Assert
            Assert.AreEqual(2, asList.Count, "The users count is not correct");
        }
        [TestMethod]
        public void Test_GetUserById()
        {
          
            var user = userService.DisplayById(2);
            Assert.AreEqual("Test2", user.Pseudo, "The users count is not correct");

            



        }
       
    }
}
