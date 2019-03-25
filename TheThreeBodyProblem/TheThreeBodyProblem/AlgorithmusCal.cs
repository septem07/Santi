using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmus
{
    class AlgorithmusCal
    {
        public void CoordUpdate(ref double coordX, ref double coordY, ref double coordZ, double veloX, double veloY, double veloZ, double currentForceX, double currentForceY, double currentForceZ, double planetMass, double currentTime, double timestep)
        {
            coordX = coordX * (currentTime + timestep) + veloX * timestep + (currentForceX / (2 * planetMass)) * timestep * timestep;
            coordY = coordY * (currentTime + timestep) + veloY * timestep + (currentForceY / (2 * planetMass)) * timestep * timestep;
            coordZ = coordZ * (currentTime + timestep) + veloZ * timestep + (currentForceZ / (2 * planetMass)) * timestep * timestep;

        }
        public void PotentialGMm(double sun1PlanetMass, double sun2PlanetMass, double sun3PlanetMass,
                ref double GMmp1p2, ref double GMmp1p3, ref double GMmp2p3, double gravitationalConstant)
        {
            GMmp1p2 = gravitationalConstant * sun1PlanetMass * sun2PlanetMass;
            GMmp1p3 = gravitationalConstant * sun1PlanetMass * sun3PlanetMass;
            GMmp2p3 = gravitationalConstant * sun2PlanetMass * sun3PlanetMass;
        }
        public void ForceCalculation(double sun1CoordX, double sun1CoordY, double sun1CoordZ, double sun2CoordX, double sun2CoordY, double sun2CoordZ, double sun3CoordX, double sun3CoordY, double sun3CoordZ,
                ref double currentForceXp1p2, ref double currentForceYp1p2, ref double currentForceZp1p2, ref double currentForceXp1p3, ref double currentForceYp1p3, ref double currentForceZp1p3,
                ref double currentForceXp2p1, ref double currentForceYp2p1, ref double currentForceZp2p1, ref double currentForceXp2p3, ref double currentForceYp2p3, ref double currentForceZp2p3,
                ref double currentForceXp3p1, ref double currentForceYp3p1, ref double currentForceZp3p1, ref double currentForceXp3p2, ref double currentForceYp3p2, ref double currentForceZp3p2,
                double GMmp1p2, double GMmp1p3, double GMmp2p3)
        {

            double distanceXp1p2 = (sun1CoordX - sun2CoordX);
            double distanceYp1p2 = (sun1CoordY - sun2CoordY);
            double distanceZp1p2 = (sun1CoordZ - sun2CoordZ);
            double distanceXp1p3 = (sun1CoordX - sun3CoordX);
            double distanceYp1p3 = (sun1CoordY - sun3CoordY);
            double distanceZp1p3 = (sun1CoordZ - sun3CoordZ);
            double distanceXp2p3 = (sun2CoordX - sun3CoordX);
            double distanceYp2p3 = (sun2CoordY - sun3CoordY);
            double distanceZp2p3 = (sun2CoordZ - sun3CoordZ);
            double distanceRPower2p1p2 = distanceXp1p2 * distanceXp1p2 + distanceYp1p2 * distanceYp1p2 + distanceZp1p2 * distanceZp1p2;
            double distanceRPower2p1p3 = distanceXp1p3 * distanceXp1p3 + distanceYp1p3 * distanceYp1p3 + distanceZp1p3 * distanceZp1p3;
            double distanceRPower2p2p3 = distanceXp2p3 * distanceXp2p3 + distanceYp2p3 * distanceYp2p3 + distanceZp2p3 * distanceZp2p3;
            double distanceRp1p2 = Math.Sqrt(distanceRPower2p1p2);
            double distanceRp1p3 = Math.Sqrt(distanceRPower2p1p3);
            double distanceRp2p3 = Math.Sqrt(distanceRPower2p2p3);
            double distanceRmulitinversep1p2 = 1 / distanceRp1p2;
            double distanceRmulitinversep1p3 = 1 / distanceRp1p3;
            double distanceRmulitinversep2p3 = 1 / distanceRp2p3;
            double distanceRPower2Mulitinversep1p2 = 1 / distanceRPower2p1p2;
            double distanceRPower2Mulitinversep1p3 = 1 / distanceRPower2p1p3;
            double distanceRPower2Mulitinversep2p3 = 1 / distanceRPower2p2p3;
            double diffPartp1p2 = distanceRmulitinversep1p2 * distanceRPower2Mulitinversep1p2;
            double diffPartp1p3 = distanceRmulitinversep1p3 * distanceRPower2Mulitinversep1p3;
            double diffPartp2p3 = distanceRmulitinversep2p3 * distanceRPower2Mulitinversep2p3;
            currentForceXp1p2 = GMmp1p2 * distanceXp1p2 * diffPartp1p2;
            currentForceXp2p1 = -currentForceXp1p2;
            currentForceYp1p2 = GMmp1p2 * distanceYp1p2 * diffPartp1p2;
            currentForceYp2p1 = -currentForceYp1p2;
            currentForceZp1p2 = GMmp1p2 * distanceZp1p2 * diffPartp1p2;
            currentForceZp2p1 = -currentForceZp1p2;
            currentForceXp1p3 = GMmp1p3 * distanceXp1p3 * diffPartp1p3;
            currentForceXp3p1 = -currentForceXp1p3;
            currentForceYp1p3 = GMmp1p3 * distanceYp1p3 * diffPartp1p3;
            currentForceYp3p1 = -currentForceYp1p3;
            currentForceZp1p3 = GMmp1p3 * distanceZp1p3 * diffPartp1p3;
            currentForceZp3p1 = -currentForceZp1p3;
            currentForceXp2p3 = GMmp2p3 * distanceXp2p3 * diffPartp2p3;
            currentForceXp3p2 = -currentForceXp2p3;
            currentForceYp2p3 = GMmp2p3 * distanceYp2p3 * diffPartp2p3;
            currentForceYp3p2 = -currentForceYp2p3;
            currentForceZp2p3 = GMmp2p3 * distanceZp2p3 * diffPartp2p3;
            currentForceZp3p2 = -currentForceZp2p3;

        }
        public void VelocityUpdate()
        {

        }
    }
}

