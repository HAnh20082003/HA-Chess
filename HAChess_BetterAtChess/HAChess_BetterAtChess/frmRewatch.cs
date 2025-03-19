using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public partial class frmRewatch : Form
    {
        InfoSettingBoard infoSettingBoard;
        Chess chess;
        LoadPiecesCapture loadPiecesCaptured;
        Color colorTextNotation = Color.Black, colorNewMoveNotation = Color.Yellow;
        Color colorHightLightRowNotation = Color.RoyalBlue;
        int indexFile = -1;
        PagedList pages;
        int count1Page = 5;
        int maxPageShow = 3;
        int currentPage = 1;
        Color colorSelect = Color.LightBlue;
        Color colorNormal = Color.White;
        string[] files;
        int indexMove = 0;
        string[] moves;
        (int, int, int, int, int[,], string[,], bool, int, int, string, string, string[], string) currentInfo;
        bool playing = false;
        public frmRewatch()
        {
            InitializeComponent();
            pages = new PagedList(pnPages, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pages.sendPageNumber += receivePage;
            loadFiles(currentPage, txtSearch.Text);
            loadPiecesCaptured = new LoadPiecesCapture(false, pnTopCapturePieces, pnBotCapturePieces);
            loadChess();
            loadSettingBoard();
            addToolTip();
            KeyPreview = true;
        }
        private void addToolTip()
        {
            ttRestart.SetToolTip(btnRestart, "Ctrl + 1");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
            ttPlayOrPause.SetToolTip(btnPlayAndPause, "Ctrl + Space");
            ttPrevMove.SetToolTip(btnPrev, "Ctr + A");
            ttNextMove.SetToolTip(btnPrev, "Ctr + D");
            ttFirstMove.SetToolTip(btnPrev, "Ctr + W");
            ttLastMove.SetToolTip(btnPrev, "Ctr + S");
        }

        private void frmRewatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
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
            chess.initBoard(pnChessBoard);
            chess.setBasicChess("", 0, false, false);
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
            }
            else
            {
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].Controls.Add(lbl);
                fpnNotations.Controls[fpnNotations.Controls.Count - 1].BackColor = colorHightLightRowNotation;
                lbl.Location = new Point(150, sizePanel.Height / 2 - lbl.Height / 2);

                fpnNotations.ScrollControlIntoView(fpnNotations.Controls[fpnNotations.Controls.Count - 1]);
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
            loadFiles(currentPage, txtSearch.Text);
        }
        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
            chess.freezeBoard();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
        }

        private void loadFiles(int page, string keyword)
        {
            fpnFiles.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            files = Directory.GetFiles("assets/saved/matches/").Where(n => n.Contains(".txt")).ToArray(); ;

            if (string.IsNullOrEmpty(keyword))
            {
                for (int i = startIndex; i <= (files.Length <= endIndex ? files.Length - 1 : endIndex); i++)
                {
                    var tmp = files[i].Split('/');
                    string name = tmp[tmp.Length - 1].Substring(0, tmp[tmp.Length - 1].LastIndexOf('.'));
                    Panel pn = new Panel()
                    {
                        Size = new Size(329, 68),
                        BorderStyle = BorderStyle.FixedSingle,
                        ForeColor = Color.DarkCyan,
                        Cursor = Cursors.Hand,
                        Tag = i,
                    };

                    if (i != indexFile)
                    {
                        pn.BackColor = colorNormal;
                    }
                    else
                    {
                        pn.BackColor = colorSelect;
                    }
                    pn.Click += selectFile;
                    fpnFiles.Controls.Add(pn);

                    Label lbl = new Label()
                    {
                        AutoSize = false,
                        TextAlign = ContentAlignment.TopLeft,
                        Size = new Size(308, 44),
                        Text = name,
                        Location = new Point(5, 8),
                        Tag = i,
                    };
                    pn.Controls.Add(lbl);
                    lbl.Click += selectFile;
                }
                pages.initPagedList(files.Length, currentPage);
            }
            else
            {
                int count = 0;
                int countFull = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    var tmp = files[i].Split('/');
                    string name = tmp[tmp.Length - 1].Substring(0, tmp[tmp.Length - 1].LastIndexOf('.'));
                    if (name.Contains(keyword))
                    {
                        countFull++;
                        if (count >= startIndex && count <= endIndex)
                        {
                            Panel pn = new Panel()
                            {
                                Size = new Size(329, 68),
                                BorderStyle = BorderStyle.FixedSingle,
                                ForeColor = Color.DarkCyan,
                                Cursor = Cursors.Hand,
                                Tag = i,
                            };

                            if (i != indexFile)
                            {
                                pn.BackColor = colorNormal;
                            }
                            else
                            {
                                pn.BackColor = colorSelect;
                            }
                            pn.Click += selectFile;
                            fpnFiles.Controls.Add(pn);

                            Label lbl = new Label()
                            {
                                AutoSize = false,
                                TextAlign = ContentAlignment.TopLeft,
                                Size = new Size(308, 44),
                                Text = name,
                                Location = new Point(5, 8),
                                Tag = i,
                            };
                            pn.Controls.Add(lbl);
                            lbl.Click += selectFile;
                        }
                        count++;
                    }

                }
                pages.initPagedList(countFull, currentPage);
            }
        }

        private void selectFile(object sender, EventArgs e)
        {
            indexFile = (int)((Control)sender).Tag;
            for (int i = 0;i < fpnFiles.Controls.Count; i++)
            {
                if ((int)fpnFiles.Controls[i].Tag == indexFile)
                {
                    fpnFiles.Controls[i].BackColor = colorSelect;
                }
                else
                {
                    fpnFiles.Controls[i].BackColor = colorNormal;
                }
            }
            currentInfo = Chess.getInfoBoardByReadFileTxt(files[indexFile]);
            chess.setChess(currentInfo.Item1, Regime.regimes[currentInfo.Item2].getTime(), Regime.regimes[currentInfo.Item2].time_bonus, chess.IsReverse, false, currentInfo.Item5, currentInfo.Item6, currentInfo.Item7, currentInfo.Item3, currentInfo.Item4, currentInfo.Item8, currentInfo.Item9);
            chess.freezeBoard();
            moves = currentInfo.Item12;
            indexMove = 0;
            btnRestart.Visible = true;
            btnPlayAndPause.Visible = btnNextMove.Visible = btnBackMove.Visible = btnGoToEnd.Visible = btnGoToFirstMove.Visible = true;
            checkAllowButton();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadFiles(currentPage, txtSearch.Text);
        }

        private void checkAllowButton()
        {
            if (indexMove == 0)
            {
                btnBackMove.Enabled = false;
            }
            else
            {
                btnBackMove.Enabled = true;
            }
            if (moves.Length >= 1 && indexMove != 1)
            {
                btnGoToFirstMove.Enabled = true;
            }
            else
            {
                btnGoToFirstMove.Enabled = false;
            }
            if (indexMove <= moves.Length - 1)
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
                    string score = EndGame.getScore(currentInfo.Item11, chess.isWhiteTurn() ? Piece.ColorBlack : Piece.ColorWhite);
                    setEndGame(score, currentInfo.Item10, currentInfo.Item11);
                }
            }
        }

        private void btnGoToFirstMove_Click(object sender, EventArgs e)
        {
            indexMove = 0;
            if (indexMove <= moves.Length - 1)
            {
                chess.restartBoard();
                string[] tmp = moves[indexMove].Split('.');
                chess.moveByLocation(tmp[0], tmp[1]);
                indexMove++;
                while (fpnNotations.Controls.Count > 1)
                {
                    fpnNotations.Controls.RemoveAt(fpnNotations.Controls.Count - 1);
                }
                checkAllowButton();
            }
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

        private void btnPlayAndPause_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                btnPlayAndPause.Image = Image.FromFile("assets/imgs/play.png");
                timerPlaying.Stop();
            }
            else
            {
                btnPlayAndPause.Image = Image.FromFile("assets/imgs/pause.png");
                timerPlaying.Start();
            }
            playing = !playing;
        }

        private bool nextMove()
        {
            if (indexMove <= moves.Length - 1)
            {
                string[] tmp = moves[indexMove].Split('.');
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
            while (indexMove <= moves.Length - 1)
            {
                string[] tmp = moves[indexMove].Split('.');
                chess.moveByLocation(tmp[0], tmp[1]);
                indexMove++;
            }

            checkAllowButton();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            chess.restartBoard();
            chess.freezeBoard();
            indexMove = 0;
            checkAllowButton();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadFiles(1, txtSearch.Text);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadFiles(1, txtSearch.Text);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            pages.prevPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pages.nextPage();
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
    }
}
