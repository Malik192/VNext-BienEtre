using System;
using System.Collections.Generic;
using System.Text;
using VNext.BienEtreAuTravail.BLL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Repositories;

namespace VNext.BienEtreAuTravail.BLL.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
