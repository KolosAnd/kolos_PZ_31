using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    public class Fisher
    {
        private double[] X =
        {
            0.37, 0.37, 0.30, 0.38, 0.33, 0.22, 0.28, 0.26, //2
            0.38, 0.34, 0.37, 0.56, 0.63, 1.03, 0.96, 0.54, 0.24, 0.19, 0.12, 0.00, //4
            0.24, 0.32, 0.35, 0.43, 0.62, 0.81, 0.99, 0.59, 0.43, 0.23, //6 
            0.12, 0.24, 0.36, 0.52, 0.56, 0.68, 0.62, 0.52, 0.27, 0.20, 0.10,//7
        };
        private double[] Y =
        {
            0.38, 0.37, 0.38, 0.36, 0.40, 0.36, 0.48, 0.32, //2
            0.35, 0.38, 0.42, 0.47, 0.60, 0.91, 0.89, 0.59, 0.38, 0.27, 0.19, 0.02, //4
            0.24, 0.32, 0.34, 0.41, 0.57, 0.81, 0.97, 0.59, 0.36, 0.21, //6
            0.14, 0.28, 0.31, 0.57, 0.65, 0.78, 0.70, 0.52, 0.19, 0.11, 0.00, //7
        };
        private double xAvg = 0, yAvg = 0;
        private double sX = 0, sY = 0;
        private double k = 0, r = 0, z0 = 0;
        public readonly double a1 = 0.05;
        public readonly double a2 = 0.01;
        public readonly double t1 = 1.98;
        public readonly double t2 = 2.56;

        public void FindAverage()
        {
            foreach (double x in X)
            {
                xAvg += x;
            }
            xAvg /= X.Length;
            Console.WriteLine($"x̄ = {xAvg}.");

            foreach (double y in Y)
            {
                yAvg += y;
            }
            yAvg /= Y.Length;
            Console.WriteLine($"ȳ = {yAvg}.");
        }
        public void FindK()
        {
            for (int i = 0; i < X.Length; i++)
            {
                k += (X[i] - xAvg) * (Y[i] - yAvg);
            }
            k /= X.Length;
            Console.WriteLine($"k = {k}");
        }
        public void FindS()
        {
            foreach (double x in X)
            {
                sX += Math.Pow(x - xAvg, 2);
            }
            sX /= X.Length;
            sX = Math.Sqrt(sX);
            Console.WriteLine($"Sx = {sX}");

            foreach (double y in Y)
            {
                sY += Math.Pow(y - yAvg, 2);
            }
            sY /= Y.Length;
            sY = Math.Sqrt(sY);
            Console.WriteLine($"Sy = {sY}");
        }
        public void FindR()
        {
            r = k / (sX * sY);
            Console.WriteLine($"r = {r}");
        }
        public void FishFunc()
        {
            z0 = 0.5 * Math.Log((1 + r) / (1 - r));

        }
        public void IntervalEstimation(double t)
        {
            double h = t / Math.Sqrt(X.Length - 3);
            double r1 = z0 - h;
            double r2 = z0 + h;
            double l = r2 - r1;
            Console.WriteLine($"{r1} < rxy* < {r2}, довжина інтервалу l = {l}");
            bool corr = l < r;
            char sign = '>';
            string response = "Отже, між X та Y немає кореляційного зв'язку";
            if(corr == true)
            {
                sign = '<';
                response = "Отже, між X та Y існує кореляційний зв'язок";
            }
            Console.WriteLine($"l < rxy* ({l} {sign} {r})\n{response}\n");
        }

    }
}
