using System;
using System.Collections.Generic;
using System.Linq;

namespace _04OnlineRadioDatabase
{
    class StartUp
    {
        static void Main()
        {
            List<Song> songs = new List<Song>();
            int songsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < songsCount; i++)
            {
                try
                {
                    string[] songArgs = Console.ReadLine().Split(';');
                    string artist = songArgs[0];
                    string name = songArgs[1];

                    try
                    {
                        var tryPerseDigits = songArgs[2].Split(':').Select(int.Parse).ToArray();
                    }
                    catch (Exception)
                    {
                        throw new InvalidSongLengthException();
                    }

                    int[] songLengthArgs = songArgs[2].Split(':').Select(int.Parse).ToArray();
                    int minutes = songLengthArgs[0];
                    int seconds = songLengthArgs[1];

                    Song song = new Song(artist, name, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var totalDuration = songs.Sum(s => s.Minutes * 60 + s.Seconds);
            var totalHours = totalDuration / 60 / 60;
            var totalMinutes = (totalDuration / 60) - (totalHours * 60);
            var totalSeconds = totalDuration % 60;

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {totalHours}h {totalMinutes}m {totalSeconds}s");
        }
    }
}
