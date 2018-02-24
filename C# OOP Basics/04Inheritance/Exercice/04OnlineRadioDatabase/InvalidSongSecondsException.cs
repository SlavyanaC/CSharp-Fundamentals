public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const int minSeconds = 0;
    private const int maxSeconds = 59;

    public override string Message => $"Song seconds should be between {minSeconds} and {maxSeconds}.";
}
