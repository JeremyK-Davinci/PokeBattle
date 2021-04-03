using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PokeBattle.Utilities.DataObjects.Pokemon
{
    public class Attack
    {
        public string Name { get; set; }

        public EnergyType Type { get; set; }
        
        public int MaxPP { get; set; }

        public int RemainingPP { get; set; }

        public Attack() { }

        public Attack(string name, EnergyType type, int maxpp, int remainingpp)
        {
            Name = name;
            Type = type;
            MaxPP = maxpp;
            RemainingPP = remainingpp;
        }
    }

    public class DamageAttack : Attack
    {
        public int Damage { get; set; }

        public DamageAttack() { }

        public DamageAttack(string name, EnergyType type, int maxpp, int remainingpp, int damage)
        {
            Name = name;
            Type = type;
            MaxPP = maxpp;
            RemainingPP = remainingpp;
            Damage = damage;
        }
    }

    public class StatusAttack : Attack
    {

    }

    public class EffectAttack : Attack
    {

    }
}
