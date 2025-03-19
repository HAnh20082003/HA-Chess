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
    public partial class frmFreeRoom : Form
    {
        Chess chess;
        LoadPiecesCapture loadPiecesCaptured;
        InfoSettingBoard infoSettingBoard;
        Color colorTextNotation = Color.Black, colorNewMoveNotation = Color.Yellow;
        Color colorHightLightRowNotation = Color.RoyalBlue;
        Color colorTimePlay = Color.Crimson;
        Color colorTimeNormal = Color.DimGray; 
        string notation = "";
        tb_Account myAccount, opponentAccount;
        int indexTypeGame = 0;
        int indexRegime = -1;
        int indexChat = 0;
        int indexMove = 0;
        int timeShowRequestDraw = 0;
        int maxTimeShowRequestDraw = 30;
        tb_MyRoom myRoom;
        bool loadFen = true;
        PagedList pagesFriends;
        int count1Page = 3;
        int maxPageShow = 3;
        int currentPageFriends = 1;
        List<tb_Friend> friends;

        Color colorNormal = Color.White;
        internal frmFreeRoom(tb_Account myAccount)
        {
            InitializeComponent(); 
            this.myAccount = myAccount;
            loadPiecesCaptured = new LoadPiecesCapture(false, pnTopCapturePieces, pnBotCapturePieces);
            myRoom = tb_MyRoom.getRoom(myAccount.Id);
            loadChess();
            loadTypeGames();
            loadRegimes();
            loadSettingBoard();

            pagesFriends = new PagedList(pnPagesFriends, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pagesFriends.sendPageNumber += receivePageFriends;
            loadFriends(currentPageFriends);
            timerWaitAcceptOpponent.Start();
            addToolTip();
            KeyPreview = true;
        }
        private void addToolTip()
        {
            ttPrintFile.SetToolTip(btnPrint, "Ctrl + P");
            ttRestart.SetToolTip(btnRestart, "Ctrl + 1");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
            ttTypeGame.SetToolTip(cbbTypeGame, "Lựa chọn 1 trong nhiều chế độ chơi");
            ttRegime.SetToolTip(cbbRegimes, "Lựa chọn 1 trong nhiều chế độ thời gian");
        }

        private void frmFreeRoom_KeyDown(object sender, KeyEventArgs e)
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
                }
            }
        }

        private void receivePageFriends(int page)
        {
            currentPageFriends = page;
            loadFriends(page);
        }

        private void loadFriends(int page)
        {
            fpnFriends.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            friends = tb_Friend.getFriendsInvite(myAccount.Id, startIndex, endIndex);
            for (int i = 0; i < friends.Count; i++)
            {
                tb_Account account;
                if (friends[i].Id_account_1 == myAccount.Id)
                {
                    account = tb_Account.getAccount(friends[i].Id_account_2);
                }
                else
                {
                    account = tb_Account.getAccount(friends[i].Id_account_1);
                }
                tb_MyRoom room = tb_MyRoom.getRoom(account.Id);
                Panel pn = new Panel()
                {
                    Size = new Size(261, 93),
                    ForeColor = Color.DarkCyan,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = colorNormal,
                };

                Label lbl = new Label()
                {
                    Location = new Point(5, 10),
                    AutoSize = false,
                    Text = account.Name + "(#" + account.Id + ")",
                    Size = new Size(242, 32),
                    TextAlign = ContentAlignment.TopLeft,
                    Tag = (i, account),
                };
                pn.Controls.Add(lbl);
                Button btnAccept = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(9, 48),
                    Image = Image.FromFile("assets/imgs/accept.png"),
                    Tag = room,
                    Cursor = Cursors.Hand,
                };
                btnAccept.FlatAppearance.BorderSize = 0;
                btnAccept.Click += accept;
                pn.Controls.Add(btnAccept);

                Button btnKick = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(73, 48),
                    Image = Image.FromFile("assets/imgs/decline.png"),
                    Cursor = Cursors.Hand,
                    Tag = room,
                };
                btnKick.FlatAppearance.BorderSize = 0;
                btnKick.Click += deny;
                pn.Controls.Add(btnKick);
                fpnFriends.Controls.Add(pn);
            }
            int count = tb_Friend.getCountFriendsInvites(myAccount.Id);
            lblCountFriends.Text = "Số lượng: " + count;

            if ((count - 1) / count1Page + 1 < page)
            {
                if (currentPageFriends != 1)
                {
                    currentPageFriends--;
                }
            }

            pagesFriends.initPagedList(count, currentPageFriends);
        }

        private void accept(object sender, EventArgs e)
        {
            var opponentRoom = (tb_MyRoom)((Control)sender).Tag;
            opponentRoom.Opponent_accepted = true;
            opponentRoom.updateAccepted();
            opponentAccount = tb_Account.getAccount(opponentRoom.Id);
            outRoom();
            joinRoom(opponentRoom);
            loadFriends(currentPageFriends);
        }


        private void deny(object sender, EventArgs e)
        {
            var opponentRoom = (tb_MyRoom)((Control)sender).Tag;
            opponentRoom.Id_opponent = 0;
            opponentRoom.updateOpponent();
            loadFriends(currentPageFriends);
        }

        private void timerWaitAcceptOpponent_Tick(object sender, EventArgs e)
        {
            timerWaitAcceptOpponent.Stop();
            myRoom.reloadAccepted();
            if (myRoom.Opponent_accepted)
            {
                opponentAccount = tb_Account.getAccount(myRoom.Id_opponent);
                setUpStartGame();
                return;
            }
            timerWaitAcceptOpponent.Start();
        }


        private void setUpStartGame()
        {
            if (myRoom.Id != myAccount.Id)
            {
                Random rnd = new Random();
                int tmp = rnd.Next(0, 100);
                if (tmp % 2 == 0)
                {
                    myRoom.YouWhite = true;
                }
                else
                {
                    myRoom.YouWhite = false;
                }
                myRoom.updateTurn();
                indexTypeGame = myRoom.IndexTypeGame;
                indexRegime = myRoom.IndexRegime;
                if (indexTypeGame == 1)
                {
                    chess.setChess960("", 0, true, chess.IsReverse);
                    myRoom.Fen = chess.getCurrentFen();
                    myRoom.updateFen();
                }
                loadFen = false;
                cbbTypeGame.SelectedIndex = myRoom.IndexTypeGame;
                cbbRegimes.SelectedIndex = myRoom.IndexRegime;
                loadFen = true;
                loadFen = false;
                txtFen.Text = myRoom.Fen;
                loadFen = true;
            }
            else
            {
                myRoom.reloadTurn();
                myRoom.reloadFen();
                txtFen.Text = myRoom.Fen;
                loadFen = false;
                cbbTypeGame.SelectedIndex = myRoom.IndexTypeGame;
                cbbRegimes.SelectedIndex = myRoom.IndexRegime;
                indexTypeGame = myRoom.IndexTypeGame;
                indexRegime = myRoom.IndexRegime;
                loadFen = true;
                btnKickOpponent.Visible = true;
                timerOutRoom.Start();
            }
            indexMove = 0;
            indexChat = 0;
            txtFen.ReadOnly = true;
            string time = Regime.regimes[indexRegime].getTime();
            chess.updateTime(time, time, Regime.regimes[indexRegime].time_bonus);
            setTurnPlay();
            setTimerStartGame();
            pnChat.Visible = true;
            btnPrint.Enabled = true;
            btnResign.Visible = btnRequestDraw.Visible = true;
            cbbTypeGame.Enabled = cbbRegimes.Enabled = false;
            btnOutRoom.Visible = true;
            lblOpponent.Text = "Đối thủ: " + opponentAccount.Name + "#" + opponentAccount.Id;
        }

        private void joinRoom(tb_MyRoom opponentRoom)
        {
            myRoom = opponentRoom;
            opponentAccount = tb_Account.getAccount(opponentRoom.Id);
            setUpStartGame();
            timerBeKick.Start();
        }

        public void outRoom()
        {
            setDBOutRoom();
            if (myRoom.Id != myAccount.Id)
            {
                myRoom = tb_MyRoom.getRoom(myAccount.Id);
            }
            txtFen.ReadOnly = false;
            lblOpponent.Text = "Đối thủ";
            btnRestart.Visible = btnPrint.Visible = false;
            pnChat.Visible = pnPromotion.Visible = false;
            pnRequestDraw.Visible = false;
            btnResign.Visible = btnRequestDraw.Visible = false;
            opponentAccount = null;
            cbbTypeGame.Enabled = cbbRegimes.Enabled = true;
            btnKickOpponent.Visible = false;
            btnOutRoom.Visible = false;
            timerBeKick.Stop();
            timerChangeIndexTypeGameAndRegime.Stop();
            timerChat.Stop();
            timerMove.Stop();
            timerRequestDrawAndResign.Stop();
            timerShowRequestDraw.Stop();
            timerWaitAcceptOpponent.Stop();
            timerWaitRestart.Stop();
            timerOutRoom.Stop();
        }

        private void setDBOutRoom()
        {
            if (myRoom != null)
            {
                myRoom.Id_opponent = 0;
                myRoom.Opponent_accepted = false;
                myRoom.StartGame = false;
                myRoom.Move = "";
                myRoom.TimeEveryMove = "";
                myRoom.Chat = "";
                myRoom.RequestDraw_you = myRoom.RequestDraw_opponent = false;
                myRoom.Resign_You = myRoom.Resign_Opponent = false;
                myRoom.Opponent_Out = false;
                myRoom.RestartGame = false;
                myRoom.updateOpponent();
                myRoom.updateAccepted();
                myRoom.updateStartGame();
                myRoom.updateMoveAndTimeEveryMove();
                myRoom.updateChat();
                myRoom.updateRequestDrawAndRegisn();
                myRoom.updateOpponentOut();
                myRoom.updateRestartGame();
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
            chess.sendTime += receiveTime;
            chess.sendUnPromotion += receiveUnPromotion;
            chess.sendResign += receiveResign;
            chess.sendDraw += receiveDraw;
            chess.sendTimeOut += receiveTimeOut;
            chess.initBoard(pnChessBoard);
        }
        public void receiveBackBoard(bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            btnResign.Enabled = btnRequestDraw.Enabled = true;
        }

        public void receiveChangeTurn(bool isWhiteColor)
        {
            lblTurn.Text = isWhiteColor ? "Lượt của cờ trắng" : "Lượt của cờ đen";
            pnPromotion.Visible = false;
            if ((isWhiteColor && chess.IsReverse) || (!isWhiteColor && !chess.IsReverse))
            {
                btnTopTime.ForeColor = colorTimePlay;
                btnBotTime.ForeColor = colorTimeNormal;
            }
            else
            {
                btnTopTime.ForeColor = colorTimeNormal;
                btnBotTime.ForeColor = colorTimePlay;
            }
        }
        public void receiveResetBoard()
        {
            setStartGame();
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

        private void receiveResign(bool isWhiteTurn)
        {

        }

        private void receiveDraw()
        {

        }

        private void receiveTimeOut(bool isWhiteTurn)
        {

        }

        private void setEndGame(string currentScore, string result, string detailResult)
        {
            btnResign.Enabled = btnRequestDraw.Enabled = false;
            lblSignEndGame.Text = "Kí hiệu: " + currentScore;
            lblTypeEndgame.Text = "Loại kết thúc: " + detailResult;
            lblResult.Text = "Kết quả: " + result;
            pnPromotion.Visible = false;
            myRoom.StartGame = false;
            if (myRoom.Id == myAccount.Id)
            {
                btnRestart.Visible = true;
                myRoom.updateStartGame();
                loadFen = true;
                txtFen.ReadOnly = false;
                cbbTypeGame.Enabled = cbbRegimes.Enabled = true;
            }
            else
            {
                timerWaitRestart.Start();
                timerChangeIndexTypeGameAndRegime.Start();
            }
            pnRequestDraw.Visible = false;
            timerShowRequestDraw.Stop();
        }

        private void setStartGame()
        {
            btnResign.Enabled = btnRequestDraw.Enabled = true;
            notation = "";
            loadPiecesCaptured.resetPieceCapture();
            resetEndGame();
            fpnNotations.Controls.Clear();
            pnPromotion.Visible = false;
            lblStartTurn.Text = "Lược đầu: trắng";
            btnRestart.Visible = false;
            pnRequestDraw.Visible = false;
            timerShowRequestDraw.Stop();
            btnTopTime.Text = btnBotTime.Text = "0:00";

            myRoom.StartGame = true;
            if (myRoom.Id == myAccount.Id)
            {
                myRoom.updateStartGame();
            }
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
            if (opponentAccount != null)
            {
                setTurnPlay();
            }
            else
            {
                chess.freezeBoard();
            }
        }
        private void setTurnPlay()
        {
            if (myRoom.Id == myAccount.Id)
            {
                if (myRoom.YouWhite != chess.isWhiteTurn())
                {
                    chess.freezeBoard();
                    timerMove.Start();
                }
            }
            else
            {
                if (myRoom.YouWhite == chess.isWhiteTurn())
                {
                    chess.freezeBoard();
                    timerMove.Start();
                }
            }
        }

        public void receiveMove(string strMove, string namePromotion, bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            pnPromotion.Visible = false;

            myRoom.Move += strMove + "," + namePromotion + "|";
            myRoom.TimeEveryMove += (((isWhiteTurn && chess.IsReverse) || (!isWhiteTurn && !chess.IsReverse)) ? btnTopTime.Text : btnBotTime.Text) + "|";

            myRoom.updateMoveAndTimeEveryMove();
            indexMove++;
            setTurnPlay();
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

        private void cbbTypeGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTypeGame();
        }

        private void setTypeGame(bool set = true)
        {
            if (!loadFen)
            {
                return;
            }
            indexTypeGame = cbbTypeGame.SelectedIndex;
            myRoom.IndexTypeGame = indexTypeGame;
            myRoom.updateIndexTypeGame();
            if (indexTypeGame == 2)
            {
                var tmp = Chess.convertFenToBoard(myRoom.Fen);
                if (tmp.Item1 != null && set)
                {
                    chess.setChess(indexTypeGame, "", 0, chess.IsReverse, true, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
                }
                else
                {
                    cbbTypeGame.SelectedIndex = 0;
                }
            }
            else
            {
                if (indexTypeGame == 1 && myRoom.Id_opponent != 0)
                {
                    if (myRoom.Id == myAccount.Id)
                    {
                        var tmp = Chess.convertFenToBoard(myRoom.Fen);
                        if (tmp.Item1 != null && set)
                        {
                            chess.setChess(indexTypeGame, "", 0, chess.IsReverse, true, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
                        }
                    }
                    else
                    {
                        if (set)
                        {
                            chess.setChess(indexTypeGame, chess.IsReverse, true);
                        }
                    }
                }
                else
                {
                    if (set)
                    {
                        chess.setChess(indexTypeGame, chess.IsReverse, true);
                    }
                }
            }
            chess.freezeBoard();
            loadFen = false;
            txtFen.Text = chess.getCurrentFen();
            loadFen = true;
        }

        private void cbbRegimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexRegime = cbbRegimes.SelectedIndex;
            myRoom.IndexRegime = indexRegime;
            myRoom.updateIndexRegime();
            string startTime = Regime.regimes[indexRegime].getTime();
            chess.updateTime(startTime, startTime, Regime.regimes[indexRegime].time_bonus);
        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            timerMove.Stop();
            myRoom.reloadMoveAndTimeEveryMove();
            string[] move = myRoom.Move.Split('|');
            string[] timeEveryMove = myRoom.TimeEveryMove.Split('|');
            if (indexMove == move.Length - 2)
            {
                string[] tmp = move[move.Length - 2].Split(',');
                chess.moveByLocation(tmp[0], tmp[1], false);
                indexMove++;
                bool whiteTurn = chess.isWhiteTurn();
                if ((chess.IsReverse && whiteTurn) || (!chess.IsReverse && !whiteTurn))
                {
                    btnTopTime.Text = timeEveryMove[move.Length - 2];
                }
                else
                {
                    btnBotTime.Text = timeEveryMove[move.Length - 2];
                }
            }
            else
            {
                timerMove.Start();
            }
        }

        private void timerChat_Tick(object sender, EventArgs e)
        {
            timerChat.Stop();
            myRoom.reloadChat();
            string[] chat = myRoom.Chat.Split('|');
            if (indexChat == chat.Length - 2)
            {
                string[] tmp = chat[chat.Length - 2].Split(',');
                showMessage(tmp[0], tmp[1], false);
            }
            timerChat.Start();
        }

        private void timerRequestDrawAndResign_Tick(object sender, EventArgs e)
        {
            timerRequestDrawAndResign.Stop();
            myRoom.reloadRequestDrawAndResign();
            if (myRoom.Id == myAccount.Id)
            {
                if (myRoom.Resign_Opponent)
                {
                    if (myRoom.YouWhite)
                    {
                        chess.resign(false, false);
                    }
                    else
                    {
                        chess.resign(true, false);
                    }
                    return;
                }
            }
            else
            {
                if (myRoom.Resign_You)
                {
                    if (myRoom.YouWhite)
                    {
                        chess.resign(true, false);
                    }
                    else
                    {
                        chess.resign(false, false);
                    }
                    return;
                }
            }
            
            if (myRoom.RequestDraw_you && myRoom.RequestDraw_opponent)
            {
                chess.draw();
                return;
            }
            if (pnRequestDraw.Visible == false)
            {
                if (myRoom.Id == myAccount.Id)
                {
                    if (myRoom.RequestDraw_opponent)
                    {
                        pnRequestDraw.Visible = true;
                        timeShowRequestDraw = maxTimeShowRequestDraw;
                        lblTimeShowRequestDraw.Text = Time.convertRealTimeToStr(timeShowRequestDraw);
                        timerShowRequestDraw.Start();
                    }
                }
                else
                {
                    if (myRoom.RequestDraw_you)
                    {
                        pnRequestDraw.Visible = true;
                        timeShowRequestDraw = maxTimeShowRequestDraw;
                        lblTimeShowRequestDraw.Text = Time.convertRealTimeToStr(timeShowRequestDraw);
                        timerShowRequestDraw.Start();
                    }
                }
            }
            timerRequestDrawAndResign.Start();
        }

        private void timerShowRequestDraw_Tick(object sender, EventArgs e)
        {
            timeShowRequestDraw--;
            lblTimeShowRequestDraw.Text = Time.convertRealTimeToStr(timeShowRequestDraw);
            if (timeShowRequestDraw == 0)
            {
                timerShowRequestDraw.Stop();
                pnRequestDraw.Visible = false;
                if (myRoom.Id == myAccount.Id)
                {
                    myRoom.RequestDraw_opponent = false;
                }
                else
                {
                    myRoom.RequestDraw_you = false;
                }
                myRoom.updateRequestDrawAndRegisn();
            }
        }

        private void showMessage(string name, string content, bool you)
        {
            string text;
            if (!string.IsNullOrEmpty(rtxChat.Text))
            {
                rtxChat.AppendText(Environment.NewLine);
            }
            Color color;
            if (you)
            {
                text = "Bạn:";
                color = Color.Navy;
            }
            else
            {
                text = name + ":";
                color = Color.Crimson;
            }
            rtxChat.SelectionColor = color;
            rtxChat.AppendText(text);
            rtxChat.SelectionColor = Color.Black;
            rtxChat.AppendText(" " + content);
            indexChat++;
        }

        private void loadTypeGames()
        {
            for (int i = 0; i < TypeGame.typeGames.Count; i++)
            {
                cbbTypeGame.Items.Add(TypeGame.typeGames[i]);
            }
            cbbTypeGame.Items.Add("Không xác định");
            cbbTypeGame.SelectedIndex = myRoom.IndexTypeGame;
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            timerShowRequestDraw.Stop();
            pnRequestDraw.Visible = false;
            if (myRoom.Id == myAccount.Id)
            {
                chess.resign(myRoom.YouWhite);
                myRoom.Resign_You = true;
                myRoom.RequestDraw_opponent = false;
                myRoom.updateRequestDrawAndRegisn();
            }
            else
            {
                chess.resign(!myRoom.YouWhite);
                myRoom.Resign_Opponent = true;
                myRoom.RequestDraw_you = false;
                myRoom.updateRequestDrawAndRegisn();
            }
        }
        private void draw()
        {
            if (myRoom.Id == myAccount.Id)
            {
                myRoom.RequestDraw_you = true;
            }
            else
            {
                myRoom.RequestDraw_opponent = true;
            }
            myRoom.updateRequestDrawAndRegisn();
            chess.draw();
        }

        private void btnRequestDraw_Click(object sender, EventArgs e)
        {
            if (pnRequestDraw.Visible)
            {
                draw();
                return;
            }
            if (myRoom.Id == myAccount.Id)
            {
                myRoom.RequestDraw_you = true;
            }
            else
            {
                myRoom.RequestDraw_opponent = true;
            }
            myRoom.updateRequestDrawAndRegisn();
        }

        private void btnAcceptDraw_Click(object sender, EventArgs e)
        {
            draw();
        }

        private void btnDeclineDraw_Click(object sender, EventArgs e)
        {
            if (myRoom.Id == myAccount.Id)
            {
                myRoom.RequestDraw_opponent = false;
            }
            else
            {
                myRoom.RequestDraw_you = false;
            }
            myRoom.updateRequestDrawAndRegisn();
            pnRequestDraw.Visible = false;
            timerShowRequestDraw.Stop();
        }

        private void txtFen_TextChanged(object sender, EventArgs e)
        {
            if (!loadFen)
            {
                return;
            }
            myRoom.Fen = txtFen.Text;
            myRoom.updateFen();
            var tmp = Chess.convertFenToBoard(myRoom.Fen);
            if (tmp.Item1 != null)
            {
                chess.setChess(indexTypeGame, "", 0, chess.IsReverse, true, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
            }
            loadFen = false;
            cbbTypeGame.SelectedIndex = 2;
            loadFen = true;
        }

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!e.Shift)
                {
                    e.SuppressKeyPress = true;
                    sendMessage();
                }
            }
        }
        private void sendMessage()
        {
            if (string.IsNullOrEmpty(txtChat.Text))
            {
                return;
            }
            //gửi tin nhắn
            myRoom.Chat += myAccount.getName() + "," + txtChat.Text + "|";
            showMessage("", txtChat.Text, true);
            txtChat.Clear();
            myRoom.updateChat();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint input = new frmPrint(chess, indexTypeGame, indexRegime, notation);
            input.ShowDialog();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            myRoom.Move = "";
            myRoom.RequestDraw_opponent = myRoom.RequestDraw_you = myRoom.Resign_You = myRoom.Resign_Opponent = false;
            myRoom.TimeEveryMove = "";
            myRoom.YouWhite = !myRoom.YouWhite;
            txtFen.ReadOnly = true;
            myRoom.updateTurn();
            myRoom.updateMoveAndTimeEveryMove();
            myRoom.updateRequestDrawAndRegisn();
            if (indexTypeGame == 1)
            {
                chess.setChess960("", 0, true, chess.IsReverse);
                myRoom.Fen = chess.getCurrentFen();
                myRoom.updateFen();
            }
            else
            {
                chess.restartBoard();
            }
            loadFen = false;
            txtFen.Text = myRoom.Fen;
            loadFen = false;
            myRoom.RestartGame = true;
            myRoom.updateRestartGame();
            string time = Regime.regimes[indexRegime].getTime();
            chess.updateTime(time, time, Regime.regimes[indexRegime].time_bonus);
            indexMove = 0;
            setTurnPlay();
            setTimerStartGame();
            cbbTypeGame.Enabled = cbbRegimes.Enabled = false;
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
        }

        private void btnOutRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn rời phòng của " + opponentAccount.Name + " không?", "Hỏi lại", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }
            outRoom();
            chess.restartBoard();
            chess.freezeBoard();
        }

        private void txtSearchOpponent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                invitePlayer(txtSearchOpponent.Text);
            }
        }

        private void btnSearchOpponent_Click(object sender, EventArgs e)
        {
            invitePlayer(txtSearchOpponent.Text);
        }

        private void invitePlayer(string keyword)
        {
            tb_Account account = tb_Account.getAccountSearch(myAccount.Id, keyword);
            if (account != null)
            {
                myRoom.Id_opponent = account.Id;
                myRoom.updateOpponent();
                myRoom.Opponent_accepted = false;
                myRoom.updateAccepted();
                timerWaitAcceptOpponent.Start();
                MessageBox.Show("Đã gửi lời mời tới " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người chơi!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReloadFriends_Click(object sender, EventArgs e)
        {
            loadFriends(currentPageFriends);
        }
        private void timerBeKick_Tick(object sender, EventArgs e)
        {
            timerBeKick.Stop();
            myRoom.reloadOpponent();
            if (myRoom.Id_opponent == 0)
            {
                outRoom();
                MessageBox.Show("Bạn đã bị đá khỏi phòng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            timerBeKick.Start();
        }


        private void timerWaitRestart_Tick(object sender, EventArgs e)
        {
            timerWaitRestart.Stop();
            myRoom.reloadRestart();
            if (myRoom.RestartGame)
            {
                timerChangeIndexTypeGameAndRegime.Stop();
                myRoom.Move = "";
                myRoom.TimeEveryMove = "";
                myRoom.RequestDraw_opponent = myRoom.RequestDraw_you = myRoom.Resign_Opponent = myRoom.Resign_You = false;
                myRoom.YouWhite = !myRoom.YouWhite;
                myRoom.RestartGame = false;
                myRoom.updateRestartGame();
                myRoom.reloadFen();
                txtFen.Text = myRoom.Fen;
                txtFen.ReadOnly = true;
                string time = Regime.regimes[indexRegime].getTime();
                chess.updateTime(time, time, Regime.regimes[indexRegime].time_bonus);
                indexMove = 0;
                setTurnPlay();
                setTimerStartGame();
                return;
            }
            timerWaitRestart.Start();
        }

        private void setTimerStartGame()
        {
            timerChat.Start();
            timerRequestDrawAndResign.Start();
            timerShowRequestDraw.Start();
        }

        private void timerChangeIndexTypeGameAndRegime_Tick(object sender, EventArgs e)
        {
            timerChangeIndexTypeGameAndRegime.Stop();
            myRoom.reloadIndexTypeGameAndRegime();
            myRoom.reloadFen();
            if (myRoom.Fen != txtFen.Text)
            {
                txtFen.Text = myRoom.Fen;
            }
            if (myRoom.IndexTypeGame != indexTypeGame || myRoom.IndexRegime != indexRegime)
            {
                loadFen = false;
                cbbTypeGame.SelectedIndex = myRoom.IndexTypeGame;
                cbbRegimes.SelectedIndex = myRoom.IndexRegime;
                indexTypeGame = myRoom.IndexTypeGame;
                indexRegime = myRoom.IndexRegime;
                loadFen = true;
                chess.freezeBoard();
            }
            timerChangeIndexTypeGameAndRegime.Start();
        }

        private void btnKickOpponent_Click(object sender, EventArgs e)
        {
            outRoom();
        }

        private void timerOutRoom_Tick(object sender, EventArgs e)
        {
            timerOutRoom.Stop();
            myRoom.reloadOpponent();
            if (myRoom.Id_opponent == 0)
            {
                outRoom();
                return;
            }
            timerOutRoom.Start();
        }

        private void loadRegimes()
        {
            for (int i = 0; i < Regime.regimes.Count; i++)
            {
                cbbRegimes.Items.Add(Regime.regimes[i].ToShortString());
            }
            cbbRegimes.SelectedIndex = myRoom.IndexRegime;
        }
        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
            chess.freezeBoard();
        }

    }
}
