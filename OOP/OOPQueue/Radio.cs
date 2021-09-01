using System;

namespace OOPQueue
{
    // Radio Manager (Logic)
    static class Radio
    {
        public static void Start()
        {
            RadioGUI.Display.MainMenu();
            MenuNavigation();
        }
        static void MenuNavigation()
        {
            while (true)
                switch (RadioGUI.InputReader<int>())
                {
                    case 1:
                        RadioGUI.Display.AddSong();
                        AddSong();
                        break;
                    case 2:
                        RadioGUI.Display.RemoveSong();
                        RemoveSong();
                        break;
                    case 3:
                        RadioGUI.Display.TrackLength();
                        TrackLength();
                        break;
                    case 4:
                        RadioGUI.Display.SongLength();
                        SongLength();
                        break;
                    case 5:
                        RadioGUI.Display.SearchSong();
                        SearchForSong();
                        break;
                    case 6:
                        RadioGUI.Display.SongList();
                        SongList();
                        break;
                    case 7:
                        RadioGUI.Display.Shutdown();
                        Shutdown();
                        break;
                }
        }

        static void AddSong()
        {

        }
        static void RemoveSong()
        {

        }
        static void TrackLength()
        {

        }
        static void SongLength()
        {

        }
        static void SearchForSong()
        {

        }
        static void SongList()
        {

        }
        static void Shutdown()
        {
            System.Threading.Thread.Sleep(5000);
            Environment.Exit(0);
        }
    }
}
