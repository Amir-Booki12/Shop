using Common.Query;
using Dapper;
using Shop.Infrastucture.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetList
{
    internal class GetUserAddressListQueryHandler : IQueryHandler<GetUserAddressListQuery, List<AddressDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<AddressDto>> Handle(GetUserAddressListQuery request, CancellationToken cancellationToken)
        {
           using var context = _dapperContext.CreateConnection();
            var sql = $"Select  * from{_dapperContext.UserAddress}Where UserId=@UserId";
            var result=await context.QueryAsync<AddressDto>(sql, new { UserId = request.UserId });
            return result.ToList();
        }
    }



}

