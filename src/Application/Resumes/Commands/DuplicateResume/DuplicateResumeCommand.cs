using Domain;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.DuplicateResume
{
    public record DuplicateResumeCommand(string ResumeId, string UserId) : IRequest<ErrorOr<Resume>>;
}