using Training.Domain.Command.Roles;

namespace Training.Domain.Service.Interface.Role
{
    public interface IAuthorService
    {
        Task<bool> CreateRole(CreateBookCommand request);
        Task<bool> DeleteRole(DeleteAuthorCommand request);
        Task<bool> GetRole(GetAuthorCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateRole(UpdateAuthorCommand request);
    }
}