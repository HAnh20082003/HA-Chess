using System;
using System.Collections.Generic;
using System.Drawing;

namespace HAChess_BetterAtChess
{
    public class Bishop : Piece
    {
        public Bishop(int i, int j, int startI, int startJ, string color) : base(i, j, startI, startJ, NameBishop, color)
        {
            TextNotation = NotationBishop;
        }
        public Bishop(int i, int j, int startI, int startJ, int value) : base(i, j, startI, startJ, value)
        {
            TextNotation = NotationBishop;
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
            if (Math.Abs(I - desI) != Math.Abs(J - desJ))
            {
                return false;
            }

            //Kiểm tra đường chéo
            if (desJ > J)
            {
                int j = J + 1;
                if (desI > I)
                {
                    for (int i = I + 1; i < desI; i++)
                    {
                        if (j >= Col || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j++;
                    }
                }
                else
                {
                    for (int i = I - 1; i > desI; i--)
                    {
                        if (j >= Col || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j++;
                    }
                }
            }
            else
            {
                int j = J - 1;
                if (desI > I)
                {
                    for (int i = I + 1; i < desI; i++)
                    {
                        if (j < 0 || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j--;
                    }
                }
                else
                {
                    for (int i = I - 1; i > desI; i--)
                    {
                        if (j < 0 || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j--;
                    }
                }
            }
            return true;
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

            if (Math.Abs(I - desI) != Math.Abs(J - desJ))
            {
                return false;
            }

            //Kiểm tra đường chéo
            if (desJ > J)
            {
                int j = J + 1;
                if (desI > I)
                {
                    for (int i = I + 1; i < desI; i++)
                    {
                        if (j >= Col || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j++;
                    }
                }
                else
                {
                    for (int i = I - 1; i > desI; i--)
                    {
                        if (j >= Col || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j++;
                    }
                }
            }
            else
            {
                int j = J - 1;
                if (desI > I)
                {
                    for (int i = I + 1; i < desI; i++)
                    {
                        if (j < 0 || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j--;
                    }
                }
                else
                {
                    for (int i = I - 1; i > desI; i--)
                    {
                        if (j < 0 || detailBoard[i, j] != null) //Có quân cản đường (đồng minh hay địch)
                        {
                            return false;
                        }
                        j--;
                    }
                }
            }
            return true;
        }

        //Lấy các điểm (i,j) có thể đi tới được từ điểm hiện tại
        public override List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            List<Point> lst = new List<Point>();
            int j = 1;
            for (int i = I + 1; i < Row; i++)
            {
                if (J + j >= Col || detailBoard[i, J + j] != null) //Out khỏi phạm vi bàn cờ hoặc Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(i, J + j));
                j++;
            }

            j = 1;
            for (int i = I + 1; i < Row; i++)
            {
                if (J - j < 0 || detailBoard[i, J - j] != null) //Out khỏi phạm vi bàn cờ hoặc Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(i, J - j));
                j++;
            }

            j = 1;
            for (int i = I - 1; i >= 0; i--)
            {
                if (J + j >= Col || detailBoard[i, J + j] != null) //Out khỏi phạm vi bàn cờ hoặc Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(i, J + j));
                j++;
            }

            j = 1;
            for (int i = I - 1; i >= 0; i--)
            {
                if (J - j < 0 || detailBoard[i, J - j] != null) //Out khỏi phạm vi bàn cờ hoặc Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(i, J - j));
                j++;
            }

            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (j = 0; j < lst.Count; j++)
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
            int j = 1;
            for (int i = I + 1; i < Row; i++)
            {
                if (J + j >= Col || (detailBoard[i, J + j] != null && detailBoard[i, J + j].Value * Value > ValueNone)) //Out khỏi phạm vi bàn cờ hoặc có quân đồng minh thì dừng duyệt
                {
                    break;
                }
                if (detailBoard[i, J + j] != null && detailBoard[i, J + j].Value * Value < ValueNone)
                {
                    lst.Add(new Point(i, J + j));
                    break;
                }
                j++;
            }

            j = 1;
            for (int i = I + 1; i < Row; i++)
            {
                if (J - j < 0 || (detailBoard[i, J - j] != null && detailBoard[i, J - j].Value * Value > ValueNone)) //Out khỏi phạm vi bàn cờ hoặc có quân đồng minh thì dừng duyệt
                {
                    break;
                }
                if (detailBoard[i, J - j] != null && detailBoard[i, J - j].Value * Value < ValueNone)
                {
                    lst.Add(new Point(i, J - j));
                    break;
                }
                j++;
            }

            j = 1;
            for (int i = I - 1; i >= 0; i--)
            {
                if (J + j >= Col || (detailBoard[i, J + j] != null && detailBoard[i, J + j].Value * Value > ValueNone)) //Out khỏi phạm vi bàn cờ hoặc có quân đồng minh thì dừng duyệt
                {
                    break;
                }
                if (detailBoard[i, J + j] != null && detailBoard[i, J + j].Value * Value < ValueNone)
                {
                    lst.Add(new Point(i, J + j));
                    break;
                }
                j++;
            }

            j = 1;
            for (int i = I - 1; i >= 0; i--)
            {
                if (J - j < 0 || (detailBoard[i, J - j] != null && detailBoard[i, J - j].Value * Value > ValueNone)) //Out khỏi phạm vi bàn cờ hoặc có quân đồng minh thì dừng duyệt
                {
                    break;
                }
                if (detailBoard[i, J - j] != null && detailBoard[i, J - j].Value * Value < ValueNone)
                {
                    lst.Add(new Point(i, J - j));
                    break;
                }
                j++;
            }
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (j = 0; j < lst.Count; j++)
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
            Bishop bishop = new Bishop(I, J, StartI, StartJ, Value);
            bishop.Step = Step;
            bishop.Status = Status;
            return bishop;
        }
        public override Piece getCoppy(Point location)
        {
            Bishop bishop = new Bishop(location.X, location.Y, StartI, StartJ, Value);
            bishop.Step = Step;
            bishop.Status = Status;
            return bishop;
        }
    }
}
