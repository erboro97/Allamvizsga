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
        private List<double> yResults;
        private double t;
        private Parameters parameters;
        private double dx = 0.1;
        private Function k1;
        private Function k2;
        private Function k3;
        private Function k4;
        private string gender;
        public RungeKutta(string gender, double lambda, double HR0, double v)
        {
            this.gender = gender;
            this.lambda = lambda;
            this.HR0 = HR0;

            k1 = new Function();
            k2 = new Function();
            k3 = new Function();
            k4 = new Function();
            parameters = new Parameters(v, HR0);
        }

       

        public void solve()
        {
            tResults = new List<double>();
            yResults = new List<double>();
            while (t < 10)
            {
                k1 = f(t, parameters);
                k2 = f(t + dx / 2, new Parameters(parameters.HR+k1.f1/2, parameters.v+k1.f2/2));
                k3 = f(t + dx / 2, new Parameters(parameters.HR+dx*k2.f1/2, parameters.v+dx*k2.f2/2));
                k4 = f(t + dx,  new Parameters(parameters.HR+k3.f1, parameters.v+k3.f2));

                parameters.HR += (k1.f1 + 2 * k2.f1 + 2 * k3.f1 + k4.f1)/6.0;
                parameters.v += (k1.f2 + 2 * k2.f2 + 2 * k3.f2 + k4.f2)/6.0;
               
                t += dx;
           
                tResults.Add(t);
                yResults.Add(parameters.v);
            }


        }

        public Function f (double t, Parameters y)
        {
            Function function = new Function();
            function.f1 = dx* fmin(y.HR) * fmax(y.HR) * fd(y.HR, y.v, t);
            function.f2 = dx*( t);
            return function;
        }
 

        

        private double HRmin (double lambda)
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
            double result= 1 - Math.Exp(-1 * (Math.Pow((HR - 35.0 / lambda), 2)) / 60.0);
            return result;
        }

        private double fmax (double HR)
        {
            double result= -1 + Math.Exp(-1 * (Math.Pow((HR - 35.0 / lambda), 2)) / 60.0);
            return result;
        }

        // HRmax mi az
        private double omega ()
        {
            double HRmax = 120;
            double result= 0.003 * lambda * Math.Pow((HRmax - HRmin(lambda)) / (HR0 - HRmin(lambda)), 4);
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
            double result= 4*L( v, t);
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
            double Lbasal = 0.5;
            double Lmax = 0.9;

            double result= Lbasal + (Lmax - Lbasal) * Math.Exp(0.5*(v-vmax()));
            return result;
        }
        private double Lont (double t)
        {
            double result = 1 - Math.Exp(-t / 420);
            return result;
        }
        private double L( double v, double t)
        {
            double result = Llambdav( v) * Lont(t);
            return result;
        }

        private double d()
        {
            double result = 0.008 * lambda;
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

        public List<double> getYResults()
        {
            return yResults;
        }

    }
}