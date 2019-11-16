using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using VNext.BienEtreAuTravail.DAL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Models.Settings;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace VNext.BienEtreAuTravail.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IOptions<ConnectionStrings> option) : base(option){}
        public IEnumerable<User> GetUsers()
        {
            using (var connection  = GetConnection())
            {
               return connection.Query<User>("[dbo].[GetAllUser]", commandType: CommandType.StoredProcedure);
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
}
