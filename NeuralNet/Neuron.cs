using System;
using System.Collections.Generic;

namespace NeuralNet
{
    public class Neuron
    {
        public int NumInputs { get; set; }
        public List<double> Weights { get; set; }

        public Neuron()
        {
            Weights = new List<double>();
        }

        public Neuron(int NumInputs)
        {
            this.NumInputs = NumInputs + 1; // Account for threshold

            for(int x=0; x<NumInputs+1; x++) // Still accounting for threshold
            {
                Weights.Add(Globals.RandomClamped());
            }
        }
    }
}
