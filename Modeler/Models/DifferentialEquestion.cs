using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace Modeler.Models
{
    public class DifferentialEquestion
    {
        private List<OdeModel> resultDifEquestion = new List<OdeModel>();
        public DifferentialEquestion()
        {
            int result;
            try
            {
                if ((result = sumTwo(1.0, 0.0, 0.0, 0.1, 1.05, 1.5)) == 1)
                {
                    ReadFromFile readFromFile = new ReadFromFile();
                    resultDifEquestion = readFromFile.getDataFromFile("D:\\Egyetem\\Allamvizsga\\Modeler\\results.txt");
                }
            }
            catch (EntryPointNotFoundException e)
            {

            }
        }

        [DllImport("D:\\Egyetem\\Allamvizsga\\Modeler\\Debug\\CppClassDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sumTwo(double var_x, double var_y, double t, double mu, double omega, double eps);

        public List<OdeModel> getResults()
        {
            return resultDifEquestion;
        }

        public List<double> getResultX0()
        {
            List<double> OdeX0 = new List<double>();
            foreach (OdeModel x0 in resultDifEquestion)
            {
                OdeX0.Add(x0.x0);
            }
            return OdeX0;
        }

        public List<double> getResultX1()
        {
            List<double> OdeX1 = new List<double>();
            foreach (OdeModel x1 in resultDifEquestion)
            {
                OdeX1.Add(x1.x1);
            }
            return OdeX1;
        }
    }
}