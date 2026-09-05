namespace ApplicationLayer.Exceptions;

public class DuplicateHolidayNameException : Exception
{
    public DuplicateHolidayNameException(string message) : base(message) { }
}
