using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.RungeKutta
{
    public class RungeKuttaV2
    {
        public List<double[]> solve()
        {
            List < double[] > results = new List<double[]>();
            double x=0;
            int i = 0;
            double[] xSol = new double[2];
            double[] k1 = new double[2];
            double[] k2 = new double[2];
            double[] k3 = new double[2];
            double[] k4 = new double[2];
            double[] y = new double[2];
            y[0] = 0.9;
            y[1] = 0.9;
            double h = 0.25;
            double xStop = 2;
            while (i <= 100)
            {
                i++;
                k1 = dEqs(x, y, h);
                k2 = dEqs(x + h / 2, plus(y, mult(k1, 0.5)), h);
                k3 = dEqs(x + h / 2, plus(y, mult(k2, 0.5)), h);
                k4 = dEqs(x + h, plus(y, k3), h);

                y=plus(y,mult(plus(k1,plus(mult(k2,2),plus(mult(k3,2),k4))),0.16666));
                x += h;
                results.Add(y);

            }
            return results;
        }
        double[] plus(double[] x, double[] y)
        {
            double[] result = new double[2];
            result[0] = x[0] + y[0];
            result[1] = x[1] + y[1];
            return result;
        }
        double[] mult(double[] y, double value)
        {
            double[] result = new double[2];
            result[0] = y[0] * value;
            result[1] = y[1] * value;
            return result;
        }
        double min(double h, double x)
        {
            if (h < x)
                return h;
            return x;
        }

        double[] dEqs(double x, double[] y, double h)
        {
            double[] result = new double[2];
            result[0]=(2.0/3.0*y[0]- (4.0 / 3.0) * y[0] * y[1])*h;
            result[1]= (y[0] * y[1] - y[1])*h;
            return result;
        }

    }
}