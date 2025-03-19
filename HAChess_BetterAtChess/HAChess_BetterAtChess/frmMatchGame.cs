using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public partial class frmMatchGame : Form
    {
        Chess chess;
        LoadPiecesCapture loadPiecesCaptured;
        InfoSettingBoard infoSettingBoard;
        Color colorTextNotation = Color.Black, colorNewMoveNotation = Color.Yellow;
        Color colorHightLightRowNotation = Color.RoyalBlue;
        Color colorTimePlay = Color.Crimson;
        Color colorTimeNormal = Color.DimGray;
        string notation = "";
        int timeFinding = 0;
        tb_Account myAccount, opponentAccount;
        int indexTypeGame = 0;
        int indexRegime = -1;
        int indexChat = 0;
        int indexMove = 0;
        tb_Elo myElo, opponentElo;
        tb_Match match;
        bool youWhite;
        int timeShowRequestDraw = 0;
        int maxTimeShowRequestDraw = 30;
        int timeOutMatch = 0;
        int maxTimeOutMatch = 30;
        tb_GroupMatch group;
        public bool inMatch = false;
        public bool finding = false;
        internal frmMatchGame(tb_Account myAccount)
        {
            InitializeComponent();
            this.myAccount = myAccount;
            lblYou.Text = "Tài khoản của tôi: " + myAccount.getName(); 
            loadPiecesCaptured = new LoadPiecesCapture(false, pnTopCapturePieces, pnBotCapturePieces);
            loadChess();
            loadTypeGames();
            loadRegimes();
            myElo = tb_Elo.getElo(myAccount.Id, indexTypeGame, Regime.regimes[indexRegime].indexName);
            loadSettingBoard();
            addToolTip();
            KeyPreview = true;

            match = tb_Match.getNewMatchByAccount(myAccount.Id);
            if (match != null && match.Result == tb_Match.resultDefault)
            {
                string[] moves = match.Move.Split('|');
                for (int i = 0; i < moves.Length - 1; i++)
                {
                    string[] tmp = moves[i].Split(',');
                    chess.moveByLocation(tmp[0], tmp[1], false);
                }
                string[] chats = match.Chat.Split('|');
                for (int i = 0; i < chats.Length - 1; i++)
                {
                    string[] tmp = chats[i].Split(',');
                    if (tmp[0] == myAccount.getName())
                    {
                        showMessage("Bạn: ", tmp[1], true);
                    }
                    else
                    {
                        showMessage(tmp[0], tmp[1], false);
                    }
                }

                btnStartFind.Enabled = false;
                group = tb_GroupMatch.getGroupMatch(match.Id_groupMatch);
                int id_opponent;
                if (group.Id_account_1 == myAccount.Id)
                {
                    id_opponent = group.Id_account_2;
                }
                else
                {
                    id_opponent = group.Id_account_1;
                }
                opponentAccount = tb_Account.getAccount(id_opponent);
                opponentElo = tb_Elo.getElo(id_opponent, indexTypeGame, Regime.regimes[indexRegime].indexName);
                joinMatch(group, match, id_opponent);
                indexMove = moves.Length - 1;
                indexChat = chats.Length - 1;
                if (youWhite)
                {
                    match.W_out = false;
                }
                else
                {
                    match.B_out = false;
                }
                match.updateOut();
                string[] timeEveryMoves = match.TimeEveryMove.Split('|');
                if (timeEveryMoves.Length != 1)
                {
                    if (chess.isWhiteTurn())
                    {
                        if (chess.IsReverse)
                        {
                            btnBotTime.Text = timeEveryMoves[timeEveryMoves.Length - 2];
                            if (timeEveryMoves.Length != 2)
                            {
                                btnTopTime.Text = timeEveryMoves[timeEveryMoves.Length - 3];
                            }
                        }
                        else
                        {
                            btnTopTime.Text = timeEveryMoves[timeEveryMoves.Length - 2];
                            if (timeEveryMoves.Length != 2)
                            {
                                btnBotTime.Text = timeEveryMoves[timeEveryMoves.Length - 3];
                            }
                        }
                    }
                    else
                    {
                        if (chess.IsReverse)
                        {
                            btnTopTime.Text = timeEveryMoves[timeEveryMoves.Length - 2];
                            if (timeEveryMoves.Length != 2)
                            {
                                btnBotTime.Text = timeEveryMoves[timeEveryMoves.Length - 3];
                            }
                        }
                        else
                        {
                            btnBotTime.Text = timeEveryMoves[timeEveryMoves.Length - 2];
                            if (timeEveryMoves.Length != 2)
                            {
                                btnTopTime.Text = timeEveryMoves[timeEveryMoves.Length - 3];
                            }
                        }
                    }
                }
            }
        }

        public bool inMatchGame()
        {
            return inMatch;
        }
        public bool isFinding()
        {
            return finding;
        }
        private void addToolTip()
        {
            ttPrintFile.SetToolTip(btnPrint, "Ctrl + P");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
        }

        private void frmMatchGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.P:
                        btnPrint.PerformClick();
                        break;
                    case Keys.D2:
                        btnReverse.PerformClick();
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
            chess.sendTime += receiveTime;
            chess.sendUnPromotion += receiveUnPromotion;
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

        private void setEndGame(string currentScore, string result, string detailResult)
        {
            btnResign.Enabled = btnRequestDraw.Enabled = false;
            lblSignEndGame.Text = "Kí hiệu: " + currentScore;
            lblTypeEndgame.Text = "Loại kết thúc: " + detailResult;
            pnPromotion.Visible = false;
            btnNewGame.Visible = btnRematch.Visible = true;
            pnRequestDraw.Visible = false;
            timerShowRequestDraw.Stop();
            timerOutMatch.Stop();
            match.DetailResult = detailResult;
            match.Notation = notation;
            if (currentScore == EndGame.winningResult)
            {
                match.Result = tb_Match.resultWin;
                if (youWhite)
                {
                    myElo.Value += match.BonusEloWin;
                    opponentElo.Value -= match.BonusEloWin;
                    lblResult.Text = "Kết quả: " + EndGame.winning;
                }
                else
                {
                    myElo.Value -= match.BonusEloWin;
                    opponentElo.Value += match.BonusEloWin;
                    lblResult.Text = "Kết quả: " + EndGame.losing;
                }
            }
            else if (currentScore == EndGame.drawResult)
            {
                match.Result = tb_Match.resultDraw;
                if (myElo.Value > opponentElo.Value)
                {
                    myElo.Value -= match.BonusEloDraw;
                    opponentElo.Value += match.BonusEloDraw;
                }
                else
                {
                    myElo.Value += match.BonusEloDraw;
                    opponentElo.Value -= match.BonusEloDraw;
                }
                lblResult.Text = "Kết quả: " + EndGame.draw;
            }
            else
            {
                match.Result = tb_Match.resultLose;
                if (youWhite)
                {
                    myElo.Value -= match.BonusEloWin;
                    opponentElo.Value += match.BonusEloWin;
                    lblResult.Text = "Kết quả: " + EndGame.losing;
                }
                else
                {
                    myElo.Value += match.BonusEloWin;
                    opponentElo.Value -= match.BonusEloWin;
                    lblResult.Text = "Kết quả: " + EndGame.winning;
                }
            }
            match.updateResult();
            myElo.updateElo();
            timerRematch.Start();
            inMatch = false;
            lblOutMatch.Visible = false;
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
            btnNewGame.Visible = btnRematch.Visible = false;
            pnRequestDraw.Visible = false;
            timerShowRequestDraw.Stop();
            btnTopTime.Text = btnBotTime.Text = "0:00";
            timerRematch.Stop();
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

        public void receiveMove(string strMove, string namePromotion, bool isWhiteTurn)
        {
            loadPiecesCaptured.updatePieceCapture(isWhiteTurn, chess);
            pnPromotion.Visible = false;

            match.Move += strMove + "," + namePromotion + "|";
            match.TimeEveryMove += (((isWhiteTurn && chess.IsReverse) || (!isWhiteTurn && !chess.IsReverse)) ? btnTopTime.Text : btnBotTime.Text) + "|";
            match.CurrentTurn = !isWhiteTurn;
            match.updateMoveAndTimeEveryMove();
            match.updateTurn();
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
        private void loadTypeGames()
        {
            for (int i = 0; i < TypeGame.typeGames.Count; i++)
            {
                cbbTypeGame.Items.Add(TypeGame.typeGames[i]);
            }
            cbbTypeGame.SelectedIndex = 0;
        }
        private void loadRegimes()
        {
            for (int i = 0; i < Regime.regimes.Count; i++)
            {
                cbbRegimes.Items.Add(Regime.regimes[i].ToShortString());
            }
            cbbRegimes.SelectedIndex = 0;
        }
        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
            chess.freezeBoard();
        }


        private void btnStartFind_Click(object sender, EventArgs e)
        {
            find();
        }

        private void btnStopFind_Click(object sender, EventArgs e)
        {
            stopFinding();
        }

        private void timerFindingGame_Tick(object sender, EventArgs e)
        {
            timeFinding++;
            lblTimeFinding.Text = Time.convertRealTimeToStr(timeFinding);
            myAccount.reloadMatchAccount();
            if (myAccount.Id_matchAccount != 0)
            {
                showMatch(myAccount.Id_matchAccount);
                hideFinding();
            }
            else
            {
                tb_Account account = myAccount.getAccountsMatchYou();
                if (account != null)
                {
                    showMatch(account.Id);
                    myAccount.updateMatchAccount(account.Id);
                    account.updateMatchAccount(myAccount.Id);
                    hideFinding();
                }
            }
        }

        private void find()
        {
            lblTimeFinding.Visible = true;
            btnStartFind.Enabled = false;
            btnStopFind.Visible = true;
            cbbTypeGame.Enabled = cbbRegimes.Enabled = false;
            myAccount.updateStatus(-2);
            timerFindingGame.Start();
            finding = true;
        }
        
        private void stopFinding()
        {
            timerFindingGame.Stop();
            cbbTypeGame.Enabled = cbbRegimes.Enabled = true;
            lblTimeFinding.Text = "0:00";
            lblTimeFinding.Visible = false;
            btnStartFind.Enabled = true;
            btnStopFind.Visible = false;
            timeFinding = 0;
            finding = false;
            myAccount.updateStatus(1);
        }
        private void hideFinding()
        {
            timerFindingGame.Stop();
            cbbTypeGame.Enabled = cbbRegimes.Enabled = false;
            lblTimeFinding.Text = "0:00";
            lblTimeFinding.Visible = false;
            btnStartFind.Enabled = false;
            btnStopFind.Visible = false;
            timeFinding = 0;
            finding = false;
        }

        private void cbbTypeGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexTypeGame = cbbTypeGame.SelectedIndex;
            myAccount.updateIndexTypeGame(indexTypeGame);
            chess.setChess(indexTypeGame, chess.IsReverse, true);
            chess.freezeBoard();
        }
        private void cbbRegimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexRegime = cbbRegimes.SelectedIndex;
            myAccount.updateIndexNameRegime(Regime.regimes[indexRegime].indexName);
            string startTime = Regime.regimes[indexRegime].getTime();
            chess.updateTime(startTime, startTime, Regime.regimes[indexRegime].time_bonus);
        }

        private void joinMatch(tb_GroupMatch group, tb_Match match, int id_opponent)
        {
            this.group = group;
            this.match = match;
            indexMove = 0;
            indexChat = 0; 
            myAccount.updateStatus(-1);
            if ((match.Account_1_white && group.Id_account_1 == myAccount.Id) || (!match.Account_1_white && group.Id_account_2 == myAccount.Id))
            {
                youWhite = true;
            }
            else
            {
                youWhite = false;
            }
            chess.reverseBoard(!youWhite);
            string time = Regime.regimes[indexRegime].getTime();
            chess.updateTime(time, time, Regime.regimes[indexRegime].time_bonus);
            setTurnPlay();
            timerChat.Start();
            timerRequestDrawAndResign.Start();
            timerOutMatch.Start();
            cbbTypeGame.Enabled = cbbRegimes.Enabled = false;
            rtxChat.Clear();
            txtChat.Clear();
            btnOutGame.Visible = true;
            btnResign.Visible = btnRequestDraw.Visible = true;
            pnChat.Visible = true;
            btnPrint.Visible = true;
            inMatch = true;
            finding = false;

            lblYou.Text = "Tài khoản của tôi: " + myAccount.Name + " cầm quân " + (youWhite ? "trắng" : "đen") + " (" + myElo.Value + " elo)";
            lblOpponent.Text = "Đối thủ của tôi: " + opponentAccount.Name + " cầm quân " + (youWhite ? "đen" : "trắng") + " (" + opponentElo.Value + " elo)";


            tb_Friend friend = tb_Friend.getFriend(myAccount.Id, opponentAccount.Id);
            if (friend == null || ((friend.Id_account_1 == myAccount.Id && friend.Status_1 == tb_Friend.none) || (friend.Id_account_2 == myAccount.Id && friend.Status_2 == tb_Friend.none)))
            {
                btnAddFriend.Visible = true;
            }
            else
            {
                btnAddFriend.Visible = false;
            }
            inMatch = true;
        }

        private void showMatch(int id_opponent)
        {
            opponentAccount = tb_Account.getAccount(id_opponent);
            opponentElo = tb_Elo.getElo(id_opponent, indexTypeGame, Regime.regimes[indexRegime].indexName);
            tb_GroupMatch group = tb_GroupMatch.getGroupMatch(myAccount.Id, id_opponent, indexTypeGame, indexRegime);
            tb_Match match;
            if (group == null)
            {
                group = new tb_GroupMatch(myAccount.Id, id_opponent, myAccount.Id + "-" + id_opponent, indexTypeGame, indexRegime);
                group.create();
                match = createMatch(group);
            }
            else
            {
                group.Rematch_1 = group.Rematch_2 = false;
                if (group.Id_account_1 == myAccount.Id)
                {
                    match = createMatch(group);
                    group.updateRematch();
                }
                else
                {
                    while (true)
                    {
                        match = tb_Match.getNewMatch(group.Id);
                        if (match != null)
                        {
                            break;
                        }
                    }
                    var tmp = Chess.convertFenToBoard(match.Fen);
                    chess.setChess(indexTypeGame, Regime.regimes[indexRegime].getTime(), Regime.regimes[indexRegime].time_bonus, chess.IsReverse, true, tmp.Item1, tmp.Item2, tmp.Item5, tmp.Item3, tmp.Item4, tmp.Item6, tmp.Item7);
                }
            }
            joinMatch(group, match, id_opponent);
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            tb_Friend friend = new tb_Friend(myAccount.Id, opponentAccount.Id, myAccount.Id);
            friend.invite(myAccount.Id);
            btnAddFriend.Visible = false;
            if (friend.Status_1 == tb_Friend.wait && friend.Status_2 == tb_Friend.wait)
            {
                friend.accept();
                MessageBox.Show("Bây giờ hai người đã trở thành bạn của nhau!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã gửi lời mời kết bạn thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private tb_Match createMatch(tb_GroupMatch group)
        {
            Random rnd = new Random();
            int tmp = rnd.Next(0, 100);
            chess.restartBoard();
            int bonusEloWin = tb_Match.getBonusElo(myElo.Value, opponentElo.Value);
            int bonusEloDraw = tb_Match.getBonusElo(myElo.Value, opponentElo.Value, true);
            tb_Match match;
            if (tmp % 2 ==  0)
            {
                match = new tb_Match(group.getCountMatch() + 1, group.Id, true, myElo.Value, opponentElo.Value, bonusEloWin, bonusEloDraw, chess.getCurrentFen(), chess.isWhiteTurn());
            }
            else
            {
                match = new tb_Match(group.getCountMatch() + 1, group.Id, false, opponentElo.Value, myElo.Value, bonusEloWin, bonusEloDraw, chess.getCurrentFen(), chess.isWhiteTurn());
            }
            match.create();
            return match;
        }

        private void setTurnPlay()
        {
            if (youWhite != chess.isWhiteTurn())
            {
                chess.freezeBoard();
                timerMove.Start();
            }
        }


        private void timerMove_Tick(object sender, EventArgs e)
        {
            timerMove.Stop();
            match.reloadMoveAndTimeEveryMove();
            string[] move = match.Move.Split('|');
            string[] timeEveryMove = match.TimeEveryMove.Split('|');
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
            else {
                timerMove.Start();
            }
        }
        private void timerRequestDrawAndResign_Tick(object sender, EventArgs e)
        {
            timerRequestDrawAndResign.Stop();
            match.reloadRequestDrawAndResign();
            if (match.Resign_w && !youWhite)
            {
                chess.resign(true, false);
                return;
            }
            if (match.Resign_b && youWhite)
            {
                chess.resign(false, false);
                return;
            }
            if (match.RequestDraw_w && match.RequestDraw_b)
            {
                chess.draw();
                return;
            }
            if (pnRequestDraw.Visible == false)
            {
                if ((match.RequestDraw_w && !youWhite) || (match.RequestDraw_b && youWhite))
                {
                    pnRequestDraw.Visible = true;
                    timeShowRequestDraw = maxTimeShowRequestDraw;
                    lblTimeShowRequestDraw.Text = Time.convertRealTimeToStr(timeShowRequestDraw);
                    timerShowRequestDraw.Start();
                }
            }
            timerRequestDrawAndResign.Start();

        }
        private void timerChat_Tick(object sender, EventArgs e)
        {
            timerChat.Stop();
            match.reloadChat();
            string[] chat = match.Chat.Split('|');
            if (indexChat == chat.Length - 2)
            {
                string[] tmp = chat[chat.Length - 2].Split(',');
                showMessage(tmp[0], tmp[1], false);
            }
            timerChat.Start();
        }


        private void showMessage(string name, string content, bool you)
        {
            //Panel pn = new Panel()
            //{
            //    Width = 450,
            //    BackColor = fpnChatContent.BackColor,
            //};
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
        
        public void outGame()
        {
            timerRematch.Stop();
            timerOutMatch.Stop();
            timerWaitOutMatch.Stop();
            timerMove.Stop();
            timerChat.Stop();
            timerRequestDrawAndResign.Stop();
            timerOutMatch.Stop();
            myAccount.updateStatus(1);
            myAccount.updateMatchAccount(0);
            if (match != null)
            {
                if (timerWaitOutMatch.Enabled)
                {
                    if (myElo.Value > opponentElo.Value)
                    {
                        myElo.Value -= match.BonusEloDraw;
                        opponentElo.Value += match.BonusEloDraw;
                    }
                    else
                    {
                        myElo.Value += match.BonusEloDraw;
                        opponentElo.Value -= match.BonusEloDraw;
                    }
                    myElo.updateElo();
                    match.Result = tb_Match.resultDraw;
                    match.DetailResult = EndGame.allOut;
                    match.W_out = match.B_out = true;
                    match.updateResult();
                    match.updateOut();
                }
                else
                {
                    if (match.Result == tb_Match.resultDefault)
                    {
                        if (youWhite)
                        {
                            match.W_out = true;
                        }
                        else
                        {
                            match.B_out = true;
                        }
                        match.updateOut();
                    }
                }
                opponentAccount.updateStatus(1);
                opponentAccount.updateMatchAccount(0);
                opponentAccount = null;
            }
            resetEndGame();
            match = null;
            opponentAccount = null;
            group = null;
            opponentElo = null;
            chess.restartBoard();
            chess.freezeBoard();
            cbbTypeGame.Enabled = cbbRegimes.Enabled = true;
            btnOutGame.Visible = false;
            pnChat.Visible = false;
            btnStartFind.Enabled = true;
            btnStopFind.Visible = false;
            btnRematch.Visible = btnNewGame.Visible = false;
            lblYou.Text = "Tài khoản của tôi: " + myAccount.Name;
            lblOpponent.Text = "Đối thủ: ";
            lblOutMatch.Visible = false;
            btnPrint.Visible = false;
            btnResign.Visible = btnRequestDraw.Visible = false;
            inMatch = false;
        }

        private void btnOutGame_Click(object sender, EventArgs e)
        {
            outGame();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            outGame();
            find();
        }
        private void btnRematch_Click(object sender, EventArgs e)
        {
            if (group.Id_account_1 == myAccount.Id)
            {
                group.Rematch_1 = true;
            }
            else
            {
                group.Rematch_2 = true;
            }
            group.updateRematch();
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            timerOutMatch.Stop();
            timerWaitOutMatch.Stop();
            chess.resign(youWhite);
            if (youWhite)
            {
                match.Resign_w = true;
            }
            else
            {
                match.Resign_b = true;
            }
            match.updateRequestDrawAndRegisn();
        }

        private void btnRequestDraw_Click(object sender, EventArgs e)
        {
            if (pnRequestDraw.Visible)
            {
                draw();
                return;
            }
            if (youWhite)
            {
                match.RequestDraw_w = true;
            }
            else
            {
                match.RequestDraw_b = true;
            }
            match.updateRequestDrawAndRegisn();
        }

        private void btnAcceptDraw_Click(object sender, EventArgs e)
        {
            draw();
        }

        private void draw()
        {
            if (youWhite)
            {
                match.RequestDraw_w = true;
            }
            else
            {
                match.RequestDraw_b = true;
            }
            match.updateRequestDrawAndRegisn();
            chess.draw();
        }

        private void btnDeclineDraw_Click(object sender, EventArgs e)
        {
            if (youWhite)
            {
                match.RequestDraw_b = false;
            }
            else
            {
                match.RequestDraw_w = false;
            }
            match.updateRequestDrawAndRegisn();
            pnRequestDraw.Visible = false;
            timerShowRequestDraw.Stop();
        }

        private void timerShowRequestDraw_Tick(object sender, EventArgs e)
        {
            timeShowRequestDraw--;
            lblTimeShowRequestDraw.Text = Time.convertRealTimeToStr(timeShowRequestDraw);
            if (timeShowRequestDraw == 0)
            {
                timerShowRequestDraw.Stop();
                pnRequestDraw.Visible = false;
                if (youWhite)
                {
                    match.RequestDraw_b = false;
                }
                else
                {
                    match.RequestDraw_w = false;
                }
                match.updateRequestDrawAndRegisn();
            }
        }

        private void timerOutMatch_Tick(object sender, EventArgs e)
        {
            timerOutMatch.Stop();
            match.reloadOut();
            if ((youWhite && !match.B_out) || (!youWhite && !match.W_out))
            {
                timerWaitOutMatch.Stop();
                lblOutMatch.Visible = false;
            }
            else if (!timerWaitOutMatch.Enabled && (youWhite && match.B_out) || (!youWhite && match.W_out))
            {
                timeOutMatch = maxTimeOutMatch;
                lblOutMatch.Text = "Đối thủ đã thoát, trận đấu sẽ huỷ trong: " + Time.convertRealTimeToStr(timeOutMatch);
                lblOutMatch.Visible = true;
                timerWaitOutMatch.Start();
            }
            timerOutMatch.Start();
        }

        private void timerWaitOutMatch_Tick(object sender, EventArgs e)
        {
            timeOutMatch--; 
            lblOutMatch.Text = "Đối thủ đã thoát, trận đấu sẽ huỷ trong: " + Time.convertRealTimeToStr(timeOutMatch);
            if (timeOutMatch == 0)
            {
                timerOutMatch.Stop();
                timerWaitOutMatch.Stop();
                chess.endGame(EndGame.giveUp, !youWhite);
                myAccount.updateMatchAccount(0);
                opponentAccount.updateMatchAccount(0);
                myAccount.updateStatus(1);
                btnRematch.Visible = false;
                lblOutMatch.Visible = false;
            }
        }

        private void timerRematch_Tick(object sender, EventArgs e)
        {
            timerRematch.Stop();
            group.reloadRematch();
            if (group.Rematch_1 && group.Rematch_2)
            {
                if (group.Id_account_1 == myAccount.Id)
                {
                    showMatch(group.Id_account_2);
                }
                else
                {
                    showMatch(group.Id_account_1);
                }
                return;
            }
            timerRematch.Start();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint input = new frmPrint(chess, group.IndexTypeGame, group.IndexRegime, notation);
            input.ShowDialog();
        }

        private void sendMessage()
        {
            if (string.IsNullOrEmpty(txtChat.Text))
            {
                return;
            }
            //gửi tin nhắn
            match.Chat += myAccount.getName() + "," + txtChat.Text + "|";
            showMessage("", txtChat.Text, true);
            txtChat.Clear();
            match.updateChat();
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

    }
}
