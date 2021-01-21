using AUPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IUserSqlProvider
    {
        User FindUserByEmailAndPassword(string email, string password);
        bool CreateUser(User user);
    }
}
