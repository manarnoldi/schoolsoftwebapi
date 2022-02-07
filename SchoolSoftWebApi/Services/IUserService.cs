using Microsoft.AspNetCore.Identity;
using SchoolSoftWeb.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Services
{
    public interface IUserService
    {
        //Task<ApplicationUser> GetCurrentUser();
        //Task<ApplicationUser> GetUserByEmail(string email);
        Task<Response> RegisterAsync(RegisterModel model);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUser(string Id);
        Task<IEnumerable<IdentityRole>> GetRoles();
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task<Response> AddRoleAsync(AddRoleModel model);
    }
}
