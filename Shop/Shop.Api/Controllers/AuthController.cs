using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using UAParser;

namespace Shop.Api.Controllers
{

    public class AuthController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;

        public AuthController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel loginViewModel)
        {

            var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
            if (user == null)
            {
                var result = OperationResult<LoginResultDto>.Error("کاربر یافت نشد");
                return CommandResult(result);
            }
            if (!Sha256Hasher.IsCompare(user.Password, loginViewModel.Password))
            {
                var result = OperationResult<LoginResultDto>.Error("مشخصات وارد  شده صحیح نمیباشد");
                return CommandResult(result);
            }
            if (user.IsActive == false)
            {
                var result = OperationResult<LoginResultDto>.Error("حساب کاربری فعال نمیباشد");
                return CommandResult(result);
            }

            var resultToken = await AddTokenAndGenerateJwt(user);
            return CommandResult(resultToken);
           
        }
        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterViewModel register)
        {
            var commend = new RegisterUserCommand(register.PhoneNumber, register.Password);
            var result = await _userFacade.RegisterUser(commend);
            return CommandResult(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
        {
            var result =await _userFacade.GetUserTokenByRefreshToken(refreshToken);
            if (result == null)
                return CommandResult(OperationResult<LoginResultDto?>.NotFound());
            if(result.ExpireDateToken>DateTime.Now)
                return CommandResult(OperationResult<LoginResultDto?>.Error("توکن هنوز منقرض نشده است"));
            if (result.ExpireDateRefreshToken < DateTime.Now)
                return CommandResult(OperationResult<LoginResultDto?>.Error("زمان رفرش توکن به پایان رسیده است"));

            var user = await _userFacade.GetUserById(result.UserId);
           await _userFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId,result.Id));
            var loginResult =await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
            
        }
        [Authorize]
        [HttpDelete("logOut")]
        public async Task<ApiResult?> LogOut()
        {
            var token =await HttpContext.GetTokenAsync("access_token");
            var result =await _userFacade.GetUserTokenByJwtToken(token);
            if (result == null)
                return CommandResult(OperationResult.NotFound());

            await _userFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId, result.Id));
            return CommandResult(OperationResult.Success());
        }
        private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
        {
            var uaParser = Parser.GetDefault();
            var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
            var device = $"{info.Device.Family}/{info.OS.Family}{info.OS.Major}.{info.OS.Minor}-{info.UA.Family}";
            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var refreshToken = Guid.NewGuid().ToString();
            var hashToken = Sha256Hasher.Hash(token);
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashToken, hashRefreshToken, DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));

            if (tokenResult.Status != OperationResultStatus.Success)
                return OperationResult<LoginResultDto?>.Error();

            return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
            {
                RefreshToken = refreshToken,
                Token = token
            });
            {

            }
        }
    }
}
