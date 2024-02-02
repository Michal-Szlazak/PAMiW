using ProjectShared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShared.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto);

        Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO);

        Task<ServiceResponse<bool>> ChangePassword(string newPassword);
    }
}
