using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPlanets
{
    class Planet
    {
        private string name;
        private float mass;
        private int diameter;
        private int density;
        private float gravity;
        private float rotaPeriod;
        private float lenODay;
        private float sunDist;
        private float orbPeriod;
        private float orbVelocity;
        private int meanTemp;
        private int moonCount;
        private bool ringSys;

        public Planet(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
        public float Mass
        {
            get { return this.mass; }
            set { this.mass = value; }
        }

        public int Diameter
        {
            get { return this.diameter; }
            set { this.diameter = value; }
        }

        public int Density
        {
            get { return this.density; }
            set { this.density = value; }
        }
        public float Gravity
        {
            get { return this.gravity; }
            set { this.gravity = value; }
        }
        public float RotationPeriod
        {
            get { return this.rotaPeriod; }
            set { this.rotaPeriod = value; }
        }
        public float LengthOfDay
        {
            get { return this.lenODay; }
            set { this.lenODay = value; }
        }
        public float DistanceFromSun
        {
            get { return this.sunDist; }
            set { this.sunDist = value; }
        }
        public float OrbitalPeriod
        {
            get { return this.orbPeriod; }
            set { this.orbPeriod = value; }
        }
        public float OrbitalVelocity
        {
            get { return this.orbVelocity; }
            set { this.orbPeriod = value; }
        }
        public int MeanTemperature
        {
            get { return this.meanTemp; }
            set { this.meanTemp = value; }
        }
        public int NumberOfMoons
        {
            get { return this.moonCount; }
            set { this.moonCount = value; }
        }
        public bool AnyRingSystem
        {
            get { return this.ringSys; }
            set { this.ringSys = value; }
        }

    }
}
