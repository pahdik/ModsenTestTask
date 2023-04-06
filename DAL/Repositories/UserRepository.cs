using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using Library.DAL.Models;
using Library.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == name);

            return user;
        }

        public async Task<(bool, string)> IsUserExistAsync(User model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName || x.Email == model.Email);
            if (user != null)
            {
                if (user.Email == model.Email)
                    return (false, "User with the same email already exists");

                if (model.UserName == model.UserName)
                    return (false, "User with the same name already exists");
            }
            return (true, "");
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }

}
