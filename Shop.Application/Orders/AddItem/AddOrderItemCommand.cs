using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.AddItem
{
    public record AddOrderItemCommand(long UserId, long InvertoryId, int Count) : IBaseCommand;
}
