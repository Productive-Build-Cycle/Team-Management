namespace TeamManagement.Application.OperationResult
{
    public class ValidationResult : Result
    {
        public override bool IsSuccess => Errors == null || Errors.Count == 0;
        public List<ValidationError>? Errors { get; set; }

        private ValidationResult(List<ValidationError> errors)
            : base(false, new Error("Validation failed", ResultErrorCodeType.ValidationError))
        {
            Errors = errors;
        }

        public static ValidationResult Fail(List<ValidationError> errors) => new ValidationResult(errors);
    }
}
