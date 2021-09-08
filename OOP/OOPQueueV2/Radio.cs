﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPQueueV2
{
    // Radio Manager (Logic)
    class Radio
    {
        public void MenuNavigation(int input)
        {
            switch (input)
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


        private void AddSong()
        {
            gui.AddSong();
            string songTitle = gui.InputReader<string>();
            string songArtist = gui.InputReader<string>("Song artist: ");
            string songLength = gui.InputReader<string>("Song length (mm:ss): ");
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

            track.tracklist.Enqueue(new Song(songTitle, songArtist, songLength, songLengthMin, songLengthSec, songLengthTSec));
            gui.Writer("Song Added.", 'n');
            Console.ReadLine();
        }
        private void RemoveSong()
        {
            gui.RemoveSong();
            string songTitle = gui.InputReader<string>();
            string songArtist = gui.InputReader<string>("Song artist: ");

            track.tracklist = new Queue<Song>(track.tracklist.Where(song => (song.Title != songTitle && song.Artist != songArtist)));
            gui.Writer("Song Removed.", 'n');
            Console.ReadLine();
        }
        private void PlaylistLength()
        {
            gui.PlaylistLength();
            Console.WriteLine(track.tracklist.Count);
            Console.ReadLine();
        }
        private void SongLength()
        {
            gui.SongLength();
            int longSongTSec = track.tracklist.Max(song => song.TotalSec);
            string longSong = Convert.ToString(longSongTSec / 60) + ":" + Convert.ToString(longSongTSec % 60);
            gui.Writer(longSong, 'n');


            int shortSongTSec = track.tracklist.Min(song => song.TotalSec);
            string shortSong = Convert.ToString(shortSongTSec / 60) + ":" + Convert.ToString(shortSongTSec % 60);
            gui.Writer("The shortest song is: " + shortSong, 'n');
            Console.ReadLine();

        }
        private void SearchForSong()
        {
            gui.SearchSong();
            string songTitle = gui.InputReader<string>();
            string songArtist = gui.InputReader<string>("Song artist: ");
            songTitle.ToLower();
            songArtist.ToLower();

            List<Song> queueChecker = track.tracklist.Where(song => (song.Title == songTitle && song.Artist == songArtist)).ToList();

            if (queueChecker.Count > 0)
            {
                gui.Writer("Your song is in the playlist, it'll appear " + queueChecker.Count, 'n');
            }
            else
            {
                gui.Writer("The song isn't in the playlist.", 'n');
            }
            Console.ReadLine();
        }
        private void SongList()
        {
            gui.SongList();
            int i = 0;

            foreach (Song song in track.tracklist)
            {
                gui.Writer($"{i + 1}. {song.Title} - {song.Artist} | {song.Length}", 'n');
                i++;
            }
            Console.ReadLine();
        }
        private void Shutdown()
        {
            gui.Shutdown();
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
