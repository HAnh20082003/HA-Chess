using System.Collections.Generic;
using System.Drawing;

namespace HAChess_BetterAtChess
{
    public class Queen : Piece
    {
        public Queen(int i, int j, int startI, int startJ, string color) : base(i, j, startI, startJ, NameQueen, color)
        {
            TextNotation = NotationQueen;
        }
        public Queen(int i, int j, int startI, int startJ, int value) : base(i, j, startI, startJ, value)
        {
            TextNotation = NotationQueen;
        }

        //Có thể đi từ điểm đang đứng tới điểm (desI, desJ) hay không
        public override bool canMoveTo(int desI, int desJ, Piece[,] detailBoard)
        {
            Rook rook = new Rook(I, J, StartI, StartJ, Color);
            Bishop bishop = new Bishop(I, J, StartI, StartJ, Color);
            if (rook.canMoveTo(desI, desJ, detailBoard) || bishop.canMoveTo(desI, desJ, detailBoard))
            {
                return true;
            }
            return false;
        }

        //Có thể từ điểm đang đứng ăn điểm (desI, desJ) hay không
        public override bool canCapTure(int desI, int desJ, Piece[,] detailBoard)
        {
            Rook rook = new Rook(I, J, StartI, StartJ, Color);
            Bishop bishop = new Bishop(I, J, StartI, StartJ, Color);
            if (rook.canCapTure(desI, desJ, detailBoard) || bishop.canCapTure(desI, desJ, detailBoard))
            {
                return true;
            }
            return false;
        }

        //Lấy các điểm (i,j) có thể đi tới được từ điểm hiện tại
        public override List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            List<Point> lst = new List<Point>();
            Rook rook = new Rook(I, J, StartI, StartJ, Color);
            Bishop bishop = new Bishop(I, J, StartI, StartJ, Color);
            List<Point> lstRook = rook.getLocaMoveTo(detailBoard, isReverse);
            List<Point> lstBishop = bishop.getLocaMoveTo(detailBoard, isReverse);
            for (int i = 0; i < lstRook.Count; i++)
            {
                lst.Add(lstRook[i]);
            }
            for (int i = 0; i < lstBishop.Count; i++)
            {
                lst.Add(lstBishop[i]);
            }
            return lst;
        }

        //Lấy các điểm (i,j) có thể ăn được từ điểm hiện tại
        public override List<Point> getLocaCapture(Piece[,] detailBoard)
        {
            List<Point> lst = new List<Point>();
            Rook rook = new Rook(I, J, StartI, StartJ, Color);
            Bishop bishop = new Bishop(I, J, StartI, StartJ, Color);
            List<Point> lstRook = rook.getLocaCapture(detailBoard);
            List<Point> lstBishop = bishop.getLocaCapture(detailBoard);
            for (int i = 0; i < lstRook.Count; i++)
            {
                lst.Add(lstRook[i]);
            }
            for (int i = 0; i < lstBishop.Count; i++)
            {
                lst.Add(lstBishop[i]);
            }
            return lst;
        }
        public override Piece getCoppy()
        {
            Queen queen = new Queen(I, J, StartI, StartJ, Value);
            queen.Step = Step;
            queen.Status = Status;
            return queen;
        }
        public override Piece getCoppy(Point location)
        {
            Queen queen = new Queen(location.X, location.Y, StartI, StartJ, Value);
            queen.Step = Step;
            queen.Status = Status;
            return queen;
        }
    }
}
