using Dapper;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastucture._Utilities;
using Shop.Infrastucture.Persistent.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.SellerAgg
{
    internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InvertoryResult> GetInvertoryResultById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

            return await connection.QueryFirstOrDefaultAsync<InvertoryResult>
                (sql, new { InventoryId = id });
        }
    }
}
