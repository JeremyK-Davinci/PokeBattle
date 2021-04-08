using PokeBattle.Utilities;
using PokeBattle.Utilities.DataObjects.Pokemon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PokeBattle.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private delegate void CrossUpdateTimer(int value);
        private delegate void CrossUpdateBattleInfoText(char text);
        private delegate void CrossClearBattleInfoText();
        private delegate void CrossLoadGameScreen();
        private Button LastSelected;
        private Pokemon MyPokemon;
        private Pokemon EnemyPokemon;
        public ObservableCollection<Pokemon> Pokemons = Utility.UserPokemon;
        public ObservableCollection<Pokemon> ComputerPokemons = Utility.OpponentPokemon;

        public GamePage()
        {
            InitializeComponent();

            SelectPokemonTemplate.ItemsSource = Pokemons;
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

        private void ExitBattleConfirm(object sender, RoutedEventArgs e) => ClosePage();

        private void ExitBattleCancel(object sender, RoutedEventArgs e) => ToggleExitBattleDialog(sender, e);

        private void DoAttack(object sender, RoutedEventArgs e)
        {
            BattleAttackButtonDisplay.Visibility = Visibility.Hidden;
            BattleInfoDisplay.Visibility = Visibility.Visible;
            DisableInput();

            Button b = (Button)sender;
            string attackName = (string)b.Tag;
            Attack myAtk = MyPokemon.Attacks.Where(x => x.Name == attackName).FirstOrDefault();

            Random rand = new Random();
            int i = rand.Next(0, EnemyPokemon.Attacks.Count);
            Attack enemyAtk = EnemyPokemon.Attacks[i];

            StartAttackSequence(myAtk, enemyAtk);
        }

        private async void StartAttackSequence(Attack MyAttack, Attack EnemyAttack)
        {
            if(MyAttack.Priority > EnemyAttack.Priority)
            {
                await PerformAttack(MyPokemon, EnemyPokemon, MyAttack);
                if (EnemyPokemon == null) return;
                await PerformAttack(EnemyPokemon, MyPokemon, EnemyAttack);
            }
            else if(MyAttack.Priority < EnemyAttack.Priority)
            {
                await PerformAttack(EnemyPokemon, MyPokemon, EnemyAttack);
                if (MyPokemon == null) return;
                await PerformAttack(MyPokemon, EnemyPokemon, MyAttack);
            }
            else
            {
                var MyPokemonSpeed = MyPokemon.CurrentStats.Where(x => x.Name == "Speed").FirstOrDefault().Value;
                var EnemyPokemonSpeed = EnemyPokemon.CurrentStats.Where(x => x.Name == "Speed").FirstOrDefault().Value;
                if (MyPokemonSpeed > EnemyPokemonSpeed || MyPokemonSpeed == EnemyPokemonSpeed)
                {
                    await PerformAttack(MyPokemon, EnemyPokemon, MyAttack);
                    if (EnemyPokemon == null) return;
                    await PerformAttack(EnemyPokemon, MyPokemon, EnemyAttack);
                }
                else if (MyPokemonSpeed < EnemyPokemonSpeed)
                {
                    await PerformAttack(EnemyPokemon, MyPokemon, EnemyAttack);
                    if (MyPokemon == null) return;
                    await PerformAttack(MyPokemon, EnemyPokemon, MyAttack);
                }
            }
            EnableInput();
        }

        private async Task PerformAttack(Pokemon sender, Pokemon reciever, Attack which)
        {
            bool forEnemy = EnemyPokemon == reciever;
            var attackType = which.Type.Name;
            var senderAttack = sender.CurrentStats.Where(x => x.Name == "Attack").FirstOrDefault().Value;
            var recieverDefense = reciever.CurrentStats.Where(x => x.Name == "Defense").FirstOrDefault().Value;
            if (reciever.Type.Resistances.Contains(attackType))
            {
                await WriteToBattleInfo($"{sender.NickName} used {which.Name}");
                await WriteToBattleInfo($"It has no effect on {reciever.NickName}");
            }
            else if (reciever.Type.Strenghts.Contains(attackType))
            {
                await WriteToBattleInfo($"{sender.NickName} used {which.Name}");
                if(which is DamageAttack)
                {
                    var attack = which as DamageAttack;
                    int damage = CalculateAttackDamage(sender.Level, senderAttack, attack.Damage, recieverDefense, 0.5, sender.Type, attack.Type);
                    await UpdateBattleDisplay(forEnemy, damage);
                    await WriteToBattleInfo($"It was not very effective...");
                }
                else if(which is StatusAttack)
                {
                    var status = which as StatusAttack;
                    UpdateStatusAfflictions(reciever, status);
                    bool canUpdate = UpdateStatusAfflictions(reciever, status);
                    if (canUpdate)
                        await WriteToBattleInfo($"{reciever.NickName}'s {status.AfflictingStatus} was decreased");
                    else
                        await WriteToBattleInfo("nothing happened");
                }
            }
            else if (reciever.Type.Weaknesses.Contains(attackType))
            {
                await WriteToBattleInfo($"{sender.NickName} used {which.Name}");
                if (which is DamageAttack)
                {
                    var attack = which as DamageAttack;
                    int damage = CalculateAttackDamage(sender.Level, senderAttack, attack.Damage, recieverDefense, 2, sender.Type, attack.Type);
                    await UpdateBattleDisplay(forEnemy, damage);
                    await WriteToBattleInfo($"It was very effective...");
                }
                else if (which is StatusAttack)
                {
                    var status = which as StatusAttack;
                    bool canUpdate = UpdateStatusAfflictions(reciever, status, 2);
                    if (canUpdate)
                        await WriteToBattleInfo($"{reciever.NickName}'s {status.AfflictingStatus} was greatly decreased");
                    else
                        await WriteToBattleInfo("nothing happened");
                }
            }
            else
            {
                await WriteToBattleInfo($"{sender.NickName} used {which.Name}");
                if (which is DamageAttack)
                {
                    var attack = which as DamageAttack;
                    int damage = CalculateAttackDamage(sender.Level, senderAttack, attack.Damage, recieverDefense, 1, sender.Type, attack.Type);
                    await UpdateBattleDisplay(forEnemy, damage);
                }
                else if (which is StatusAttack)
                {
                    var status = which as StatusAttack;
                    UpdateStatusAfflictions(reciever, status);
                    bool canUpdate = UpdateStatusAfflictions(reciever, status);
                    if (canUpdate)
                        await WriteToBattleInfo($"{reciever.NickName}'s {status.AfflictingStatus} was decreased");
                    else
                        await WriteToBattleInfo("nothing happened");
                }
            }
            await Task.Delay(250);
        }

        private async Task UpdateBattleDisplay(bool forEnemy, int damage)
        {
            if (forEnemy)
            {
                if (EnemyPokemon.CurrentHP - damage < 0)
                {
                    EnemyPokemon.CurrentHP = 0;
                    EnemyPokemon.Fainted = true;
                    EnemyHealth.Value = EnemyPokemon.CurrentHP;
                    await WriteToBattleInfo($"{MyPokemon.NickName} Defeated {EnemyPokemon.NickName}");
                    await WriteToBattleInfo("Returning to Menu");
                    ClosePage();
                }
                else
                {
                    EnemyPokemon.CurrentHP -= damage;
                    EnemyHealth.Value = EnemyPokemon.CurrentHP;
                }
            }
            else
            {
                if (MyPokemon.CurrentHP - damage < 0)
                {
                    MyPokemon.CurrentHP = 0;
                    MyPokemon.Fainted = true;
                    MyHealth.Value = MyPokemon.CurrentHP;
                    MyCurrentHealthText.Text = $"{MyPokemon.CurrentHP}";
                    await WriteToBattleInfo($"{EnemyPokemon.NickName} Defeated {MyPokemon.NickName}");
                    await WriteToBattleInfo("Returning to menu");
                    ClosePage();
                }
                else
                {
                    MyPokemon.CurrentHP -= damage;
                    MyHealth.Value = MyPokemon.CurrentHP;
                    MyCurrentHealthText.Text = $"{MyPokemon.CurrentHP}";
                }
            }
        }

        private async Task WriteToBattleInfo(string text)
        {
            BattleInfoDisplay.Visibility = Visibility.Visible;
            Task t = new Task(() =>
            {
                for (int i = 0; i < text.Length; i++)
                {
                    delegateUpdateBattleInfoText(text[i]);
                    Task.Delay(50).GetAwaiter().GetResult();
                }
                Task.Delay(2500).GetAwaiter().GetResult();
                delegateClearBattleInfoText();
            });
            t.Start();
            while (!t.IsCompleted) await Task.Delay(1);
        }

        private void StartTimer()
        {
            int countdown = 5;
            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    delegateUpdateTimer(countdown);
                    countdown--;
                    Thread.Sleep(1000);
                }
                delegateLoadGameScreen();
            });
            t.Start();
        }

        private void delegateClearBattleInfoText() => Dispatcher.Invoke(new CrossClearBattleInfoText(ClearBattleInfoText));

        private void ClearBattleInfoText() => BattleInfoText.Text = "";

        private void delegateUpdateBattleInfoText(char c) => Dispatcher.Invoke(new CrossUpdateBattleInfoText(UpdateBattleInfoText), c);

        private void UpdateBattleInfoText(char c) => BattleInfoText.Text = BattleInfoText.Text + c;

        private void delegateLoadGameScreen() => Dispatcher.Invoke(new CrossLoadGameScreen(LoadGameScreen));

        private void LoadGameScreen() => GameStartingWindow.Visibility = Visibility.Hidden;

        private void UpdateTimer(int value) => StartingTextCountdown.Text = $"{value}";

        private void delegateUpdateTimer(int value) => Dispatcher.Invoke(new CrossUpdateTimer(UpdateTimer), value);

        private void SelectPokemon(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if(b != LastSelected)
            {
                if(LastSelected != null)
                    LastSelected.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                LastSelected = b;
                MyPokemon = Pokemons.Where(x => x.Name == (string)b.Tag).FirstOrDefault();
                ButtonStartGame.IsEnabled = true;
            }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            UpdateEnemyPokemon();
            if(MyPokemon != null && EnemyPokemon != null)
            {
                PreStartDialogWindow.Visibility = Visibility.Hidden;
                GameStartingWindow.Visibility = Visibility.Visible;
                UpdateDataContext(MyPokemon, false);
                UpdateDataContext(EnemyPokemon, true);
                UpdatePokemonImages();
                StartTimer();
            }
        }

        private void ClosePage()
        {
            MyPokemon = null;
            EnemyPokemon = null;
            LastSelected = null;
            Utility.ResetPokemon();
            PreGameWindow._Window.CloseCurrentPage();
        }

        public int CalculateAttackDamage(int senderLevel, int senderAttack, int attackDamage, int recieverDefense, double TypeModifier, EnergyType senderType, EnergyType attackType)
        {
            Random rand = new Random();
            int random = rand.Next(217, 255);
            double stab = senderType == attackType ? 1.5 : 1;
            decimal levelVal = (decimal)((2 * senderLevel) / 5) + 2;
            decimal atkDefVal;

            try
            {
                atkDefVal = (decimal)senderAttack / recieverDefense;
            }
            catch(DivideByZeroException e)
            {
                atkDefVal = (decimal)0.5;
            }

            decimal randomMod = (decimal)random / 255;
            decimal modifier = (decimal)((double)randomMod * stab * TypeModifier);

            int ReturnDamage = (int)Math.Ceiling((double)(((((levelVal * attackDamage) * atkDefVal) / 50) + 2) * modifier) * 2.5);
            return ReturnDamage;
        }

        public bool UpdateStatusAfflictions(Pokemon reciever, StatusAttack attack, int multiplier = 1)
        {
            var origStatus = reciever.Stats.Where(x => x.Name == attack.AfflictingStatus).FirstOrDefault();
            var status = reciever.CurrentStats.Where(x => x.Name == attack.AfflictingStatus).FirstOrDefault();
            if ((status.CurrentAffliction == -6 && attack.AfflictionValue < 0) || (status.CurrentAffliction == 6 && attack.AfflictionValue > 0)) return false;
            status.CurrentAffliction += (attack.AfflictionValue * multiplier);

            switch (status.CurrentAffliction)
            {
                case -6:
                    status.Value = (int)(origStatus.Value * 0.25);
                    return true;
                case -5:
                    status.Value = (int)(origStatus.Value * 0.28);
                    return true;
                case -4:
                    status.Value = (int)(origStatus.Value * 0.33);
                    return true;
                case -3:
                    status.Value = (int)(origStatus.Value * 0.4);
                    return true;
                case -2:
                    status.Value = (int)(origStatus.Value * 0.5);
                    return true;
                case -1:
                    status.Value = (int)(origStatus.Value * 0.66);
                    return true;
                case 0:
                    status.Value = origStatus.Value;
                    return true;
                case 1:
                    status.Value = (int)(origStatus.Value * 1.5);
                    return true;
                case 2:
                    status.Value = (int)(origStatus.Value * 2);
                    return true;
                case 3:
                    status.Value = (int)(origStatus.Value * 2.5);
                    return true;
                case 4:
                    status.Value = (int)(origStatus.Value * 3);
                    return true;
                case 5:
                    status.Value = (int)(origStatus.Value * 3.5);
                    return true;
                case 6:
                    status.Value = (int)(origStatus.Value * 4);
                    return true;
            }
            return false;
        }

        private void DisableInput()
        {
            ButtonAttack.IsEnabled = false;
            ButtonRun.IsEnabled = false;
        }

        private void EnableInput()
        {
            ButtonAttack.IsEnabled = true;
            ButtonRun.IsEnabled = true;
        }

        public void UpdateEnemyPokemon()
        {
            Random rand = new Random();
            int index = rand.Next(0, ComputerPokemons.Count);
            if (ComputerPokemons[index] == MyPokemon)
                index = rand.Next(0, ComputerPokemons.Count);
            EnemyPokemon = ComputerPokemons[index];
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
