using System;

public class InvalidSongException : Exception
{
    private string exeptionMessage = "Invalid song.";

    public virtual string ExeptionMesage
    {
        set => this.exeptionMessage = value;
    }

    public override string Message => exeptionMessage;
}
