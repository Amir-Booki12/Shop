using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit
{
    public class EditRolePermissionCommandHandler : IBaseCommandHandler<EditRolePermissionCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public EditRolePermissionCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async  Task<OperationResult> Handle(EditRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();
            role.Edit(request.Title);
            var permission = new List<RolePermission>();

            request.Permissions.ForEach(f =>
            {
                permission.Add(new RolePermission(f));
            });
            role.SetPermisstion(permission);
            await _roleRepository.Save();
            return OperationResult.Success();


        }
    }
}
