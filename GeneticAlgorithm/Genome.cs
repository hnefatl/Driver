using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NeuralNet;

namespace GeneticAlgorithm
{
    public class Genome
    {
        public NeuralNetwork Net { get; set; }

        public int Fitness { get; set; }

        private static Random Generator = new Random();

        public Genome(int NumInputs, int NumOutputs, int NeuronsPerHiddenLayer, int NumHiddenLayers)
        {
            Net = new NeuralNetwork();
            Net.NumInputs = NumInputs;
            Net.NumOutputs = NumOutputs;
            Net.NeuronsPerHiddenLayer = NeuronsPerHiddenLayer;
            Net.NumHiddenLayers = NumHiddenLayers;

            Fitness = 0;
        }

        public static Genome Breed(Genome One, Genome Two)
        {
            Genome New = new Genome(One.Net.NumInputs, One.Net.NumOutputs, One.Net.NeuronsPerHiddenLayer, One.Net.NumHiddenLayers);

            for (int x = 0; x < One.Net.Layers.Count; x++) // Loop though all the layers
            {
                New.Net.Layers.Add(new NeuronLayer()); // Create a new layer

                for (int y = 0; y < One.Net.Layers[x].Neurons.Count; y++) // Loop through all the neurons
                {
                    New.Net.Layers[x].Neurons.Add(new Neuron()); // Create a new neuron

                    for (int z = 0; z < One.Net.Layers[x].Neurons[y].Weights.Count; z++) // Loop through all the weights
                    {
                        // Randomly decide on a parent weight to inherit
                        if (Generator.Next(0, 2) == 0)
                        {
                            New.Net.Layers[x].Neurons[y].Weights.Add(One.Net.Layers[x].Neurons[y].Weights[z]);
                        }
                        else
                        {
                            New.Net.Layers[x].Neurons[y].Weights.Add(Two.Net.Layers[x].Neurons[y].Weights[z]);
                        }
                    }
                }
            }

            return New;
        }
        public static Genome Mutate(Genome One, double MutationChance)
        {
            Genome New = new Genome(One.Net.NumInputs, One.Net.NumOutputs, One.Net.NeuronsPerHiddenLayer, One.Net.NumHiddenLayers);

            for (int x = 0; x < New.Net.Layers.Count; x++) // Loop though all the layers
            {
                for (int y = 0; y < New.Net.Layers[x].Neurons.Count; y++) // Loop through all the neurons
                {
                    for (int z = 0; z < New.Net.Layers[x].Neurons[y].Weights.Count; z++) // Loop through all the weights
                    {
                        if (Generator.NextDouble() < MutationChance) // If randomly mutates
                        {
                            // Mutate the weight to a random value between 0.0 and 1.0
                            New.Net.Layers[x].Neurons[y].Weights[z] = Generator.NextDouble();
                        }
                    }
                }
            }

            return New;
        }

        public static bool operator <(Genome One, Genome Two)
        {
            return One.Fitness < Two.Fitness;
        }
        public static bool operator >(Genome One, Genome Two)
        {
            return One.Fitness > Two.Fitness;
        }
    }
}
