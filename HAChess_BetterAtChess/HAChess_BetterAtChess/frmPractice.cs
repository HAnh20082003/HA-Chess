using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public partial class frmPractice : Form
    {
        Chess chess;
        LoadPiecesCapture loadPiecesCaptured;
        Color colorTextNotation = Color.Black, colorNewMoveNotation = Color.Yellow;
        Color colorHightLightRowNotation = Color.RoyalBlue;
        string notation = "";
        InfoSettingBoard infoSettingBoard;
        int indexTypeGame = 0;
        int indexRegime = 0;
        bool loadFen = false;
        public frmPractice()
        {
            InitializeComponent(); 
            loadPiecesCaptured = new LoadPiecesCapture(false, pnTopCapturePieces, pnBotCapturePieces);
            loadChess();
            loadTypeGames();
            loadSettingBoard();
            addToolTip();
            KeyPreview = true;
        }
        private void addToolTip()
        {
            ttPrintFile.SetToolTip(btnPrint, "Ctrl + P");
            ttRestart.SetToolTip(btnRestart, "Ctrl + 1");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
            ttPrevMove.SetToolTip(btnBackChess, "Ctr + A");
            ttFirstMove.SetToolTip(btnGoToFirstMove, "Ctr + W");
        }

        private void frmPractice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.P:
                        btnPrint.PerformClick();
                        break;
                    case Keys.D1:
                        btnRestart.PerformClick();
                        break;
                    case Keys.D2:
                        btnReverse.PerformClick();
                        break;
                    case Keys.A:
                        btnBackChess.PerformClick();
                        break;
                    case Keys.W:
                        btnGoToFirstMove.PerformClick();
                        break;
                }
            }
        }

        public void loadChess()
        {
            chess = new Chess(pnChessBoard.Width, 20);
            chess.sendBackBoard += receiveBackBoard;
            chess.sendChangeTurn += receiveChangeTurn;
            chess.sendEndGame += receiveEndGame;
            chess.sendReset += receiveResetBoard;
            chess.sendPromotion += receivePromotion;
            chess.sendReverse += receiveReverseBoard;
            chess.sendMove += receiveMove;
            chess.sendStrNotation += receiveStrNotation;
            chess.sendUnPromotion += receiveUnPromotion;
            chess.initBoard(pnChessBoard);
        }

        public void receiveBackBoard(bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            btnResign.Enabled = btnMakeDraw.Enabled = true;
        }

        public void receiveChangeTurn(bool isWhiteColor)
        {
            lblTurn.Text = isWhiteColor ? "Lượt của cờ trắng" : "Lượt của cờ đen";
            btnResign.Text = isWhiteColor ? "Trắng đầu hàng" : "Đen đầu hàng";
            pnPromotion.Visible = false;
        }
        public void receiveResetBoard()
        {
            setStartGame();
        }


        private void setEndGame(string currentScore, string result, string detailResult)
        {
            btnResign.Enabled = btnMakeDraw.Enabled = false;
            lblSignEndGame.Text = "Kí hiệu: " + currentScore;
            lblTypeEndgame.Text = "Loại kết thúc: " + detailResult;
            lblResult.Text = "Kết quả: " + result;
            pnPromotion.Visible = false;
        }
        private void setStartGame()
        {
            btnResign.Enabled = btnMakeDraw.Enabled = true; 
            notation = "";
            loadPiecesCaptured.resetPieceCapture(); 
            resetEndGame();
            btnBackChess.Enabled = btnGoToFirstMove.Enabled = false;
            fpnNotations.Controls.Clear();
            pnPromotion.Visible = false;
            lblStartTurn.Text = "Lược đầu: trắng";
        }
        private void resetEndGame()
        {
            lblTypeEndgame.Text = "Loại kết thúc: ";
            lblSignEndGame.Text = "Kí hiệu: ";
            lblResult.Text = "Kết quả: ";
        }


        public void receiveEndGame(string currentScore, string result, string detailResult)
        {
            setEndGame(currentScore, result, detailResult);
        }
        public void receiveReverseBoard(bool isReverse)
        {
            loadPiecesCaptured.swapPieceCapture(isReverse);
        }

        public void receiveMove(string strMove, string namePromotion, bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            btnBackChess.Enabled = true;
            if (chess.canGoToFirstMove())
            {
                btnGoToFirstMove.Enabled = true;
            }
            pnPromotion.Visible = false;
        }

        private void receivePromotion(bool colorTurn)
        {
            ptrQueen.Image = Image.FromFile(Piece.getPathImg(Piece.NameQueen, colorTurn));
            ptrQueen.Tag = (Piece.NameQueen, colorTurn);
            ptrRook.Image = Image.FromFile(Piece.getPathImg(Piece.NameRook, colorTurn));
            ptrRook.Tag = (Piece.NameRook, colorTurn);
            ptrKnight.Image = Image.FromFile(Piece.getPathImg(Piece.NameKnight, colorTurn));
            ptrKnight.Tag = (Piece.NameKnight, colorTurn);
            ptrBishop.Image = Image.FromFile(Piece.getPathImg(Piece.NameBishop, colorTurn));
            ptrBishop.Tag = (Piece.NameBishop, colorTurn);

            pnPromotion.Visible = true;
        }

        private void selectPromotion(object sender, EventArgs e)
        {
            (string, bool) tag = ((string, bool))((Control)sender).Tag;
            chess.promotionPiece(tag.Item1, tag.Item2);
            pnPromotion.Visible = false;
        }

        private void receiveUnPromotion()
        {
            pnPromotion.Visible = false;
        }

        public void receiveStrNotation(string strNotation)
        {
            foreach (Control pn in fpnNotations.Controls)
            {
                pn.BackColor = Color.Transparent;
                foreach (Control item in pn.Controls)
                {
                    item.ForeColor = colorTextNotation;
                }
            }
            int lastIndex = chess.saveMoves.Count;

            Label lbl = new Label()
            {
                Text = strNotation,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = lastIndex,
                ForeColor = colorNewMoveNotation,
            };
            lbl.MouseClick += selectMoveNotation;

            Size sizePanel = new Size(fpnNotations.Width - 50, 44);

            if (lastIndex % 2 == 0)
            {
                Panel pn = new Panel()
                {
                    Size = sizePanel,
                };
                fpnNotations.Controls.Add(pn);

                pn.Controls.Add(lbl);
                int indexNotation = lastIndex / 2 + 1;
                Label lblSTT = new Label()
                {
                    Text = indexNotation + ".",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = colorTextNotation,
                };
                pn.Controls.Add(lblSTT);

                lblSTT.Location = new Point(10, sizePanel.Height / 2 - lblSTT.Height / 2);

                lbl.Location = new Point(40, sizePanel.Height / 2 - lbl.Height / 2);
                pn.BackColor = colorHightLightRowNotation;
                fpnNotations.ScrollControlIntoView(pn);
                notation += indexNotation + ". " + strNotation;
            }
            else
            {
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].Controls.Add(lbl);
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].BackColor = colorHightLightRowNotation;
                lbl.Location = new Point(150, sizePanel.Height / 2 - lbl.Height / 2);

                fpnNotations.ScrollControlIntoView(fpnNotations.Controls[fpnNotations.Controls.Count - 1]);
                notation += " " + strNotation + Environment.NewLine;
            }
        }

        private void selectMoveNotation(object sender, MouseEventArgs e)
        {
            int indexMove = (int)((Control)sender).Tag;
            var tmp = chess.getBoardByIndex(indexMove + 1);
            int indexNotation = (indexMove) / 2;
            string notation = fpnNotations.Controls[indexNotation].Controls[1].Text + " ";
            if (indexMove % 2 != 0)
            {
                notation += "... " + fpnNotations.Controls[indexNotation].Controls[2].Text;
            }
            else
            {
                notation += fpnNotations.Controls[indexNotation].Controls[0].Text;
            }
        }

        private void btnBackChess_Click(object sender, EventArgs e)
        {
            resetEndGame();
            int lastIndex = chess.saveMoves.Count - 1;
            if (lastIndex % 2 == 0)
            {
                fpnNotations.Controls.RemoveAt(fpnNotations.Controls.Count - 1);
                if (fpnNotations.Controls.Count != 0)
                {
                    fpnNotations.Controls[fpnNotations.Controls.Count - 1].BackColor = colorHightLightRowNotation;
                    fpnNotations.Controls[fpnNotations.Controls.Count - 1].Controls[2].ForeColor = colorNewMoveNotation;
                }
            }
            else
            {
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].Controls.RemoveAt(2);
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].BackColor = colorHightLightRowNotation;
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].Controls[0].ForeColor = colorNewMoveNotation;
            }
            int indexNotation = (chess.saveMoves.Count - 1) / 2 + 1;
            int index = notation.LastIndexOf(indexNotation + ".");
            string tmp = notation.Substring(index);

            string str = tmp.Substring(tmp.LastIndexOf('.') + 2);
            string[] split = str.Split(' ');
            if (split.Length == 2)
            {
                notation = notation.Remove(notation.LastIndexOf(' '));
            }
            else
            {
                notation = notation.Remove(index);
            }


            pnPromotion.Visible = false;
            chess.backMove();
            if (!chess.canBackChess())
            {
                btnBackChess.Enabled = false;
            }
            if (!chess.canGoToFirstMove())
            {
                btnGoToFirstMove.Enabled = false;
            }
        }

        private void btnGoToFirstMove_Click(object sender, EventArgs e)
        {
            pnPromotion.Visible = false;
            resetEndGame();
            chess.goToFirstMove();
            while (fpnNotations.Controls.Count > 1)
            {
                fpnNotations.Controls.RemoveAt(fpnNotations.Controls.Count - 1);
            }
            btnGoToFirstMove.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            chess.restartBoard();
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            chess.resign();
        }

        private void btnMakeDraw_Click(object sender, EventArgs e)
        {
            chess.draw();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint input = new frmPrint(chess, indexTypeGame, indexRegime, notation);
            input.ShowDialog();
        }

        private void loadTypeGames()
        {
            for (int i = 0; i < TypeGame.typeGames.Count; i++)
            {
                cbbTypeGame.Items.Add(TypeGame.typeGames[i]);
            }
            cbbTypeGame.SelectedIndex = 0;
        }

        private void cbbTypeGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexTypeGame = cbbTypeGame.SelectedIndex;
            if (cbbTypeGame.SelectedIndex == 2)
            {
                loadChessByFen();
            }
            else
            {
                chess.setChess(indexTypeGame, chess.IsReverse, false);
                loadFen = false;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
                if (cbbTypeGame.Items.Count == 3)
                {
                    cbbTypeGame.Items.RemoveAt(2);
                }
            }
        }

        private void loadChessByFen()
        {
            var tmp = Chess.convertFenToBoard(txtFen.Text);
            if (tmp.Item1 != null)
            {
                chess.setChess(indexTypeGame, "", 0, chess.IsReverse, false, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
        }

        private void txtFen_TextChanged(object sender, EventArgs e)
        {
            if (!loadFen)
            {
                return;
            }
            if (cbbTypeGame.Items.Count == 3)
            {
                loadChessByFen();
            }
            else
            {
                cbbTypeGame.Items.Add("Bàn cờ tự nhập");
                cbbTypeGame.SelectedIndex = 2;
            }
        }

        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
        }

    }
}
