using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    public class Romanovskyy
    {
        //private double[] X =
        //{
        //    0.24, 0.32, 0.29, 0.31, 0.27, 0.32, 0.29,
        //    0.30, 0.29, 0.32, 0.36, 0.37, 0.37, 0.42, 0.40,
        //    0.26, 0.34, 0.57, 0.72, 0.77, 0.85, 0.64, 0.45, 0.24,
        //    0.24, 0.32, 0.35, 0.43, 0.62, 0.81, 0.99, 0.59, 0.43, 0.23,
        //    0.15, 0.17, 0.30, 0.43, 0.65, 0.60, 0.43, 0.34, 0.10, 0.00,
        //    0.02, 0.22, 0.29, 0.31, 0.36, 0.63, 0.76, 0.56, 0.32, 0.13
        //};
        //private double[] Y =
        //{
        //    0.35, 0.35, 0.30, 0.36, 0.31, 0.36, 0.34,
        //    0.32, 0.31, 0.36, 0.38, 0.40, 0.42, 0.43, 0.41,
        //    0.29, 0.34, 0.49, 0.60, 0.86, 0.99, 0.72, 0.43, 0.25,
        //    0.24, 0.32, 0.34, 0.41, 0.57, 0.81, 0.97, 0.59, 0.36, 0.21,
        //    0.25, 0.32, 0.36, 0.44, 0.65, 0.88, 0.57, 0.42, 0.25, 0.00,
        //    0.03, 0.24, 0.33, 0.33, 0.38, 0.63, 0.79, 0.55, 0.34, 0.14
        //};

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


        private double xAvg = 0, yAvg = 0;
        private double sX = 0, sY = 0;
        private double k = 0, r = 0;
        private double Criterii;

        public void FindAverage()
        {
            foreach(double x in X)
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
            for(int i = 0; i < X.Length; i++)
            {
                k += (X[i] - xAvg) * (Y[i] - yAvg);
            }
            k /= X.Length;
            Console.WriteLine($"k = {k}");
        }
        public void FindS()
        {
            foreach(double x in X)
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
            Criterii = 3 * (1 - Math.Pow(r, 2)) / Math.Sqrt(X.Length);
            if (Criterii < Math.Abs(r))
            {
                Console.WriteLine($"\nКритерій Романовського виконується: |rxy*| = {r} > {Criterii}.");
                Console.WriteLine("Отже, між X та Y існує кореляційний зв'язок");
            }
            else
            {
                Console.WriteLine($"Критерій Романовського не виконується: |rxy*| = {r} < {Criterii}.");
                Console.WriteLine("Отже, між X та Y не існує кореляційного зв'язку");
            }
        }
    }
}
