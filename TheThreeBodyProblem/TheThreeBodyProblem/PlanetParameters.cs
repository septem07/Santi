using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreeBodyProblem
{
    class PlanetParameters
    {
        public double coordX;
        public double coordY;
        public double coordZ;
        public double veloX;
        public double veloY;
        public double veloZ;
        public double currentForceX;
        public double currentForceY;
        public double currentForceZ;
        public double currentForceXp1p2;
        public double currentForceYp1p2;
        public double currentForceZp1p2;
        public double currentForceXp1p3;
        public double currentForceYp1p3;
        public double currentForceZp1p3;
        public double nextForceX;
        public double nextForceY;
        public double nextForceZ;
        public double nextForceXp1p2;
        public double nextForceYp1p2;
        public double nextForceZp1p2;
        public double nextForceXp1p3;
        public double nextForceYp1p3;
        public double nextForceZp1p3;
        public double planetMass;
        public void ForceUpdate(ref double currentForceX, double currentForceXp1p2, double currentForceXp1p3, ref double currentForceY, double currentForceYp1p2, double currentForceYp1p3, ref double currentForceZ, double currentForceZp1p2, double currentForceZp1p3)
        {
            currentForceX = currentForceXp1p2 + currentForceXp1p3;
            currentForceY = currentForceYp1p2 + currentForceYp1p3;
            currentForceZ = currentForceZp1p2 + currentForceZp1p3;
        }
    }

}
