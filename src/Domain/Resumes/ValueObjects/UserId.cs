public sealed class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique() => new(Guid.CreateVersion7());

    public static UserId Create(Guid value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}