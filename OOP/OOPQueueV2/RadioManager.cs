using System.Collections.Generic;

namespace OOPQueueV2
{
    class RadioManager
    {
        RadioGUI gui = new RadioGUI();
        Radio radio = new Radio();
        RadioCollection songs = new RadioCollection();

        public void MainSystem()
        {
            songs.tracklist.Add(new Track("Main Track"));
            //songs.tracklist[0].track.Enqueue(new Song)
            int mainIndex = songs.tracklist.FindIndex(track => track.trackName == "Main Track");
            while (true)
            {
                gui.MainMenu();
                switch (gui.InputReader<int>())
                {
                    case 1:

                        gui.AddSong();
                        radio.AddSong();
                        break;
                    case 2:
                        radio.RemoveSong();
                        break;
                    case 3:
                        radio.PlaylistLength();
                        break;
                    case 4:
                        radio.SongLength();
                        break;
                    case 5:
                        radio.SearchForSong();
                        break;
                    case 6:
                        radio.SongList();
                        break;
                    case 7:
                        radio.Shutdown();
                        break;
                }

            }
        }
    }
}
