using Training.Domain.Command.UserRoles;

namespace Training.Domain.Service.Interface.UserRole
{
    public interface IUserRoleService
    {
        Task<bool> CreateUserRole(CreateUserRoleCommand request);
        Task<bool> DeleteUserRole(DeleteUserRoleCommand request);
        Task<bool> GetUserRole(GetUserRoleCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateUserRole(UpdateUserRoleCommand request);
    }
}