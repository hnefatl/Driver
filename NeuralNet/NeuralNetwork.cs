using System;
using System.Collections.Generic;

namespace NeuralNet
{
    public class NeuralNetwork
    {
        public int NumInputs { get; set; }
        public int NumOutputs { get; set; }
        public int NumHiddenLayers { get; set; }
        public int NeuronsPerHiddenLayer { get; set; }

        public List<NeuronLayer> Layers { get; set; }

        public NeuralNetwork()
        {
            Layers = new List<NeuronLayer>();
        }

        public void CreateNet()
        {
            if(NumHiddenLayers>0)
            {
                // First hidden layer ("input" layer)
                Layers.Add(new NeuronLayer(NeuronsPerHiddenLayer, NumInputs));

                for(int x=0; x<NumHiddenLayers; x++) // All hidden layers
                {
                    Layers.Add(new NeuronLayer(NeuronsPerHiddenLayer, NeuronsPerHiddenLayer));
                }

                // Final layer ("output" layer)
                Layers.Add(new NeuronLayer(NumOutputs, NeuronsPerHiddenLayer));
            }
            else
            {
                // Final layer ("output" layer)
                Layers.Add(new NeuronLayer(NumOutputs, NumInputs));
            }
        }

        public List<double> Update(List<double> Inputs)
        {
            List<double> Outputs = new List<double>();

            if (Inputs.Count != NumInputs) // Wrong number of inputs
            {
                return null;
            }

            List<double> NewInputs = Inputs;
            for (int x = 0; x < NumHiddenLayers; x++) // Loop through all layers in the net
            {
                if (x > 0) // Not the first layer
                {
                    NewInputs = Outputs;
                }

                Outputs.Clear();

                for (int y = 0; y < Layers[x].Neurons.Count; y++) // Loop through all neurons in a layer
                {
                    double NetInput = 0;

                    int z = 0;
                    for (; z < Layers[x].Neurons[y].NumInputs - 1; z++) // Sum the product of the inputs and with weights
                    {
                        NetInput += Layers[x].Neurons[y].Weights[z] * Inputs[z];
                    }

                    NetInput += Layers[x].Neurons[y].Weights[z] * Globals.Bias; // Account for the threshold

                    Outputs.Add(Globals.Sigmoid(NetInput)); // Squash the output
                }
            }

            return Outputs;
        }
    }
}
