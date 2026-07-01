using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.DeleteResume
{
    public record DeleteResumeCommand() : IRequest<ErrorOr<DeleteResumePayload>>
    {
        public required Guid Id { get; init; }
    }
}