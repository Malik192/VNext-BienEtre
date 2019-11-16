using System;
using System.Collections.Generic;
using System.Text;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(); 

    }
}
