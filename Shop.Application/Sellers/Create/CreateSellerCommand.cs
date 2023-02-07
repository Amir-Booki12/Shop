using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Create
{
    public record CreateSellerCommand(long UserId, string ShopName, string NationalCode) : IBaseCommand;
}
