using DataBaseLayer;

namespace ConsoleApp2.Validation
{
    public interface IValidationRule<T>
    {
        ValidationError Error { get; }
        bool Validate(T arg);
    }
}
