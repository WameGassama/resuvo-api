using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.RenameResume
{
    public record RenameResumeCommand(string ResumeId, string Name) : IRequest<ErrorOr<Resume>>;
}