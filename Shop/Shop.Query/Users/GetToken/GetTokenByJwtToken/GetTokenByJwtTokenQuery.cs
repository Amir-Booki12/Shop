using Common.Query;
using Dapper;
using Shop.Infrastucture.Persistent.Dapper;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetToken.GetTokenByRefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetToken.GetTokenByJwtToken
{
    public record GetTokenByJwtTokenQuery(string HashJwtToken) : IQuery<UserTokenDto>;

    internal class GetTokenByJwtTokenQueryHandler : IQueryHandler<GetTokenByJwtTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetTokenByJwtTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserToken} where HashJwtToken=@hashJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJwtToken = request.HashJwtToken });
        }
    }

}
