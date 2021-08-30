using System;

namespace OOPGeometry
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opgave A
            Square mainBuilding = new Square(4);
            Square sideBuilding = new Square(6);
            Square downBuilding = new Square(2);
            Square endBuilding = new Square(7.4f);

            Console.WriteLine("Opgave A");
            Console.WriteLine("Area: ");
            Console.WriteLine(mainBuilding.Area());
            Console.WriteLine(sideBuilding.Area());
            Console.WriteLine(downBuilding.Area());
            Console.WriteLine(endBuilding.Area());

            Console.WriteLine("Circumference: ");
            Console.WriteLine(mainBuilding.Perimet());
            Console.WriteLine(sideBuilding.Perimet());
            Console.WriteLine(downBuilding.Perimet());
            Console.WriteLine(endBuilding.Perimet());

            // Opgave b
            Square main2Building = new Square();
            Square side2Building = new Square();
            Square down2Building = new Square();
            Square end2Building = new Square();

            main2Building.A = 4;
            main2Building.A = 6;
            main2Building.A = 2;
            main2Building.A = 7.4f;
            
            Console.WriteLine("Opgave B");
            Console.WriteLine("Opgave B");
            Console.WriteLine("Area: ");
            Console.WriteLine(main2Building.Area());
            Console.WriteLine(side2Building.Area());
            Console.WriteLine(down2Building.Area());
            Console.WriteLine(end2Building.Area());

            Console.WriteLine("Circumference: ");
            Console.WriteLine(main2Building.Perimet());
            Console.WriteLine(side2Building.Perimet());
            Console.WriteLine(down2Building.Perimet());
            Console.WriteLine(end2Building.Perimet());
        }
    }
}
