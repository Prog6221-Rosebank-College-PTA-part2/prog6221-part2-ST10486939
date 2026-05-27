using CyberBot;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberBotWPF
{
    public partial class MainWindow : Window
    {
        private CSChatBot bot = new CSChatBot();
        private string userName = "";
        
        public MainWindow()
        {
            InitializeComponent();
            Logo();

            Audio();

            BotMessage("Welcome to the Cyber Security Awareness chatbot");
            BotMessage("What is your name?");
            

        }

        //ASCII ART
        private async Task Logo()
        {
            try
            {
                string logo = File.ReadAllText("ascii-text-art.txt");
                LogoTextBox.Text = logo;

                //flicker effect
                for (int i=0; i<6; i++)
                {
                    LogoTextBox.Text = "";

                    await Task.Delay(80);

                    LogoTextBox.Text = logo;

                    await Task.Delay(80);
                }

                //stable no flicker art
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
            SendMessage();
        }

        //SEND MESSAGE 
        private async void SendMessage()
        {
            string userInput = MessageTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            UserMessage(userInput);

            MessageTextBox.Clear();

            //USERNAME INPUT
            if (string.IsNullOrEmpty(userName))
            {
                userName = userInput;

                //typing bubble
                Border typingBubble = TypingBubble();
                ChatPanel.Children.Add(typingBubble);
                ChatScrollViewer.ScrollToEnd();

                //simulateed delay
                await Task.Delay(1500);

                //remove typing bubble
                ChatPanel.Children.Remove(typingBubble);

                BotMessage("Nice to meet you, " + userName + "!");
                BotMessage("Ask me anything about cybersecurity.");

                return;
            }

            //TYPING ANIMATION
            Border bottypingBubble = TypingBubble();
            ChatPanel.Children.Add(bottypingBubble);
            ChatScrollViewer.ScrollToEnd();
            await Task.Delay(1500);
            ChatPanel.Children.Remove(bottypingBubble);

            //Chatbot response
            string response = bot.GetResponse(userInput, userName);

            BotMessage(response);

        }

        //ENTER KEY SUPPORT
        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.Key == Key.Enter)
            {
                SendMessage();
            }
        }


        //USER INPUT
        private void UserMessage(string message)
        {
            Border bubble = new Border
            { 
                Background = System.Windows.Media.Brushes.HotPink,
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(12),
                Margin = new Thickness(150, 5, 10, 5),
                HorizontalAlignment = HorizontalAlignment.Right,
                MaxWidth = 400
            };

            TextBlock text = new TextBlock
            {
                Text = userName+": "+message,
                Foreground = System.Windows.Media.Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 15,
                TextAlignment = TextAlignment.Left
            };

            bubble.Child = text;

            ChatPanel.Children.Add(bubble);

            ChatScrollViewer.ScrollToEnd();
        }

        private object newBrushConverter()
        {
            throw new NotImplementedException();
        }

        //BOT MESSAGE
        private void BotMessage(string message)
        {
            Border bubble = new Border
            {
                //Background = System.Windows.Media.Brushes.DarkSlateGray,
                Background = System.Windows.Media.Brushes.DimGray,
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(12),
                Margin = new Thickness(10, 5, 150, 5),
                HorizontalAlignment = HorizontalAlignment.Left,
                MaxWidth = 400,
                BorderBrush = System.Windows.Media.Brushes.DimGray,
                BorderThickness = new Thickness(1)
            };

            TextBlock text = new TextBlock
            {
                Text = "Cyberbot: " + message,
                Foreground = System.Windows.Media.Brushes.WhiteSmoke,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 15
            };

            bubble.Child = text;

            ChatPanel.Children.Add(bubble);

            ChatScrollViewer.ScrollToEnd();
        }

        //TYPING BUBBLE
        private Border TypingBubble()
        {
            Border bubble = new Border
            {
                Background = System.Windows.Media.Brushes.DimGray,
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(12),
                Margin = new Thickness(10, 5, 150, 5),
                HorizontalAlignment = HorizontalAlignment.Left,
                MaxWidth = 250,
                BorderBrush = System.Windows.Media.Brushes.DimGray,
                BorderThickness = new Thickness(1)
            };

            TextBlock text = new TextBlock
            {
                Text = "Cyberbot is typing...",
                Foreground = System.Windows.Media.Brushes.WhiteSmoke,
                FontStyle = FontStyles.Italic,
                FontSize = 14
            };

            bubble.Child = text;

            return bubble;
        }

    }

}