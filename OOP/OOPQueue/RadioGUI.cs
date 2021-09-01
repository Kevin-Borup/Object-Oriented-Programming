using System;

namespace OOPQueue
{
    // Radio Display System (GUI)
    static class RadioGUI
    {
        public static class Display
        {
            public static void MainMenu()
            {
                string mainMenu = 
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|                                                |\n" +
                "==================================================\n" +
                "\n" +
                "1. Add song \n" +
                "2. Remove song \n" +
                "3. Show track length \n" +
                "4. Display shortest & longest song \n" +
                "5. Search for a song \n" +
                "6. Preview tracklist\n" +
                "7. End broadcast\n" +
                "\n" +
                "Enter your choice: ";

                Console.Clear();
                Console.Write(mainMenu);
            }
            public static void AddSong()
            {

            }
            public static void RemoveSong()
            {

            }
            public static void TrackLength()
            {

            }
            public static void SongLength()
            {

            }
            public static void SearchSong()
            {

            }
            public static void SongList()
            {

            }
            public static void Shutdown()
            {
                Console.Clear();
                Console.WriteLine("Have a nice day! :)");
            }
        }

        public static dynamic InputReader<T>()
        {
            string input = Console.ReadLine();

            if (typeof(T) == typeof(int))
            {
                return int.Parse(input);
            }
            return input;
        }
    }
}