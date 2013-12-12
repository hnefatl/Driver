using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class Algorithm
    {
        public List<Genome> Population { get; set; }

        public int PopulationSize { get; set; }
        public double MutationChance { get; set; }

        protected int NumInputs { get; set; }
        protected int NumOutputs { get; set; }
        protected int NeuronsPerHiddenLayer { get; set; }
        protected int HiddenLayers { get; set; }

        public Algorithm(int PopulationSize, double MutationChance)
        {
            this.PopulationSize = PopulationSize;
            this.MutationChance = MutationChance;
        }

        public void Update()
        {
            
        }
    }
}
