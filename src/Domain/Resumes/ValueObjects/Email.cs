namespace Domain.Resumes.ValueObjects
{
    public class Email : ValueObject
    {
        public string? Value { get; private set; }

        private Email(string? value)
        {
            Value = value;
        }

        public static Email Create(string? value) => new(value);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}