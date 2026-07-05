namespace Application.Resumes.Commands.CreateResume
{
    public record CreateResumePayload(ResumeDTO Resume);

    public record ResumeDTO(Guid Id, Guid UserId, string Name, string TemplateId, DateTime CreatedAt, DateTime UpdatedAt);
}