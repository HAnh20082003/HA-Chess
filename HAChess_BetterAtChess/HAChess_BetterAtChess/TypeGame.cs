using System.Collections.Generic;

namespace HAChess_BetterAtChess
{
    public class TypeGame
    {
        public string name;
        public string board;
        public string abilities;
        public bool startWhiteTurn;
        public int row, col;
        public int countNoPawnNoCapture, countMoveOverall;
        public static List<string> typeGames = new List<string>() { "Cổ điển", "Chess960" };
        public TypeGame(string name)
        {
            this.name = name;
            if (name == typeGames[0])
            {
                board = Chess.convertToStrBoard(Chess.getBasicIntBoard(false), 8, 8);
                abilities = Chess.convertToStrAbilities(Chess.getBasicAbilities(false), 8, 8);
                startWhiteTurn = true;
                countNoPawnNoCapture = 0;
                countMoveOverall = 1;
                row = col = 8;
            }
            else if (name == typeGames[1])
            {
                board = Chess.convertToStrBoard(Chess.getChess960IntBoard(false, 8, 8), 8, 8);
                abilities = Chess.convertToStrAbilities(Chess.getChess960Abilities(false, 8, 8), 8, 8);
                startWhiteTurn = true;
                countNoPawnNoCapture = 0;
                countMoveOverall = 1;
                row = col = 8;
            }
            else
            {
                board = Chess.convertToStrBoard(Chess.getBasicIntBoard(false), 8, 8);
                abilities = Chess.convertToStrAbilities(Chess.getBasicAbilities(false), 8, 8);
                startWhiteTurn = true;
                countNoPawnNoCapture = 0;
                countMoveOverall = 1;
                row = col = 8;
            }
        }

        public bool isChess960()
        {
            return name == typeGames[1];
        }
        public static int getIndexTypeGame(string name)
        {
            for (int i = 0; i < typeGames.Count; i++)
            {
                if (typeGames[i] == name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
