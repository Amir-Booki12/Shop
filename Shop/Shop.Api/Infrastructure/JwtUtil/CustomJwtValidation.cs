using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Addresses;

namespace Shop.Api.Infrastructure.JwtUtil
{
    public class CustomJwtValidation
    {
        private readonly IUserFacade _userFacade;

        public CustomJwtValidation(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public async Task Validate(TokenValidatedContext context)
        {
            var userId = context.Principal.GetUserId();
            var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearar ", "");
            var token =await _userFacade.GetUserTokenByJwtToken(jwtToken);
            if(token == null)
            {
                context.Fail("token notfound");
                return;
            }
            var user =await _userFacade.GetUserById(userId);
            if (user == null || user.IsActive == false)
            {
                context.Fail("user InActive");
                return;
            }
        }
    }
}
