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

namespace BadBacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

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
                index = random.Next(animalEmoji.Count);
                nextEmoji = animalEmoji[index];
                emojiIconContainer.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
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
                
            }
            else if (clickedTextBlock.Text == lastClickedTextBlock.Text)
            {
                findingMatch = false;
                clickedTextBlock.Visibility = Visibility.Hidden;

            }
            else
            {
                findingMatch = false;
                lastClickedTextBlock.Visibility = Visibility.Visible;
            }
            

        }
    }
}