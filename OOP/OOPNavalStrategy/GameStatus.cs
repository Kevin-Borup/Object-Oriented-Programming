using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNavalStrategy
{
    class GameStatus
    {

    }

    class Board
    {
        List<int, char> boardLoc = new List<int, char>();
    }

    class Ship
    {
        private string name;
        private int size, hits;
        private bool operational;

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            Hits = 0;
            Operational = true;
        }
        /// <summary>
        /// Updates the registered hits by one.
        /// </summary>
        public void AddHit()
        {
            Hits++;
        }
        /// <summary>
        /// A method to update the ship to be sunken.
        /// </summary>
        public void Sunken()
        {
            operational = false;
        }

        public string Name { get { return name; } private set { name = value; } }
        public int Size { get { return size; } private set { size = value; } }
        public int Hits { get { return hits; } private set { hits = value; } }
        public bool Operational { get { return operational; } private set { operational = value; } }
    }
}
