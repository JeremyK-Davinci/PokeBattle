using PokeBattle.Utilities;
using PokeBattle.Utilities.DataObjects.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokeBattle.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Pokemon MyPokemon;

        private Pokemon EnemyPokemon;

        public GamePage()
        {
            InitializeComponent();
            MyPokemon = new Pokemon("Pikachu", Utility.EnergyTypes.Where(x => x.Name == "Electric").FirstOrDefault(), 35,
                                    Utility.ToListItem(new Stat[] { new Atk(55), new Def(40), new SPAtk(50), new SPDef(50), new Speed(90) }),
                                    Utility.ToListItem(new Attack[] {
                                        new StatusAttack("Growl", Utility.EnergyTypes.Where(x => x.Name == "Normal").FirstOrDefault(), 40, "Attack", -1),
                                        new DamageAttack("Thunder Shock", Utility.EnergyTypes.Where(x => x.Name == "Electric").FirstOrDefault(), 30, 40),
                                        new StatusAttack("Tail Whip", Utility.EnergyTypes.Where(x => x.Name == "Normal").FirstOrDefault(), 30, "Defense", -1)
                                    }));

            EnemyPokemon = new Pokemon("Charmander", Utility.EnergyTypes.Where(x => x.Name == "Fire").FirstOrDefault(), 39,
                                        Utility.ToListItem(new Stat[] { new Atk(52), new Def(43), new SPAtk(60), new SPDef(50), new Speed(65) }),
                                        Utility.ToListItem(new Attack[] {
                                            new StatusAttack("Growl", Utility.EnergyTypes.Where(x => x.Name == "Normal").FirstOrDefault(), 40, "Attack", -1),
                                            new DamageAttack("Scratch", Utility.EnergyTypes.Where(x => x.Name == "Normal").FirstOrDefault(), 35, 40)
                                        }));

            UpdatePokemonImages(MyPokemon.ImageLinkBack, EnemyPokemon.ImageLinkFront);

            UpdateDataContext(EnemyPokemon, true);
            UpdateDataContext(MyPokemon, false);
        }

        private void ToggleAttackButtonsDisplay(object sender, RoutedEventArgs e)
        {
            if(BattleAttackButtonDisplay.Visibility == Visibility.Visible)
            {
                BattleAttackButtonDisplay.Visibility = Visibility.Hidden;
                BattleInfoDisplay.Visibility = Visibility.Visible;
            }
            else
            {
                BattleInfoDisplay.Visibility = Visibility.Hidden;
                BattleAttackButtonDisplay.Visibility = Visibility.Visible;
            }
        }

        private void ToggleExitBattleDialog(object sender, RoutedEventArgs e)
        {
            if (ExitBattleDialogWindow.Visibility == Visibility.Hidden)
                ExitBattleDialogWindow.Visibility = Visibility.Visible;
            else
                ExitBattleDialogWindow.Visibility = Visibility.Hidden;
        }

        private void ExitBattleDialogConfirm(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBattleDialogCancel(object sender, RoutedEventArgs e) => ToggleExitBattleDialog(sender, e);

        public void UpdatePokemonImages(string mySource, string enemySource)
        {
            MyPokemonImage.Source = Utility.GetImageFromUri(mySource);
            EnemyPokemonImage.Source = Utility.GetImageFromUri(enemySource);
        }

        public void UpdateDataContext(Pokemon Selected, bool isEnemy)
        {
            if (isEnemy)
            {
                EnemyIndicator.DataContext = EnemyPokemon;

                EnemyHealth.Maximum = EnemyPokemon.MaxHP;
                EnemyHealth.Value = EnemyPokemon.CurrentHP;
            }
            else
            {
                MyIndicator.DataContext = MyPokemon;

                MyHealth.Maximum = MyPokemon.MaxHP;
                MyHealth.Value = MyPokemon.CurrentHP;

                MyExperience.Maximum = MyPokemon.ExpToNext;
                MyExperience.Value = MyPokemon.Exp;

                AttacksTemplate.ItemsSource = Selected.Attacks;
            }
        }
    }
}
