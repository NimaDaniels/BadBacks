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

            foreach(TextBlock emojiIconHolder in MainGrid.Children.OfType<TextBlock>())
            {
                index = random.Next(animalEmoji.Count);
                nextEmoji = animalEmoji[index];
                emojiIconHolder.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }
    }
}