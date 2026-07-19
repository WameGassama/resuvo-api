namespace Domain.Resumes.ValueObjects
{
    public sealed class TemplateId : ValueObject
    {
        public Guid Value { get; private set; }

        private TemplateId(Guid value)
        {
            Value = value;
        }

        public static TemplateId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
