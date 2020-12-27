using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    public class Lab9
    {
        double delta1 = 0, deltaA1 = 0, deltaB1 = 0, alpha1 = 0, beta1 = 0;
        double delta2 = 0, deltaA2 = 0, deltaB2 = 0, alpha2 = 0, beta2 = 0;
        string YonX = "", XonY = "";

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

        public Lab9()
        {
            length = this.X.Length;
            this.calculateDelta1();
            this.calculateDeltaA1();
            this.calculateDeltaB1();
            this.calculateDelta2();
            this.calculateDeltaA2();
            this.calculateDeltaB2();
            this.calculateAlpha();
            this.calculateBeta();
            this.setXonY();
            this.setYonX();
        }

        public void calculateDelta1()
        {
            double left = 0.0, right = 0.0;
            for (int i = 0; i < length; ++i)
            {
                left += Math.Pow(X[i], 2);
                right += X[i];
            }
            left *= length;
            right = Math.Pow(right, 2);
            delta1 = left
            - right;

        }
        public void calculateDeltaA1()
        {
            double left1 = 0.0, right1 = 0.0;
            double left2 = 0.0, right2 = 0.0;
            for (int i = 0; i < length; ++i)
            {
                left1 += Math.Pow(X[i], 2);
                right1 += Y[i];
                left2 += X[i];
                right2 += X[i] * Y[i];
            }
            deltaA1 = left1 * right1

            - left2 * right2;

        }
        public void calculateDeltaB1()
        {
            double left1 = 0.0;
            double left2 = 0.0, right2 = 0.0;
            for (int i = 0; i < length; ++i)
            {
                left1 += X[i] * Y[i];
                left2 += X[i];
                right2 += Y[i];
            }
            left1 *= length;
            deltaB1 = left1

            - left2 * right2;

        }
        public void calculateDelta2()
        {
            double left = 0.0, right = 0.0;
            for (int i = 0; i < length; ++i)
            {
                left += Math.Pow(Y[i], 2);
                right += Y[i];
            }
            left *= length;
            right = Math.Pow(right, 2);
            delta2 = left
            - right;

        }
        public void calculateDeltaA2()
        {
            double left1 = 0.0, right1 = 0.0;
            double left2 = 0.0, right2 = 0.0;
            for (int i = 0; i < length; ++i)
            {
                left1 += Math.Pow(Y[i], 2);
                right1 += X[i];
                left2 += Y[i];
                right2 += Y[i] * X[i];
            }
            deltaA2 = left1 * right1

            - left2 * right2;

        }
        public void calculateDeltaB2()
        {
            deltaB2 = deltaB1;
        }
        public void calculateAlpha()
        {
            alpha1 = deltaA1 / delta1;
            alpha2 = deltaA2 / delta2;
        }
        public void calculateBeta()
        {
            beta1 = deltaB1 / delta1;
            beta2 = deltaB2 / delta2;         
        }
        public void setYonX()
        {
            YonX = "y = " + String.Format("{0:f5}", alpha1) + " + " + String.Format("{0:f5}",beta1) + "x";
        }
        public void setXonY()
        {
            XonY = "x = " + String.Format("{0:f5}", alpha2) + " + " + String.Format("{0:f5}", beta2) + "y";
        }

        public void printData()
        {
            Console.WriteLine(" ∆=" + String.Format("{0:f5}", delta1));
            Console.WriteLine(" ∆α=" + String.Format("{0:f5}", deltaA1));
            Console.WriteLine(" ∆β=" + String.Format("{0:f5}", deltaB1));
            Console.WriteLine(" α=" + String.Format("{0:f5}", alpha1));
            Console.WriteLine(" β=" + String.Format("{0:f5}", beta1));
            Console.WriteLine(" Рівняння Y на X: " + YonX);
            Console.WriteLine("\n\n");
            Console.WriteLine(" ∆’=" + String.Format("{0:f5}", delta2));
            Console.WriteLine(" ∆’α=" + String.Format("{0:f5}", deltaA2));
            Console.WriteLine(" ∆’β=" + String.Format("{0:f5}", deltaB2));
            Console.WriteLine(" α’=" + String.Format("{0:f5}", alpha1));
            Console.WriteLine(" β’=" + String.Format("{0:f5}", beta1));
            Console.WriteLine(" Рівняння X на Y: " + XonY + "\n\n");
        }
    }
}
