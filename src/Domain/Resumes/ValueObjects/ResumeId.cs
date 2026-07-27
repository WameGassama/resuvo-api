namespace Domain.Resumes.ValueObjects
{
    public sealed class ResumeId : ValueObject
    {
        public Guid Value { get; private set; }

        private ResumeId(Guid value)
        {
            Value = value;
        }

        public static ResumeId CreateUnique() => new(Guid.CreateVersion7());

        public static ResumeId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}