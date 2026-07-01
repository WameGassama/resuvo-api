namespace Application.Resumes.Queries.GetResume
{
    public record GetResumePayload(Guid Id, Guid UserId, string Name, string TemplateId, DateTime CreatedAt, DateTime UpdatedAt);
}