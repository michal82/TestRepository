using ConsoleApp2.MappingClasses;
using DataBaseLayer;
using System.Linq;

namespace ConsoleApp2.Validation
{
    public class GuaranteeAmountRule : IValidationRule<Contract>
    {
        public ValidationError Error => new ValidationError
        {
            Code = "4",
            Message = "Sum of ( SubjectRole.GuaranteeAmount ) attribute values must be lower than the Contract.OriginalAmount attribute value"
        };

        public bool Validate(Contract arg)
        {
            return arg.SubjectRole.Sum(x => x.GuaranteeAmount != null ? x.GuaranteeAmount.Value : 0) < arg.ContractData.OriginalAmount.Value;
        }
    }
}
