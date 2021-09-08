
namespace OOPQueueV2
{
    class RadioManager
    {
        RadioGUI gui = new RadioGUI();
        Radio radio = new Radio();
        RadioTracks track = new RadioTracks();

        public void MainSystem()
        {
            while (true)
            {
                gui.MainMenu();
                gui.MenuNavigation(gui.InputReader<int>());
            }
        }
    }
}
