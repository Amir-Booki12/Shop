using Common.Query;
using Dapper;
using Shop.Infrastucture.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById
{
    internal class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<AddressDto> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
           using var context = _dapperContext.CreateConnection();
            var sql = $"Select top 1 * from{_dapperContext.UserAddress}Where id=@id";
            return await context.QueryFirstOrDefault(sql, new {id=request.UserAddressId});
        }
    }
}
