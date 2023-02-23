using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList
{
    public class GetListRoleQueryHandler : IQueryHandler<GetListRoleQuery, List<RoleDto>>
    {
        private readonly ShopContext _context;

        public GetListRoleQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<RoleDto>> Handle(GetListRoleQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.Select(role => new RoleDto()
            {
                RoleTitle = role.RoleTitle,
                CreationDate = role.CreationDate,
                Id = role.Id,
                Permissions = role.Permissions.Select(s => s.Permission).ToList()
            }).ToListAsync();
        }
    }
}
