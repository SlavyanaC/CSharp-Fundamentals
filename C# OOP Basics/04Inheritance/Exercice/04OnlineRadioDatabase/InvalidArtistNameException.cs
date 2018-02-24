public class InvalidArtistNameException : InvalidSongException
{
    private const int minLength = 3;
    private const int maxLength = 20;

    public override string Message => $"Artist name should be between {minLength} and {maxLength} symbols.";
}
