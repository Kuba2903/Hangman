

class Program
{
    public static void Main(string[] args)
    {
        string[] words = { "Dog", "Mouse", "Horse", "Elephant" };


        while (true)
        {
            int tries = 3;

            Random rnd = new Random();
            int random = rnd.Next(0, 4);
            string word = words[random];

            var parts = word.ToCharArray();

            char[] empty = new char[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {

                empty[i] = '-';
            }


            Console.WriteLine("Try to guess the word!\n");

            int position = rnd.Next(0, word.Length);

            for (int i = 0; i < word.Length; i++)
            {
                if (i == position)
                {
                    empty[i] = word[i];
                }
            }

            foreach (var x in empty)
            {
                Console.Write(x);
            }
            Console.WriteLine();

            bool is_all_words_guessed = false;
            while (!is_all_words_guessed)
            {
                bool isGuessed = false;


                Console.WriteLine("Enter a character:");
                char guess = char.Parse(Console.ReadLine());

                for (int i = 0; i < word.Length; i++)
                {
                    if (guess == word[i])
                    {
                        empty[i] = word[i];
                        isGuessed = true;
                    }
                }

                if (isGuessed)
                {
                    Console.WriteLine("You guessed a character!");
                }
                else
                {
                    Console.WriteLine("You didn't guessed!");
                    tries--;
                    if (tries == 0)
                    {
                        break;
                    }
                    Console.WriteLine($"You still have {tries} chances");
                }

                foreach (var x in empty)
                {
                    Console.Write(x);
                }
                Console.WriteLine();
                if (!empty.Contains('-'))
                {
                    is_all_words_guessed = true;
                }

            }
            Console.WriteLine();
            if (!empty.Contains('-'))
            {
                Console.WriteLine($"Congratulations! You guessed the word {word}");
            }
            else
            {
                Console.WriteLine("You lost all your chances!");
                Console.WriteLine($"The word was {word}");
            }

            Console.WriteLine("Do you want to play again? (Y/N)");

            string again = Console.ReadLine();
            if(again.ToLower() == "yes" || again.ToLower() == "y")
            {
                continue;
            }
            else
            {
                break;
            }
        }
    }
}
