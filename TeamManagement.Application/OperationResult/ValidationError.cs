namespace TeamManagement.Application.OperationResult
{
    public class ValidationError
    {
        public string Field { get; set; }
        public List<string> MessageList { get; set; } = new();
        public string Messages => string.Join(",", MessageList);
        public bool IsValid => !MessageList.Any();

        public ValidationError(string field)
        {
            Field = field;
        }

        public ValidationError(string field, List<string> messages) : this(field)
        {
            MessageList = messages;
        }

        public ValidationError(string field, string message) : this(field, new List<string> { message }) { }

        public void Add(string message)
        {
            MessageList.Add(message);
        }
    }
}
