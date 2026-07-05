using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.DeleteResume
{
    public record DeleteResumeCommand(Guid Id) : IRequest<ErrorOr<DeleteResumePayload>>;
}