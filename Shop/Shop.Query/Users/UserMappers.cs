using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users
{
    public static class UserMappers
    {
        public static UserDto Map(this User user)
        {
            return new UserDto()
            {
                AvatarName = user.AvatarName,
                CreationDate = user.CreationDate,
                Email = user.Email,
                Family = user.Family,
                Gender = user.Gender,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                UserRoles = user.UserRoles.Select(s => new UserRoleDto()
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    RoleId = s.RoleId,
                    RoleTitle = ""
                }).ToList()
            };
        }
        public static UserFilterData MapFilter(this User user)
        {
            return new UserFilterData()
            {
                AvatarName = user.AvatarName,
                CreationDate = user.CreationDate,
                Email = user.Email,
                Family = user.Family,
                Gender = user.Gender,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public static async Task<UserDto> SetRoleTitles(this UserDto userDto, ShopContext context)
        {
            var roleIds = userDto.UserRoles.Select(s => s.RoleId);
            var result =await context.Roles.Where(s => roleIds.Contains(s.Id)).ToListAsync();
            var roles = new List<UserRoleDto>();


            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.RoleTitle,
                    CreationDate = role.CreationDate,
                    Id = role.Id

                });
               
            }
            userDto.UserRoles = roles;
            return userDto;
        }
    }
}
