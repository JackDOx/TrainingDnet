using Training.Domain.Command.Authors;

namespace Training.Domain.Service.Interface.Author
{
    public interface IAuthorService
    {
        Task<bool> CreateAuthor(CreateAuthorCommand request);
        Task<bool> DeleteAuthor(DeleteAuthorCommand request);
        Task<bool> GetAuthor(GetAuthorCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateAuthor(UpdateAuthorCommand request);
    }
}