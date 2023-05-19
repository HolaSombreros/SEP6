namespace MovieManagement.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class OptionalStringLengthAttribute : StringLengthAttribute
{
    public OptionalStringLengthAttribute(int maximumLength) : base(maximumLength)
    {
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        var length = ((string)value).Length;
        if (length == 0)
        {
            return true;
        }

        return base.IsValid(value);
    }
}
