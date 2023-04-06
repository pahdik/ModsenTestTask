using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.DTO;
using Library.BLL.Models;

namespace Library.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ResponseAuthModel> AddUserAsync(RegisterDTO model);
        public Task<ResponseAuthModel> SignInAsync(LoginDTO model);

    }
}
