using System;
using System.Collections.Generic;
using System.Text;

namespace PokeBattle.Utilities.DataObjects.Pokemon
{
    public class Stat
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public int CurrentAffliction { get; set; }

        public Stat() { }

        public Stat(string name, int value, int currentaffliction = 0)
        {
            Name = name;
            Value = value;
            CurrentAffliction = currentaffliction;
        }
    }

    public class Atk : Stat
    {
        public Atk() { }

        public Atk(int value, int currentaffliction = 0)
        {
            Name = "Attack";
            Value = value;
            CurrentAffliction = currentaffliction;
        }
    }

    public class Def : Stat
    {
        public Def() { }

        public Def(int value, int currentaffliction = 0)
        {
            Name = "Defense";
            Value = value;
            CurrentAffliction = currentaffliction;
        }
    }

    public class SPAtk : Stat
    {
        public SPAtk() { }

        public SPAtk(int value, int currentaffliction = 0)
        {
            Name = "Special Attack";
            Value = value;
            CurrentAffliction = currentaffliction;
        }
    }

    public class SPDef : Stat
    {
        public SPDef() { }

        public SPDef(int value, int currentaffliction = 0)
        {
            Name = "Special Defense";
            Value = value;
            CurrentAffliction = currentaffliction;
        }
    }

    public class Speed : Stat
    {
        public Speed() { }

        public Speed(int value, int currentaffliction = 0)
        {
            Name = "Speed";
            Value = value;
            CurrentAffliction = currentaffliction;
        }
    }
}
