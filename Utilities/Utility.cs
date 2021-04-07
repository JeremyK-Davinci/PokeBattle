using PokeBattle.Utilities.DataObjects.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;

namespace PokeBattle.Utilities
{
    public class Utility
    {
        public static Page ActivePage;

        public static ObservableCollection<Pokemon> UserPokemon = CreateStarterPokemon();
        public static ObservableCollection<Pokemon> OpponentPokemon = CreateGamePokemon();

        #region EnergyTypes

        public static List<EnergyType> EnergyTypes = CreateEnergyTypes();
        public static EnergyType Normal;
        public static EnergyType Fighting;
        public static EnergyType Flying;
        public static EnergyType Poison;
        public static EnergyType Ground;
        public static EnergyType Rock;
        public static EnergyType Bug;
        public static EnergyType Ghost;
        public static EnergyType Steel;
        public static EnergyType Fire;
        public static EnergyType Water;
        public static EnergyType Grass;
        public static EnergyType Electric;
        public static EnergyType Psychic;
        public static EnergyType Ice;
        public static EnergyType Dragon;
        public static EnergyType Dark;
        public static EnergyType Fairy;

        #endregion

        private static List<EnergyType> CreateEnergyTypes()
        {
            var energyTypes = new List<EnergyType>();

            //Normal
            energyTypes.Add(new EnergyType("Normal", weaknesses:ToListItem(new[] { "Fighting" }), resistances:ToListItem(new[] { "Ghost" })));

            //Fighting
            energyTypes.Add(new EnergyType("Fighting", ToListItem(new[] { "Rock", "Bug", "Dark" }), ToListItem(new[] { "Flying", "Psychic", "Fairy" })));

            //Flying
            energyTypes.Add(new EnergyType("Flying", ToListItem(new[] { "Fighting", "Bug", "Grass" }), ToListItem(new[] { "Rock", "Electric", "Ice" }), ToListItem(new[] { "Ground" })));

            //Poison
            energyTypes.Add(new EnergyType("Poison", ToListItem(new[] { "Fighting", "Poison", "Bug", "Grass", "Fairy" }), ToListItem(new[] { "Ground", "Psychic" })));

            //Ground
            energyTypes.Add(new EnergyType("Ground", ToListItem(new[] { "Poison", "Rock" }), ToListItem(new[] { "Water", "Grass", "Ice" }), ToListItem(new[] { "Electric" })));

            //Rock
            energyTypes.Add(new EnergyType("Rock", ToListItem(new[] { "Normal", "Flying", "Poison", "Fire" }), ToListItem(new[] { "Fighting", "Ground", "Steel", "Water", "Grass" })));

            //Bug
            energyTypes.Add(new EnergyType("Bug", ToListItem(new[] { "Fighting", "Ground", "Grass" }), ToListItem(new[] { "Flying", "Rock", "Fire" })));

            //Ghost
            energyTypes.Add(new EnergyType("Ghost", ToListItem(new[] { "Poison", "Bug" }), ToListItem(new[] { "Ghost", "Dark" }), ToListItem(new[] { "Normal", "Fighting" })));

            //Steel
            energyTypes.Add(new EnergyType("Steel", ToListItem(new[] { "Normal", "Flying", "Rock", "Bug", "Steel", "Grass", "Psychic", "Ice", "Dragon", "Fairy" }), ToListItem(new[] { "Fighting", "Ground", "Fire" }), ToListItem(new[] { "Poison" })));

            //Fire
            energyTypes.Add(new EnergyType("Fire", ToListItem(new[] { "Bug", "Steel", "Fire", "Grass", "Ice", "Fairy" }), ToListItem(new[] { "Ground", "Rock", "Water" })));

            //Water
            energyTypes.Add(new EnergyType("Water", ToListItem(new[] { "Steel", "Fire", "Water", "Ice" }), ToListItem(new[] { "Grass", "Electric" })));

            //Grass
            energyTypes.Add(new EnergyType("Grass", ToListItem(new[] { "Ground", "Water", "Grass", "Electric" }), ToListItem(new[] { "Flying", "Poison", "Bug", "Fire", "Ice" })));

            //Electric
            energyTypes.Add(new EnergyType("Electric", ToListItem(new[] { "Flying", "Steel", "Electric" }), ToListItem(new[] { "Ground" })));

            //Psychic
            energyTypes.Add(new EnergyType("Psychic", ToListItem(new[] { "Fighting", "Psychic" }), ToListItem(new[] { "Bug", "Ghost", "Dark" })));

            //Ice
            energyTypes.Add(new EnergyType("Ice", ToListItem(new[] { "Ice" }), ToListItem(new[] { "Fighting", "Rock", "Steel", "Fire" })));

            //Dragon
            energyTypes.Add(new EnergyType("Dragon", ToListItem(new[] { "Fire", "Water", "Grass", "Electric" }), ToListItem(new[] { "Ice", "Dragon", "Fairy" })));

            //Dark
            energyTypes.Add(new EnergyType("Dark", ToListItem(new[] { "Ghost", "Dark" }), ToListItem(new[] { "Fighting", "Bug", "Fairy" }), ToListItem(new[] { "Psychic" })));

            //Fairy
            energyTypes.Add(new EnergyType("Fairy", ToListItem(new[] { "Fighting", "Bug", "Dark" }), ToListItem(new[] { "Poison", "Steel" }), ToListItem(new[] { "Dragon" })));

            return energyTypes;
        }

