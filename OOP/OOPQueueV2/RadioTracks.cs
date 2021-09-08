using System.Collections.Generic;

namespace OOPQueueV2
{
    // Collection of songs (Database)
    class RadioCollection
    {
        public List<Track> tracklist = new List<Track>();
        public Dictionary<string, Queue<Song>> tracklist2 = new Dictionary<string, Queue<Song>>();
        
    }

    class Track
    {
        public string trackName;
        public Queue<Song> track = new Queue<Song>();

        public Track(string name)
        {
            trackName = name;
        }
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
