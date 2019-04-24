namespace Refactoring.Models
{
    public class OperationResult<T>
    {
        public T Value { get; }
        public bool Succeeded { get; }
        public string ErrorMessage { get; }

        public OperationResult(T value, bool succeeded, string errorMessage)
        {
            Value = value;
            Succeeded = succeeded;
            ErrorMessage = errorMessage;
        }

        public static OperationResult<T> Success(T value)
        {
            return new OperationResult<T>(value, true, string.Empty);
        }

        public static OperationResult<T> Failure(string errorMessage)
        {
            return new OperationResult<T>(default(T), false, errorMessage);
        }
    }
}
