using System.ComponentModel.DataAnnotations;

namespace Bookify.Service.Validations
{
    public class NotEmptyGuid: ValidationAttribute
    {
        private string? DefaultErrorMessage { get; set; }

        public NotEmptyGuid(string? ErrorMessage) : base(ErrorMessage)
        {
            DefaultErrorMessage = ErrorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            var providedGuid = (Guid?)value;
            return providedGuid != Guid.Empty;
        }
    }
}
