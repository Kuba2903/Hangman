using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RandomWord();
        }

        public int tries { get; set; }
        public string letter { get; set; }

        string[] words = { "rhino", "mouse", "horse", "elephant", "giraffe" };

        public string Word { get; set; }

        char[] empty;

        
        public void RandomWord()
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 5);
            Word = words[random];


            var parts = Word.ToCharArray();

            char[] empty = new char[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {

                empty[i] = '-';
            }




            int position = rnd.Next(0, Word.Length);
            int position2 = rnd.Next(0, Word.Length);

            if (position2 == position)
                position2++;

            for (int i = 0; i < Word.Length; i++)
            {
                if (i == position)
                {
                    empty[i] = Word[i];
                }
                if (i == position2)
                {
                    empty[i] = Word[i];
                }
            }

            this.empty = empty;
            foreach (char c in empty)
            {
                this.word.Text += c;
            }


        }
        private int pic_num = 1;
        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            letter = button.Content.ToString();
            letter = letter.ToLower();

           
            //bool is_all_words_guessed = false;

            bool isGuessed = false;


            char guess = letter[0];


            for (int i = 0; i < Word.Length; i++)
            {
                if (guess == Word[i])
                {
                    empty[i] = Word[i];
                    this.word.Text = new string(empty);
                    isGuessed = true;
                }
                else
                    isGuessed = false;
            }

            if (!isGuessed)
            {
                pic.Source = new BitmapImage(new Uri($"C:/Users/bigie/source/repos/HangMan/grafika/{pic_num}.jpg"));
                pic_num++;
            }

            if(pic_num == 5)
            {
                this.word.Text = "Game end!";
                button.IsEnabled = false;
            }

        }
    }
}