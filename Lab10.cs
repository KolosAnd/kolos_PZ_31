using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    public class Lab10
    {
        double xAverage = 0, yAverage = 0;
        double sX = 0, sY = 0;
        double k = 0, r = 0;
        String firstEquation = "", secondEquation = "";
        private double[] X =
        {
            0.37, 0.37, 0.30, 0.38, 0.33, 0.22, 0.28, 0.26, //2
            0.38, 0.34, 0.37, 0.56, 0.63, 1.03, 0.96, 0.54, 0.24, 0.19, 0.12, 0.00, //4
            0.24, 0.32, 0.35, 0.43, 0.62, 0.81, 0.99, 0.59, 0.43, 0.23, //6 
            0.12, 0.24, 0.36, 0.52, 0.56, 0.68, 0.62, 0.52, 0.27, 0.20, 0.10,//7
            0.15, 0.17, 0.30, 0.43, 0.65, 0.60, 0.43, 0.34, 0.10, 0.00,//8
            0.02, 0.22, 0.29, 0.31, 0.36, 0.63, 0.76, 0.56, 0.32, 0.13//9
        };
        private double[] Y =
        {
            0.38, 0.37, 0.38, 0.36, 0.40, 0.36, 0.48, 0.32, //2
            0.35, 0.38, 0.42, 0.47, 0.60, 0.91, 0.89, 0.59, 0.38, 0.27, 0.19, 0.02, //4
            0.24, 0.32, 0.34, 0.41, 0.57, 0.81, 0.97, 0.59, 0.36, 0.21, //6
            0.14, 0.28, 0.31, 0.57, 0.65, 0.78, 0.70, 0.52, 0.19, 0.11, 0.00, //7
            0.25, 0.32, 0.36, 0.44, 0.65, 0.88, 0.57, 0.42, 0.25, 0.00, //8
            0.03, 0.24, 0.33, 0.33, 0.38, 0.63, 0.79, 0.55, 0.34, 0.14  //9
        };
        int length;

        public Lab10()
        {
            length = X.Length;
            this.calculateAverage();
            this.calculateK();
            this.calculateS();
            this.calculateR();
            this.setYonX();
            this.setXonY();
        }

        public void calculateAverage()
        {
            foreach (var x in X)
                xAverage += x;
            xAverage /= length;
            foreach (var y in Y)
                yAverage += y;
            yAverage /= length;
        }
        public void calculateK()
        {
            for (int i = 0; i < length; ++i)
            {          
                k += (X[i] - xAverage) * (Y[i] - yAverage);
            }
            k /= length;
        }
        public void calculateS()
        {
            foreach (var x in X)
            {
                sX += Math.Pow(x - xAverage, 2);
            }
            sX /= length;
            sX = Math.Sqrt(sX);
            foreach (var y in Y)
            {
                sY += Math.Pow(y - yAverage, 2);
            }
            sY /= length;
            sY = Math.Sqrt(sY);
        }
        public void calculateR()
        {
            r = k / (sX * sY);
        }
        public void setYonX()
        {
            firstEquation = " y = " + String.Format("{0:f5}", (yAverage - (r * sY / sX) * xAverage)) + " + " 
                + String.Format("{0:f5}", (r * sY / sX)) + "x";
        }
        public void setXonY()
        {
            secondEquation = " x = " + String.Format("{0:f5}",(xAverage - (r * sX / sY) * yAverage)) + " + "
                + String.Format("{0:f5}", (r * sX / sY)) + "y";
        }
        public void printData()
        {
            Console.WriteLine(" Sx = " + String.Format("{0:f5}",sX));
            Console.WriteLine(" Sy = " + String.Format("{0:f5}",sY));
            Console.WriteLine(" r* = " + String.Format("{0:f5}",r));
            Console.WriteLine(firstEquation);
            Console.WriteLine(secondEquation);
        }
    }
}
