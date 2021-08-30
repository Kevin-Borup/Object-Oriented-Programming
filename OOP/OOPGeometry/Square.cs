using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGeometry
{
    class Square
    {
        private float a;

        public float A
        {
            get
            {
                return this.a;
            }
            set
            {
                this.a = value;
            }
        }

        public Square()
        {

        }
        public Square(float number) 
        {
            a = number;
        }

        public float Area()
        {
            return a * a;
        }
        public float Perimet()
        {
            return 4 * a;
        }
    }
}