        private static void UpdateEnergyTypeVariables()
        {
            if (EnergyTypes == null || EnergyTypes.Count <= 0)
                EnergyTypes = CreateEnergyTypes();

             Normal = EnergyTypes.Where(x => x.Name == "Normal").First();
             Fighting = EnergyTypes.Where(x => x.Name == "Fighting").First();
             Flying = EnergyTypes.Where(x => x.Name == "Flying").First();
             Poison = EnergyTypes.Where(x => x.Name == "Poison").First();
             Ground = EnergyTypes.Where(x => x.Name == "Ground").First();
             Rock = EnergyTypes.Where(x => x.Name == "Rock").First();
             Bug = EnergyTypes.Where(x => x.Name == "Bug").First();
             Ghost = EnergyTypes.Where(x => x.Name == "Ghost").First();
             Steel = EnergyTypes.Where(x => x.Name == "Steel").First();
             Fire = EnergyTypes.Where(x => x.Name == "Fire").First();
             Water = EnergyTypes.Where(x => x.Name == "Water").First();
             Grass = EnergyTypes.Where(x => x.Name == "Grass").First();
             Electric = EnergyTypes.Where(x => x.Name == "Electric").First();
             Psychic = EnergyTypes.Where(x => x.Name == "Psychic").First();
             Ice = EnergyTypes.Where(x => x.Name == "Ice").First();
             Dragon = EnergyTypes.Where(x => x.Name == "Dragon").First();
             Dark = EnergyTypes.Where(x => x.Name == "Dark").First();
             Fairy = EnergyTypes.Where(x => x.Name == "Fairy").First();
    }

