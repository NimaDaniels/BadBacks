﻿using System.Net;
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

        public MainWindow()
        {
            InitializeComponent();


            Timer.Interval = TimeSpan.FromSeconds(0.1);
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
                "🐊", "🐊"
            };
            random = new Random();

            foreach (TextBlock emojiIconContainer in MainGrid.Children.OfType<TextBlock>())
            {
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
            }
            else if (clickedTextBlock.Text == lastClickedTextBlock.Text)
            {
                findingMatch = false;
                clickedTextBlock.Visibility = Visibility.Hidden;
                statusTextBlock.Text = "Good job!";
                matchesFound += 1;

                if (matchesFound == 8)
                {
                    statusTextBlock.Text = "You won!";
                }

            }
            else
            {
                findingMatch = false;
                lastClickedTextBlock.Visibility = Visibility.Visible;
                statusTextBlock.Text = "Wrong pair!";
            }

        }



    }
}