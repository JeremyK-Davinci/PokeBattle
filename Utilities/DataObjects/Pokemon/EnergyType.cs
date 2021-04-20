using System;
using System.Collections.Generic;
using System.Text;

namespace PokeBattle.Utilities.DataObjects.Pokemon
{
    public class EnergyType
    {
        public string Name { get; set; }

        public List<string> Strenghts { get; set; } = new List<string>();

        public List<string> Weaknesses { get; set; } = new List<string>();

        public List<string> Resistances { get; set; } = new List<string>();

        /// <summary>
        /// Creates a new EnergyType with no additional data
        /// </summary>
        public EnergyType() { }

        /// <summary>
        /// Creates a new EnergyType with all required data
        /// </summary>
        public EnergyType(string name, List<string> strenghts = null, List<string> weaknesses = null, List<string> resistances = null)
        {
            Name = name;
            Strenghts = strenghts == null ? new List<string>() : strenghts;
            Weaknesses = weaknesses == null ? new List<string>() : weaknesses;
            Resistances = resistances == null ? new List<string>() : resistances;
        }
    }
}
