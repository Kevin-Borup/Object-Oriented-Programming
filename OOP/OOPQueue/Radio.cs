using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPQueue
{
    // Radio Manager (Logic)
    static class Radio
    {
        public static void Start()
        {
            MenuNavigation();
        }
        static void MenuNavigation()
        {
            while (true)
            {
                RadioGUI.Display.MainMenu();
                switch (RadioGUI.InputReader<int>())
                {
                    case 1:
                        AddSong();
                        break;
                    case 2:
                        RemoveSong();
                        break;
                    case 3:
                        PlaylistLength();
                        break;
                    case 4:
                        SongLength();
                        break;
                    case 5:
                        SearchForSong();
                        break;
                    case 6:
                        SongList();
                        break;
                    case 7:
                        Shutdown();
                        break;
                }
            }
        }

        static void AddSong()
        {
            RadioGUI.Display.AddSong();
            string songTitle = RadioGUI.InputReader<string>();
            string songArtist = RadioGUI.InputReader<string>("Song artist: ");
            string songLength = RadioGUI.InputReader<string>("Song length (mm:ss): ");
            int songLengthMin;
            int songLengthSec;
            int songLengthTSec;
            string[] songLengthSplit;

            songTitle.ToLower();
            songArtist.ToLower();
            songLengthSplit = songLength.Split(':');
            songLengthMin = int.Parse(songLengthSplit[0]);
            songLengthSec = int.Parse(songLengthSplit[1]);

            songLengthTSec = songLengthMin * 60 + songLengthSec;

            RadioTracks.tracklist.Enqueue(new Song(songTitle, songArtist, songLength, songLengthMin, songLengthSec, songLengthTSec));
            RadioGUI.Display.Writer("Song Added.", 'n');
            Console.ReadLine();
        }
        static void RemoveSong()
        {
            RadioGUI.Display.RemoveSong();
            string songTitle = RadioGUI.InputReader<string>();
            string songArtist = RadioGUI.InputReader<string>("Song artist: ");

            RadioTracks.tracklist = new Queue<Song>(RadioTracks.tracklist.Where(song => ( song.Title != songTitle && song.Artist != songArtist)));
            RadioGUI.Display.Writer("Song Removed.", 'n');
            Console.ReadLine();
        }
        static void PlaylistLength()
        {
            RadioGUI.Display.PlaylistLength();
            Console.WriteLine(RadioTracks.tracklist.Count);
            Console.ReadLine();
        }
        static void SongLength()
        {
            RadioGUI.Display.SongLength();
            int longSongTSec = RadioTracks.tracklist.Max(song => song.TotalSec);
            string longSong = Convert.ToString(longSongTSec / 60) + ":" + Convert.ToString(longSongTSec % 60);
            RadioGUI.Display.Writer(longSong, 'n');


            int shortSongTSec = RadioTracks.tracklist.Min(song => song.TotalSec);
            string shortSong = Convert.ToString(shortSongTSec / 60) + ":" + Convert.ToString(shortSongTSec % 60);
            RadioGUI.Display.Writer("The shortest song is: " + shortSong, 'n');
            Console.ReadLine();

        }
        static void SearchForSong()
        {
            RadioGUI.Display.SearchSong();
            string songTitle = RadioGUI.InputReader<string>();
            string songArtist = RadioGUI.InputReader<string>("Song artist: ");
            songTitle.ToLower();
            songArtist.ToLower();

            List<Song> queueChecker = RadioTracks.tracklist.Where(song => (song.Title == songTitle && song.Artist == songArtist)).ToList();

            if (queueChecker.Count > 0)
            {
                RadioGUI.Display.Writer("Your song is in the playlist, it'll appear " + queueChecker.Count, 'n');
            }
            else
            {
                RadioGUI.Display.Writer("The song isn't in the playlist.", 'n');
            }
            Console.ReadLine();
        }
        static void SongList()
        {
            RadioGUI.Display.SongList();
            int i = 0;

            foreach (Song song in RadioTracks.tracklist)
            {
                RadioGUI.Display.Writer($"{i + 1}. {song.Title} - {song.Artist} | {song.Length}", 'n');
                i++;
            }
            Console.ReadLine();
        }
        static void Shutdown()
        {
            RadioGUI.Display.Shutdown();
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
