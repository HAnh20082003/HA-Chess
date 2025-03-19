using System;
using System.Collections.Generic;
using System.Drawing;

namespace HAChess_BetterAtChess
{
    public class Pawn : Piece
    {
        private static string enpassantLeft = "Bắt tốt trái qua đường (Enpassant)";
        private static string enpassantRight = "Bắt tốt phải qua đường (Enpassant)";
        private bool isUp;
        private bool allowEnpassantLeft = true, allowEnpassantRight = true;
        public bool IsUp { get => isUp; set => isUp = value; }
        public bool AllowEnpassantLeft { get => allowEnpassantLeft; set => allowEnpassantLeft = value; }
        public bool AllowEnpassantRight { get => allowEnpassantRight; set => allowEnpassantRight = value; }
        public static string EnpassantLeft { get => enpassantLeft; set => enpassantLeft = value; }
        public static string EnpassantRight { get => enpassantRight; set => enpassantRight = value; }

        public Pawn(int i, int j, int startI, int startJ, string color) : base(i, j, startI, startJ, NamePawn, color)
        {
            TextNotation = NotationPawn;
        }
        public Pawn(int i, int j, int startI, int startJ, int value) : base(i, j, startI, startJ, value)
        {
            TextNotation = NotationPawn;
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

            if (desI == I && desJ == J) //dậm chân tại chỗ
            {
                return false;
            }


            if ((IsUp && I > desI) || (!IsUp && I < desI))
            {
                return false;
            }

            if (desJ == J)
            {
                if (Step == 0)
                {
                    if (IsUp)
                    {
                        if (detailBoard[I + 1, J] == null && Math.Abs(desI - I) == 2) //có quân cản bước đi 2
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (detailBoard[I - 1, J] == null && Math.Abs(desI - I) == 2) //có quân cản bước đi 2
                        {
                            return true;
                        }
                    }
                }
                if (Math.Abs(desI - I) == 1)
                {
                    return true;
                }
            }
            else
            {
                var enpassant = findEnpassant(detailBoard, Row, Col);
                var locaMoveEnpassant = getLocaMoveEnpassant();
                if (enpassant.Item1 != null && desI == locaMoveEnpassant.Item1.X && desJ == locaMoveEnpassant.Item1.Y)
                {
                    return true;
                }
                if (enpassant.Item2 != null && desI == locaMoveEnpassant.Item2.X && desJ == locaMoveEnpassant.Item2.Y)
                {
                    return true;
                }
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

            if (detailBoard[desI, desJ] == null || detailBoard[desI, desJ].Value * Value > ValueNone) //điểm đến là ô trống hoặc quân đồng minh
            {
                return false;
            }

            if (desI == I && desJ == J) //dậm chân tại chỗ
            {
                return false;
            }

            if (Math.Abs(desJ - J) != 1)
            {
                return false;
            }

            if (IsUp && desI - I == 1)
            {
                return true;

            }
            if (!IsUp && desI - I == -1)
            {
                return true;
            }
            var enpassant = findEnpassant(detailBoard, Row, Col);
            var locaCaptureEnpassant = getLocaCaptureEnpassant();
            if (enpassant.Item1 != null && desI == locaCaptureEnpassant.Item1.X && desJ == locaCaptureEnpassant.Item1.Y)
            {
                return true;
            }
            if (enpassant.Item2 != null && desI == locaCaptureEnpassant.Item2.X && desJ == locaCaptureEnpassant.Item2.Y)
            {
                return true;
            }
            return false;
        }

        //Lấy các điểm (i,j) có thể đi tới được từ điểm hiện tại
        public override List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            List<Point> lst = new List<Point>();

            if (IsUp)
            {
                if (Step == 0)
                {
                    if (I + 1 < Row && detailBoard[I + 1, J] == null && I + 2 < Row && detailBoard[I + 2, J] == null)
                    {
                        lst.Add(new Point(I + 2, J));
                    }
                }
                if (I + 1 < Row && detailBoard[I + 1, J] == null)
                {
                    lst.Add(new Point(I + 1, J));
                }
            }
            else
            {
                if (Step == 0)
                {
                    if (I - 1 >= 0 && detailBoard[I - 1, J] == null && I - 2 < Row && detailBoard[I - 2, J] == null)
                    {
                        lst.Add(new Point(I - 2, J));
                    }
                }
                if (I - 1 >= 0 && detailBoard[I - 1, J] == null)
                {
                    lst.Add(new Point(I - 1, J));
                }
            }
            var enpassant = findEnpassant(detailBoard, Row, Col);
            var locaMoveEnpassant = getLocaMoveEnpassant();
            if (enpassant.Item1 != null)
            {
                lst.Add(locaMoveEnpassant.Item1);
            }
            if (enpassant.Item2 != null)
            {
                lst.Add(locaMoveEnpassant.Item2);
            }
            (Point, Point) locaCaptureEnpassant = getLocaCaptureEnpassant();
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    if (enpassant.Item1 != null && lst[j].X == locaMoveEnpassant.Item1.X && lst[j].Y == locaMoveEnpassant.Item1.Y)
                    {
                        tmp[locaCaptureEnpassant.Item1.X, locaCaptureEnpassant.Item1.Y] = null;
                    }
                    else if (enpassant.Item2 != null && lst[j].X == locaMoveEnpassant.Item2.X && lst[j].Y == locaMoveEnpassant.Item2.Y)
                    {
                        tmp[lst[j].X, lst[j].Y] = null;
                        tmp[locaCaptureEnpassant.Item2.X, locaCaptureEnpassant.Item2.Y] = null;
                    }
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

            if (IsUp)
            {
                if (I + 1 < Row) //Nằm trong phạm vi bàn cờ
                {
                    if (J + 1 < Col && detailBoard[I + 1, J + 1] != null && detailBoard[I + 1, J + 1].Value * Value < ValueNone) //Nằm trong phạm vi bàn cờ và gặp quân địch
                    {
                        lst.Add(new Point(I + 1, J + 1));
                    }
                    if (J - 1 >= 0 && detailBoard[I + 1, J - 1] != null && detailBoard[I + 1, J - 1].Value * Value < ValueNone) //Nằm trong phạm vi bàn cờ và gặp quân địch
                    {
                        lst.Add(new Point(I + 1, J - 1));
                    }
                }
            }
            else
            {
                if (I - 1 >= 0) //Nằm trong phạm vi bàn cờ
                {
                    if (J + 1 < Col && detailBoard[I - 1, J + 1] != null && detailBoard[I - 1, J + 1].Value * Value < ValueNone) //Nằm trong phạm vi bàn cờ và gặp quân địch
                    {
                        lst.Add(new Point(I - 1, J + 1));
                    }
                    if (J - 1 >= 0 && detailBoard[I - 1, J - 1] != null && detailBoard[I - 1, J - 1].Value * Value < ValueNone) //Nằm trong phạm vi bàn cờ và gặp quân địch
                    {
                        lst.Add(new Point(I - 1, J - 1));
                    }
                }
            }
            var enpassant = findEnpassant(detailBoard, Row, Col);
            var locaCaptureEnpassant = getLocaCaptureEnpassant();
            if (enpassant.Item1 != null)
            {
                lst.Add(locaCaptureEnpassant.Item1);
            }
            if (enpassant.Item2 != null)
            {
                lst.Add(locaCaptureEnpassant.Item2);
            }
            (Point, Point) locaEnpassant = getLocaMoveEnpassant();
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    if (enpassant.Item1 != null && lst[j].X == locaCaptureEnpassant.Item1.X && lst[j].Y == locaCaptureEnpassant.Item1.Y)
                    {
                        tmp[lst[j].X, lst[j].Y] = null;
                        tmp[locaEnpassant.Item1.X, locaEnpassant.Item1.Y] = getCoppy(locaEnpassant.Item1);
                    }
                    else if (enpassant.Item2 != null && lst[j].X == locaCaptureEnpassant.Item2.X && lst[j].Y == locaCaptureEnpassant.Item2.Y)
                    {
                        tmp[lst[j].X, lst[j].Y] = null;
                        tmp[locaEnpassant.Item2.X, locaEnpassant.Item2.Y] = getCoppy(locaEnpassant.Item2);
                    }
                    else
                    {
                        tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                    }
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

        public (Point, Point) getLocaMoveEnpassant()
        {
            if (isUp)
            {
                return (new Point(I + 1, J - 1), new Point(I + 1, J + 1));
            }
            return (new Point(I - 1, J - 1), new Point(I - 1, J + 1));
        }
        public (Point, Point) getLocaCaptureEnpassant()
        {
            return (new Point(I, J - 1), new Point(I, J + 1));
        }

        public bool canPromote(int i, int j, Piece[,] detailBoard)
        {
            if (Step == 0)
            {
                if ((IsUp && i - I != 1 && i - I != 2) || (!IsUp && i - I != -1 && i - I != -2))
                {
                    return false;
                }
            }
            else
            {
                if ((IsUp && i - I != 1) || (!IsUp && i - I != -1))
                {
                    return false;
                }
            }
            if ((IsUp && i == Row - 1) || (!IsUp && i == 0))
            {
                if ((Math.Abs(j - J) == 1 && detailBoard[i, j] != null && detailBoard[i, j].Value * Value < ValueNone) || (j == J && detailBoard[i, j] == null))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isOkForBeEnpassant()
        {
            return Step == 1 && Math.Abs(StartI - I) == 2;
        }


        public (string, string) findEnpassant(Piece[,] detailBoard, int row, int col)
        {
            string resultLeft = null, resultRight = null;
            if ((isUp && I + 1 >= row) || (!isUp && I - 1 < 0))
            {
                return (resultLeft, resultRight);
            }

            if (isUp)
            {
                if (I + 1 < row)
                {
                    if (allowEnpassantLeft && J - 1 >= 0 && detailBoard[I + 1, J - 1] == null && detailBoard[I, J - 1] != null && detailBoard[I, J - 1].Name == NamePawn)
                    {
                        Pawn pawn = (Pawn)detailBoard[I, J - 1];
                        if (pawn.isOkForBeEnpassant())
                        {
                            resultLeft = EnpassantLeft;
                        }
                    }
                    if (allowEnpassantRight && J + 1 < col && detailBoard[I + 1, J + 1] == null && detailBoard[I, J + 1] != null && detailBoard[I, J + 1].Name == NamePawn)
                    {
                        Pawn pawn = (Pawn)detailBoard[I, J + 1];
                        if (pawn.isOkForBeEnpassant())
                        {
                            resultRight = enpassantRight;
                        }
                    }
                }
            }
            else
            {
                if (I - 1 >= 0)
                {
                    if (allowEnpassantLeft && J - 1 >= 0 && detailBoard[I - 1, J - 1] == null && detailBoard[I, J - 1] != null && detailBoard[I, J - 1].Name == NamePawn)
                    {
                        Pawn pawn = (Pawn)detailBoard[I, J - 1];
                        if (pawn.isOkForBeEnpassant())
                        {
                            resultLeft = EnpassantLeft;
                        }
                    }
                    if (allowEnpassantRight && J + 1 < col && detailBoard[I - 1, J + 1] == null && detailBoard[I, J + 1] != null && detailBoard[I, J + 1].Name == NamePawn)
                    {
                        Pawn pawn = (Pawn)detailBoard[I, J + 1];
                        if (pawn.isOkForBeEnpassant())
                        {
                            resultRight = enpassantRight;
                        }
                    }
                }
            }
            return (resultLeft, resultRight);
        }

        public override Piece getCoppy()
        {
            Pawn pawn = new Pawn(I, J, StartI, StartJ, Value);
            pawn.IsUp = IsUp;
            pawn.Step = Step;
            pawn.AllowEnpassantLeft = AllowEnpassantLeft;
            pawn.AllowEnpassantRight = AllowEnpassantRight;
            pawn.Status = Status;
            return pawn;
        }
        public override Piece getCoppy(Point location)
        {
            Pawn pawn = new Pawn(location.X, location.Y, StartI, StartJ, Value);
            pawn.IsUp = IsUp;
            pawn.Step = Step;
            pawn.AllowEnpassantLeft = AllowEnpassantLeft;
            pawn.AllowEnpassantRight = AllowEnpassantRight;
            pawn.Status = Status;
            return pawn;
        }
    }
}
