using AutoMapper;
using Bookify.Data.JwtBearer;
using Bookify.Service.Beans;
using Bookify.Service.interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Bookify.Service.Services
{
    public class UserService: IUserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        private readonly IUser _userRepository;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper, 
            JwtHandler jwtHandler, IUser userRepository)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;

            _userRepository = userRepository;
        }

        public async Task<IdentityResult?> SignUp(UserRegister userRegister)
        {
            userRegister.Id = Guid.NewGuid();

            var user = _mapper.Map<User>(userRegister);
            return await _userManager.CreateAsync(user, userRegister.Password);
        }

        public async Task<string?> SignIn(UserLogin userLogin)
        {
            var result = await _userManager.FindByEmailAsync(userLogin.Email);

            string token = null;

            if(result != null)
            {
                var isAuth = await _userManager.CheckPasswordAsync(result, userLogin.Password);
                if (isAuth)
                {
                    var sigingCredentials = _jwtHandler.GetSigningCredentials();
                    var claims = _jwtHandler.GetClaims(result);
                    var tokenOptions = _jwtHandler.GenerateTokenOptions(sigingCredentials, claims);
                    token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                }
            }

            return token;
        }  
    }
}
