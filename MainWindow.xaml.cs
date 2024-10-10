using System.Data.Common;
using System.Net;
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
using System.Windows.Threading;

namespace BadBacks
{


    public partial class MainWindow : Window
    {

        DispatcherTimer Timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound = 0;
        bool gameStarted;
        bool playerWon = false;

        public MainWindow()
        {
            InitializeComponent();


            Timer.Interval = TimeSpan.FromSeconds(0.1);
            Timer.Tick += Timer_Tick;

            SetUpGame();
        }

        TextBlock statusTextBlock;
        private void SetUpGame()
        {

            List<string> animalEmoji;
            string nextEmoji;
            Random random;
            int index;


            animalEmoji = new List<string>()
            {
                "🐤", "🐤",
                "🐎", "🐎",
                "🐏", "🐏",
                "🐘", "🐘",
                "🐡", "🐡",
                "🦘", "🦘",
                "🐧", "🐧",
                "🐊", "🐊",
            };
            random = new Random();

            foreach (TextBlock emojiIconContainer in MainGrid.Children.OfType<TextBlock>())
            {
                emojiIconContainer.Visibility = Visibility.Visible;
                tenthsOfSecondsElapsed = 0;

                if (emojiIconContainer.Name == "statustextblock")
                {
                    emojiIconContainer.Text = "Click animal!";
                    break;
                }

                index = random.Next(animalEmoji.Count);
                nextEmoji = animalEmoji[index];
                emojiIconContainer.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }


            foreach (TextBlock textblock in MainGrid.Children.OfType<TextBlock>())
            {
                if (textblock.Name == "statustextblock")
                {
                    statusTextBlock = textblock;
                }
            }
        }


        bool findingMatch;
        TextBlock lastClickedTextBlock;

        private void mousedown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock clickedTextBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                findingMatch = true;
                clickedTextBlock.Visibility = Visibility.Hidden;
                lastClickedTextBlock = clickedTextBlock;

                statusTextBlock.Text = "Finding...";

                
                if (gameStarted == false)
                {
                    matchesFound = 0;
                    gameStarted = true;
                    playerWon = false;

                    Timer.Start();
                } 
                

            }
            else if (clickedTextBlock.Text == lastClickedTextBlock.Text)
            {
                findingMatch = false;
                clickedTextBlock.Visibility = Visibility.Hidden;
                statusTextBlock.Text = "Good job!";
                matchesFound += 1;

                if (matchesFound == 8)
                {
                    gameStarted = false;
                    playerWon = true;
                }

            }
            else
            {
                findingMatch = false;
                lastClickedTextBlock.Visibility = Visibility.Visible;
                statusTextBlock.Text = "Wrong pair!";
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            float record = tenthsOfSecondsElapsed / 10F;


            if (gameStarted == false && playerWon == false)
            {
                Timer.Stop();
                SetUpGame();

                timeTextBlock.Text = (record - 0.1).ToString("0.0s");
                statusTextBlock.Text = "You failed!";
                return;
            }

            if (gameStarted == false && playerWon == true)
            {
                Timer.Stop();
                SetUpGame();

                statusTextBlock.Text = "You won!";
            }


            tenthsOfSecondsElapsed++;

            if (record >= 5)
            {
                gameStarted = false;
            }

            timeTextBlock.Text = (record).ToString("0.0s");
        }

    }
}
