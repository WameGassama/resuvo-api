namespace Application.Resumes
{
    public record ResumeDTO(Guid Id, Guid UserId, string Name, string TemplateId, DateTime CreatedAt, DateTime UpdatedAt);
}
