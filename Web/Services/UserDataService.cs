using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Data;

namespace Web.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserDataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User GetUser(string id)
        {
            return _dbContext.Users.Find(id);
        }
    }
}
