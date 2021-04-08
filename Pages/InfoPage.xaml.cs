using PokeBattle.Utilities;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PokeBattle.Pages
{
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            IconCreditsTemplate.ItemsSource = Utility.IconCredits;
            DesignCreditsTemplate.ItemsSource = Utility.DesignCredits;
            DevelopmentCreditsTemplate.ItemsSource = Utility.DevelopmentCredits;
            string copy = char.ConvertFromUtf32(169);
            string copyright = $"{copy} Overnight Studios, 2019-2021";
            Copyright.Text = copyright;
        }

        private void NavigateToWeb(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    string url = e.Uri.AbsoluteUri.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", e.Uri.AbsoluteUri);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", e.Uri.AbsoluteUri);
                }
                else
                {
                    throw;
                }
            }
            e.Handled = true;
        }
    }
}
