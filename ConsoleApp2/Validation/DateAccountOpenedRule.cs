using ConsoleApp2.MappingClasses;
using DataBaseLayer;

namespace ConsoleApp2.Validation
{
    public class DateAccountOpenedRule : IValidationRule<Contract>
    {
        public ValidationError Error => new ValidationError
        {
            Code = "3",
            Message = "Contract.DateAccountOpened attribute value must be before (in time) Contract.DateOfLastPayment attribute value"
        };

        public bool Validate(Contract arg)
        {
            return arg.ContractData.DateAccountOpened < arg.ContractData.DateOfLastPayment;
        }
    }
}
