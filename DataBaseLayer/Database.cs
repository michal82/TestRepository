using System;
using System.Threading.Tasks;

namespace DataBaseLayer
{
    public class ValidationError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class Database
    {
        public Task WriteValidationErrorToDbAsync(ValidationError validationError)
        {
            return new Task(() =>
            {
                Console.WriteLine(validationError.Message);
            });
        }
    }
}
