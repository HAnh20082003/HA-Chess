using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    class LoadPiecesCapture
    {
        PictureBox[] ptrTopImgPieceCapture = new PictureBox[Piece.countPiece];
        int[] countTopEveryPieceCapture = new int[Piece.countPiece];
        Label[] lblCountTopEveryPieceCapture = new Label[Piece.countPiece];
        PictureBox[] ptrBotImgPieceCapture = new PictureBox[Piece.countPiece];
        int[] countBotEveryPieceCapture = new int[Piece.countPiece];
        Label[] lblCountBotEveryPieceCapture = new Label[Piece.countPiece];
        Color colorText = Color.Navy;
        Color colorSelect = Color.Yellow;
        public LoadPiecesCapture(bool isReverse, Panel pnTopCapturePieces, Panel pnBotCapturePieces)
        {
            string[] piece = { Piece.NamePawn, Piece.NameRook, Piece.NameKnight, Piece.NameBishop, Piece.NameQueen, Piece.NameKing };
            Point location = new Point(0, 0);
            Size size = new Size(30, 30);
            for (int i = 0; i < Piece.countPiece; i++)
            {
                string colorTop, colorBot;
                if (isReverse)
                {
                    colorTop = Piece.ColorBlack;
                    colorBot = Piece.ColorWhite;
                }
                else
                {
                    colorTop = Piece.ColorWhite;
                    colorBot = Piece.ColorBlack;
                }
                ptrTopImgPieceCapture[i] = new PictureBox()
                {
                    Size = size,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(Piece.getPathImg(piece[i], colorTop)),
                    Location = location,
                };
                pnTopCapturePieces.Controls.Add(ptrTopImgPieceCapture[i]);
                ptrBotImgPieceCapture[i] = new PictureBox()
                {
                    Size = size,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(Piece.getPathImg(piece[i], colorBot)),
                    Location = location,
                };
                pnBotCapturePieces.Controls.Add(ptrBotImgPieceCapture[i]);
                location.X += size.Width + 5;
                countTopEveryPieceCapture[i] = 0;
                countBotEveryPieceCapture[i] = 0;
                lblCountTopEveryPieceCapture[i] = new Label()
                {
                    Text = countTopEveryPieceCapture[i].ToString(),
                    AutoSize = true,
                    ForeColor = colorText,
                };
                lblCountTopEveryPieceCapture[i].Location = new Point(location.X, location.Y + ptrTopImgPieceCapture[i].Height / 2 - lblCountTopEveryPieceCapture[i].Height / 2);
                pnTopCapturePieces.Controls.Add(lblCountTopEveryPieceCapture[i]);
                lblCountBotEveryPieceCapture[i] = new Label()
                {
                    Text = countBotEveryPieceCapture[i].ToString(),
                    Location = location,
                    AutoSize = true,
                    ForeColor = colorText,
                };
                lblCountBotEveryPieceCapture[i].Location = new Point(location.X, location.Y + ptrBotImgPieceCapture[i].Height / 2 - lblCountBotEveryPieceCapture[i].Height / 2);
                pnBotCapturePieces.Controls.Add(lblCountBotEveryPieceCapture[i]);
                location.X += 20;
            }
        }

        public void updatePieceCapture(bool isWhiteTurn, Chess chess)
        {
            (int[], int) captureList = chess.getStrPieceCapture(!isWhiteTurn);
            if (isWhiteTurn && chess.IsReverse || (!isWhiteTurn && !chess.IsReverse))
            {
                for (int i = 0; i < captureList.Item1.Length; i++)
                {
                    countTopEveryPieceCapture[i] = captureList.Item1[i];
                    lblCountTopEveryPieceCapture[i].Text = countTopEveryPieceCapture[i].ToString();
                    if (i == captureList.Item2)
                    {
                        ptrTopImgPieceCapture[i].BackColor = Color.Yellow;
                        //lblCountTopEveryPieceCapture[i].ForeColor = Color.Yellow;
                    }
                    else
                    {
                        ptrTopImgPieceCapture[i].BackColor = Color.Transparent;
                        //lblCountTopEveryPieceCapture[i].ForeColor = colorText;
                    }
                }
            }
            else
            {
                for (int i = 0; i < captureList.Item1.Length; i++)
                {
                    countBotEveryPieceCapture[i] = captureList.Item1[i];
                    lblCountBotEveryPieceCapture[i].Text = countBotEveryPieceCapture[i].ToString();
                    if (i == captureList.Item2)
                    {
                        ptrBotImgPieceCapture[i].BackColor = colorSelect;
                        //lblCountBotEveryPieceCapture[i].ForeColor = Color.Yellow;
                    }
                    else
                    {
                        ptrBotImgPieceCapture[i].BackColor = Color.Transparent;
                        //lblCountBotEveryPieceCapture[i].ForeColor = colorText;
                    }
                }
            }
        }
        public void swapPieceCapture(bool isReverse)
        {
            string[] piece = { Piece.NamePawn, Piece.NameRook, Piece.NameKnight, Piece.NameBishop, Piece.NameQueen, Piece.NameKing };
            for (int i = 0; i < Piece.countPiece; i++)
            {
                string colorTop, colorBot;
                if (isReverse)
                {
                    colorTop = Piece.ColorBlack;
                    colorBot = Piece.ColorWhite;
                }
                else
                {
                    colorTop = Piece.ColorWhite;
                    colorBot = Piece.ColorBlack;
                }
                ptrTopImgPieceCapture[i].Image = Image.FromFile(Piece.getPathImg(piece[i], colorTop));
                ptrBotImgPieceCapture[i].Image = Image.FromFile(Piece.getPathImg(piece[i], colorBot));
                Color tmpColor = ptrTopImgPieceCapture[i].BackColor;
                ptrTopImgPieceCapture[i].BackColor = ptrBotImgPieceCapture[i].BackColor;
                ptrBotImgPieceCapture[i].BackColor = tmpColor;
                //lblCountTopEveryPieceCapture[i].ForeColor = ptrTopImgPieceCapture[i].BackColor;
                //lblCountBotEveryPieceCapture[i].ForeColor = ptrBotImgPieceCapture[i].BackColor;
                int tmpCount = countTopEveryPieceCapture[i];
                countTopEveryPieceCapture[i] = countBotEveryPieceCapture[i];
                countBotEveryPieceCapture[i] = tmpCount;
                lblCountTopEveryPieceCapture[i].Text = countTopEveryPieceCapture[i].ToString();
                lblCountBotEveryPieceCapture[i].Text = countBotEveryPieceCapture[i].ToString();
            }
        }
        public void resetPieceCapture()
        {
            if (ptrTopImgPieceCapture == null)
            {
                return;
            }
            for (int i = 0; i < Piece.countPiece; i++)
            {
                countTopEveryPieceCapture[i] = 0;
                countBotEveryPieceCapture[i] = 0;
                lblCountTopEveryPieceCapture[i].Text = countTopEveryPieceCapture[i].ToString();
                lblCountBotEveryPieceCapture[i].Text = countBotEveryPieceCapture[i].ToString();
                ptrTopImgPieceCapture[i].BackColor = Color.Transparent;
                //lblCountTopEveryPieceCapture[i].ForeColor = Color.Transparent;
                ptrBotImgPieceCapture[i].BackColor = Color.Transparent;
                //lblCountBotEveryPieceCapture[i].ForeColor = Color.Transparent;
            }
        }
    }
}
