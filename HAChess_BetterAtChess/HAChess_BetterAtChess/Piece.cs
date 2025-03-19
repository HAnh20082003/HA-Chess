using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace HAChess_BetterAtChess
{
    public class Piece
    {
        public static string pathWhiteTurn = "assets/imgs/White Pawn.png";
        public static string pathBlackTurn = "assets/imgs/Black Pawn.png";

        public static int countPiece = 6;
        private int row = 8, col = 8;
        private static string colorVNWhite = "Trắng";
        private static string colorVNBlack = "Đen";
        private static string fenColorWhite = "w";
        private static string fenColorWBlack = "b";
        private static string colorWhite = "white";
        private static string colorBlack = "black";
        private static string nameKing = "king";
        private static string nameRook = "rook";
        private static string nameKnight = "knight";
        private static string nameBishop = "bishop";
        private static string nameQueen = "queen";
        private static string namePawn = "pawn";
        private static string nameNone = "none";

        private static string nameKingVN = "Vua";
        private static string nameRookVN = "Xe";
        private static string nameKnightVN = "Mã";
        private static string nameBishopVN = "Tượng";
        private static string nameQueenVN = "Hậu";
        private static string namePawnVN = "Tốt";
        private static string nameNoneVN = "Ô trống";

        private static int valuePawn = 1;
        private static int valueRook = 2;
        private static int valueKnight = 3;
        private static int valueBishop = 4;
        private static int valueQueen = 5;
        private static int valueKing = 6;
        private static int valueNone = 0;
        private static string notationPawn = "";
        private static string notationRook = "R";
        private static string notationKnight = "N";
        private static string notationBishop = "B";
        private static string notationQueen = "Q";
        private static string notationKing = "K";
        private static string fenPawn = "P";
        private static string fenRook = "R";
        private static string fenKnight = "N";
        private static string fenBishop = "B";
        private static string fenQueen = "Q";
        private static string fenKing = "K";
        private static int typePiece = 1;
        private static string tailImg = ".png";
        private static string statusCurrentPrevMove = "Nước xuất phát";
        private static string statusCurrentDesMove = "Nước đích";
        private static string statusNone = "Không có gì";
        private static string[] typesPieces = { "Kiểu chủ đề mới", "Kiểu chủ đề biển băng", "Kiểu chủ đề thuỷ tinh", "Kiểu chủ đề gỗ", "Kiểu chủ đề cổ điển" };

        private int step = 0;
        private int i, j;
        private int startI, startJ;
        private string name;
        private string color;
        private int value;
        private string textNotation;
        private string status;
        private string fen;

        public static string ColorWhite { get => colorWhite; }
        public static string ColorBlack { get => colorBlack; }
        public static string NameKing { get => nameKing; }
        public static string NameRook { get => nameRook; }
        public static string NameKnight { get => nameKnight; }
        public static string NameBishop { get => nameBishop; }
        public static string NameQueen { get => nameQueen; }
        public static string NamePawn { get => namePawn; }
        public static string NameNone { get => nameNone; }
        public static string[] TypesPieces { get => typesPieces; set => typesPieces = value; }

        public int I { get => i; set => i = value; }
        public int J { get => j; set => j = value; }
        public int StartI { get => startI; set => startI = value; }
        public int StartJ { get => startJ; set => startJ = value; }
        public static int TypePiece { get => typePiece; set => typePiece = value; }
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public static int ValuePawn { get => valuePawn; }
        public static int ValueRook { get => valueRook; }
        public static int ValueKnight { get => valueKnight; }
        public static int ValueBishop { get => valueBishop; }
        public static int ValueQueen { get => valueQueen; }
        public static int ValueKing { get => valueKing; }
        public static int ValueNone { get => valueNone; }
        public int Value { get => value; set => this.value = value; }
        public int Step { get => step; set => step = value; }
        public string Name { get => name; set => name = value; }
        public string Color { get => color; set => color = value; }
        public static string ColorVNWhite { get => colorVNWhite; }
        public static string ColorVNBlack { get => colorVNBlack; }
        public string TextNotation { get => textNotation; set => textNotation = value; }
        public static string NotationPawn { get => notationPawn; }
        public static string NotationRook { get => notationRook; }
        public static string NotationKnight { get => notationKnight; }
        public static string NotationBishop { get => notationBishop; }
        public static string NotationQueen { get => notationQueen; }
        public static string NotationKing { get => notationKing; }
        public static string FenColorWhite { get => fenColorWhite; }
        public static string FenColorWBlack { get => fenColorWBlack; }
        public static string FenPawn { get => fenPawn; }
        public static string FenRook { get => fenRook; }
        public static string FenKnight { get => fenKnight; }
        public static string FenBishop { get => fenBishop; }
        public static string FenQueen { get => fenQueen; }
        public static string FenKing { get => fenKing; }
        public string Status { get => status; set => status = value; }
        public static string StatusCurrentPrevMove { get => statusCurrentPrevMove; }
        public static string StatusCurrentDesMove { get => statusCurrentDesMove; }
        public string Fen { get => fen; set => fen = value; }

        public Piece(int i, int j, int startI, int startJ, string name, string color)
        {
            I = i;
            J = j;
            StartI = startI;
            StartJ = startJ;
            Name = name;
            Color = color;
            value = findValue(name, color);
            Status = statusNone;
            fen = findFen(name, color);
            TextNotation = findTextNotation(name);
        }
        public Piece(int i, int j, int startI, int startJ, int value)
        {
            I = i;
            J = j;
            StartI = startI;
            StartJ = startJ;
            this.value = value;
            var nameAndColor = findNameAndColor(value);
            Name = nameAndColor.Item1;
            Color = nameAndColor.Item2;
            Status = statusNone;
            fen = findFen(value);
            TextNotation = findTextNotation(Name);
        }

        public static string getNameVN(string name)
        {
            if (name == namePawn)
            {
                return namePawnVN;
            }
            if (name == NameKing)
            {
                return nameKingVN;
            }
            if (name == nameRook)
            {
                return nameRookVN;
            }
            if (name == nameKnight)
            {
                return nameKnightVN;
            }
            if (name == nameBishop)
            {
                return nameBishopVN;
            }
            if (name == nameQueen)
            {
                return nameQueenVN;
            }
            return nameNoneVN;
        }
        public static string getNameVNByNotation(string notation)
        {
            if (notation == notationRook)
            {
                return nameRookVN;
            }
            if (notation == notationKnight)
            {
                return nameKnightVN;
            }
            if (notation == notationBishop)
            {
                return nameBishopVN;
            }
            return notationQueen;
        }

        public static string getVNColor(string colorEng)
        {
            if (colorEng == colorWhite)
            {
                return ColorVNWhite;
            }
            return colorVNBlack;
        }
        public static Piece getPieceByNotation(string notation, string color, int startI, int startJ, int i, int j)
        {
            if (notation == NotationPawn)
            {
                return new Pawn(i, j, startI, startJ, color);
            }
            if (notation == NotationRook)
            {
                return new Rook(i, j, startI, startJ, color);
            }
            if (notation == NotationKnight)
            {
                return new Knight(i, j, startI, startJ, color);
            }
            if (notation == NotationBishop)
            {
                return new Bishop(i, j, startI, startJ, color);
            }
            if (notation == NotationQueen)
            {
                return new Queen(i, j, startI, startJ, color);
            }
            if (notation == notationKing)
            {
                return new King(i, j, startI, startJ, color);
            }
            return null;
        }

        public static bool isSameMaterial(Piece pieceA, Piece pieceB)
        {
            if (pieceA == null || pieceB == null)
            {
                return pieceA == null && pieceB == null;
            }
            return pieceA.Value == pieceB.Value;
        }

        public List<Piece> getSamePiece(Piece[,] detailBoard)
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (detailBoard[i, j] != null)
                    {
                        if (detailBoard[i, j].Name == Name && detailBoard[i, j].Color == Color)
                        {
                            pieces.Add(detailBoard[i, j]);
                        }
                    }
                }
            }
            return pieces;
        }

        public Piece findPiece()
        {
            int tmpValue = Math.Abs(value);
            if (tmpValue == ValueRook)
            {
                return new Rook(i, j, StartI, StartJ, value);
            }
            if (tmpValue == ValueKnight)
            {
                return new Knight(i, j, StartI, StartJ, value);
            }
            if (tmpValue == ValueBishop)
            {
                return new Bishop(i, j, StartI, StartJ, value);
            }
            if (tmpValue == ValueQueen)
            {
                return new Queen(i, j, StartI, StartJ, value);
            }
            if (tmpValue == ValuePawn)
            {
                return new Pawn(i, j, StartI, StartJ, value);
            }
            if (tmpValue == ValueKing)
            {
                return new King(i, j, StartI, StartJ, value);
            }
            return null;
        }
        public string findFen(string name, string color)
        {
            if (name == NamePawn)
            {
                return color == ColorWhite ? fenPawn : fenPawn.ToLower();
            }
            if (name == NameRook)
            {
                return color == ColorWhite ? fenRook : fenRook.ToLower();
            }
            if (name == NameKnight)
            {
                return color == ColorWhite ? fenRook : fenKnight.ToLower();
            }
            if (name == NameBishop)
            {
                return color == ColorWhite ? fenRook : fenBishop.ToLower();
            }
            if (name == NameQueen)
            {
                return color == ColorWhite ? fenRook : fenQueen.ToLower();
            }
            if (name == NameKing)
            {
                return color == ColorWhite ? fenRook : fenKing.ToLower();
            }
            return null;
        }
        public string findTextNotation(string name)
        {
            if (name == NamePawn)
            {
                return notationPawn;
            }
            if (name == NameRook)
            {
                return notationRook;
            }
            if (name == NameKnight)
            {
                return notationKnight;
            }
            if (name == NameBishop)
            {
                return notationBishop;
            }
            if (name == NameQueen)
            {
                return notationQueen;
            }
            if (name == NameKing)
            {
                return notationKing;
            }
            return null;
        }
        public static int convertFenToValuePiece(string fenPiece)
        {
            if (fenPiece == fenRook)
            {
                return valueRook;
            }
            if (fenPiece == fenRook.ToLower())
            {
                return -valueRook;
            }
            if (fenPiece == fenKnight)
            {
                return valueKnight;
            }
            if (fenPiece == fenKnight.ToLower())
            {
                return -valueKnight;
            }
            if (fenPiece == fenBishop)
            {
                return valueBishop;
            }
            if (fenPiece == fenBishop.ToLower())
            {
                return -valueBishop;
            }
            if (fenPiece == fenQueen)
            {
                return valueQueen;
            }
            if (fenPiece == fenQueen.ToLower())
            {
                return -valueQueen;
            }
            if (fenPiece == fenPawn)
            {
                return valuePawn;
            }
            if (fenPiece == fenPawn.ToLower())
            {
                return -valuePawn;
            }
            if (fenPiece == fenKing)
            {
                return valueKing;
            }
            if (fenPiece == fenKing.ToLower())
            {
                return -valueKing;
            }
            return valueNone;
        }
        public string findFen(int value)
        {
            bool isWhite = value < 0 ? false : true;
            value = Math.Abs(value);
            if (value == valuePawn)
            {
                return isWhite ? fenPawn : fenPawn.ToLower();
            }
            if (value == ValueRook)
            {
                return isWhite ? FenRook : fenRook.ToLower();
            }
            if (value == ValueKnight)
            {
                return isWhite ? fenKnight : fenKnight.ToLower();
            }
            if (value == ValueBishop)
            {
                return isWhite ? fenBishop : fenBishop.ToLower();
            }
            if (value == ValueQueen)
            {
                return isWhite ? fenQueen : fenQueen.ToLower();
            }
            if (value == ValueKing)
            {
                return isWhite ? fenKing : fenKing.ToLower();
            }
            return null;
        }

        public int findValue(string name, string color)
        {
            if (name == NamePawn)
            {
                return color == ColorWhite ? ValuePawn : -ValuePawn;
            }
            if (name == NameRook)
            {
                return color == ColorWhite ? ValueRook : -ValueRook;
            }
            if (name == NameKnight)
            {
                return color == ColorWhite ? ValueKnight : -ValueKnight;
            }
            if (name == NameBishop)
            {
                return color == ColorWhite ? ValueBishop : -ValueBishop;
            }
            if (name == NameQueen)
            {
                return color == ColorWhite ? ValueQueen : -ValueQueen;
            }
            if (name == NameKing)
            {
                return color == ColorWhite ? ValueKing : -ValueKing;
            }
            return color == ColorWhite ? ValueNone : -ValueNone;
        }
        public (string, string) findNameAndColor(int value)
        {
            string color = ColorWhite;
            if (value < 0)
            {
                color = ColorBlack;
            }
            value = Math.Abs(value);
            if (value == ValuePawn)
            {
                return (NamePawn, color);
            }
            if (value == ValueRook)
            {
                return (NameRook, color);
            }
            if (value == ValueKnight)
            {
                return (NameKnight, color);
            }
            if (value == ValueBishop)
            {
                return (NameBishop, color);
            }
            if (value == ValueQueen)
            {
                return (NameQueen, color);
            }
            if (value == ValueKing)
            {
                return (NameKing, color);
            }
            return (NameNone, color);
        }

        public string getVNName()
        {
            if (Name == NamePawn)
            {
                return "Tốt";
            }
            if (Name == NameRook)
            {
                return "Xe";
            }
            if (Name == NameKnight)
            {
                return "Mã";
            }
            if (Name == NameBishop)
            {
                return "Tượng";
            }
            if (Name == NameQueen)
            {
                return "Hậu";
            }
            if (Name == NameKing)
            {
                return "Vua";
            }
            return "Ô trống";
        }

        public string getPathImg()
        {
            return "assets/imgs/pieces/type_" + typePiece + "/" + Color + "_" + Name + tailImg;
        }
        public static string getPathImg(string name, string color)
        {
            return "assets/imgs/pieces/type_" + typePiece + "/" + color + "_" + name + tailImg;
        }
        public static string getPathImg(string name, bool whiteColor)
        {
            return "assets/imgs/pieces/type_" + typePiece + "/" + (whiteColor ? ColorWhite : colorBlack ) + "_" + name + tailImg;
        }

        public static void changeTypePiece(int newNumberType)
        {
            if (File.Exists("assets/imgs/pieces/type_" + newNumberType + "/" + ColorBlack + "_" + NameKing + tailImg))
            {
                typePiece = newNumberType;
            }
        }

        public static List<Piece> getPieces(string name, string color, int row, int col, Piece[,] detailBoard)
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null && detailBoard[i, j].Name == name && detailBoard[i, j].Color == color)
                    {
                        pieces.Add(detailBoard[i, j].getCoppy());
                    }
                }
            }
            return pieces;
        }
        public static List<Piece> getAllPieces(int row, int col, Piece[,] detailBoard)
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null)
                    {
                        pieces.Add(detailBoard[i, j].getCoppy());
                    }
                }
            }
            return pieces;
        }
        public static List<Piece> getPieces(string color, int row, int col, Piece[,] detailBoard)
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null && detailBoard[i, j].Color == color)
                    {
                        pieces.Add(detailBoard[i, j].getCoppy());
                    }
                }
            }
            return pieces;
        }

        public List<King> getMyKing(Piece[,] detailBoard)
        {
            List<King> kings = new List<King>();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (detailBoard[i, j] != null && detailBoard[i, j].Color == Color && detailBoard[i, j].Name == NameKing)
                    {
                        kings.Add((King)detailBoard[i, j].getCoppy());
                    }
                }
            }
            return kings;
        }
        public static List<King> getKing(int row, int col, string color, Piece[,] detailBoard)
        {
            List<King> kings = new List<King>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null && detailBoard[i, j].Color == color && detailBoard[i, j].Name == NameKing)
                    {
                        kings.Add((King)detailBoard[i, j].getCoppy());
                    }
                }
            }
            return kings;
        }

        public Piece[,] coppyBoard(Piece[,] detailBoard)
        {
            Piece[,] tmp = new Piece[row, col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (detailBoard[i, j] == null)
                    {
                        tmp[i, j] = null;
                    }
                    else
                    {
                        tmp[i, j] = detailBoard[i, j].getCoppy();
                    }
                }
            }
            return tmp;
        }

        public virtual bool canMoveTo(int desI, int desJ, Piece[,] detailBoard)
        {
            return true;
        }

        public virtual bool canCapTure(int desI, int desJ, Piece[,] detailBoard)
        {
            return true;
        }

        public virtual List<Point> getLocaMoveTo(Piece[,] detailBoard, bool isReverse)
        {
            return new List<Point>();
        }
        public virtual List<Point> getLocaCapture(Piece[,] detailBoard)
        {
            return new List<Point>();
        }

        public virtual Piece getCoppy()
        {
            if (this is Pawn)
            {
                return ((Pawn)this).getCoppy();
            }
            if (this is Rook)
            {
                return ((Rook)this).getCoppy();
            }
            if (this is Bishop)
            {
                return ((Bishop)this).getCoppy();
            }
            if (this is Knight)
            {
                return ((Knight)this).getCoppy();
            }
            if (this is Queen)
            {
                return ((Queen)this).getCoppy();
            }
            if (this is King)
            {
                return ((King)this).getCoppy();
            }
            return null;
        }
        public virtual Piece getCoppy(Point location)
        {
            return null;
        }
    }
}
