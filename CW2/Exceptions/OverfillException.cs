namespace CW2.Exceptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }
    
    public OverfillException(string message) : base(message)
    {
    }

    public OverfillException(string message, Exception innerException) : base(message, innerException)
    {
    }
}