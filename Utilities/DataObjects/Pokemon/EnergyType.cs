using System;
using System.Collections.Generic;
using System.Text;

namespace PokeBattle.Utilities.DataObjects.Pokemon
{
    public class EnergyType
    {
        public string Name { get; set; }

        public List<string> Strenghts { get; set; }

        public List<string> Weaknesses { get; set; }

        public List<string> Resistances { get; set; }

        public EnergyType() { }

        public EnergyType(string name, List<string> strenghts, List<string> weaknesses, List<string> resistances)
        {
            Name = name;
            Strenghts = strenghts;
            Weaknesses = weaknesses;
            Resistances = resistances;
        }
    }
}
