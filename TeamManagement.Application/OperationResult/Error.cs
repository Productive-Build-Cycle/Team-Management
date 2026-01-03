namespace TeamManagement.Application.OperationResult
{
    public record Error(string Message, ResultErrorCodeType Code)
    {
        public string CodeString => Code.ToString().ToUpper();
    }
}
