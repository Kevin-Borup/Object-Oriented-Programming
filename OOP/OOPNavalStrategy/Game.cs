using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNavalStrategy
{
    class Game
    {
        GUI ui = new GUI();
        GameManager gm = new GameManager();
        GameStatus board = new GameStatus();

        List<Ship> user1, user2;
        /// <summary>
        /// The main manager of the board game itself.
        /// </summary>
        public void Start()
        {
            // ASK ABOUT THIS!
            (user1, user2) = (gm.ShipList(), gm.ShipList());
            user1 = user2 = gm.ShipList();

            user1 = gm.ShipList();
            user2 = gm.ShipList();

        }
    }
}
