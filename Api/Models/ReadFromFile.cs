using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Modeler.Models
{
    public class ReadFromFile
    {
        private OdeModel splitLine(string line)
        {
            char[] delimiterChars = { ' ', '\n' };
            string[] dataString = line.Split(delimiterChars);
            if (dataString.Length!=3)
            {
                throw new Exception("Not suitable data structure");
            }
            else
            {
                OdeModel odeModel = new OdeModel() {
                    t = Double.Parse(dataString[0]),
                    x0 = Double.Parse(dataString[1]),
                    x1=Double.Parse(dataString[2])
                };
                return odeModel;
            }    
        }
        public List<OdeModel> getDataFromFile(string fileName)
        {
            List<OdeModel> dataFromFile = new List<OdeModel>();
            var lines = File.ReadLines(fileName);
            foreach (var line in lines)
            {
                try
                {
                    dataFromFile.Add(splitLine(line));
                }
                catch(Exception e)
                {

                }
            }
            return dataFromFile;
        }
    }
}