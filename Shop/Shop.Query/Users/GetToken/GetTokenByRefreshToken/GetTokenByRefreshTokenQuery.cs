using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetToken.GetTokenByRefreshToken
{
    public record GetTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto>;


}
