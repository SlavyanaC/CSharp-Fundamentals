using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string artist;
    private string name;
    private int minutes;
    private int seconds;

    public Song(string artist, string name, int minutes, int seconds)
    {
        this.Artist = artist;
        this.Name = name;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string Artist
    {
        get { return artist; }
        set
        {
            if (value?.Length < 3 || value?.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            artist = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value?.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            name = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            seconds = value;
        }
    }
}
