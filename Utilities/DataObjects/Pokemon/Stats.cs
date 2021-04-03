using System;
using System.Collections.Generic;
using System.Text;

namespace PokeBattle.Utilities.DataObjects.Pokemon
{
    public class Stat
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public Stat() { }

        public Stat(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
