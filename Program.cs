using System;
using System.ComponentModel;

namespace Game_in_Csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Who are you, Stranger?");
            string name = Console.ReadLine();

            // sprawdzenie czy gracz podał swoje imię
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("I will still call you Stranger, then.");
                name = "Stranger";
            }
            else if (name.ToLower() == "stranger")
            {
                Console.WriteLine("Ha! I knew it!");
            }

            // zapytanie o miejsce pochodzenia gracza
            Console.WriteLine($"Where are you from {name}?");
            string place = Console.ReadLine();

            // sprawdzenie czy gracz podał swoje miejsce pochodzenia
            if (string.IsNullOrWhiteSpace(place))
            {
                Console.WriteLine("You are not to talkative, are you?");
                place = "Nowhere";
            }
            else if (place.ToLower() == "nowhere")
            {
                Console.WriteLine("Oh! Exacly what I guessed!");
            }

            Console.WriteLine($"Welcome to Game {name} from {place}!");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey(true);

            Console.Clear();
            Console.WriteLine("Before you start your journey, you need to know where you are going.");
            Console.WriteLine("Here's a map of the area you are about to explore. You can move around using the arrow keys. Your mission is to find the key to the treasure chest.");
            Console.WriteLine("Wanna see the map? Press any key until it is revealed...");

            string[] level = Map.level;
            string[] scroll = Map.scroll;
            Map.DrawMap();

            Player player = new Player(2,3,"@");

            while (true)
            {
                Display.WriteAt(player.x, player.y, player.avatar);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                string currentRow = level[player.y];
                char currentCell = currentRow[player.x];
                Display.WriteAt(player.x, player.y, currentCell);

                player.Move(keyInfo, level);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (player.CheckWinRules())
                {
                    break;
                }
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}
