using Common.Query;
using MediatR;
using Shop.Query.Users.Addresses.GetById;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Addresses.GetList
{
    public record GetUserAddressListQuery(long UserId) : IQuery<List<AddressDto>>;



}

