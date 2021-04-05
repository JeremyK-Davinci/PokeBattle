using PokeBattle.Utilities;
using PokeBattle.Utilities.DataObjects.Pokemon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Pokemon> Pokemons = Utility.StarterPokemon; 

        public GamePage()
        {
            InitializeComponent();
            MyPokemon = new Pokemon("Pikachu", Utility.Electric, 35, Utility.ToListItem(new Stat[] { new Atk(55), new Def(40), new SPAtk(50), new SPDef(50), new Speed(90) }), Utility.ToListItem(new Attack[] { new StatusAttack("Growl", Utility.Normal, 40, "Attack", -1), new DamageAttack("Thunder Shock", Utility.Electric, 30, 40), new StatusAttack("Tail Whip", Utility.Normal, 30, "Defense", -1) }));
            EnemyPokemon = Utility.StarterPokemon.Where(x => x.Name == "Charmander").First();

            SelectPokemonTemplate.ItemsSource = Pokemons;
            TestObject.DataContext = MyPokemon;

            UpdatePokemonImages();

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

        private void ExitBattleConfirm(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBattleCancel(object sender, RoutedEventArgs e) => ToggleExitBattleDialog(sender, e);

        private void DoAttack(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string attackName = (string)b.Tag;
        }

        public void UpdatePokemonImages()
        {
            MyPokemonImage.Source = MyPokemon.ImageBack;
            EnemyPokemonImage.Source = EnemyPokemon.ImageFront;
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
