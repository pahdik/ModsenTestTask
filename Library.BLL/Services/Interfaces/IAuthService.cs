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
