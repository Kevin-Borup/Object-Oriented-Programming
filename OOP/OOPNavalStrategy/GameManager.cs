using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNavalStrategy
{
    class GameManager
    {
        /// <summary>
        /// A method which adds the ships to the player's inventory.
        /// </summary>
        /// <returns></returns>
        public List<Ship> ShipList()
        {
            // Ship Types:
            // Carrier - Battleship - Destroyer - Submarine - Scout.
            List<Ship> ships = new List<Ship>();
            
            ships.Add(new Ship("Carrier", 5));
            ships.Add(new Ship("Battleship", 4));
            ships.Add(new Ship("Destroyer", 3));
            ships.Add(new Ship("Submarine", 3));
            ships.Add(new Ship("Scout", 2));

            return ships;
        }
    }
}
