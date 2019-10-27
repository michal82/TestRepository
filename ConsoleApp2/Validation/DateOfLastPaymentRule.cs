using ConsoleApp2.MappingClasses;

namespace ConsoleApp2.Validation
{
    public class DateOfLastPaymentRule : IValidationRule<Contract>
    {
        public ValidationError Error => new ValidationError
        {
            Code = "2",
            Message = "Contract.DateOfLastPayment attribute value must be before (in time) Contract.NextPaymentDate attribute value"
        };

        public bool Validate(Contract arg)
        {
            return arg.ContractData.DateOfLastPayment < arg.ContractData.NextPaymentDate;
        }
    }
}
