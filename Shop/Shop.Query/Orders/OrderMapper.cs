using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastucture.Persistent.Dapper;
using Shop.Infrastucture.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders
{
    public static class OrderMapper
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                CreationDate = order.CreationDate,
                Id = order.Id,
                Status = order.Status,
                Addresses = order.Addresses,
                Discount = order.Discount,
                Items = new(),
                LastUpdate = order.LastUpdate,
                shippingMethod = order.shippingMethod,
                FullName = "",
                UserId = order.UserId,
            };
        }

        public static OrderFilterData MapFilter(this Order order,ShopContext context)
        {
            var userFullName = context.Users.Where(w => w.Id == order.UserId)
                .Select(s => $"{s.Name}{s.Family}").First();
            return new OrderFilterData()
            {
                CreationDate = order.CreationDate,
                Id = order.Id,
                Status = order.Status,
                City=order.Addresses?.City,
                FullName = userFullName,
                UserId = order.UserId,
                Shire=order.Addresses?.Shire,
                ShppingType=order.shippingMethod?.ShppingType,
                TotalItemCount=order.Items.Count,
                TotalPrice=order.TotalPrice
            };
        }

        public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = @$"SELECT o.Id, s.ShopName ,o.OrderId,o.InventoryId,o.Count,o.price,
                          p.Title as ProductTitle , p.Slug as ProductSlug ,
                          p.ImageName as ProductImageName
                    FROM {dapperContext.OrderItems} o
                    Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                    Inner Join {dapperContext.Products} p on i.ProductId=p.Id
                    Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id
                    where o.OrderId=@orderId";

            var result = await connection
                .QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });
            return result.ToList();
        }
        }
    }
