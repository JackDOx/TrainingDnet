using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Authors;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Authors
{
    public class CreateAuthorHandler : AuthorBaseHandler, IRequestHandler<CreateAuthorCommand, bool>
    {
        public CreateAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var author = new Author
            {
                Id = id,
                Name = request.Name,
            };

            _unitOfWork.Author.Insert(author);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

