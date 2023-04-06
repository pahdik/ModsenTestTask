using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.DTO;

namespace Library.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> AddUser(RegisterDTO model);

    }
}
