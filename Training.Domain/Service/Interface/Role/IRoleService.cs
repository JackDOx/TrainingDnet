using Training.Domain.Command.Roles;

namespace Training.Domain.Service.Interface.Role
{
    public interface IRoleService
    {
        Task<bool> CreateRole(CreateRoleCommand request);
        Task<bool> DeleteRole(DeleteRoleCommand request);
        Task<bool> GetRole(GetRoleCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateRole(UpdateRoleCommand request);
    }
}