using Domain.Common.Models;

namespace Domain
{
    public class Resume : AggregateRoot<ResumeId>
    {
        public UserId UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string TemplateId { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        private Resume(
            ResumeId resumeId,
            UserId userId,
            string name,
            string templateId,
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
            string templateId,
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
