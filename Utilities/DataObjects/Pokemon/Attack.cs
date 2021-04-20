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

        public int Priority { get; set; }

        /// <summary>
        /// Creates a new Attack with no additional data
        /// </summary>
        public Attack() { }

        /// <summary>
        /// Creates a new Attack with all required data
        /// </summary>
        public Attack(string name, EnergyType type, int priority = 1)
        {
            Name = name;
            Type = type;
            Priority = priority;
        }
    }

    public class DamageAttack : Attack
    {
        public int Damage { get; set; }

        /// <summary>
        /// Creates a new DamageAttack with no additional data
        /// </summary>
        public DamageAttack() { }

        /// <summary>
        /// Creates a new DamageAttack with all required data
        /// </summary>
        public DamageAttack(string name, EnergyType type, int damage, int priority = 1)
        {
            Name = name;
            Type = type;
            Damage = damage;
            Priority = priority;
        }
    }

    public class StatusAttack : Attack
    {
        public string AfflictingStatus { get; set; }

        public int AfflictionValue { get; set; }

        public bool Self { get; set; }

        /// <summary>
        /// Creates a new StatusAttack with no additional data
        /// </summary>
        public StatusAttack() { }

        /// <summary>
        /// Creates a new StatusAttack with all required data
        /// </summary>
        public StatusAttack(string name, EnergyType type, string statusname, int statusaffliction, bool self = false, int priority = 1)
        {
            Name = name;
            Type = type;
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

        /// <summary>
        /// Creates a new EffectAttack with no additional data
        /// </summary>
        public EffectAttack() { }

        /// <summary>
        /// Creates a new EffectAttack with all required data
        /// </summary>
        public EffectAttack(string name, EnergyType type, string effectname, int mineffectduration, int maxeffectduration, int effectdamage = 0, int priority = 1)
        {
            Name = name;
            Type = type;
            EffectName = effectname;
            MinEffectDuration = mineffectduration;
            MaxEffectDuration = maxeffectduration;
            EffectDamage = effectdamage;
            Priority = priority;
        }
    }
}
