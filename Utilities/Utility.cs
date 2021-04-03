using PokeBattle.Utilities.DataObjects.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace PokeBattle.Utilities
{
    public class Utility
    {
        public static Page ActivePage;

        public static List<EnergyType> EnergyTypes = CreateEnergyTypes();

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

        /// <summary>
        /// Creates a string list from a string array
        /// </summary>
        private static List<string> ToListItem(string[] values) => new List<string>(values);
    }
}
