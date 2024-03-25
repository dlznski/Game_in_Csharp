using System;

namespace Game_in_Csharp
{
    public class Player
    {
        public int x = 2;
        public int y = 3;
        public string avatar = "@";

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
    }
}