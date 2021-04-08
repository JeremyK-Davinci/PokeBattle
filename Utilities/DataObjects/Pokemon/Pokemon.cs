using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;

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

        public List<Stat> CurrentStats { get; set; }

        public List<Attack> Attacks { get; set; }

        public BitmapImage ImageFront { get; set; }

        public BitmapImage ImageBack { get; set; }

        public bool Fainted { get; set; }

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
            Fainted = false;

            string ImageLinkFront = string.Format("https://img.pokemondb.net/sprites/black-white/normal/{0}.png", name.ToLower());
            string ImageLinkBack = string.Format("https://img.pokemondb.net/sprites/black-white/back-normal/{0}.png", name.ToLower());

            ImageFront = Utility.GetImageFromUri(ImageLinkFront);
            ImageBack = Utility.GetImageFromUri(ImageLinkBack);

            CalculateStats();

            CurrentStats = Stats;
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
                    int increment = rand.Next(0, 5);
                    value += increment;
                }
                stat.Value = value;
            }
        }

        public int CalculateExpToNextLevel()
        {
            int value = -1;
            switch (ExpGroup)
            {
                case ExperienceGroup.Erratic:
                    value = CalculateExpToNextLevelErratic();
                    return value;
                case ExperienceGroup.Fast:
                    value = (int)Math.Floor(0.8 * Math.Pow(Level, 3));
                    return value;
                case ExperienceGroup.Medium_Fast:
                    value = (int)Math.Floor(Math.Pow(Level, 3));
                    return value;
                case ExperienceGroup.Medium_Slow:
                    value = (int)Math.Floor(1.2 * (Math.Pow(Level, 3) - 15 * Math.Pow(Level, 2) + 100 * Level - 140));
                    return value;
                case ExperienceGroup.Slow:
                    value = (int)Math.Floor(1.25 * Math.Pow(Level, 3));
                    return value;
                case ExperienceGroup.Fluctuating:
                    value = CalculateExpToNextLevelFluctuating();
                    return value;
            }

            return value;
        }

        private int CalculateExpToNextLevelErratic()
        {
            if (Level < 50)
                return (int)Math.Floor(Math.Pow(Level, 3) * (100 - Level) / 50);
            else if (Level >= 50 && Level < 68)
                return (int)Math.Floor(Math.Pow(Level, 3) * (150 - Level) / 100);
            else if (Level >= 68 && Level < 98)
                return (int)Math.Floor(Math.Pow(Level, 3) * ((1911 - (10 * Level)) / 3) / 500);
            else
                return (int)Math.Floor(Math.Pow(Level, 3) * (160 - Level) / 100);
        }

        private int CalculateExpToNextLevelFluctuating()
        {
            if (Level < 15)
                return (int)Math.Floor(Math.Pow(Level, 3) * ((((Level + 1) / 3) + 24) / 50));
            else if (Level >= 15 && Level < 36)
                return (int)Math.Floor(Math.Pow(Level, 3) * ((Level + 14) / 50));
            else
                return (int)Math.Floor(Math.Pow(Level, 3) * (((Level / 2) + 32) / 50));
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
