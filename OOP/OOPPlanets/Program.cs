using System;
using System.Collections.Generic;

namespace OOPPlanets
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet mercury = new Planet("Mercury");
            Planet venus = new Planet("Venus");
            Planet earth = new Planet("Earth");
            Planet mars = new Planet("Mars");
            Planet jupiter = new Planet("Jupiter");
            Planet saturn = new Planet("Saturn");
            Planet uranus = new Planet("Uranus");
            Planet neptune = new Planet("Neptune");
            Planet pluto = new Planet("Pluto");

            List<Planet> milkyway = new List<Planet>();

            milkyway.Add(mercury);
            milkyway.Add(earth);
            milkyway.Add(mars);
            milkyway.Add(jupiter);
            milkyway.Add(saturn);
            milkyway.Add(uranus);
            milkyway.Add(neptune);
            milkyway.Add(pluto);

            foreach (Planet ufo in milkyway)
            {
                grossPlanetDetailer(ufo);
            }


            Console.WriteLine("Planets: ");
            foreach (Planet ufo in milkyway)
            {
                Console.Write(ufo.Name + " ");
            }


            grossPlanetDetailer(venus);
            milkyway.Insert(milkyway.IndexOf(earth), venus);
            Console.WriteLine("\nPlanets (Added Venus): ");
            foreach (Planet ufo in milkyway)
            {
                Console.Write(ufo.Name + " ");
            }

            milkyway.RemoveAt(milkyway.IndexOf(pluto));
            Console.WriteLine("\nPlanets (Pluto Removed): ");
            foreach (Planet ufo in milkyway)
            {
                Console.Write(ufo.Name + " ");
            }

            Console.WriteLine("\nPlanet Count: ");
            Console.WriteLine(milkyway.Count);

            List<Planet> negativeTemp = new List<Planet>();
            foreach (Planet ufo in milkyway)
            {
                if (ufo.MeanTemperature < 0)
                {
                    negativeTemp.Add(ufo);
                }
            }
            Console.WriteLine("\nMean Temperature List: ");
            foreach (Planet ufo in negativeTemp)
            {
                Console.Write(ufo.Name + " ");
            }

            List<Planet> sizedPlanetList = new List<Planet>();
            foreach (Planet ufo in milkyway)
            {
                if (10000 < ufo.Diameter && ufo.Diameter < 50000)
                {
                    sizedPlanetList.Add(ufo);
                }
            }
            Console.WriteLine("\nDiameter List: ");
            foreach (Planet ufo in sizedPlanetList)
            {
                Console.Write(ufo.Name + " ");
            }

            // Empty every list
            milkyway.Clear();
            negativeTemp.Clear();
            sizedPlanetList.Clear();
        }

        static void grossPlanetDetailer(Planet planet)
        {
            switch (planet.Name)
            {
                case "Mercury":
                    planet.Mass = 0.330f;
                    planet.Diameter = 4879;
                    planet.Density = 5427;
                    planet.Gravity = 3.7f;
                    planet.RotationPeriod = 1407.6f;
                    planet.LengthOfDay = 4222.6f;
                    planet.DistanceFromSun = 57.9f;
                    planet.OrbitalPeriod = 88.0f;
                    planet.OrbitalVelocity = 47.4f;
                    planet.MeanTemperature = 167;
                    planet.NumberOfMoons = 0;
                    planet.AnyRingSystem = false;
                    break;
                case "Venus":
                    planet.Mass = 4.87f;
                    planet.Diameter = 12104;
                    planet.Density = 5243;
                    planet.Gravity = 8.9f;
                    planet.RotationPeriod = -5832.5f;
                    planet.LengthOfDay = 2802.0f;
                    planet.DistanceFromSun = 108.2f;
                    planet.OrbitalPeriod = 224.7f;
                    planet.OrbitalVelocity = 35.0f;
                    planet.MeanTemperature = 464;
                    planet.NumberOfMoons = 0;
                    planet.AnyRingSystem = false;
                    break;
                case "Earth":
                    planet.Mass = 5.97f;
                    planet.Diameter = 12756;
                    planet.Density = 5514;
                    planet.Gravity = 9.8f;
                    planet.RotationPeriod = 23.9f;
                    planet.LengthOfDay = 24.0f;
                    planet.DistanceFromSun = 149.6f;
                    planet.OrbitalPeriod = 365.2f;
                    planet.OrbitalVelocity = 29.8f;
                    planet.MeanTemperature = 15;
                    planet.NumberOfMoons = 1;
                    planet.AnyRingSystem = false;
                    break;
                case "Mars":
                    planet.Mass = 0.642f;
                    planet.Diameter = 6792;
                    planet.Density = 3933;
                    planet.Gravity = 3.7f;
                    planet.RotationPeriod = 24.6f;
                    planet.LengthOfDay = 24.7f;
                    planet.DistanceFromSun = 227.9f;
                    planet.OrbitalPeriod = 687.0f;
                    planet.OrbitalVelocity = 24.1f;
                    planet.MeanTemperature = -65;
                    planet.NumberOfMoons = 2;
                    planet.AnyRingSystem = false;
                    break;
                case "Jupiter":
                    planet.Mass = 1898f;
                    planet.Diameter = 142984;
                    planet.Density = 1326;
                    planet.Gravity = 23.1f;
                    planet.RotationPeriod = 9.9f;
                    planet.LengthOfDay = 9.9f;
                    planet.DistanceFromSun = 778.6f;
                    planet.OrbitalPeriod = 4331f;
                    planet.OrbitalVelocity = 13.1f;
                    planet.MeanTemperature = -110;
                    planet.NumberOfMoons = 67;
                    planet.AnyRingSystem = true;
                    break;
                case "Saturn":
                    planet.Mass = 568f;
                    planet.Diameter = 120536;
                    planet.Density = 687;
                    planet.Gravity = 9.0f;
                    planet.RotationPeriod = 10.7f;
                    planet.LengthOfDay = 10.7f;
                    planet.DistanceFromSun = 1433.5f;
                    planet.OrbitalPeriod = 10747f;
                    planet.OrbitalVelocity = 9.7f;
                    planet.MeanTemperature = -140;
                    planet.NumberOfMoons = 62;
                    planet.AnyRingSystem = true;
                    break;
                case "Uranus":
                    planet.Mass = 86.8f;
                    planet.Diameter = 51118;
                    planet.Density = 1271;
                    planet.Gravity = 8.7f;
                    planet.RotationPeriod = -17.2f;
                    planet.LengthOfDay = 17.2f;
                    planet.DistanceFromSun = 2872.5f;
                    planet.OrbitalPeriod = 30589f;
                    planet.OrbitalVelocity = 6.8f;
                    planet.MeanTemperature = -195;
                    planet.NumberOfMoons = 27;
                    planet.AnyRingSystem = true;
                    break;
                case "Neptune":
                    planet.Mass = 102f;
                    planet.Diameter = 49528;
                    planet.Density = 1638;
                    planet.Gravity = 11.0f;
                    planet.RotationPeriod = 16.1f;
                    planet.LengthOfDay = 16.1f;
                    planet.DistanceFromSun = 4495.1f;
                    planet.OrbitalPeriod = 59800f;
                    planet.OrbitalVelocity = 5.4f;
                    planet.MeanTemperature = -200;
                    planet.NumberOfMoons = 14;
                    planet.AnyRingSystem = true;
                    break;
                case "Pluto":
                    planet.Mass = 0.0146f;
                    planet.Diameter = 2370;
                    planet.Density = 2095;
                    planet.Gravity = 0.7f;
                    planet.RotationPeriod = -153.3f;
                    planet.LengthOfDay = 153.3f;
                    planet.DistanceFromSun = 5906.4f;
                    planet.OrbitalPeriod = 90560;
                    planet.OrbitalVelocity = 4.7f;
                    planet.MeanTemperature = -225;
                    planet.NumberOfMoons = 5;
                    planet.AnyRingSystem = false;
                    break;
                default:
                    break;
            }
        }
    }
}
