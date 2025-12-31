namespace Application.Exception;

public sealed class NotFoundExeption : Exception
{
    public NotFoundExeption(string entityName,object key):base ($"{entityName}with identifier '{key}' was not found.")
    {

    }
}