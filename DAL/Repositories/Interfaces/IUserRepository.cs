using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Models;

namespace Library.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByNameAsync(string name);
        public Task AddUserAsync(User user);
        public Task<(bool,string)> IsUserExistAsync(User model);
    }
}
