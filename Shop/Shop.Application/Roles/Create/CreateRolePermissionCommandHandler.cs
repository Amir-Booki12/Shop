using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create
{
    public class CreateRolePermissionCommandHandler : IBaseCommandHandler<CreateRolePermissionCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRolePermissionCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new List<RolePermission>();

            request.Permissions.ForEach(f =>
            {
                permission.Add(new RolePermission(f));
            });
            var role = new Role(request.Title, permission);
            _roleRepository.Add(role);
            await _roleRepository.Save();
            return OperationResult.Success();

        }
    }
}
