using System;

namespace Game_in_Csharp
{
    public class Map
    {
        // tablica z mapą
        public static string[] level =
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
        public static string[] scroll =
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


        public static void DrawMap()
        {
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
        }
    }
}