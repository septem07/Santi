using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheThreeBodyProblem;
using Algorithmus;
using InputandOutput;
using PlanetParameters;
namespace MainCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet sun1 = new Planet();
            Planet sun2 = new Planet();
            Planet sun3 = new Planet();
            AlgorithmusCal calculationProcess = new AlgorithmusCal();
            double timestep = 0;
            double currentTime = 0;
            double finishTime = 0;
            ReadWrite.ReadData(ref timestep, ref finishTime, ref sun1.coordX, ref sun1.coordY, ref sun1.coordZ, ref sun1.veloX, ref sun1.veloY, ref sun1.veloZ, ref sun1.planetMass,
            ref sun2.coordX, ref sun2.coordY, ref sun2.coordZ, ref sun2.veloX, ref sun2.veloY, ref sun2.veloZ, ref sun2.planetMass,
            ref sun3.coordX, ref sun3.coordY, ref sun3.coordZ, ref sun3.veloX, ref sun3.veloY, ref sun3.veloZ, ref sun3.planetMass);
            string writeLineSun1;
            string writeLineSun2;
            string writeLineSun3;
            double countStep = finishTime / timestep;
            double GMmp1p2 = 0;
            double GMmp1p3 = 0;
            double GMmp2p3 = 0;

            calculationProcess.PotentialGMm(sun1.planetMass, sun2.planetMass, sun3.planetMass,
                ref GMmp1p2, ref GMmp1p3, ref GMmp2p3, ConstantsParameter.gravitationalConstant);
            //Initialize force
            calculationProcess.ForceCalculation(sun1.coordX, sun1.coordY, sun1.coordZ, sun2.coordX, sun2.coordY, sun2.coordZ, sun3.coordX, sun3.coordY, sun3.coordZ,
                ref sun1.currentForceXp1p2, ref sun1.currentForceYp1p2, ref sun1.currentForceZp1p2, ref sun1.currentForceXp1p3, ref sun1.currentForceYp1p3, ref sun1.currentForceZp1p3,
                ref sun2.currentForceXp1p2, ref sun2.currentForceYp1p2, ref sun2.currentForceZp1p2, ref sun2.currentForceXp1p3, ref sun2.currentForceYp1p3, ref sun2.currentForceZp1p3,
                ref sun3.currentForceXp1p2, ref sun3.currentForceYp1p2, ref sun3.currentForceZp1p2, ref sun3.currentForceXp1p3, ref sun3.currentForceYp1p3, ref sun3.currentForceZp1p3,
                GMmp1p2, GMmp1p2, GMmp1p2);
            sun1.ForceUpdate(ref sun1.currentForceX, sun1.currentForceXp1p2, sun1.currentForceXp1p3, ref sun1.currentForceY, sun1.currentForceYp1p2, sun1.currentForceYp1p3,
                ref sun1.currentForceZ, sun1.currentForceZp1p2, sun1.currentForceZp1p3);
            sun2.ForceUpdate(ref sun2.currentForceX, sun2.currentForceXp1p2, sun2.currentForceXp1p3, ref sun2.currentForceY, sun2.currentForceYp1p2, sun2.currentForceYp1p3,
                ref sun2.currentForceZ, sun2.currentForceZp1p2, sun2.currentForceZp1p3);
            sun3.ForceUpdate(ref sun3.currentForceX, sun3.currentForceXp1p2, sun3.currentForceXp1p3, ref sun3.currentForceY, sun3.currentForceYp1p2, sun3.currentForceYp1p3,
                ref sun3.currentForceZ, sun3.currentForceZp1p2, sun3.currentForceZp1p3);
            ReadWrite.DeleteOldWriteFile();

            for (int i = 1; i <= countStep; i++)
            {
                //Calculation position, loop from here
                calculationProcess.CoordUpdate(ref sun1.coordX, ref sun1.coordY, ref sun1.coordZ, sun1.veloX, sun1.veloY, sun1.veloZ,
                    sun1.currentForceX, sun1.currentForceY, sun1.currentForceZ, sun1.planetMass, currentTime, timestep);
                calculationProcess.CoordUpdate(ref sun2.coordX, ref sun2.coordY, ref sun2.coordZ, sun2.veloX, sun2.veloY, sun2.veloZ,
                    sun2.currentForceX, sun2.currentForceY, sun2.currentForceZ, sun2.planetMass, currentTime, timestep);
                calculationProcess.CoordUpdate(ref sun3.coordX, ref sun3.coordY, ref sun3.coordZ, sun3.veloX, sun3.veloY, sun3.veloZ,
                    sun3.currentForceX, sun3.currentForceY, sun3.currentForceZ, sun3.planetMass, currentTime, timestep);

                //Updateforce
                calculationProcess.ForceCalculation(sun1.coordX, sun1.coordY, sun1.coordZ, sun2.coordX, sun2.coordY, sun2.coordZ, sun3.coordX, sun3.coordY, sun3.coordZ,
                   ref sun1.currentForceXp1p2, ref sun1.currentForceYp1p2, ref sun1.currentForceZp1p2, ref sun1.currentForceXp1p3, ref sun1.currentForceYp1p3, ref sun1.currentForceZp1p3,
                   ref sun2.currentForceXp1p2, ref sun2.currentForceYp1p2, ref sun2.currentForceZp1p2, ref sun2.currentForceXp1p3, ref sun2.currentForceYp1p3, ref sun2.currentForceZp1p3,
                   ref sun3.currentForceXp1p2, ref sun3.currentForceYp1p2, ref sun3.currentForceZp1p2, ref sun3.currentForceXp1p3, ref sun3.currentForceYp1p3, ref sun3.currentForceZp1p3,
                   GMmp1p2, GMmp1p2, GMmp1p2);
                sun1.ForceUpdate(ref sun1.currentForceX, sun1.currentForceXp1p2, sun1.currentForceXp1p3, ref sun1.currentForceY, sun1.currentForceYp1p2, sun1.currentForceYp1p3,
                    ref sun1.currentForceZ, sun1.currentForceZp1p2, sun1.currentForceZp1p3);
                sun2.ForceUpdate(ref sun2.currentForceX, sun2.currentForceXp1p2, sun2.currentForceXp1p3, ref sun2.currentForceY, sun2.currentForceYp1p2, sun2.currentForceYp1p3,
                    ref sun2.currentForceZ, sun2.currentForceZp1p2, sun2.currentForceZp1p3);
                sun3.ForceUpdate(ref sun3.currentForceX, sun3.currentForceXp1p2, sun3.currentForceXp1p3, ref sun3.currentForceY, sun3.currentForceYp1p2, sun3.currentForceYp1p3,
                    ref sun3.currentForceZ, sun3.currentForceZp1p2, sun3.currentForceZp1p3);
                writeLineSun1 = System.Convert.ToString(sun1.coordX + "," + sun1.coordY + "," + sun1.coordZ);
                writeLineSun2 = System.Convert.ToString(sun2.coordX + "," + sun2.coordY + "," + sun2.coordZ);
                writeLineSun3 = System.Convert.ToString(sun3.coordX + "," + sun3.coordY + "," + sun3.coordZ);
                ReadWrite.WriteData(writeLineSun1,1);
                ReadWrite.WriteData(writeLineSun2,2);
                ReadWrite.WriteData(writeLineSun3,3);
            }
            //Console.WriteLine("{0},{1},{2}", sun1.coordX, sun1.coordY, sun1.coordZ);
            Console.ReadLine();




        }
    }
}
