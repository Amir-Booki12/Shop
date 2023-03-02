using Commom.Domain.ValueObjects;
using Common.Query;
using Common.Query.Filter;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.DTOs
{
    public class UserDto:BaseDto
    {
        public string Name { get;  set; }
        public string Family { get;  set; }
        public string Password { get;  set; }
        public string AvatarName { get;  set; }
        public string Email { get;  set; }
        public bool IsActive { get;  set; }
       
        public string PhoneNumber { get;  set; }
        public Gender Gender { get;  set; }
        public List<UserRoleDto> UserRoles { get;  set; }
    }
    public class UserRoleDto : BaseDto
    {
        public long RoleId { get; set; }
        public string RoleTitle { get; set; }
    }

    public class UserFilterData : BaseDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string AvatarName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
    }
    
    public class UserFilterParams:BaseFilterParam
    {
        public long? Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class UserFilterResult:BaseFilter<UserFilterData,UserFilterParams>
    {

    }
}
