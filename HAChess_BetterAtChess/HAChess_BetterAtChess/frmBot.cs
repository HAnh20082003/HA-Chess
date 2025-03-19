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
    public partial class frmBot : Form
    {
        List<BotChess> bots;
        tb_Account myAccount;
        Color colorTextNotation = Color.Black, colorNewMoveNotation = Color.Yellow;
        Color colorHightLightRowNotation = Color.RoyalBlue;
        Chess chess;
        LoadPiecesCapture loadPiecesCaptured;
        string notation = "";
        int indexTypeGame, indexRegime;
        InfoSettingBoard infoSettingBoard;

        bool loadfen = true;

        internal frmBot(tb_Account myAccount)
        {
            InitializeComponent();
            this.myAccount = myAccount;
            loadPiecesCaptured = new LoadPiecesCapture(false, pnTopCapturePieces, pnBotCapturePieces);
            loadChess();
            loadRegimes();
            loadTypeGames();
            loadBots();
            loadSettingBoard();
            addToolTip();
            KeyPreview = true;
        }

        private void addToolTip()
        {
            ttPrintFile.SetToolTip(btnPrint, "Ctrl + P");
            ttRestart.SetToolTip(btnRestart, "Ctrl + 1");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
            ttCbbWhite.SetToolTip(cbbWhite, "Lựa chọn 1 trong nhiều đối tượng trong danh sách");
            ttCbbWhite.SetToolTip(cbbBlack, "Lựa chọn 1 trong nhiều đối tượng trong danh sách");
        }

        private void frmBot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch(e.KeyCode)
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
                }
            }
        }

        private void loadBots()
        {
            bots = BotChess.getAllBots();
            cbbWhite.Items.Add("Chính tôi - " + myAccount.Name + "#" + myAccount.Id);
            cbbBlack.Items.Add("Chính tôi - " + myAccount.Name + "#" + myAccount.Id);
            for (int i = 0; i < bots.Count; i++)
            {
                cbbWhite.Items.Add(bots[i].NameBot + " (" + bots[i].Elo + " elo)");
                cbbBlack.Items.Add(bots[i].NameBot + " (" + bots[i].Elo + " elo)");
            }
            bots.Insert(0, new BotChess());
            cbbWhite.SelectedIndex = 0;
            cbbBlack.SelectedIndex = 0;
        }

        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
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
                loadfen = false;
                txtFen.Text = chess.getCurrentFen();
                loadfen = true;
                if (cbbTypeGame.Items.Count == 3)
                {
                    cbbTypeGame.Items.RemoveAt(2);
                }
            }
            indexTypeGame = cbbTypeGame.SelectedIndex;
            chess.setChess(indexTypeGame, chess.IsReverse, true);
        }
        private void loadChessByFen()
        {
            var tmp = Chess.convertFenToBoard(txtFen.Text);
            if (tmp.Item1 != null)
            {
                chess.setChess(indexTypeGame, "", 0, chess.IsReverse, false, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
            }
        }
        private void txtFen_TextChanged(object sender, EventArgs e)
        {
            if (!loadfen)
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


        private void loadTypeGames()
        {
            for (int i = 0; i < TypeGame.typeGames.Count; i++)
            {
                cbbTypeGame.Items.Add(TypeGame.typeGames[i]);
            }
            cbbTypeGame.SelectedIndex = 0;
        }

        private void cbbRegimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexRegime = cbbRegimes.SelectedIndex;
            string time = Regime.regimes[indexRegime].getTime();
            chess.updateTime(time, time, Regime.regimes[indexRegime].time_bonus);
        }
        private void loadRegimes()
        {
            for (int i = 0; i < Regime.regimes.Count; i++)
            {
                cbbRegimes.Items.Add(Regime.regimes[i].ToShortString());
            }
            cbbRegimes.SelectedIndex = 0;
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
            chess.sendTime += receiveTime;
            chess.sendTimeOut += receiveTimeOut;
            chess.sendUnPromotion += receiveUnPromotion;
            chess.initBoard(pnChessBoard);
        }
        private void receiveTimeOut(bool isWhiteTurn)
        {

        }
        private void receiveTime(bool isTop, string time, int timeBonus)
        {
            if (isTop)
            {
                btnTopTime.Text = time;
            }
            else
            {
                btnBotTime.Text = time;
            }
        }

        public void receiveBackBoard(bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            btnResign.Enabled = true;
        }

        public void receiveChangeTurn(bool isWhiteColor)
        {
            if (chess.BotPlayer1 != null || chess.BotPlayer2 != null)
            {
                btnResign.Text = "Đầu hàng";
            }
            else
            {
                btnResign.Text = isWhiteColor ? "Trắng đầu hàng" : "Đen đầu hàng";
            }
            lblTurn.Text = isWhiteColor ? "Lượt của cờ trắng" : "Lượt của cờ đen";
            pnPromotion.Visible = false;
        }
        public void receiveResetBoard()
        {
            setStartGame();
        }


        private void setEndGame(string currentScore, string result, string detailResult)
        {
            btnResign.Enabled = false;
            lblSignEndGame.Text = "Kí hiệu: " + currentScore;
            lblTypeEndgame.Text = "Loại kết thúc: " + detailResult;
            lblResult.Text = "Kết quả: " + result;
            pnPromotion.Visible = false;
        }
        private void setStartGame()
        {
            btnResign.Enabled = true;
            notation = "";
            loadPiecesCaptured.resetPieceCapture();
            resetEndGame();
            fpnNotations.Controls.Clear();
            pnPromotion.Visible = false;
            lblStartTurn.Text = "Lược đầu: trắng";

            string time = Regime.regimes[indexRegime].getTime();
            chess.updateTime(time, time, Regime.regimes[indexRegime].time_bonus);
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

        private void cbbWhite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bots[cbbWhite.SelectedIndex].NameBot))
            {
                ptrWhite.Image = Image.FromFile("assets/imgs/you.png");
                lblNameWhite.Text = myAccount.Name + "#" + myAccount.Id;
            }
            else
            {
                ptrWhite.Image = bots[cbbWhite.SelectedIndex].Avatar;
                lblNameWhite.Text = bots[cbbWhite.SelectedIndex].NameBot + " (" + bots[cbbWhite.SelectedIndex].Elo + " elo)";
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            chess.restartBoard();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint input = new frmPrint(chess, cbbTypeGame.SelectedIndex, cbbRegimes.SelectedIndex, notation);
            input.ShowDialog();
        }

        private void cbbBlack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bots[cbbBlack.SelectedIndex].NameBot))
            {
                ptrBlack.Image = Image.FromFile("assets/imgs/you.png");
                lblNameBlack.Text = myAccount.Name + "#" + myAccount.Id;
            }
            else
            {
                ptrBlack.Image = bots[cbbBlack.SelectedIndex].Avatar;
                lblNameBlack.Text = bots[cbbBlack.SelectedIndex].NameBot + " (" + bots[cbbBlack.SelectedIndex].Elo + " elo)";
            }
        }

        private void timerWaitSetup_Tick(object sender, EventArgs e)
        {
            timerWaitSetup.Stop();
            btnAccept.Enabled = true;
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            if (chess.BotPlayer1 != null)
            {
                chess.resign(false);
            }
            else if (chess.BotPlayer2 != null)
            {
                chess.resign(true);
            }
            else
            {
                chess.resign();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbbWhite.SelectedIndex == 0)
            {
                chess.cancelBot(true);
            }
            else
            {
                chess.freezeBoardByTurnBot();
                chess.setBotChess(bots[cbbWhite.SelectedIndex], true);
                setTimeBot();
                chess.nextMoveByBot();
            }

            if (cbbBlack.SelectedIndex == 0)
            {
                chess.cancelBot(false);
            }
            else
            {
                chess.freezeBoardByTurnBot();
                chess.setBotChess(bots[cbbBlack.SelectedIndex], false);
                setTimeBot();
                chess.nextMoveByBot();
            }

            if (chess.BotPlayer1 != null && chess.BotPlayer2 != null)
            {
                btnResign.Visible = false;
            }
            else
            {
                btnResign.Visible = true;
                if (chess.BotPlayer1 != null || chess.BotPlayer2 != null)
                {
                    btnResign.Text = "Đầu hàng";
                }
                else
                {
                    btnResign.Text = chess.isWhiteTurn() ? "Trắng đầu hàng" : "Đen đầu hàng";
                }
            }
            btnAccept.Enabled = false;
            timerWaitSetup.Start();
        }

        private void setTimeBot()
        {
            if (chess.BotPlayer1 != null)
            {
                chess.BotPlayer1.setUpTime(Regime.regimes[cbbRegimes.SelectedIndex].indexName);
            }
            if (chess.BotPlayer2 != null)
            {
                chess.BotPlayer2.setUpTime(Regime.regimes[cbbRegimes.SelectedIndex].indexName);
            }
        }
    }
}
