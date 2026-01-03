namespace TeamManagement.Application.OperationResult
{
    public enum ResultErrorCodeType
    {
        Unknown = 0,

        // 1xx - Client errors
        ValidationError = 100,
        NotFound = 101,
        Duplicate = 102,
        AccessDenied = 103,
        Unauthorized = 104,

        // 2xx - Server errors
        Unexpected = 200,
        DatabaseError = 201,
        ExternalServiceError = 202,
        DatabaseDidNotChange = 203,
    }
}
