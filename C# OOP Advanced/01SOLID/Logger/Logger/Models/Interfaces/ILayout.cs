namespace Logger.Models.Interfaces
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}