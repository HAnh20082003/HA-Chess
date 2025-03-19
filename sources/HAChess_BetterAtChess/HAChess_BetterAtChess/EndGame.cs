using System.Collections.Generic;

namespace HAChess_BetterAtChess
{
    public class EndGame
    {
        public static string checkmate = "Chiếu hết";
        public static string stalemateForRepeat = "Hoà cờ vì lặp lại nước đi 3 lần";
        public static string stalemateForIllegalMoves = "Hoà cờ vì hết nước đi";
        public static string stalemateForNotEnoughPieces = "Hoà cờ vì không đủ quân: ";
        public static string stalemateFor50Moves = "Hoà cờ vì luật 50 nước";
        public static string resign = "Đầu hàng";
        public static string requestDraw = "Thoả thuận hoà";
        public static string giveUp = "Bỏ cuộc";
        public static string timeOut = "Hết giờ";
        public static string allOut = "Bỏ dỡ";
        public static string[] typeEndGame = new string[] { checkmate, resign, requestDraw, giveUp, timeOut, stalemateForRepeat, stalemateForIllegalMoves, stalemateForNotEnoughPieces, stalemateFor50Moves };

        public static string winningResult = "1 - 0";
        public static string losingResult = "0 - 1";
        public static string drawResult = "1/2 - 1/2";

        public static string winning = "Chiến thắng";
        public static string losing = "Thất bại";
        public static string draw = "Hoà cờ";


        public static string checkForEndGame(string color, int row, int col, Piece[,] detailBoard, List<Piece[,]> historyDetailBoard, int countNoPawnNoCapture, bool isReverse)
        {
            bool isEnd = true;
            List<Piece> pieces = Piece.getPieces(color, row, col, detailBoard);
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].getLocaMoveTo(detailBoard, isReverse).Count != 0 || pieces[i].getLocaCapture(detailBoard).Count != 0)
                {
                    isEnd = false;
                }
            }
            if (isEnd)
            {
                List<King> kings = Piece.getKing(row, col, color, detailBoard);
                for (int i = 0; i < kings.Count; i++)
                {
                    if (kings[i].beCheck(kings[i].I, kings[i].J, detailBoard))
                    {
                        return checkmate;
                    }
                }
                return stalemateForIllegalMoves;
            }

            if (countNoPawnNoCapture == 100)
            {
                return stalemateFor50Moves;
            }

            int countKingW = 0, countKingB = 0;
            int countBishopW = 0, countBishopB = 0;
            int countKnightW = 0, countKnightB = 0;
            int countOther = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null)
                    {
                        if (detailBoard[i, j].Value == Piece.ValueKing)
                        {
                            countKingW++;
                        }
                        else if (detailBoard[i, j].Value == -Piece.ValueKing)
                        {
                            countKingB++;
                        }
                        else if (detailBoard[i, j].Value == Piece.ValueBishop)
                        {
                            countBishopW++;
                        }
                        else if (detailBoard[i, j].Value == -Piece.ValueBishop)
                        {
                            countBishopB++;
                        }
                        else if (detailBoard[i, j].Value == Piece.ValueKnight)
                        {
                            countKnightW++;
                        }
                        else if (detailBoard[i, j].Value == -Piece.ValueKnight)
                        {
                            countKnightB++;
                        }
                        else
                        {
                            countOther++;
                        }
                    }
                }
            }

            if (countKingW == 0 || countKingB == 0)
            {
                return stalemateForNotEnoughPieces + "Thiếu 1 vua " + (countKingW == 0 ? "trắng" : "đen");
            }

            if (countOther == 0 && countKingW == 1 && countKingB == 1)
            {
                if (countKnightB == 0)
                {
                    if (countBishopB == 0 && countKnightW == 0 && countBishopW == 0)
                    {
                        return stalemateForNotEnoughPieces + "vua đấu vua";
                    }
                    if (countBishopB == 1 && countKnightW == 0 && countBishopW == 0)
                    {
                        return stalemateForNotEnoughPieces + "1 vua - 1 tượng đen đấu vua trắng";
                    }
                    if (countBishopW == 1 && countKnightW == 0 && countBishopB == 0)
                    {
                        return stalemateForNotEnoughPieces + "1 vua - 1 tượng trắng đấu vua đen";
                    }
                    if (countKnightW == 1 && countBishopW == 0 && countBishopB == 0)
                    {
                        return stalemateForNotEnoughPieces + "1 vua - 1 mã trắng đấu vua đen";
                    }
                }
                if (countKnightB == 1 && countKnightW == 0 && countBishopB == 0 && countBishopW == 0)
                {
                    return stalemateForNotEnoughPieces + "1 vua - 1 mã đen đấu vua trắng";
                }
            }
            //Luật lặp lại 3 lần
            int count = 1;
            for (int i = 0; i < historyDetailBoard.Count - 1; i++)
            {
                bool isSame = true;
                for (int k = 0; k < row; k++)
                {
                    for (int l = 0; l < col; l++)
                    {
                        if (!Piece.isSameMaterial(historyDetailBoard[i][k, l], detailBoard[k, l]))
                        {
                            isSame = false;
                            break;
                        }
                    }
                }
                if (isSame)
                {
                    count++;
                    if (count == 3)
                    {
                        return stalemateForRepeat;
                    }
                }
            }
            return null;
        }

        public static string getScore(string detailEnd, string color)
        {
            if (color == Piece.ColorWhite)
            {
                if (detailEnd == checkmate)
                {
                    return winningResult;
                }
                if (detailEnd == resign || detailEnd == giveUp)
                {
                    return losingResult;
                }
            }
            if (color == Piece.ColorBlack)
            {
                if (detailEnd == checkmate)
                {
                    return losingResult;
                }
                if (detailEnd == resign || detailEnd == giveUp)
                {
                    return winningResult;
                }
            }
            if (detailEnd != null)
            {
                return drawResult;
            }
            return null;
        }

        public static string getResultByScore(string score)
        {
            if (string.IsNullOrEmpty(score))
            {
                return null;
            }
            if (score == winningResult)
            {
                return winning;
            }
            if (score == losingResult)
            {
                return losing;
            }
            return draw;
        }
    }
}
