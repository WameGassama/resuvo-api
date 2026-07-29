using Domain;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.CreateResume
{
    public record CreateResumeCommand(string UserId, string Title, string TemplateId) : IRequest<ErrorOr<Resume>>;
}