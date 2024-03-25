using System;

namespace Game_in_Csharp
{
    class Program
    {
        static void Main(string[] args)
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

            // tablica z mapą
            string[] level =
             {
                "############",
                "#     #    #",
                "#     #    #",
                "#   ###    #",
                "#   #      #",
                "#   #      #",
                "#   ###    #",
                "#          #",
                "############"
            };

            //tablica z pergaminem na którym wyświetlana jest mapa
            string[] scroll =
            {
                 "      _______________",
                 "()==(               (@==()",
                 "     '______________'|",
                 "      |              |",
                 "      |              |    ",
                 "     _|______________|    ",
                 "()==(               (@==()",
                 "     '--------------'     "
            };

            Console.Clear();
            Console.WriteLine("Before you start your journey, you need to know where you are going.");
            Console.WriteLine("Here's a map of the area you are about to explore. You can move around using the arrow keys.");
            Console.WriteLine("Wanna see the map? Press any key until it is revealed...");

            // wyświetlenie połowy pergaminu
            int scrollHalf = scroll.Length / 2;
            for (int i = 0; i < scrollHalf; i++)
            {
                Console.WriteLine(scroll[i]);
            }

            // wyświetlenie mapy na pergaminie
            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in level)
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"      | {row} |");

                for (int i = scrollHalf; i < scroll.Length; i++)
                {
                    Console.WriteLine(scroll[i]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }

            // wyświetlenie drugiej połowy pergaminu
            Console.Clear();
            foreach (string row in level)
            {
                Console.WriteLine(row);
            }


            Player player = new Player(2,3,"@");

            // funckja poruszanienia gracza po mapie
            while (true)
            {
                // wyświetlenie gracza na mapie
                Display.WriteAt(player.x, player.y, player.avatar);

                // odczytanie klawisza
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // usunięcie gracza z poprzedniej pozycji
                string currentRow = level[player.y];
                char currentCell = currentRow[player.x];
                Display.WriteAt(player.x, player.y, currentCell);

                player.Move(keyInfo, level);
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}
