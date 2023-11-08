using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Comme_Chez_Swa.Models.Reservatie.Utility
{
    public class ExpectedValueAttribute : ValidationAttribute
    {
        private readonly bool _constantValue;
        public ExpectedValueAttribute(bool constantValue)
        {
            _constantValue = constantValue;
        }

        protected override ValidationResult IsValid(object attributedInstance, ValidationContext validationContext)
        {
            // Defensive programming: ensure data state
            if (attributedInstance == null)
                throw new NullReferenceException("Input object cannot be null");
            if (validationContext == null)
                throw new NullReferenceException("Input validation context cannot be null");

            // Command-Query pattern: Query/initialise arguments
            ValidationResult? result = null;

            // Command-Query pattern: Command/produce a result
            if (!_constantValue)
                result = new ValidationResult(ErrorMessage);
            else
                result = ValidationResult.Success!;

            // Publish result
            return result!;
        }
    }
}
