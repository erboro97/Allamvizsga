using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RungeKutta
    {
        #region Set solution/iteration parameters
        static double tmax = 5.0;
        static double deltaT = 0.001;
        static int samples = Convert.ToInt32(tmax / deltaT);
        static double tStart = 0.1;
        static double tStop = 0.2;
        static double time = 0;
        static double k1d, k2d, k3d, k4d;
        static double k1w, k2w, k3w, k4w;
        #endregion

        #region Set machine parameters & initial conditions
        static double H = 10.0;
        static double xMachine = 0.1;
        static double Pm = 1.00;
        static double angleInit = Math.Asin(0.1);
        static double powerPrev = Pm;

        static double speedSync = 2 * Math.PI * 60;
        static double speedPrev = speedSync;

        static double damp = 0.0;

        static double a = speedSync / (2 * H);
        #endregion

        #region Initialize Arrays
        static double[] MachineAngle = new double[samples];
        static double[] MachineSpeed = new double[samples];
        static double[] MachinePowerE = new double[samples];
        #endregion

        public void Initialize()
        {
            int t1 = (int)(samples * tStart / tmax);
            for (int i = 0; i < t1; i++)
            {
                MachinePowerE[i] = Pm;
                MachineAngle[i] = angleInit;
                MachineSpeed[i] = speedSync;
            }
        }

        public void RungeKuttaMethod()
        {
            #region Define Internal Variables
            double anglePrev = angleInit;
            double newAngle, newSpeed, newPower;
            #endregion

            int t1 = (int)(samples * tStart / tmax);
            //Start analysis after 100 samples

            for (int i = t1; i < samples; i++)
            {
                time = i * deltaT;

                #region First Estimate
                k1d = speedPrev - speedSync;
                k1w = a * (Pm - powerPrev);
                newAngle = anglePrev + 0.5 * deltaT * k1d;
                newSpeed = speedPrev + 0.5 * deltaT * k1w;

                if (time >= tStart && time <= tStop)
                    newPower = 0.0;
                else
                {
                    newPower = 1.0 * Math.Sin(newAngle) / xMachine;
                }
                #endregion

                #region Second Estimate
                k2d = speedPrev - speedSync;
                k2w = a * (Pm - newPower);
                newAngle = anglePrev + 0.5 * deltaT * k2d;
                newSpeed = speedPrev + 0.5 * deltaT * k2w;

                if (time >= tStart && time <= tStop)
                    newPower = 0.0;
                else
                {
                    newPower = 1.0 * Math.Sin(newAngle) / xMachine;
                }
                #endregion

                #region Third Estimate
                k3d = newSpeed - speedSync;
                k3w = a * (Pm - newPower);
                newAngle = anglePrev + deltaT * k3d;
                newSpeed = speedPrev + deltaT * k3w;

                if (time >= tStart && time <= tStop)
                    newPower = 0.0;
                else
                {
                    newPower = 1.0 * Math.Sin(newAngle) / xMachine;
                }
                #endregion

                #region Fourth estimate and final calculation of speed, angle and power
                k4d = newSpeed - speedSync;
                k4w = a * (Pm - newPower);
                MachineAngle[i] = anglePrev + deltaT / 6 * (k1d + 2 * k2d + 2 * k3d + k4d);
                MachineSpeed[i] = speedPrev + deltaT / 6 * (k1w + 2 * k2w + 2 * k3w + k4w);

                MachinePowerE[i] = newPower;
                #endregion
                powerPrev = MachinePowerE[i];
                anglePrev = MachineAngle[i];
                speedPrev = MachineSpeed[i];

            }
        }
    }
}