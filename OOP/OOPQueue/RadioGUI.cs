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
                "|                    Main Menu                   |\n" +
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
                string addSong =
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|                   Add a song                   |\n" +
                "==================================================\n" +
                "\n" +
                "Song title: ";

                Console.Clear();
                Console.Write(addSong);
            }
            public static void RemoveSong()
            {
                string removeSong =
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|                 Remove a song                  |\n" +
                "==================================================\n" +
                "\n" +
                "Song title: ";

                Console.Clear();
                Console.Write(removeSong);
            }
            public static void PlaylistLength()
            {
                string playlistLength =
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|                Playlist Length                 |\n" +
                "==================================================\n" +
                "\n" +
                "Song count of the playlist: ";

                Console.Clear();
                Console.Write(playlistLength);
            }
            public static void SongLength()
            {
                string songLength =
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|                  Song Length                   |\n" +
                "==================================================\n" +
                "\n" +
                "The longest song is: ";

                Console.Clear();
                Console.Write(songLength);
            }
            public static void SearchSong()
            {
                string searchSong =
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|               Search for a song                |\n" +
                "==================================================\n" +
                "\n" +
                "Song title: ";

                Console.Clear();
                Console.Write(searchSong);
            }
            public static void SongList()
            {
                string songList =
                "==================================================\n" +
                "|                                                |\n" +
                "|              Radio Operation Menu              |\n" +
                "|                    Playlist                    |\n" +
                "==================================================\n" +
                "\n" +
                "";

                Console.Clear();
                Console.Write(songList);
            }
            public static void Shutdown()
            {
                string goodbye =
                "==================================================\n" +
                "|                                                |\n" +
                "|            This was the radio system           |\n" +
                "|                Have a nice day :)              |\n" +
                "==================================================\n";

                Console.Clear();
                Console.WriteLine(goodbye);
            }
            public static void Writer(string output, char varient = ' ')
            {
                if (varient != 'n')
                {
                    Console.Write(output);
                }
                else
                {
                    Console.WriteLine(output);
                }
            }
        }

        public static dynamic InputReader<T>(string output = "")
        {
            Console.Write(output);
            string input = Console.ReadLine();

            if (typeof(T) == typeof(int))
            {
                return int.Parse(input);
            }
            return input;
        }
    }
}