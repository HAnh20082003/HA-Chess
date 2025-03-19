using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public class King : Piece
    {
        private bool allowCastleLeft = true, allowCastleRight = true;
        private static string castleLeft = "Nhập thành trái";
        private static string castleRight = "Nhập thành phải";

        public static string CastleLeft { get => castleLeft; set => castleLeft = value; }
        public static string CastleRight { get => castleRight; set => castleRight = value; }
        public bool AllowCastleLeft { get => allowCastleLeft; set => allowCastleLeft = value; }
        public bool AllowCastleRight { get => allowCastleRight; set => allowCastleRight = value; }
        public static int locaJKingDefault = 4;
        public static int desLocaLeft = 2;
        public static int desLocaRight = 6;
        public static int locaJKingDefaultReverse = 3;
        public static int desLocaLeftReverse = 1;
        public static int desLocaRightReverse = 5;
        public King(int i, int j, int startI, int startJ, string color) : base(i, j, startI, startJ, NameKing, color)
        {
            TextNotation = NotationKing;
        }
        public King(int i, int j, int startI, int startJ, int value) : base(i, j, startI, startJ, value)
        {
            TextNotation = NotationKing;
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
            if (Math.Abs(I - desI) <= 1 && Math.Abs(J - desJ) <= 1)
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
            if (desI == I && desJ == J) //dậm chân tại chỗ
            {
                return false;
            }
            if (Math.Abs(I - desI) <= 1 && Math.Abs(J - desJ) <= 1)
            {
                return true;
            }
            return false;
        }

        //Lấy các điểm (i,j) có thể đi tới được từ điểm hiện tại
        public override List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            List<Point> lst = new List<Point>();

            //Kiểm tra ngang dọc
            if (I + 1 < Row && detailBoard[I + 1, J] == null) //Trong phạm vi bàn cờ và ô trống
            {
                lst.Add(new Point(I + 1, J));
            }

            if (I - 1 >= 0 && detailBoard[I - 1, J] == null) //Trong phạm vi bàn cờ và ô trống
            {
                lst.Add(new Point(I - 1, J));
            }

            if (J + 1 < Col && detailBoard[I, J + 1] == null) //Trong phạm vi bàn cờ và ô trống
            {
                lst.Add(new Point(I, J + 1));
            }

            if (J - 1 >= 0 && detailBoard[I, J - 1] == null) //Trong phạm vi bàn cờ và ô trống
            {
                lst.Add(new Point(I, J - 1));
            }


            //Kiểm tra chéo
            if (I + 1 < Row) //Trong phạm vi bàn cờ
            {
                if (J + 1 < Col && detailBoard[I + 1, J + 1] == null) //Trong phạm vi bàn cờ và ô trống
                {
                    lst.Add(new Point(I + 1, J + 1));
                }
                if (J - 1 >= 0 && detailBoard[I + 1, J - 1] == null) //Trong phạm vi bàn cờ và ô trống
                {
                    lst.Add(new Point(I + 1, J - 1));
                }
            }

            if (I - 1 >= 0) //Trong phạm vi bàn cờ
            {
                if (J + 1 < Col && detailBoard[I - 1, J + 1] == null) //Trong phạm vi bàn cờ và ô trống
                {
                    lst.Add(new Point(I - 1, J + 1));
                }
                if (J - 1 >= 0 && detailBoard[I - 1, J - 1] == null) //Trong phạm vi bàn cờ và ô trống
                {
                    lst.Add(new Point(I - 1, J - 1));
                }
            }
            var castle = findCastle(detailBoard, isReverse);
            if (castle.Item1 != -1)
            {
                lst.Add(new Point(I, castle.Item1));
            }
            if (castle.Item2 != -1)
            {
                lst.Add(new Point(I, castle.Item2));
            }
            for (int j = 0; j < lst.Count; j++)
            {
                Piece[,] tmp = coppyBoard(detailBoard);
                tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                tmp[I, J] = null;
                if (beCheck(lst[j].X, lst[j].Y, tmp))
                {
                    lst.RemoveAt(j);
                    j--;
                }
            }
            List<King> kings = getMyKing(detailBoard);
            for (int i = 0; i < kings.Count; i++)
            {
                if (I == kings[i].I && kings[i].J == J)
                {
                    continue;
                }
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                    tmp[I, J] = null;
                    if (kings[i].beCheck(kings[i].I, kings[i].J, tmp))
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

            //Kiểm tra ngang dọc
            if (I + 1 < Row && detailBoard[I + 1, J] != null && detailBoard[I + 1, J].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
            {
                lst.Add(new Point(I + 1, J));
            }

            if (I - 1 >= 0 && detailBoard[I - 1, J] != null && detailBoard[I - 1, J].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
            {
                lst.Add(new Point(I - 1, J));
            }

            if (J + 1 < Col && detailBoard[I, J + 1] != null && detailBoard[I, J + 1].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
            {
                lst.Add(new Point(I, J + 1));
            }

            if (J - 1 >= 0 && detailBoard[I, J - 1] != null && detailBoard[I, J - 1].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
            {
                lst.Add(new Point(I, J - 1));
            }

            //Kiểm tra chéo
            if (I + 1 < Row) //Trong phạm vi bàn cờ và quân địch
            {
                if (J + 1 < Col && detailBoard[I + 1, J + 1] != null && detailBoard[I + 1, J + 1].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
                {
                    lst.Add(new Point(I + 1, J + 1));
                }
                if (J - 1 >= 0 && detailBoard[I + 1, J - 1] != null && detailBoard[I + 1, J - 1].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
                {
                    lst.Add(new Point(I + 1, J - 1));
                }
            }

            if (I - 1 >= 0) //Trong phạm vi bàn cờ
            {
                if (J + 1 < Col && detailBoard[I - 1, J + 1] != null && detailBoard[I - 1, J + 1].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
                {
                    lst.Add(new Point(I - 1, J + 1));
                }
                if (J - 1 >= 0 && detailBoard[I - 1, J - 1] != null && detailBoard[I - 1, J - 1].Value * Value < ValueNone) //Trong phạm vi bàn cờ và quân địch
                {
                    lst.Add(new Point(I - 1, J - 1));
                }
            }

            for (int j = 0; j < lst.Count; j++)
            {
                Piece[,] tmp = coppyBoard(detailBoard);
                tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                tmp[I, J] = null;
                if (beCheck(lst[j].X, lst[j].Y, tmp))
                {
                    lst.RemoveAt(j);
                    j--;
                }
            }
            List<King> kings = getMyKing(detailBoard);
            for (int i = 0; i < kings.Count; i++)
            {
                if (I == kings[i].I && kings[i].J == J)
                {
                    continue;
                }
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[lst[j].X, lst[j].Y] = getCoppy(lst[j]);
                    tmp[I, J] = null;
                    if (kings[i].beCheck(kings[i].I, kings[i].J, tmp))
                    {
                        lst.RemoveAt(j);
                        j--;
                    }
                }
            }
            return lst;
        }

        public bool beCheck(int locaI, int locaJ, Piece[,] detailBoard)
        {
            if (locaI < 0 || locaI >= Row || locaJ < 0 || locaJ >= Col)
            {
                return false;
            }
            List<Piece> pieceOp = getPieces(Color == ColorWhite ? ColorBlack : ColorWhite, Row, Col, detailBoard);
            foreach (Piece piece in pieceOp)
            {
                if (piece.canCapTure(locaI, locaJ, detailBoard))
                {
                    return true;
                }
            }
            return false;
        }

        public (bool, bool) checkAllowCastle(Piece[,] detailBoard)
        {
            bool castleLeft = false, caslteRight = false;
            if (Step != 0)
            {
                return (castleLeft, caslteRight);
            }
            if (AllowCastleLeft)
            {
                for (int i = J - 1; i >=0; i--)
                {
                    if (detailBoard[I, i] != null && detailBoard[I, i].Name == NameRook && detailBoard[I, i].Color == Color && detailBoard[I, i].Step == 0)
                    {
                        castleLeft = true;
                    }
                }
            }
            if (allowCastleRight)
            {
                for (int i = J + 1; i < Col; i++)
                {
                    if (detailBoard[I, i] != null && detailBoard[I, i].Name == NameRook && detailBoard[I, i].Color == Color && detailBoard[I, i].Step == 0)
                    {
                        caslteRight = true;
                    }
                }
            }
            return (castleLeft, caslteRight);
        }

        public (int, int) getLocationCastle(Piece[,] detailBoard, bool isReverse)
        {
            //Lấy xe và vua ra, xác định nào trái vua, nào phải vua để nhập thành cánh nào
            //Xét đoạn giữa xe và vua đó có bị chắn k
            //Xét tại ô vua và xe sẽ đứng sau khi nhập thành xem co đang bị chiếm chỗ k


            int j_left = -1, j_right = -1;
            if (Step != 0)
            {
                return (j_left, j_right);
            }

            List<Rook> rooks = new List<Rook>();
            List<King> kings = new List<King>();

            for (int i = 0; i < Row; i += 7)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (detailBoard[i, j] != null && detailBoard[i, j].Color == Color && detailBoard[i, j].Step == 0)
                    {
                        if (detailBoard[i, j].Name == NameRook)
                        {
                            rooks.Add((Rook)detailBoard[i, j]);
                        }
                        else if (detailBoard[i, j].Name == NameKing)
                        {
                            kings.Add((King)detailBoard[i, j]);
                        }
                    }
                }
            }

            Rook rookLeft = null, rookRight = null;
            bool hadLeft = false, hadRight = false;

            for (int i = rooks.Count - 1; i >= 0; i--)
            {
                if (!hadLeft && rooks[i].J < J)
                {
                    rookLeft = rooks[i];
                    hadLeft = true;
                }
                else if (!hadRight && rooks[i].J > J)
                {
                    rookRight = rooks[i];
                    hadRight = true;
                }
            }

            for (int i = 0; i < kings.Count; i++)
            {
                if (kings[i].I != I || kings[i].J != J)
                {
                    if (rookLeft != null)
                    {
                        if (kings[i].J < J && kings[i].J > rookLeft.J)
                        {
                            rookLeft = null;
                        }
                    }
                    if (rookRight != null)
                    {
                        if (kings[i].J > J && kings[i].J < rookRight.J)
                        {
                            rookRight = null;
                        }
                    }
                }
            }

            if (rookLeft != null)
            {
                int j_start, j_end;
                if (isReverse)
                {
                    if (desLocaLeftReverse < rookLeft.J)
                    {
                        j_start = desLocaLeftReverse;
                    }
                    else
                    {
                        j_start = rookLeft.J + 1;
                    }
                    j_end = locaJKingDefaultReverse - 1;
                }
                else
                {
                    if (desLocaLeftReverse < rookLeft.J)
                    {
                        j_start = desLocaLeft;
                    }
                    else
                    {
                        j_start = rookLeft.J + 1;
                    }
                    j_end = locaJKingDefault - 1;
                }
                for (int i = j_start; i <= j_end; i++)
                {
                    if (detailBoard[I, i] != null)
                    {
                        if (detailBoard[I, i].Name == NameRook)
                        {
                            if (detailBoard[I, i].J != rookLeft.J)
                            {
                                rookLeft = null;
                                break;
                            }
                        }
                        else if (detailBoard[I, i].Name == NameKing)
                        {
                            if (detailBoard[I, i].J != J)
                            {
                                rookLeft = null;
                                break;
                            }
                        }
                        else
                        {
                            rookLeft = null;
                            break;
                        }
                    }
                }
            }

            if (rookRight != null)
            {
                int j_start, j_end;
                if (isReverse)
                {
                    j_start = locaJKingDefaultReverse + 1;
                    if (desLocaRightReverse > rookRight.J)
                    {
                        j_end = desLocaRightReverse;
                    }
                    else
                    {
                        j_end = rookRight.J - 1;
                    }
                }
                else
                {
                    j_start = locaJKingDefault + 1;
                    if (desLocaRight > rookRight.J)
                    {
                        j_end = desLocaRight;
                    }
                    else
                    {
                        j_end = rookRight.J - 1;
                    }
                }
                for (int i = j_start; i <= j_end; i++)
                {
                    if (detailBoard[I, i] != null)
                    {
                        if (detailBoard[I, i].Name == NameRook)
                        {
                            if (detailBoard[I, i].J != rookRight.J)
                            {
                                rookRight = null;
                                break;
                            }
                        }
                        else if (detailBoard[I, i].Name == NameKing)
                        {
                            if (detailBoard[I, i].J != J)
                            {
                                rookRight = null;
                                break;
                            }
                        }
                        else
                        {
                            rookRight = null;
                            break;
                        }
                    }
                }
            }

            if (rookLeft != null)
            {
                if (isReverse)
                {
                    if (rookLeft.J == J - 1 || J == desLocaLeftReverse || rookLeft.J == desLocaLeftReverse || J - 1 == desLocaLeftReverse)
                    {
                        j_left = rookLeft.J;
                    }
                    else
                    {
                        j_left = desLocaLeftReverse;
                    }
                }
                else
                {
                    if (rookLeft.J == J - 1 || J == desLocaLeft || rookLeft.J == desLocaLeft || J - 1 == desLocaLeft)
                    {
                        j_left = rookLeft.J;
                    }
                    else
                    {
                        j_left = desLocaLeft;
                    }
                }
            }

            if (rookRight != null)
            {
                if (isReverse)
                {
                    if (rookRight.J == J + 1 || J == desLocaRightReverse || rookRight.J == desLocaRightReverse || J + 1 == desLocaRightReverse)
                    {
                        j_right = rookRight.J;
                    }
                    else
                    {
                        j_right = desLocaRightReverse;
                    }
                }
                else
                {
                    if (rookRight.J == J + 1 || J == desLocaRight || rookRight.J == desLocaRight || J + 1 == desLocaRight)
                    {
                        j_right = rookRight.J;
                    }
                    else
                    {
                        j_right = desLocaRight;
                    }
                }
            }

            return (j_left, j_right);
        }

        public (int, int) findCastle(Piece[,] detailBoard, bool isReverse)
        {
            (int, int) locationCastle = getLocationCastle(detailBoard, isReverse);
            if (beCheck(I, J, detailBoard) || (locationCastle.Item1 == -1 && locationCastle.Item2 == -1))
            {
                return (-1, -1);
            }
            int start, end;
            if (locationCastle.Item1 != -1)
            {
                if (isReverse)
                {
                    start = locaJKingDefaultReverse - 1;
                    end = desLocaLeftReverse;
                }
                else
                {
                    start = locaJKingDefault - 1;
                    end = desLocaLeft;
                }
                for (int j = start; j >= end; j--)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[I, j] = getCoppy(new Point(I, j));
                    tmp[I, J] = null;
                    if (beCheck(I, j, tmp))
                    {
                        locationCastle.Item1 = -1;
                        break;
                    }
                }
            }
            if (locationCastle.Item2 != -1)
            {
                if (isReverse)
                {
                    start = locaJKingDefaultReverse + 1;
                    end = desLocaRightReverse;
                }
                else
                {
                    start = locaJKingDefault + 1;
                    end = desLocaRight;
                }
                for (int j = start; j <= end; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[I, j] = getCoppy(new Point(I, j));
                    tmp[I, J] = null;
                    if (beCheck(I, j, tmp))
                    {
                        locationCastle.Item2 = -1;
                        break;
                    }
                }
            }
            return locationCastle;
        }

        public override Piece getCoppy()
        {
            King king = new King(I, J, StartI, StartJ, Value);
            king.allowCastleLeft = allowCastleLeft;
            king.allowCastleRight = allowCastleRight;
            king.Step = Step;
            king.Status = Status;
            return king;
        }
        public override Piece getCoppy(Point location)
        {
            King king = new King(location.X, location.Y, StartI, StartJ, Value);
            king.allowCastleLeft = allowCastleLeft;
            king.allowCastleRight = allowCastleRight;
            king.Step = Step;
            king.Status = Status;
            return king;
        }
    }
}
