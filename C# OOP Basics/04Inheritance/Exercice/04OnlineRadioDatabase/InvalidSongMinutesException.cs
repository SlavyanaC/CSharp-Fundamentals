public class InvalidSongMinutesException : InvalidSongLengthException
{
    private const int minMinutes = 0;
    private const int maxMinutes = 14;

    public override string Message => $"Song minutes should be between {minMinutes} and {maxMinutes}.";
}
