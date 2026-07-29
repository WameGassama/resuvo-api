using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.RetitleResume
{
    public record RetitleResumeCommand(string ResumeId, string Title) : IRequest<ErrorOr<Resume>>;
}
