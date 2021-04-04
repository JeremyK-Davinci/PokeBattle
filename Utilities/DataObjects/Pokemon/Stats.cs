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

    public class Atk : Stat
    {
        public Atk() { }

        public Atk(int value)
        {
            Name = "Attack";
            Value = value;
        }
    }

    public class Def : Stat
    {
        public Def() { }

        public Def(int value)
        {
            Name = "Defense";
            Value = value;
        }
    }

    public class SPAtk : Stat
    {
        public SPAtk() { }

        public SPAtk(int value)
        {
            Name = "Special Attack";
            Value = value;
        }
    }

    public class SPDef : Stat
    {
        public SPDef() { }

        public SPDef(int value)
        {
            Name = "Special Defense";
            Value = value;
        }
    }

    public class Speed : Stat
    {
        public Speed() { }

        public Speed(int value)
        {
            Name = "Speed";
            Value = value;
        }
    }
}
