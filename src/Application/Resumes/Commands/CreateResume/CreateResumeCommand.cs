using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.CreateResume
{
    public record CreateResumeCommand() : IRequest<ErrorOr<CreateResumePayload>>
    {
        public required Guid UserId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string TemplateId { get; init; } = string.Empty;
    }
}