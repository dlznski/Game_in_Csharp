using System;

namespace Game_in_Csharp
{
    class Display
    {
        // funkcja odpowiedzialna za wyświetlanie gracza na mapie
        public static void WriteAt(int Col, int Row, string text)
        {
            Console.SetCursorPosition(Col, Row);
            Console.Write(text);
        }

        // funkcja odpowiedzialna za wyświetlanie gracza na mapie
        public static void WriteAt(int Col, int Row, char sign)
        {
            Console.SetCursorPosition(Col, Row);
            Console.Write(sign);
        }

        // funkcja odpowiedzialna za czyszczenie linii konsoli
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}