using Commom.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg.Repository
{
    public interface ISellerRepository:IBaseRepository<Seller>
    {
        Task<InvertoryResult> GetInvertoryResultById(long id);
    }

    public class InvertoryResult
    {
        public long Id { get; set; }
        public long SellerId { get;  set; }
        public long ProductId { get; set; }
        public int Price { get;  set; }
        public int Count { get; set; }
    }

}
