using System.Collections.Generic;
using System.Drawing;

namespace HAChess_BetterAtChess
{
    public class Rook : Piece
    {
        public Rook(int i, int j, int startI, int startJ, string color) : base(i, j, startI, startJ, NameRook, color)
        {
            TextNotation = NotationRook;
        }
        public Rook(int i, int j, int startI, int startJ, int value) : base(i, j, startI, startJ, value)
        {
            TextNotation = NotationRook;
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

            if (desI != I && desJ != J) // Không cùng dòng và không cùng hàng
            {
                return false;
            }

            if (desI == I && desJ == J) //dậm chân tại chỗ
            {
                return false;
            }

            if (desI == I) //nằm trên cùng dòng I
            {
                //đoạn giữa J và desJ trên cùng dòng I với J < desJ
                for (int k = J + 1; k < desJ; k++)
                {
                    if (detailBoard[I, k] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                    {
                        return false;
                    }
                }

                //đoạn giữa J và desJ trên cùng dòng I với desJ < J
                for (int k = desJ + 1; k < J; k++)
                {
                    if (detailBoard[I, k] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                    {
                        return false;
                    }
                }
                return true;
            }

            //nằm trên cùng cột J

            //đoạn giữa I và desI trên cùng cột J với I < desI
            for (int k = I + 1; k < desI; k++)
            {
                if (detailBoard[k, J] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                {
                    return false;
                }
            }

            //đoạn giữa I và desI trên cùng cột J với desI < I
            for (int k = desI + 1; k < I; k++)
            {
                if (detailBoard[k, J] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                {
                    return false;
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

            if (detailBoard[desI, desJ] == null || detailBoard[desI, desJ].Value * Value > ValueNone)  //điểm đến không phải là quân đồng minh hay điểm đó là ô trống
            {
                return false;
            }

            if (desI != I && desJ != J) // Không cùng dòng và không cùng hàng
            {
                return false;
            }

            if (desI == I && desJ == J) //dậm chân tại chỗ
            {
                return false;
            }

            if (desI == I) //nằm trên cùng dòng I
            {

                //đoạn giữa J và desJ trên cùng dòng I với J < desJ
                for (int k = J + 1; k < desJ; k++)
                {
                    if (detailBoard[I, k] != null) //có quân cảng đường (đồng minh hay địch)
                    {
                        return false;
                    }
                }

                //đoạn giữa J và desJ trên cùng dòng I với desJ < J
                for (int k = desJ + 1; k < J; k++)
                {
                    if (detailBoard[I, k] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                    {
                        return false;
                    }
                }
                return true;
            }

            //nằm trên cùng cột J

            //đoạn giữa I và desI trên cùng cột J với I < desI
            for (int k = I + 1; k < desI; k++)
            {
                if (detailBoard[k, J] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                {
                    return false;
                }
            }

            //đoạn giữa I và desI trên cùng cột J với desI < I
            for (int k = desI + 1; k < I; k++)
            {
                if (detailBoard[k, J] != null) //có quân đang đứng (có thể là đồng minh hoặc quân địch) <=> bị cản đường
                {
                    return false;
                }
            }
            return true;
        }

        //Lấy các điểm (i,j) có thể đi tới được từ điểm hiện tại
        public override List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            List<Point> lst = new List<Point>();

            for (int i = I + 1; i < Row; i++)
            {
                if (detailBoard[i, J] != null) //Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(i, J));
            }
            for (int i = I - 1; i >= 0; i--)
            {
                if (detailBoard[i, J] != null) //Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(i, J));
            }
            for (int i = J + 1; i < Col; i++)
            {
                if (detailBoard[I, i] != null) //Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(I, i));
            }
            for (int i = J - 1; i >= 0; i--)
            {
                if (detailBoard[I, i] != null) //Có quân cản đường (địch hoặc đồng minh) thì dừng duyệt
                {
                    break;
                }
                lst.Add(new Point(I, i));
            }
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[lst[j].X, lst[j].Y] = getCoppy();
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
            for (int i = I + 1; i < Row; i++)
            {
                if (detailBoard[i, J] != null && detailBoard[i, J].Value * Value > ValueNone) //Quân đồng minh cản đường
                {
                    break;
                }
                if (detailBoard[i, J] != null && detailBoard[i, J].Value * Value < ValueNone) //Quân địch
                {
                    lst.Add(new Point(i, J));
                    break;
                }
            }
            for (int i = I - 1; i >= 0; i--)
            {
                if (detailBoard[i, J] != null && detailBoard[i, J].Value * Value > ValueNone) //Quân đồng minh cản đường
                {
                    break;
                }
                if (detailBoard[i, J] != null && detailBoard[i, J].Value * Value < ValueNone) //Quân địch
                {
                    lst.Add(new Point(i, J));
                    break;
                }
            }
            for (int i = J + 1; i < Col; i++)
            {
                if (detailBoard[I, i] != null && detailBoard[I, i].Value * Value > ValueNone) //Quân đồng minh cản đường
                {
                    break;
                }
                if (detailBoard[I, i] != null && detailBoard[I, i].Value * Value < ValueNone) //Quân địch
                {
                    lst.Add(new Point(I, i));
                    break;
                }
            }
            for (int i = J - 1; i >= 0; i--)
            {
                if (detailBoard[I, i] != null && detailBoard[I, i].Value * Value > ValueNone) //Quân đồng minh cản đường
                {
                    break;
                }
                if (detailBoard[I, i] != null && detailBoard[I, i].Value * Value < ValueNone) //Quân địch
                {
                    lst.Add(new Point(I, i));
                    break;
                }
            }
            List<King> king = getMyKing(detailBoard);
            for (int i = 0; i < king.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    Piece[,] tmp = coppyBoard(detailBoard);
                    tmp[lst[j].X, lst[j].Y] = getCoppy();
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
            Rook rook = new Rook(I, J, StartI, StartJ, Value);
            rook.Step = Step;
            rook.Status = Status;
            return rook;
        }
        public override Piece getCoppy(Point location)
        {
            Rook rook = new Rook(location.X, location.Y, StartI, StartJ, Value);
            rook.Step = Step;
            rook.Status = Status;
            return rook;
        }
    }
}
