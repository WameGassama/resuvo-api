using Domain;

namespace Application.Resumes.Commands.CreateResume
{
    public record CreateResumePayload(Guid Id, Guid UserId, string Name, string TemplateId, DateTime CreatedAt, DateTime UpdatedAt);
}