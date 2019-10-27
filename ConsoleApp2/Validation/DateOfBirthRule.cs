using ConsoleApp2.MappingClasses;
using DataBaseLayer;
using System;

namespace ConsoleApp2.Validation
{
    public class DateOfBirthRule : IValidationRule<Individual>
    {
        public ValidationError Error => new ValidationError
        {
            Code = "1",
            Message = "Individual.DateOfBirth attribute value must be between 18 and 99 years"
        };

        public bool Validate(Individual arg)
        {
            int years = DateTime.Now.Year - arg.DateOfBirth.Year;
            return (years >= 18) && (years <= 99);
        }
    }
}
