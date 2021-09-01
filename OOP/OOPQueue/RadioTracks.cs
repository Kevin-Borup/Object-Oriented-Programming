using System.Collections.Generic;

namespace OOPQueue
{
    // Collection of songs (Database)
    static class RadioTracks
    {
        static Queue<Song> tracklist = new Queue<Song>();
    }
    class Song
    {
        public string Name { get; set; }
        public int LengthSec { get; set; }
        public int LengthMin { get; set; }
        public int TotalSec { get; set; }
    }
}
