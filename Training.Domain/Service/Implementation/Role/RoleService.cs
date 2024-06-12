using MediatR;
using Training.Domain.Command.Roles;
using Training.Domain.Service.Interface.Role;

namespace Training.Domain.Service.Implementation.Role
{
    public class BookService : IAuthorService
    {
        private readonly IMediator _mediator;
        public BookService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateRole(CreateBookCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteRole(DeleteAuthorCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateRole(UpdateAuthorCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> GetRole(GetAuthorCommand request)
        {
            return await _mediator.Send(request);

        }
    }
}