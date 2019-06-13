using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputandOutput
{
    class ReadWrite
    {

        public static void DataAssignment(ref string readParaString, ref double readXParameter, ref double readYParameter, ref double readZParameter)
        {
            string[] parametersCut = readParaString.Trim().Split(',');
            readXParameter = System.Convert.ToDouble(parametersCut[0]);
            readYParameter = System.Convert.ToDouble(parametersCut[1]);
            readZParameter = System.Convert.ToDouble(parametersCut[2]);
        }
        private string ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData.ToString();

        }

        public static void ReadData(ref double timestep, ref double finishTime, ref double sun1coordX, ref double sun1coordY, ref double sun1coordZ, ref double sun1veloX, ref double sun1veloY, ref double sun1veloZ, ref double sun1planetMass,
            ref double sun2coordX, ref double sun2coordY, ref double sun2coordZ, ref double sun2veloX, ref double sun2veloY, ref double sun2veloZ, ref double sun2planetMass,
            ref double sun3coordX, ref double sun3coordY, ref double sun3coordZ, ref double sun3veloX, ref double sun3veloY, ref double sun3veloZ, ref double sun3planetMass)

        {
            
            string readLine;
            int counter = 0;
          
            string system_language;
            system_language = System.Globalization.CultureInfo.CurrentCulture.Name;
            StreamReader textfile;
            if (system_language.Contains("DE")) 
            {
            textfile = new System.IO.StreamReader("testdata_comma.txt");
            }
            else
            {
            textfile = new System.IO.StreamReader("testdata_point.txt");
            }
            while ((readLine = textfile.ReadLine()) != null)
            {
                switch (counter)
                {
                    case 0:
                        timestep = System.Convert.ToDouble(readLine);
                        counter++;
                        break;
                    case 1:
                        finishTime = System.Convert.ToDouble(readLine); ;
                        counter++;
                        break;
                    case 2:
                        DataAssignment(ref readLine, ref sun1coordX, ref sun1coordY, ref sun1coordZ);
                        counter++;
                        break;
                    case 3:
                        DataAssignment(ref readLine, ref sun1veloX, ref sun1veloY, ref sun1veloZ);
                        counter++;
                        break;
                    case 4:
                        sun1planetMass = System.Convert.ToDouble(readLine);
                        counter++;
                        break;
                    case 5:
                        DataAssignment(ref readLine, ref sun2coordX, ref sun2coordY, ref sun2coordZ);
                        counter++;
                        break;
                    case 6:
                        DataAssignment(ref readLine, ref sun2veloX, ref sun2veloY, ref sun2veloZ);
                        counter++;
                        break;
                    case 7:
                        sun2planetMass = System.Convert.ToDouble(readLine);
                        counter++;
                        break;
                    case 8:
                        DataAssignment(ref readLine, ref sun3coordX, ref sun3coordY, ref sun3coordZ);
                        counter++;
                        break;
                    case 9:
                        DataAssignment(ref readLine, ref sun3veloX, ref sun3veloY, ref sun3veloZ);
                        counter++;
                        break;
                    case 10:
                        sun3planetMass = System.Convert.ToDouble(readLine);
                        counter++;
                        break;
                }
            }

        }
        public static void WriteData(string writeLine, int sunNo)
        {
            switch (sunNo)
            {
                case 1:
                    StreamWriter sun1Writer = new StreamWriter("Sun1Coordinate.txt", true, System.Text.Encoding.Default);
                    sun1Writer.WriteLine(writeLine);
                    sun1Writer.Close();
                    break;
                case 2:
                    StreamWriter sun2Writer = new StreamWriter("Sun2Coordinate.txt", true, System.Text.Encoding.Default);
                    sun2Writer.WriteLine(writeLine);
                    sun2Writer.Close();
                    break;
                case 3:
                    StreamWriter sun3Writer = new StreamWriter("Sun3Coordinate.txt", true, System.Text.Encoding.Default);
                    sun3Writer.WriteLine(writeLine);
                    sun3Writer.Close();
                    break;
            }
         

        }
  

        public static void DeleteOldWriteFile()
        {
            List<string> writeDataFile = new List<string>
            {
                "Sun1Coordinate.txt",
                "Sun2Coordinate.txt",
                "Sun3Coordinate.txt"
            };
            foreach (string item in writeDataFile)
                {

                if (System.IO.File.Exists(item))
                {
                    try
                    {
                        System.IO.File.Delete(item);
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }
        }
    }
}
