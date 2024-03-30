using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using main.Models;

namespace main.Services
{
    public interface IUserDataService
    {
        User GetUser(string author);
    }
}
