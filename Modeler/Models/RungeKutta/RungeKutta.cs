using Modeler.Models.DataModels;
using Modeler.Models.RungeKutta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RungeKutta
    {
        private double lambda;
        private double HR0;
        private List<double> tResults;
        private List<double> HRResults;
        private List<double> vResults;
        private double t=0;
        private double dx = 0.25;
        private double[] k1;
        private double[] k2;
        private double[] k3;
        private double[] k4;
        private double[] y;
        private string gender;
        public RungeKutta(string gender, double lambda, double HR0, double v)
        {
            this.gender = gender;
            this.lambda = lambda;
            this.HR0 = HR0;

            k1 = new double[2];
            k2 = new double[2];
            k3 = new double[2];
            k4 = new double[2];
            y = new double[2];
            tResults = new List<double>();
            HRResults = new List<double>();
            vResults = new List<double>();
            y[0] = HR0;
            y[1] = v;
         }

       /// <summary>
       /// milyen betegseget tudunk ezzel elore jelezni
       /// </summary>
       // hr az y(0), v az y(1)
        public void solve()
        {
            int i = 0;
            while (i <= 100)
            {
                i++;
                k1 = f(t, y);
                k2 = f(t + dx / 2, plus(y, mult(k1, 0.5)));
                k3 = f(t + dx / 2, plus(y, mult(k2, 0.5)));
                k4 = f(t + dx, plus(y, k3));

                y = plus(y, mult(plus(k1, plus(mult(k2, 2), plus(mult(k3, 2), k4))), 0.16666));
                t += dx;
                tResults.Add(t);
                HRResults.Add(y[0]);
                vResults.Add(y[1]);

            }


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
       

        double[] dEqs(double x, double[] y, double h)
        {
            double[] result = new double[2];
            result[0] = (2.0 / 3.0 * y[0] - (4.0 / 3.0) * y[0] * y[1]) * h;
            result[1] = (y[0] * y[1] - y[1]) * h;
            return result;
        }
        public double[] f(double t, double[] y)
        {
            double[] function = new double[2];
            function[0] = dx * fmin(y[0]) * fmax(y[0]) * fd(y[0], y[1], t);
            function[1] = dx;
            return function;
        }

        //public Function f (double t, Parameters y)
        //{
        //    //x=y.v, y=y.HR
        //    Function function = new Function();
        //    function.f1 = dx * ((2.0 / 3.0) * y.HR- (4.0 / 3.0) * y.HR* y.v);
        //    function.f2 = dx * ( y.HR * y.v - y.v);
        //    return function;
        //}

        

        private double HRmin ()
        {
            switch (gender)
            {
                case "male":
                    return 35.0 / lambda;
                case "female":
                    return 35.0 / lambda + 5;
            }
            return 35.0 / lambda;

        }
        private double fmin (double HR)
        {
            double alfa2 = 60.0;
            double result= 1 - Math.Exp(-1 * Math.Pow((HR - HRmin())/alfa2, 2));
            return result;
        }

        private double fmax (double HR)
        {
            double alfa1 = 10.0;
            double HRmax = 190.0;
            double result= -1 + Math.Exp(-1 * Math.Pow((HR - HRmax / alfa1), 2));
            return result;
        }

        // HRmax mi az
        private double omega ()
        {
            double alfa4 = 0.003;
            double alfa5 = 4;
            double HRmax = 195;
            double result = alfa4 * lambda * Math.Pow(((HRmax - HRmin()) / (HR0 - HRmin())), alfa5);
            return result;
        }

        private double D( double v, double t)
        {
            double Dap = Dapostroph(t, v);
            double x = HR0 - Dapostroph(t, v);
            double y = Math.Exp(-omega() * t * t);
            double result= Dapostroph( t, v) + (HR0 - Dapostroph( t, v)) * Math.Exp(-omega() * t * t);
            return result;
        }
        // ezt sem talaltam meg
        //private double Dss(double lambda, double v, double t)
        //{

        //}
        private double Dapostroph (double t, double v)
        {
            // return Dss(lambda, v, t) + Dla(lamdba, v, t);
            double result= Dla( v, t);
            return result;
        }

        private double Dla( double v, double t)
        {
            double alfa3 = 4.0;
            double result= alfa3*L( v, t);
            return result;
        }

        private double vmax ()
        {
            double result=  20 * Math.Sqrt(lambda);
            return result;
        }
        // **** random szamok Lbasal-nak Lmax-nak
        private double Llambdav(double v)
        {
            double Lbasal = 1;
            double Lmax = 12;
            double alfa6 = 0.5;
            double result= Lbasal + (Lmax - Lbasal) * Math.Exp(alfa6*(v-vmax()));
            return result;
        }
        private double Lont (double t)
        {
            double alfa7 = 420.0;
            double result = 1 - Math.Exp(-t / alfa7);
            return result;
        }
        private double L( double v, double t)
        {
            double result = Llambdav( v) * Lont(t);
            return result;
        }

        private double d()
        {
            double alfa0 = 0.08;
            double result = alfa0 * lambda;
            return result;
        }

        private double fd (double HR, double v,  double t)
        {
            double result = -d() * (HR - D( v, t));
            return result;
        }

        public List<double> getTResults()
        {
            return tResults;
        }

        public List<double> getHRResults()
        {
            return HRResults;
        }

        public List<double> getvResults()
        {
            return vResults;
        }



    }
}