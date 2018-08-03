using CP.Domain.ValueObjects;

namespace CP.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
