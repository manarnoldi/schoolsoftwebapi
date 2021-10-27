using SchoolSoftWeb.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Services
{
   public interface IUserService
    {
        Task<Response> RegisterAsync(RegisterModel model);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task<Response> AddRoleAsync(AddRoleModel model);
    }
}
