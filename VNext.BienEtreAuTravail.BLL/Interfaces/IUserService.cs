using System;
using System.Collections.Generic;
using System.Text;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}
