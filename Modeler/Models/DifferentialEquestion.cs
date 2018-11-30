using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace Modeler.Models
{
    public class DifferentialEquestion
    {
        struct OdeHelper
        {
            double t;
            double x0;
            double x1;
        };
        public DifferentialEquestion()
        {
            int result = ODESolverLibrary(0.1, 1.05, 1.5);
            if (result ==1)
            {
                int ok = 1;
            }

        }

        [DllImport("D:\\Egyetem\\Allamvizsga\\Modeler\\Debug\\CppClassDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ODESolverLibrary(double mu, double omega, double eps);

    }
}