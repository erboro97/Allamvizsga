using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace Modeler.Models
{
    public class DifferentialEquestion
    {
        public DifferentialEquestion()
        {
            double var_x = 5;
            double var_y = 30;
            int result;
            try
            {
                result = sumTwo(var_x, var_y);
            }
            catch (EntryPointNotFoundException e)
            {

            }
        }

        [DllImport("D:\\Egyetem\\Allamvizsga\\Modeler\\Debug\\CppClassDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int sumTwo(double var_x, double var_y);

    }
}