using System.Collections.Generic;

namespace OOPQueue
{
    // Collection of songs (Database)
    static class RadioTracks
    {
        public static Queue<Song> tracklist = new Queue<Song>();
    }
    class Song
    {
        public Song(string title, string artist)
        {
            this.Title = title;
            this.Artist = artist;
        }
        public Song(string title, string artist, string length, int lengthMin, int lengthSec, int totalSec)
        {
            this.Title = title;
            this.Artist = artist;
            this.Length = length;
            this.LengthMin = lengthMin;
            this.LengthSec = lengthSec;
            this.TotalSec = totalSec;
        }
        public string Title { get; }
        public string Artist { get; }
        public string Length { get; }
        public int LengthMin { get; }
        public int LengthSec { get; }
        public int TotalSec { get; }
    }
}
