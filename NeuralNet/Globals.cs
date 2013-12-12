using System;

namespace NeuralNet
{
    public class Globals
    {
        public static double Bias { get; set; }
        public static double Activation { get; set; }

        private static Random Generator = new Random();

        public static double Sigmoid(double Input)
        {
            /* Fix Activation */
            return 1.0f / (1.0f + (float)Math.Exp(-Input / Activation));
        }

        public static double RandomClamped()
        {
            return Generator.NextDouble();
        }
    }
}
