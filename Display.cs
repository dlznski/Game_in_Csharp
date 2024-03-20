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
    }
}