        private static ObservableCollection<Pokemon> CreateStarterPokemon()
        {
            UpdateEnergyTypeVariables();
            var pokemons = new ObservableCollection<Pokemon>();

            #region Generation 1

            //Bulbasaur
            pokemons.Add(new Pokemon("Bulbasaur", Grass, 45, ToListItem(new Stat[] { new Atk(49), new Def(49), new SPAtk(65), new SPDef(65), new Speed(45) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Tackle", Normal, 35, 40) })));

            //Charmander
            pokemons.Add(new Pokemon("Charmander", Fire, 39, ToListItem(new Stat[] { new Atk(52), new Def(43), new SPAtk(60), new SPDef(50), new Speed(65) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Scratch", Normal, 35, 40) })));

            //Squirtle
            pokemons.Add(new Pokemon("Squirtle", Water, 44, ToListItem(new Stat[] { new Atk(48), new Def(65), new SPAtk(50), new SPDef(64), new Speed(43) }), ToListItem(new Attack[] { new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Tail Whip", Normal, 30, "Defense", -1) })));

            #endregion

            #region Generation 2

            //Chikorita
            pokemons.Add(new Pokemon("Chikorita", Grass, 45, ToListItem(new Stat[] { new Atk(49), new Def(65), new SPAtk(49), new SPDef(65), new Speed(45) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Tackle", Normal, 35, 40) })));

            //Cyndaquil
            pokemons.Add(new Pokemon("Cyndaquil", Fire, 39, ToListItem(new Stat[] { new Atk(52), new Def(43), new SPAtk(60), new SPDef(50), new Speed(65) }), ToListItem(new Attack[] { new StatusAttack("Leer", Normal, 30, "Attack", -1), new DamageAttack("Tackle", Normal, 35, 40) })));

            //Totodile
            pokemons.Add(new Pokemon("Totodile", Water, 50, ToListItem(new Stat[] { new Atk(65), new Def(64), new SPAtk(44), new SPDef(48), new Speed(43) }), ToListItem(new Attack[] { new StatusAttack("Leer", Normal, 30, "Attack", -1), new DamageAttack("Scratch", Normal, 35, 40) })));

            #endregion

            #region Generation 3

            //Treecko
            pokemons.Add(new Pokemon("Treecko", Grass, 40, ToListItem(new Stat[] { new Atk(45), new Def(35), new SPAtk(65), new SPDef(55), new Speed(70) }), ToListItem(new Attack[] { new StatusAttack("Leer", Normal, 30, "Attack", -1), new DamageAttack("Pound", Normal, 35, 40) })));

            //Torchic
            pokemons.Add(new Pokemon("Torchic", Fire, 45, ToListItem(new Stat[] { new Atk(60), new Def(40), new SPAtk(70), new SPDef(50), new Speed(45) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Scratch", Normal, 35, 40) })));

            //Mudkip
            pokemons.Add(new Pokemon("Mudkip", Water, 50, ToListItem(new Stat[] { new Atk(70), new Def(50), new SPAtk(50), new SPDef(50), new Speed(40) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Tackle", Normal, 35, 40) })));

            #endregion

            #region Generation 4

            //Turtwig
            pokemons.Add(new Pokemon("Turtwig", Grass, 55, ToListItem(new Stat[] { new Atk(68), new Def(64), new SPAtk(45), new SPDef(55), new Speed(31) }), ToListItem(new Attack[] { new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Withdraw", Water, 40, "Defense", 1, true)})));

            //Chimchar
            pokemons.Add(new Pokemon("Chimchar", Fire, 44, ToListItem(new Stat[] { new Atk(58), new Def(44), new SPAtk(58), new SPDef(44), new Speed(61) }), ToListItem(new Attack[] { new StatusAttack("Leer", Normal, 30, "Attack", -1), new DamageAttack("Scratch", Normal, 35, 40) })));

            //Piplup
            pokemons.Add(new Pokemon("Piplup", Water, 53, ToListItem(new Stat[] { new Atk(51), new Def(53), new SPAtk(61), new SPDef(56), new Speed(40) }), ToListItem(new Attack[] { new DamageAttack("Pound", Normal, 35, 40), new StatusAttack("Growl", Normal, 40, "Attack", -1) })));

            #endregion

            #region Generation 5

            //Snivy
            pokemons.Add(new Pokemon("Snivy", Grass, 45, ToListItem(new Stat[] { new Atk(45), new Def(55), new SPAtk(45), new SPDef(55), new Speed(63) }), ToListItem(new Attack[] { new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Leer", Normal, 30, "Attack", -1) })));

            //Tepig
            pokemons.Add(new Pokemon("Tepig", Fire, 65, ToListItem(new Stat[] { new Atk(63), new Def(45), new SPAtk(45), new SPDef(45), new Speed(45) }), ToListItem(new Attack[] { new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Tail Whip", Normal, 30, "Defense", -1) })));

            //Oshawott
            pokemons.Add(new Pokemon("Oshawott", Water, 55, ToListItem(new Stat[] { new Atk(55), new Def(45), new SPAtk(63), new SPDef(45), new Speed(45) }), ToListItem(new Attack[] { new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Tail Whip", Normal, 30, "Defense", -1) })));

            #endregion

            /*#region Generation 6

            //Chespin
            pokemons.Add(new Pokemon("Chespin", Grass, 56, ToListItem(new Stat[] { new Atk(61), new Def(65), new SPAtk(48), new SPDef(45), new Speed(38) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Tackle", Normal, 35, 40), new DamageAttack("Vine Whip", Grass, 25, 45) })));

            //Fennekin
            pokemons.Add(new Pokemon("Fennekin", Fire, 40, ToListItem(new Stat[] { new Atk(45), new Def(40), new SPAtk(62), new SPDef(60), new Speed(60) }), ToListItem(new Attack[] { new DamageAttack("Scratch", Normal, 35, 40), new StatusAttack("Tail Whip", Normal, 30, "Defense", -1), new DamageAttack("Ember", Fire, 25, 40) })));

            //Froakie
            pokemons.Add(new Pokemon("Froakie", Water, 41, ToListItem(new Stat[] { new Atk(56), new Def(40), new SPAtk(62), new SPDef(44), new Speed(71) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Pound", Normal, 35, 40), new DamageAttack("Bubble", Water, 30, 40) })));

            #endregion

            #region Generation 7

            //Rowlet
            pokemons.Add(new Pokemon("Rowlet", Grass, 68, ToListItem(new Stat[] { new Atk(55), new Def(55), new SPAtk(50), new SPDef(50), new Speed(42) }), ToListItem(new Attack[] { new DamageAttack("Leafage", Grass, 40, 40), new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Growl", Normal, 40, "Attack", -1) })));

            //Litten
            pokemons.Add(new Pokemon("Litten", Fire, 45, ToListItem(new Stat[] { new Atk(65), new Def(40), new SPAtk(60), new SPDef(40), new Speed(70) }), ToListItem(new Attack[] { new DamageAttack("Ember", Fire, 25, 40), new DamageAttack("Scratch", Normal, 35, 40), new StatusAttack("Growl", Normal, 40, "Attack", -1) })));

            //Popplio
            pokemons.Add(new Pokemon("Popplio", Water, 50, ToListItem(new Stat[] { new Atk(54), new Def(54), new SPAtk(66), new SPDef(56), new Speed(40) }), ToListItem(new Attack[] { new DamageAttack("Pound", Normal, 35, 40), new DamageAttack("Water Gun", Water, 25, 40), new StatusAttack("Growl", Normal, 40, "Attack", -1) })));

            #endregion*/

            return pokemons;
        }

        private static ObservableCollection<Pokemon> CreateGamePokemon()
        {
            if (UserPokemon == null || UserPokemon.Count <= 0)
                UserPokemon = CreateStarterPokemon();
            var pokemons = new ObservableCollection<Pokemon>();

            foreach (Pokemon p in UserPokemon) pokemons.Add(p);

            #region Generation 1

            //Eevee
            pokemons.Add(new Pokemon("Eevee", Normal, 55, ToListItem(new Stat[] { new Atk(55), new Def(50), new SPAtk(45), new SPDef(65), new Speed(55) }), ToListItem(new Attack[] { new DamageAttack("Tackle", Normal, 35, 40), new StatusAttack("Tail Whip", Normal, 30, "Defense", -1) })));

            //Pikachu
            pokemons.Add(new Pokemon("Pikachu", Electric, 35, ToListItem(new Stat[] { new Atk(55), new Def(40), new SPAtk(50), new SPDef(50), new Speed(90) }), ToListItem(new Attack[] { new StatusAttack("Growl", Normal, 40, "Attack", -1), new DamageAttack("Thunder Shock", Electric, 30, 40) })));

            #endregion

            return pokemons;
        }

        /// <summary>
        /// Creates a string list from a string array
        /// </summary>
        public static List<T> ToListItem<T>(T[] values) => new List<T>(values);

        public static BitmapImage GetImageFromUri(string uri) => new BitmapImage(new Uri(uri, UriKind.Absolute));
    }
}
