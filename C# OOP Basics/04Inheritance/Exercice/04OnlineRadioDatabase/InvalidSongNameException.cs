public class InvalidSongNameException : InvalidSongException
{
    private const int minLength = 3;
    private const int maxLenght = 30;

    public override string Message => $"Song name should be between {minLength} and {maxLenght} symbols.";
}
