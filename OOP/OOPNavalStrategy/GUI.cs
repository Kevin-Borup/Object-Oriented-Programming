using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNavalStrategy
{
    class GUI
    {
        /// <summary>
        /// Provides the user with feedback from the shot taken.
        /// </summary>
        /// <param name="hit"></param>
        public void Feedback(int hit)
        {
            switch (hit)
            {
                case 1:
                    Console.WriteLine("HIT!");
                    break;
                case 2:
                    Console.WriteLine("HIT & SUNKEN!");
                    break;
                default:
                    Console.WriteLine("SPLASH!");
                    break;
            }
        }
        /// <summary>
        /// A dynamic method which returns the datatype specified on calling the method.
        /// It uses the provided datatype to determine how to process the user input.
        /// </summary>
        /// <typeparam name="TReturn">Used to specify datatype of return</typeparam>
        /// <returns>Returns the value of TReturn.</returns>
        public dynamic InputReader<TReturn>()
        {
            string input = Console.ReadLine();

            if (typeof(TReturn) == typeof(int))
            {
                return int.Parse(input);
            }
            return input;
        }
    }
}
