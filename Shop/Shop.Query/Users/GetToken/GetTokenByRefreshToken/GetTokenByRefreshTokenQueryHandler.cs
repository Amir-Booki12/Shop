using Common.Query;
using Dapper;
using Shop.Infrastucture.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetToken.GetTokenByRefreshToken
{
    internal class GetTokenByRefreshTokenQueryHandler : IQueryHandler<GetTokenByRefreshTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserToken} where HashJwtRefreshToken=@hashJwtRefreshToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJwtRefreshToken = request.HashRefreshToken });
        }
    }


}
