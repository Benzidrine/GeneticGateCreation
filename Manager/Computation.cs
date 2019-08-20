using System;
using System.Collections.Generic;
using GeneticGateCreation.Models;

namespace GeneticGateCreation.Manager
{       
    public class ComputationManager
    {
        public ComputationManager() {}

        public static Tuple<string,string> Compute(List<Gene> Genes, Tuple<string,string> input)
        {
            //convert to list of inputs
            String InputA = input.Item1;
            String InputB = input.Item2;
            String OutputA = "";
            String OutputB = "";
            string result = "";
            foreach(Gene g in Genes)
            {
                switch(g.GateOne)
                {
                    case Geneset.AND:
                        result = AND_Gate(InputA,InputB);
                        InputA = result;
                        OutputA = result + OutputA;
                        break;
                    case Geneset.OR:
                        result = OR_Gate(InputA,InputB);
                        InputA = result;
                        OutputA = result + OutputA;
                        break;
                    case Geneset.XOR:
                        result = XOR_Gate(InputA,InputB);
                        InputA = result;
                        OutputA = result + OutputA;
                        break;
                    case Geneset.NAND:
                        result = NAND_Gate(InputA,InputB);
                        InputA = result;
                        OutputA = result + OutputA;
                        break;
                    case Geneset.XNOR:
                        result = XNOR_Gate(InputA,InputB);
                        InputA = result;
                        OutputA = result + OutputA;
                        break;
                    default:
                        result = InputA;
                        InputA = result;
                        OutputA = result + OutputA;
                        break;
                }

                switch(g.GateTwo)
                {
                    case Geneset.AND:
                        result = AND_Gate(InputA,InputB);
                        InputB = result;
                        OutputB = result + OutputB;
                        break;
                    case Geneset.OR:
                        result = OR_Gate(InputA,InputB);
                        InputB = result;
                        OutputB = result + OutputB;
                        break;
                    case Geneset.XOR:
                        result = XOR_Gate(InputA,InputB);
                        InputB = result;
                        OutputB = result + OutputB;
                        break;
                    case Geneset.NAND:
                        result = NAND_Gate(InputA,InputB);
                        InputB = result;
                        OutputB = result + OutputB;
                        break;
                    case Geneset.XNOR:
                        result = XNOR_Gate(InputA,InputB);
                        InputB = result;
                        OutputB = result + OutputB;
                        break;
                    default:
                        result = InputB;
                        InputB = result;
                        OutputB = result + OutputB;
                        break;
                }
            }
            return new Tuple<string, string>(OutputA,OutputB);
        }

        public static string AND_Gate(string inputOne, string inputTwo)
        {
            if (inputOne == "1" && inputTwo == "1")
            {
                return "1";
            }
            else
                return "0";    
        }

        public static string OR_Gate(string inputOne, string inputTwo)
        {
            if (inputOne == "1" || inputTwo == "1")
            {
                return "1";
            }
            else
                return "0";    
        }

        public static string XOR_Gate(string inputOne, string inputTwo)
        {
            if (inputOne == "1" || inputTwo == "1" && !(inputOne == "1" && inputTwo == "1"))
            {
                return "1";
            }
            else
                return "0";    
        }

        public static string NAND_Gate(string inputOne, string inputTwo)
        {
            if (inputOne == "1" && inputTwo == "1")
            {
                return "0";
            }
            else
                return "1";    
        }
        public static string XNOR_Gate(string inputOne, string inputTwo)
        {
            if (inputOne == "1" || inputTwo == "1" && !(inputOne == "1" && inputTwo == "1"))
            {
                return "0";
            }
            else
                return "1";    
        }
    }
}