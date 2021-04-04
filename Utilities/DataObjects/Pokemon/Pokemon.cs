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

        public int ExpToNext { get; set; }

        public ExperienceGroup ExpGroup { get; set; }

        public EnergyType Type { get; set; }

        public int BaseHP { get; set; }

        public int MaxHP { get; set; }

        public int CurrentHP { get; set; }

        public List<Stat> Stats { get; set; }

        public List<Attack> Attacks { get; set; }

        public string ImageLinkFront { get; set; }

        public string ImageLinkBack { get; set; }

        public Pokemon() { }

        public Pokemon(string name, EnergyType type, int basehp, List<Stat> stats, List<Attack> attacks, int level = 5, int experience = 0, string nickname = "", ExperienceGroup expgroup = ExperienceGroup.Medium_Slow)
        {
            Name = name;
            Level = level;
            Exp = experience;
            ExpGroup = expgroup;
            ExpToNext = CalculateExpToNextLevel();
            Type = type;
            BaseHP = basehp;
            MaxHP = CalculateHP();
            CurrentHP = MaxHP;
            Stats = stats;
            Attacks = attacks;
            NickName = string.IsNullOrWhiteSpace(nickname) ? name : nickname;

            ImageLinkFront = string.Format("https://img.pokemondb.net/sprites/ruby-sapphire/normal/{0}.png", name.ToLower());
            ImageLinkBack = string.Format("https://img.pokemondb.net/sprites/ruby-sapphire/back-normal/{0}.png", name.ToLower());

            CalculateStats();
        }

        public int CalculateHP()
        {
            Random rand = new Random();
            int value = BaseHP;
            for(int i=0; i<Level; i++)
            {
                int increment = rand.Next(1, 4);
                value += increment;
            }

            return value;
        }

        public void CalculateStats()
        {
            Random rand = new Random();
            foreach (Stat stat in Stats)
            {
                int value = stat.Value;
                for(int i=0; i<Level; i++)
                {
                    int increment = rand.Next(0, 4);
                    value += increment;
                }
                stat.Value = value;
            }
        }

        public int CalculateExpToNextLevel()
        {
            switch (ExpGroup)
            {
                case ExperienceGroup.Erratic:
                    return 100;
                case ExperienceGroup.Fast:
                    return 100;
                case ExperienceGroup.Medium_Fast:
                    return 100;
                case ExperienceGroup.Medium_Slow:
                    int value = (int)Math.Floor(1.2 * (Math.Pow(Level, 3) - 15 * Math.Pow(Level, 2) + 100 * Level - 140));
                    return value;
                case ExperienceGroup.Slow:
                    return 100;
                case ExperienceGroup.Fluctuating:
                    return 100;
            }

            return -1;
        }
    }

    public enum ExperienceGroup
    {
        Erratic,
        Fast,
        Medium_Fast,
        Medium_Slow,
        Slow,
        Fluctuating
    }
}
