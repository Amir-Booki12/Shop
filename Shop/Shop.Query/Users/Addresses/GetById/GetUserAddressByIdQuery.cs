using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Addresses.GetById
{
    public record GetUserAddressByIdQuery(long UserAddressId):IQuery<AddressDto>;
}
