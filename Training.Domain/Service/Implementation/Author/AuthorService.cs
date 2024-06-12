using MediatR;
using Training.Domain.Command.Authors;
using Training.Domain.Service.Interface.Author;

namespace Training.Domain.Service.Implementation.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly IMediator _mediator;
        public AuthorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateAuthor(CreateAuthorCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteAuthor(DeleteAuthorCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateAuthor(UpdateAuthorCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> GetAuthor(GetAuthorCommand request)
        {
            return await _mediator.Send(request);

        }
    }
}