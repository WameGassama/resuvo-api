using Domain.Common.Models;
using Domain.Resumes.ValueObjects;

namespace Domain
{
    public class Resume : AggregateRoot<ResumeId>
    {
        public UserId UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public TemplateId TemplateId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        
        private Resume(
            ResumeId resumeId,
            UserId userId,
            string name,
            TemplateId templateId,
            DateTime createdAt,
            DateTime updatedAt) : base(resumeId)
        {
            UserId = userId;
            Name = name;
            TemplateId = templateId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Resume Create(UserId userId,
            string name,
            TemplateId templateId,
            DateTime createdAt,
            DateTime updatedAt)
        {
            return new(ResumeId.CreateUnique(), userId, name, templateId, createdAt, updatedAt);
        }

        private Resume()
        {

        }
    }
}
