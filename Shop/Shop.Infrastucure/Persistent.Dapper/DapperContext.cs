
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);


        public string Inventories => "[seller].Inventories";
        public string OrderItems => "[order].Items";
        public string Products => "[product].Products";
        public string Sellers => "[seller].Sellers";
        public string UserAddress => "[user].Addresses";
    }
}
