using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.CreateResume
{
    public record CreateResumeCommand(Guid UserId, string Name, string TemplateId) : IRequest<ErrorOr<CreateResumePayload>>;
}