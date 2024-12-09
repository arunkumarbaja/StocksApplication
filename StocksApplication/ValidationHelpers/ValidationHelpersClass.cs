using System.ComponentModel.DataAnnotations;

namespace StocksApplication.ValidationHelpers
{
    public static class ValidationHelpersClass
    {
        public static void ModelValidations(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);

            List<ValidationResult> Validation_Results = new List<ValidationResult>();

            bool IsValid = Validator.TryValidateObject(obj, validationContext, Validation_Results, true);

            if (IsValid == false)
            {
                throw new ArgumentException(Validation_Results.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
