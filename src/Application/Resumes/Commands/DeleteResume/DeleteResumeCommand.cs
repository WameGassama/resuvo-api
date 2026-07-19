using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.DeleteResume
{
    public record DeleteResumeCommand(string Id) : IRequest<ErrorOr<Deleted>>;
}