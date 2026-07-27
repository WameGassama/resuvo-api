using System.Text.RegularExpressions;
using Throw;

public partial class Email : ValueObject
{
    public string? Value { get; private set; }

    private Email(string? value)
    {
        if (value is null)
        {
            Value = null;
        }
        else
        {
            Value = value.Throw("Email address is not valid!").IfNotMatches(MyRegex());
        }
    }

    public static Email Create(string? value) => new(value);

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex MyRegex();

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}