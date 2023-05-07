using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectRepository _projectRepositorty;
        public CreateCommentCommandHandler(IProjectRepository projectRepositorty)
        {
            _projectRepositorty = projectRepositorty;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            ProjectComment comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _projectRepositorty.AddCommentAsync(comment);

            return Unit.Value;
        }
    }
}
