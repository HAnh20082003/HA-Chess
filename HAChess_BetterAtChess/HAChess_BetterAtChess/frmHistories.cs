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
    public partial class frmHistories : Form
    {
        InfoSettingBoard infoSettingBoard;
        Chess chess;
        LoadPiecesCapture loadPiecesCaptured;
        string notation = "";
        Color colorTextNotation = Color.Black, colorNewMoveNotation = Color.Yellow;
        Color colorHightLightRowNotation = Color.RoyalBlue;
        int indexHistory = -1;
        int id_groupMatch = -1;
        tb_GroupMatch group;
        int stt = -1;
        string filterDetailEnd = null;
        PagedList pages;
        int count1Page = 3;
        int maxPageShow = 3;
        int currentPage = 1;
        tb_Account myAccount;
        List<tb_Match> matches;
        Color colorSelect = Color.LightBlue;
        Color colorNormal = Color.White;
        bool playing = false;
        int indexMove = 0;
        string[] moves;
        string[] times;
        bool youWhite;
        internal frmHistories(tb_Account myAccount)
        {
            InitializeComponent();
            this.myAccount = myAccount;
            pages = new PagedList(pnPages, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pages.sendPageNumber += receivePage;
            loadHistories(filterDetailEnd, currentPage);
            loadPiecesCaptured = new LoadPiecesCapture(false, pnTopCapturePieces, pnBotCapturePieces);
            loadChess();
            loadSettingBoard();
            loadDetailEnd();
            addToolTip();
            KeyPreview = true;
        }
        private void addToolTip()
        {
            ttPrintFile.SetToolTip(btnPrint, "Ctrl + P");
            ttRestart.SetToolTip(btnRestart, "Ctrl + 1");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
            ttPlayOrPause.SetToolTip(btnPlayAndPause, "Ctrl + Space");
            ttPrevMove.SetToolTip(btnPrev, "Ctr + A");
            ttNextMove.SetToolTip(btnPrev, "Ctr + D");
            ttFirstMove.SetToolTip(btnPrev, "Ctr + W");
            ttLastMove.SetToolTip(btnPrev, "Ctr + S");
        }

        private void frmHistories_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.Space:
                        btnPlayAndPause.PerformClick();
                        break;
                    case Keys.A:
                        btnBackMove.PerformClick();
                        break;
                    case Keys.D:
                        btnNextMove.PerformClick();
                        break;
                    case Keys.W:
                        btnGoToFirstMove.PerformClick();
                        break;
                    case Keys.S:
                        btnGoToEnd.PerformClick();
                        break;
                }
            }
        }


        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
            chess.freezeBoard();
        }

        public void loadChess()
        {
            chess = new Chess(pnChessBoard.Width, 20);
            chess.sendBackBoard += receiveBackBoard;
            chess.sendChangeTurn += receiveChangeTurn;
            chess.sendEndGame += receiveEndGame;
            chess.sendReset += receiveResetBoard;
            chess.sendReverse += receiveReverseBoard;
            chess.sendMove += receiveMove;
            chess.sendStrNotation += receiveStrNotation;
            chess.sendTime += receiveTime;
            chess.initBoard(pnChessBoard);
            chess.setBasicChess("", 0, false, false);
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
        }

        public void receiveChangeTurn(bool isWhiteColor)
        {
            lblTurn.Text = isWhiteColor ? "Lượt của cờ trắng" : "Lượt của cờ đen";
        }
        public void receiveResetBoard()
        {
            setStartGame();
        }


        private void setEndGame(string currentScore, string result, string detailResult)
        {
            lblSignEndGame.Text = "Kí hiệu: " + currentScore;
            lblTypeEndgame.Text = "Loại kết thúc: " + detailResult;
            lblResult.Text = "Kết quả: " + result;
        }
        private void setStartGame()
        {
            notation = "";
            loadPiecesCaptured.resetPieceCapture();
            resetEndGame();
            fpnNotations.Controls.Clear();
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
            string time = btnTopTime.Text;
            btnTopTime.Text = btnBotTime.Text;
            btnBotTime.Text = time;
            chess.freezeBoard();
        }

        public void receiveMove(string strMove, string namePromotion, bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            btnBackMove.Enabled = true;
            if (chess.canGoToFirstMove())
            {
                btnGoToFirstMove.Enabled = true;
            }
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
        private void receivePage(int page)
        {
            currentPage = page;
            loadHistories(filterDetailEnd, currentPage);
        }

        private void loadHistories(string filterDetailEnd, int page)
        {
            fpnMatches.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            matches = tb_Match.getHistories(startIndex, endIndex, myAccount.Id, filterDetailEnd);
            for (int i = 0; i < matches.Count; i++)
            {

                tb_GroupMatch group = tb_GroupMatch.getGroupMatch(matches[i].Id_groupMatch);
                tb_Account account_1 = tb_Account.getAccount(group.Id_account_1);
                tb_Account account_2 = tb_Account.getAccount(group.Id_account_2);
                Panel pn = new Panel()
                {
                    Size = new Size(329, 133),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Tag = (i, group, account_1, account_2),
                };

                if (matches[i].Id_groupMatch == id_groupMatch && matches[i].Stt == stt)
                {
                    pn.BackColor = colorSelect;
                } 
                else
                {
                    pn.BackColor = colorNormal;
                }
                pn.Click += selectHistory;



                Label lbl1 = new Label()
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopLeft,
                    Size = new Size(308, 28),
                    Location = new Point(5, 8),
                    ForeColor = Color.DarkCyan,
                    Text = account_1.Name + "#" + account_1.Id + " (" + (matches[i].Account_1_white ? matches[i].Elo_white : matches[i].Elo_black) + " elo) vs " + account_2.Name + "#" + account_2.Id + " (" + (matches[i].Account_1_white ? matches[i].Elo_black : matches[i].Elo_white) + " elo)",
                    Tag = (i, group, account_1, account_2),
                };
                pn.Controls.Add(lbl1);
                lbl1.Click += selectHistory;

                Label lbl2 = new Label()
                {
                    AutoSize = true,
                    Location = new Point(5, 44),
                    ForeColor = Color.DimGray,
                    Tag = (i, group, account_1, account_2),
                };

                if (matches[i].Result == tb_Match.resultWin)
                {
                    if (myAccount.Id == group.Id_account_1)
                    {
                        if (matches[i].Account_1_white)
                        {
                            lbl2.Text = EndGame.winning;
                        }
                        else
                        {
                            lbl2.Text = EndGame.losing;
                        }
                    }
                    else
                    {
                        if (matches[i].Account_1_white)
                        {
                            lbl2.Text = EndGame.losing;
                        }
                        else
                        {
                            lbl2.Text = EndGame.winning;
                        }
                    }
                }
                else if (matches[i].Result == tb_Match.resultLose)
                {
                    if (myAccount.Id == group.Id_account_1)
                    {
                        if (matches[i].Account_1_white)
                        {
                            lbl2.Text = EndGame.losing;
                        }
                        else
                        {
                            lbl2.Text = EndGame.winning;
                        }
                    }
                    else
                    {
                        if (matches[i].Account_1_white)
                        {
                            lbl2.Text = EndGame.winning;
                        }
                        else
                        {
                            lbl2.Text = EndGame.losing;
                        }
                    }
                }
                else
                {
                    lbl2.Text = EndGame.draw;
                }

                pn.Controls.Add(lbl2);
                lbl2.Click += selectHistory;

                Label lbl3 = new Label()
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopLeft,
                    Size = new Size(307, 34),
                    Location = new Point(6, 68),
                    ForeColor = Color.Black,
                    Text = matches[i].DetailResult,
                    Tag = (i, group, account_1, account_2),
                };
                pn.Controls.Add(lbl3);
                lbl3.Click += selectHistory;

                Label lbl4 = new Label()
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopLeft,
                    Size = new Size(76, 19),
                    Location = new Point(5, 105),
                    ForeColor = Color.Black,
                    Text = TypeGame.typeGames[group.IndexTypeGame] + ", " + Regime.regimes[group.IndexRegime].ToShortString(),
                    Tag = i,
                };
                pn.Controls.Add(lbl4);
                lbl4.Click += selectHistory;
                fpnMatches.Controls.Add(pn);
            }
            pages.initPagedList(tb_Match.getCountHistories(myAccount.Id, filterDetailEnd), currentPage);
        }

        private void selectHistory(object sender, EventArgs e)
        {
            btnPrint.Visible = btnRestart.Visible = true;
            timerPlaying.Stop();
            playing = false;
            indexMove = 0;
            btnPlayAndPause.Image = Image.FromFile("assets/imgs/play.png");
            var tag = ((int, tb_GroupMatch, tb_Account, tb_Account))((Control)sender).Tag;
            indexHistory = tag.Item1;
            group = tag.Item2;
            id_groupMatch = matches[indexHistory].Id_groupMatch;
            stt = matches[indexHistory].Stt;
            for (int i = 0; i < matches.Count; i++)
            {
                if (i == indexHistory)
                {
                    fpnMatches.Controls[i].BackColor = colorSelect;
                }
                else
                {
                    fpnMatches.Controls[i].BackColor = colorNormal;
                }
            }
            var tmp = Chess.convertFenToBoard(matches[indexHistory].Fen);
            chess.setChess(tag.Item2.IndexTypeGame, Regime.regimes[tag.Item2.IndexRegime].getTime(), Regime.regimes[tag.Item2.IndexRegime].time_bonus, chess.IsReverse, false, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
            chess.freezeBoard();
            resetEndGame();
            if (tag.Item2.Id_account_1 == myAccount.Id)
            {
                if (matches[indexHistory].Account_1_white)
                {
                    lblYou.Text = "Tài khoản của tôi: " + myAccount.Name + "#" + myAccount.Id + " (" + matches[indexHistory].Elo_white + " elo)";
                    lblOpponent.Text = "Đối thủ: " + tag.Item4.Name + "#" + tag.Item4.Id + " (" + matches[indexHistory].Elo_black + " elo)";
                    youWhite = true;
                }
                else
                {
                    lblYou.Text = "Tài khoản của tôi: " + myAccount.Name + "#" + myAccount.Id + " (" + matches[indexHistory].Elo_black + " elo)";
                    lblOpponent.Text = "Đối thủ: " + tag.Item4.Name + "#" + tag.Item4.Id + " (" + matches[indexHistory].Elo_white + " elo)";
                    youWhite = false;
                }
            }
            else
            {
                if (matches[indexHistory].Account_1_white)
                {
                    lblYou.Text = "Tài khoản của tôi: " + myAccount.Name + "#" + myAccount.Id + " (" + matches[indexHistory].Elo_black + " elo)";
                    lblOpponent.Text = "Đối thủ: " + tag.Item3.Name + "#" + tag.Item3.Id + " (" + matches[indexHistory].Elo_white + " elo)";
                    youWhite = true;
                }
                else
                {
                    lblYou.Text = "Tài khoản của tôi: " + myAccount.Name + "#" + myAccount.Id + " (" + matches[indexHistory].Elo_white + " elo)";
                    lblOpponent.Text = "Đối thủ: " + tag.Item3.Name + "#" + tag.Item3.Id + " (" + matches[indexHistory].Elo_black + " elo)";
                    youWhite = false;
                }
            }
            moves = matches[indexHistory].Move.Split('|');
            times = matches[indexHistory].TimeEveryMove.Split('|');
            btnPlayAndPause.Visible = btnNextMove.Visible = btnBackMove.Visible = btnGoToEnd.Visible = btnGoToFirstMove.Visible = true;
            checkAllowButton();
        }

        private void loadDetailEnd()
        {
            cbbFilterDetailEnd.DataSource = EndGame.typeEndGame;
            cbbFilterDetailEnd.SelectedIndex = 0;
        }

        private void cbFilterDetailEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFilterDetailEnd.Checked)
            {
                filterDetailEnd = cbbFilterDetailEnd.Text;
            }
            else
            {
                filterDetailEnd = null;
            }
            loadHistories(filterDetailEnd, currentPage);
        }

        private void cbbFilterDetailEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterDetailEnd.Checked)
            {
                filterDetailEnd = cbbFilterDetailEnd.Text;
                loadHistories(filterDetailEnd, currentPage);
            }
        }

        private void btnPlayAndPause_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                btnPlayAndPause.Image = Image.FromFile("assets/imgs/play.png");
                timerPlaying.Stop();
                ttPlayOrPause.ToolTipTitle = "Phát tự động trận đấu";
            }
            else
            {
                btnPlayAndPause.Image = Image.FromFile("assets/imgs/pause.png");
                timerPlaying.Start();
                ttPlayOrPause.ToolTipTitle = "Tạm dừng phát";
            }
            playing = !playing;
        }

        private void btnBackMove_Click(object sender, EventArgs e)
        {
            if (chess.backMove())
            {
                chess.freezeBoard();
                if ((indexMove - 1) % 2 == 0)
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
                indexMove--;
                checkAllowButton();
            }
        }

        private bool nextMove()
        {
            if (indexMove <= moves.Length - 2)
            {
                string[] tmp = moves[indexMove].Split(',');

                chess.moveByLocation(tmp[0], tmp[1]);
                
                chess.freezeBoard();
                indexMove++;

                checkAllowButton();
                return true;
            }
            return false;
        }

        private void btnNextMove_Click(object sender, EventArgs e)
        {
            nextMove();
        }

        private void btnGoToEnd_Click(object sender, EventArgs e)
        {
            while (indexMove <= moves.Length - 2)
            {
                string[] tmp = moves[indexMove].Split(',');
                chess.moveByLocation(tmp[0], tmp[1]);
                indexMove++;
            }

            checkAllowButton();
        }

        private void btnGoToFirstMove_Click(object sender, EventArgs e)
        {
            indexMove = 0;
            if (indexMove <= moves.Length - 2)
            {
                chess.restartBoard();
                string[] tmp = moves[indexMove].Split(',');
                chess.moveByLocation(tmp[0], tmp[1]);
                indexMove++; 
                while (fpnNotations.Controls.Count > 1)
                {
                    fpnNotations.Controls.RemoveAt(fpnNotations.Controls.Count - 1);
                }
                checkAllowButton();
            }
        }

        private void checkAllowButton()
        {
            int indexSet = indexMove - 1;
            if (indexSet >= 0)
            {
                if (chess.isWhiteTurn())
                {
                    if (chess.IsReverse)
                    {
                        btnBotTime.Text = times[indexSet];
                        if (indexSet != 0)
                        {
                            btnTopTime.Text = times[indexSet - 1];
                        }
                    }
                    else
                    {
                        btnTopTime.Text = times[indexSet];
                        if (indexSet != 0)
                        {
                            btnBotTime.Text = times[indexSet - 1];
                        }
                    }
                }
                else
                {
                    if (chess.IsReverse)
                    {
                        btnTopTime.Text = times[indexSet];
                        if (indexSet != 0)
                        {
                            btnBotTime.Text = times[indexSet - 1];
                        }
                    }
                    else
                    {
                        btnBotTime.Text = times[indexSet];
                        if (indexSet != 0)
                        {
                            btnTopTime.Text = times[indexSet - 1];
                        }
                    }
                }
            }

            if (indexMove == 0)
            {
                btnBackMove.Enabled = false;
            }
            else
            {
                btnBackMove.Enabled = true;
            }
            if (moves.Length >= 2 && indexMove != 1)
            {
                btnGoToFirstMove.Enabled = true;
            }
            else
            {
                btnGoToFirstMove.Enabled = false;
            }
            if (indexMove <= moves.Length - 2)
            {
                btnNextMove.Enabled = btnGoToEnd.Enabled = true;
                btnPlayAndPause.Enabled = true;
            }
            else
            {
                btnNextMove.Enabled = btnGoToEnd.Enabled = false;
                btnPlayAndPause.Enabled = false;
                if (!chess.IsEnd)
                {
                    string colorPiece;
                    string result;
                    if (matches[indexHistory].Result == tb_Match.resultWin)
                    {
                        colorPiece = Piece.ColorWhite;
                        if (youWhite)
                        {
                            result = EndGame.winning;
                        }
                        else
                        {
                            result = EndGame.losing;
                        }
                    }
                    else
                    {
                        colorPiece = Piece.ColorBlack;
                        if (matches[indexHistory].Result == tb_Match.resultLose)
                        {
                            if (youWhite)
                            {
                                result = EndGame.losing;
                            }
                            else
                            {
                                result = EndGame.winning;
                            }
                        }
                        else
                        {
                            result = EndGame.draw;
                        }
                    }
                    string score = EndGame.getScore(matches[indexHistory].DetailResult, colorPiece);
                    setEndGame(score, result, matches[indexHistory].DetailResult);
                }
            }
        }

        private void timerPlaying_Tick(object sender, EventArgs e)
        {
            if (playing)
            { 
                if (!nextMove())
                {
                    timerPlaying.Stop();
                    btnPlayAndPause.Image = Image.FromFile("assets/imgs/play.png");
                    playing = false;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint input = new frmPrint(chess, group.IndexTypeGame, group.IndexRegime, notation);
            input.ShowDialog();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            chess.restartBoard();
            chess.freezeBoard();
            indexMove = 0;
            checkAllowButton();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            pages.prevPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pages.nextPage();
        }
        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
        }
    }
}
