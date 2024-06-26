﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolSoftWeb.Constants;
using SchoolSoftWeb.Data.Identity;
using SchoolSoftWeb.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        //public async Task<ApplicationUser> GetUserByEmail (string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    return user;
        //}

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }
        public async Task<Response> RegisterAsync(RegisterModel model)
        {
            Response res = new Response()
            {
                ErrorOccured = false,
                ResponseMessage = ""
            };

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Authorization.default_role.ToString());
                }
                res.ErrorOccured = false;
                res.ResponseMessage = $"User Registered with username {user.UserName}";
                return res;
            }
            else
            {
                res.ErrorOccured = true;
                res.ResponseMessage = $"Email {user.Email } is already registered.";
                return res;
            }
        }

        public async Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model)
        {
            var authenticationModel = new AuthenticationModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"No Accounts Registered with {model.Email}.";
                return authenticationModel;
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authenticationModel.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationModel.Email = user.Email;
                authenticationModel.UserName = user.UserName;
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();
                authenticationModel.Id = user.Id;
                return authenticationModel;
            }
            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = $"Incorrect Credentials for user {user.Email}.";
            return authenticationModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task<Response> AddRoleAsync(AddRoleModel model)
        {
            Response res = new Response()
            {
                ErrorOccured = false,
                ResponseMessage = ""
            };

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                res.ErrorOccured = true;
                res.ResponseMessage = $"No Accounts Registered with {model.Email}.";
                return res;
            }

            var userRoleExists = await _userManager.IsInRoleAsync(user, model.Role);
            if (userRoleExists)
            {
                res.ErrorOccured = true;
                res.ResponseMessage = "Role already exists to the user.";
                return res;
            }

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var roleExists = Enum.GetNames(typeof(Authorization.Roles)).Any(x => x.ToLower() == model.Role.ToLower());
                if (roleExists)
                {
                    var validRole = Enum.GetValues(typeof(Authorization.Roles)).Cast<Authorization.Roles>().Where(x => x.ToString().ToLower() == model.Role.ToLower()).FirstOrDefault();
                    await _userManager.AddToRoleAsync(user, validRole.ToString());
                    res.ErrorOccured = false;
                    res.ResponseMessage = $"Added {model.Role} to user {model.Email}.";
                    return res;
                }
                res.ErrorOccured = true;
                res.ResponseMessage = $"Role {model.Role} not found.";
                return res;
            }
            res.ErrorOccured = true;
            res.ResponseMessage = $"Incorrect Credentials for user {user.Email}.";
            return res;
        }
    }
}
