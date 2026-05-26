using CyberBot;
using System.IO;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CyberBotWPF
{
    public partial class MainWindow : Window
    {
        private CSChatBot bot = new CSChatBot();
        public MainWindow()
        {
            InitializeComponent();
            Logo();

            Audio();
 

        }

        //ASCII ART
        private void Logo()
        {
            try
            {
                string logo = File.ReadAllText("ascii-text-art.txt");
                LogoTextBox.Text = logo;
            }
            catch
            {
                LogoTextBox.Text = "CYBERBOT";
            }
        }

        //AUDIO GREETING
        private void Audio()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("cyberbotGreeting.wav");
                player.Play();
            }
            catch
            {

            }
        }

        //SEND BUTTON
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //ENTER KEY SUPPORT
        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }

}