using System;
using System.Collections.Generic;
using GeneticGateCreation.Manager;

namespace GeneticGateCreation.Models
{
    public class Chromosome
    {
        List<Gene> genes {get; set;}

        //Generates a random parent with length being the number of operations
        public void GenerateParent(int Length)
        {
            genes = new List<Gene>();
            for(int i = 0; i < Length; i++)
            {
                genes.Add(GenerateGene());
            }
        }
        public Chromosome Clone()
        {
            Chromosome chromosome = new Chromosome();
            chromosome.genes = new List<Gene>();
            foreach(Gene g in genes)
                chromosome.genes.Add(new Gene(g.GateOne,g.GateTwo));
            return chromosome;
        }

        public Gene GenerateGene()
        {
            Random rnd = new Random();
            //Get number of values defined in Gene Set
            int GenesetCount = Enum.GetNames(typeof(Geneset)).Length;
            //Get random sample from Geneset to create first gate 
            Geneset genesetOne = (Geneset)rnd.Next(0,GenesetCount);
            //Get random sample from Geneset to create second gate 
            Geneset genesetTwo = (Geneset)rnd.Next(0,GenesetCount);
            return new Gene(genesetOne,genesetTwo);
        }
 
        public void Mutate()
        {
            Random rnd = new Random();
            int Index = rnd.Next(0,genes.Count);
            genes[Index] = GenerateGene();
        }

        public double GetFitness(Tuple<string,string> inputs, string output)
        {
            double Fitness = 0;
            Fitness -= Math.Abs(Convert.ToInt32(output,2) - Convert.ToInt32(ComputationManager.Compute(genes,inputs).Item1,2));
            return Fitness;
        }

        public string Display (Tuple<string,string> inputs)
        {
            return ComputationManager.Compute(genes,inputs).Item1;
        }
    
    }
}