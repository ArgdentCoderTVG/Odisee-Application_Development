namespace Comme_Chez_Swa.Models.Reservatie.Utility
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public class EmailConfirmationAttribute : ValidationAttribute
    {
        private readonly string _emailPropertyName;

        public EmailConfirmationAttribute(string emailPropertyName)
        {
            _emailPropertyName = emailPropertyName;
        }

        protected override ValidationResult IsValid(object? emailConfirmObject, ValidationContext? emailValidationContext)
        {
            // Defensive programming: ensure data state
            if (emailConfirmObject == null) 
                throw new NullReferenceException("Input object cannot be null");
            if (emailValidationContext == null) 
                throw new NullReferenceException("Input validation context cannot be null");
            if (emailValidationContext.ObjectType?.GetProperty(_emailPropertyName) == null) 
                throw new NullReferenceException($"Property \"{_emailPropertyName}\" not found");
            if (emailValidationContext.ObjectType?.GetProperty(_emailPropertyName) == null) 
                throw new NullReferenceException($"Property \"{_emailPropertyName}\" not found");
            if (emailValidationContext.ObjectType?.GetProperty(_emailPropertyName)!.GetValue(emailValidationContext.ObjectInstance) == null) 
                throw new NullReferenceException($"Property value for \"{_emailPropertyName}\" not found");

            // Command-Query pattern: Query/initialise arguments
            ValidationResult? result = null;
            PropertyInfo emailPropertyInfo = emailValidationContext.ObjectType.GetProperty(_emailPropertyName)!;
            string emailConfirmValue = emailConfirmObject.ToString()!;
            string emailValue = emailPropertyInfo.GetValue(emailValidationContext.ObjectInstance)!.ToString()!;

            // Command-Query pattern: Command/produce a result
            if (!string.Equals(emailConfirmValue, emailValue, StringComparison.OrdinalIgnoreCase))
                result = new ValidationResult(ErrorMessage);
            else
                result = ValidationResult.Success!;

            // Publish result
            return result!;
        }
    }

}