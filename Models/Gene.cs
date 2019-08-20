namespace GeneticGateCreation.Models
{
    public class Gene
    {
        public Gene(Geneset gateOne, Geneset gateTwo)
        {
            GateOne = gateOne;
            GateTwo = gateTwo;
        }
        public Geneset GateOne {get; set;}
        public Geneset GateTwo {get; set;}
    }
}