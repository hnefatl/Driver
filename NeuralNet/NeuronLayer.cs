using System;
using System.Collections.Generic;

namespace NeuralNet
{
    public class NeuronLayer
    {
        public List<Neuron> Neurons { get; set; }

        public NeuronLayer()
        {
            Neurons = new List<Neuron>();
        }

        public NeuronLayer(int NumNeurons, int InputsPerNeuron)
        {
            for (int x = 0; x < NumNeurons; x++)
            {
                Neurons.Add(new Neuron(InputsPerNeuron));
            }
        }
    }
}
