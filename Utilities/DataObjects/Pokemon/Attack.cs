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

        public int Priority { get; set; }

        public Attack() { }

        public Attack(string name, EnergyType type, int maxpp, int priority = 1)
        {
            Name = name;
            Type = type;
            MaxPP = maxpp;
            RemainingPP = MaxPP;
            Priority = priority;
        }
    }

    public class DamageAttack : Attack
    {
        public int Damage { get; set; }

        public DamageAttack() { }

        public DamageAttack(string name, EnergyType type, int maxpp, int damage, int priority = 1)
        {
            Name = name;
            Type = type;
            MaxPP = maxpp;
            RemainingPP = MaxPP;
            Damage = damage;
            Priority = priority;
        }
    }

    public class StatusAttack : Attack
    {
        public string AfflictingStatus { get; set; }

        public int AfflictionValue { get; set; }

        public bool Self { get; set; }
        
        public StatusAttack() { }

        public StatusAttack(string name, EnergyType type, int maxpp, string statusname, int statusaffliction, bool self = false, int priority = 1)
        {
            Name = name;
            Type = type;
            MaxPP = maxpp;
            RemainingPP = MaxPP;
            AfflictingStatus = statusname;
            AfflictionValue = statusaffliction;
            Self = self;
            Priority = priority;
        }
    }

    public class EffectAttack : Attack
    {
        public string EffectName { get; set; }

        public int MinEffectDuration { get; set; }

        public int MaxEffectDuration { get; set; }

        public int EffectDamage { get; set; } = 0;

        public EffectAttack() { }

        public EffectAttack(string name, EnergyType type, int maxpp, string effectname, int mineffectduration, int maxeffectduration, int effectdamage = 0, int priority = 1)
        {
            Name = name;
            Type = type;
            MaxPP = maxpp;
            RemainingPP = MaxPP;
            EffectName = effectname;
            MinEffectDuration = mineffectduration;
            MaxEffectDuration = maxeffectduration;
            EffectDamage = effectdamage;
            Priority = priority;
        }
    }
}
