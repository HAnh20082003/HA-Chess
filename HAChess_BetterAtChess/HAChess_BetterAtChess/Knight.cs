using System;
using System.Collections.Generic;
using System.Drawing;

namespace HAChess_BetterAtChess
{
    public class Knight : Piece
    {
        public Knight(int i, int j, int startI, int startJ, string color) : base(i, j, startI, startJ, NameKnight, color)
        {
            TextNotation = NotationKnight;
        }
        public Knight(int i, int j, int startI, int startJ, int value) : base(i, j, startI, startJ, value)
        {
            TextNotation = NotationKnight;
        }

        //Có thể đi từ điểm đang đứng tới điểm (desI, desJ) hay không
        public override bool canMoveTo(int desI, int desJ, Piece[,] detailBoard)
        {
            if (desI < 0 || desJ < 0 || desI >= Row || desJ >= Col) //out khỏi phạm vi bàn cờ
            {
                return false;
            }

            if (detailBoard[desI, desJ] != null) //điểm đến không phải là 1 ô trống (có thể là địch hoặc đồng minh)
            {
                return false;
            }

            if (Math.Abs(I - desI) == 2 && Math.Abs(J - desJ) == 1) //Có dạng chữ L (1 đoạn dài 2 và 1 đoạn dài 1)
            {
                return true;
            }

            if (Math.Abs(I - desI) == 1 && Math.Abs(J - desJ) == 2) //Có dạng chữ L (1 đoạn dài 2 và 1 đoạn dài 1)
            {
                return true;
            }
            return false;
        }

        //Có thể từ điểm đang đứng ăn điểm (desI, desJ) hay không
        public override bool canCapTure(int desI, int desJ, Piece[,] detailBoard)
        {
            if (desI < 0 || desJ < 0 || desI >= Row || desJ >= Col) //out khỏi phạm vi bàn cờ
            {
                return false;
            }

            if (detailBoard[desI, desJ] == null || detailBoard[desI, desJ].Value * Value > ValueNone) //điểm đến không phải là quân đồng minh hay điểm đó là ô trống
            {
                return false;
            }

            if (Math.Abs(I - desI) == 2 && Math.Abs(J - desJ) == 1) //Có dạng chữ L (1 đoạn dài 2 và 1 đoạn dài 1)
            {
                return true;
            }

            if (Math.Abs(I - desI) == 1 && Math.Abs(J - desJ) == 2) //Có dạng chữ L (1 đoạn dài 2 và 1 đoạn dài 1)
            {
                return true;
            }
            return false;
        }

        //Lấy các điểm (i,j) có thể đi tới được từ điểm hiện tại
        public override List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            List<Point> lst = new List<Point>();
            for (int i = I - 2; i <= I + 2; i += 4)
            {
                for (int j = J - 1; j <= J + 1; j += 2)
                {
                    if (i < 0 || j < 0 || i >= Row || j >= Col) //out khỏi phạm vi bàn cờ
                    {
                        continue;
                    }
                    if (detailBoard[i, j] == null) //ô đó là ô trống
                    {
                        lst.Add(new Point(i, j));
                    }
                }
            }
            for (int i = I - 1; i <= I + 1; i += 2)
            {
                for (int j = J - 2; j <= J + 2; j += 4)
                {
                    if (i < 0 || j < 0 || i >= Row || j >= Col) //out khỏi phạm vi bàn cờ
                    {
                        continue;
                    }
                    if (detailBoard[i, j] == null) //ô đó là ô trống
                    {
                        lst.Add(new Point(i, j));
                    }
                }
            }
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                    tmp[I, J] = null;
                    if (king[i].beCheck(king[i].I, king[i].J, tmp))
                    {
                        lst.RemoveAt(j);
                        j--;
                    }
                }
            }
            return lst;
        }

        //Lấy các điểm (i,j) có thể ăn được từ điểm hiện tại
        public override List<Point> getLocaCapture(Piece[,] detailBoard)
        {
            List<Point> lst = new List<Point>();
            for (int i = I - 2; i <= I + 2; i += 4)
            {
                for (int j = J - 1; j <= J + 1; j += 2)
                {
                    if (i < 0 || j < 0 || i >= Row || j >= Col) //out khỏi phạm vi bàn cờ
                    {
                        continue;
                    }
                    if (detailBoard[i, j] != null && detailBoard[i, j].Value * Value < ValueNone) //ô đó có địch đứng
                    {
                        lst.Add(new Point(i, j));
                    }
                }
            }
            for (int i = I - 1; i <= I + 1; i += 2)
            {
                for (int j = J - 2; j <= J + 2; j += 4)
                {
                    if (i < 0 || j < 0 || i >= Row || j >= Col) //out khỏi phạm vi bàn cờ
                    {
                        continue;
                    }
                    if (detailBoard[i, j] != null && detailBoard[i, j].Value * Value < ValueNone) //ô đó có địch đứng
                    {
                        lst.Add(new Point(i, j));
                    }
                }
            }
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                    tmp[I, J] = null;
                    if (king[i].beCheck(king[i].I, king[i].J, tmp))
                    {
                        lst.RemoveAt(j);
                        j--;
                    }
                }
            }
            return lst;
        }
        public override Piece getCoppy()
        {
            Knight knight = new Knight(I, J, StartI, StartJ, Value);
            knight.Step = Step;
            knight.Status = Status;
            return knight;
        }
        public override Piece getCoppy(Point location)
        {
            Knight knight = new Knight(location.X, location.Y, StartI, StartJ, Value);
            knight.Step = Step;
            knight.Status = Status;
            return knight;
        }
    }
}
