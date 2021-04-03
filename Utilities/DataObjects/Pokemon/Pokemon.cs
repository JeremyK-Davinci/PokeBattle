using System;
using System.Collections.Generic;
using System.Text;

namespace PokeBattle.Utilities.DataObjects.Pokemon
{
    public class Pokemon
    {
        public string Name { get; set; }

        public string NickName { get; set; }

        public int Level { get; set; }

        public int Exp { get; set; }

        public EnergyType Type { get; set; }

        public int MaxHP { get; set; }

        public int CurrentHP { get; set; }

        public List<Stat> Stats { get; set; }

        public List<Attack> Attacks { get; set; }

        public string ImageLinkFront { get; set; }

        public string ImageLinkBack { get; set; }

        public Pokemon() { }

        public Pokemon(string name, EnergyType type, int maxhp, List<Stat> stats, List<Attack> attacks, int level = 5, int experience = 0, string nickname = "")
        {
            Name = name;
            Level = level;
            Exp = experience;
            Type = type;
            MaxHP = maxhp;
            CurrentHP = maxhp;
            Stats = stats;
            Attacks = attacks;
            NickName = string.IsNullOrWhiteSpace(nickname) ? name : nickname;

            ImageLinkFront = string.Format("https://img.pokemondb.net/sprites/ruby-sapphire/normal/{0}.png", name.ToLower());
            ImageLinkBack = string.Format("https://img.pokemondb.net/sprites/ruby-sapphire/back-normal/{0}.png", name.ToLower());
        }
    }
}
