using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetById
{
    public record GetUserByIdQuery(long UserId):IQuery<UserDto>;
}
