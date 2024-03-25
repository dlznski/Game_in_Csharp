using System;

namespace Game_in_Csharp
{
    public class Player
    {
        public int x = 2;
        public int y = 3;
        public string avatar = "@";
        public bool key = false;
        public bool win = false;

        public Player(int x, int y, string avatar)
        {
            this.x = x;
            this.y = y;
            this.avatar = avatar;
        }

        public void Move(ConsoleKeyInfo keyInfo, string[] level)
        {
            int targetColumn = x;
            int targetRow = y;

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    targetColumn--;
                    break;
                case ConsoleKey.RightArrow:
                    targetColumn++;
                    break;
                case ConsoleKey.UpArrow:
                    targetRow--;
                    break;
                case ConsoleKey.DownArrow:
                    targetRow++;
                    break;
                default:
                    return;
            }

            if (targetColumn >= 0 && targetColumn < level[y].Length && level[y][targetColumn] != '#')
            {
                x = targetColumn;
            }

            if (targetRow >= 0 && targetRow < level.Length && level[targetRow][x] != '#')
            {
                y = targetRow;
            }
        }

        private void UpdateLevel(int x, int y, char symbol)
        {
            string updatedRow = Map.level[y].Substring(0, x) + symbol + Map.level[y].Substring(x + 1);
            Map.level[y] = updatedRow;
            Display.WriteAt(x, y, symbol);
            Console.SetCursorPosition(0, Map.level.Length + 1);
        }

        public bool CheckWinRules()
        {
            if (Map.level[y][x] == 'k')
            {
                key = true;
                UpdateLevel(y, x, ' ');
                Console.WriteLine("Congratulations! You found key! I wonder what it opens ");
                Console.ReadKey(true);
                Console.SetCursorPosition(0, Map.level.Length + 1);
                Display.ClearCurrentConsoleLine();
                return false;
            }

            if (Map.level[y][x] == 'c' && key == true)
            {
                win = true;
                UpdateLevel(y, x, ' ');
                Console.WriteLine("Congratulations! You have found the treasure!");
                Console.SetCursorPosition(0, Map.level.Length + 1);
                Console.ReadKey(true);
                return true;
            }

            return false;
        }
    }
}