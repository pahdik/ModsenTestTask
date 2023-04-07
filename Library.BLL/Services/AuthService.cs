using Library.BLL.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Options;
using Library.BLL.DTO;
using Azure;
using System.Net;
using Library.DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.Models;
using Library.DAL.Models;
using Library.BLL.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace Library.BLL.Services
{
    public class AuthService:IAuthService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private readonly JWTSettings _jwtSettings;
        public AuthService(IUserRepository userRepository,IMapper mapper, IOptions<JWTSettings> jwtOptions)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtSettings = jwtOptions.Value;
        }
        public async Task<ResponseAuthModel> AddUserAsync(RegisterDTO model)
        {
            User user = _mapper.Map<User>(model);
            var IsExist = await _userRepository.IsUserExistAsync(user);
            if (!IsExist.Item1) 
                return new ResponseAuthModel()
                {
                    StatusCode = 404,
                    Token = null,
                    Message = IsExist.Item2
                };

            user.Id = 0;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            await _userRepository.AddUserAsync(user);
            return new ResponseAuthModel()
            {
                StatusCode = 200,
                Token = GetToken(user),
                Message = null
            };
        }

        public async Task<ResponseAuthModel> SignInAsync(LoginDTO model)
        {
            User user = await _userRepository.GetUserByNameAsync(model.UserName);
            if (user == null)
                return new ResponseAuthModel()
                {
                    StatusCode = 404,
                    Token = null,
                    Message = "User does not exist"
                };
            
            var IsMatch= BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
            if (!IsMatch)
                return new ResponseAuthModel()
                {
                    StatusCode = 404,
                    Token = null,
                    Message = "Wrong password"
                };

            return new ResponseAuthModel()
            {
                StatusCode = 400,
                Token = GetToken(user),
                Message = null
            }; 
        }

        private string GetToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName)
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials);
            
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
           
            return token; 
        }

    }
}
