using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAChess_BetterAtChess
{
    class tb_Match
    {
        public static int maxBonusElo = 30;
        public static int resultWin = 1, resultDraw = 0, resultLose = -1, resultDefault = -2;
        private int stt;
        private int id_groupMatch;
        private bool account_1_white;
        private int elo_white;
        private int elo_black;
        private int bonusEloWin;
        private int bonusEloDraw;
        private string fen;
        private string move;
        private string timeEveryMove;
        private string chat;
        private int result;
        private string detailResult;
        private string notation;
        private bool requestDraw_w;
        private bool requestDraw_b;
        private bool resign_w;
        private bool resign_b;
        private bool w_out;
        private bool b_out;
        private DateTime dateMatch;
        private bool currentTurn;

        public tb_Match(int stt, int id_groupMatch, bool account_1_white, int elo_white, int elo_black, int bonusEloWin, int bonusEloDraw, string fen, string move, string timeEveryMove, string chat, int result, string detailResult, string notation, bool requestDraw_w, bool requestDraw_b, bool resign_w, bool resign_b, bool w_out, bool b_out, DateTime dateMatch, bool currentTurn)
        {
            this.stt = stt;
            this.id_groupMatch = id_groupMatch;
            this.account_1_white = account_1_white;
            this.elo_white = elo_white;
            this.elo_black = elo_black;
            this.bonusEloWin = bonusEloWin;
            this.bonusEloDraw = bonusEloDraw;
            this.fen = fen;
            this.move = move;
            this.timeEveryMove = timeEveryMove;
            this.chat = chat;
            this.result = result;
            this.detailResult = detailResult;
            this.notation = notation;
            this.requestDraw_w = requestDraw_w;
            this.requestDraw_b = requestDraw_b;
            this.resign_w = resign_w;
            this.resign_b = resign_b;
            this.w_out = w_out;
            this.b_out = b_out;
            this.dateMatch = dateMatch;
            this.currentTurn = currentTurn;
        }

        public tb_Match(int stt, int id_groupMatch, bool account_1_white, int elo_white, int elo_black, int bonusEloWin, int bonusEloDraw, string fen, bool currentTurn)
        {
            this.stt = stt;
            this.id_groupMatch = id_groupMatch;
            this.account_1_white = account_1_white;
            this.elo_white = elo_white;
            this.elo_black = elo_black;
            this.bonusEloWin = bonusEloWin;
            this.bonusEloDraw = bonusEloDraw;
            this.fen = fen;
            this.currentTurn = currentTurn;
            result = resultDefault;
            move = timeEveryMove = "";
            chat = "";
            detailResult = notation = "";
            requestDraw_w = requestDraw_b = false;
            resign_w = resign_b = false;
            resign_w = resign_b = false;
            w_out = false;
            b_out = false;
            dateMatch = DateTime.Now;
        }

        public static tb_Match getNewMatch(int id_groupMatch)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Match where Result = @default and ID_GroupMatch = @id order by STT Desc", new List<string>() { "default", "id" }, new List<object>() { resultDefault, id_groupMatch });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            return new tb_Match((int)dt.Rows[i][0], (int)dt.Rows[i][1], (bool)dt.Rows[i][2], (int)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (string)dt.Rows[i][8], (string)dt.Rows[i][9], (string)dt.Rows[i][10],(int)dt.Rows[i][11], (string)dt.Rows[i][12], (string)dt.Rows[i][13], (bool)dt.Rows[i][14], (bool)dt.Rows[i][15], (bool)dt.Rows[i][16], (bool)dt.Rows[i][17], (bool)dt.Rows[i][18], (bool)dt.Rows[i][19], (DateTime)dt.Rows[i][20], (bool)dt.Rows[i][21]);
        }
        public static tb_Match getNewMatchByAccount(int id_account)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Match where ID_GroupMatch in (Select ID from tb_GroupMatch where strAccount like '%" + id_account + "%') order by STT Desc");
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            return new tb_Match((int)dt.Rows[i][0], (int)dt.Rows[i][1], (bool)dt.Rows[i][2], (int)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (string)dt.Rows[i][8], (string)dt.Rows[i][9], (string)dt.Rows[i][10], (int)dt.Rows[i][11], (string)dt.Rows[i][12], (string)dt.Rows[i][13], (bool)dt.Rows[i][14], (bool)dt.Rows[i][15], (bool)dt.Rows[i][16], (bool)dt.Rows[i][17], (bool)dt.Rows[i][18], (bool)dt.Rows[i][19], (DateTime)dt.Rows[i][20], (bool)dt.Rows[i][21]);
        }

        public void create()
        {
            SQL.Excute_Non_Value("Insert into tb_Match values (@stt, @id_groupMatch, @account_1_white, @elo_white, @elo_black, @bonusEloWin, @bonusEloDraw, @fen, @move, @timeEveryMove, @chat, @result, @detailResult, @notation, @requestDraw_w, @requestDraw_b, @resign_w, @resign_b, @w_out, @b_out, GETDATE(), @currentTurn)", new List<string>() { "stt", "id_groupMatch", "account_1_white", "elo_white", "elo_black", "bonusEloWin", "bonusEloDraw", "fen", "move", "timeEveryMove", "chat", "result", "detailResult", "notation", "requestDraw_w", "requestDraw_b", "resign_w", "resign_b", "w_out", "b_out", "currentTurn" }, new List<object>() { stt, id_groupMatch, account_1_white, elo_white, elo_black, bonusEloWin, bonusEloDraw, fen, move, timeEveryMove, chat, result, detailResult, notation, requestDraw_w, requestDraw_b, resign_w, resign_b, w_out, b_out, currentTurn });
        }

        public void reloadMoveAndTimeEveryMove()
        {
            DataTable dt =  SQL.Excute_Values("Select Move,TimeEveryMove from tb_Match where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "stt", "id_groupMatch" }, new List<object>() { stt, id_groupMatch });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                move = (string)dt.Rows[i][0];
                timeEveryMove = (string)dt.Rows[i][1];
            }
        }
        public void reloadChat()
        {
            chat = (string)SQL.Excute_A_Value("Select Chat from tb_Match where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "stt", "id_groupMatch" }, new List<object>() { stt, id_groupMatch });
        }
        public void reloadRequestDrawAndResign()
        {
            DataTable dt = SQL.Excute_Values("Select RequestDraw_W, RequestDraw_B, Resign_W, Resign_B from tb_Match where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "stt", "id_groupMatch" }, new List<object>() { stt, id_groupMatch });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                requestDraw_w = (bool)dt.Rows[i][0];
                requestDraw_b = (bool)dt.Rows[i][1];
                resign_w = (bool)dt.Rows[i][2];
                resign_b = (bool)dt.Rows[i][3];
            }
        }
        public void reloadOut()
        {
            DataTable dt = SQL.Excute_Values("Select W_Out, B_Out from tb_Match where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "stt", "id_groupMatch" }, new List<object>() { stt, id_groupMatch });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                w_out = (bool)dt.Rows[i][0];
                b_out = (bool)dt.Rows[i][1];
            }
        }
        public void reloadTurn()
        {
            currentTurn = (bool)SQL.Excute_A_Value("Select CurrentTurn from tb_Match where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "stt", "id_groupMatch" }, new List<object>() { stt, id_groupMatch });
        }

        public void updateMoveAndTimeEveryMove()
        {
            SQL.Excute_Non_Value("Update tb_Match Set Move = @move, TimeEveryMove = @timeEveryMove where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "move", "TimeEveryMove", "stt", "id_groupMatch" }, new List<object>() { move, TimeEveryMove, stt, id_groupMatch });
        }
        public void updateChat()
        {
            SQL.Excute_Non_Value("Update tb_Match Set Chat = @chat where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "chat", "stt", "id_groupMatch" }, new List<object>() { chat, stt, id_groupMatch });
        }
        public void updateResult()
        {
            SQL.Excute_Non_Value("Update tb_Match Set Result = @result, DetailResult = @detailResult, Notation = @notation where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "result", "detailResult", "notation", "stt", "id_groupMatch" }, new List<object>() { result, detailResult, notation, stt, id_groupMatch });
        }
        public void updateRequestDrawAndRegisn()
        {
            SQL.Excute_Non_Value("Update tb_Match Set Resign_W = @resign_W, Resign_B = @resign_B, RequestDraw_w = @requestDraw_w, RequestDraw_b = @requestDraw_b where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "resign_w", "resign_b", "requestDraw_w", "requestDraw_b", "stt", "id_groupMatch" }, new List<object>() { resign_w, resign_b, requestDraw_w, requestDraw_b, stt, id_groupMatch });
        }
        public void updateOut()
        {
            SQL.Excute_Non_Value("Update tb_Match Set W_Out = @w_Out, B_Out = @b_Out where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "w_Out", "b_Out", "stt", "id_groupMatch" }, new List<object>() { w_out, b_out, stt, id_groupMatch });
        }
        public void updateTurn()
        {
            SQL.Excute_Non_Value("Update tb_Match Set CurrentTurn = @currentTurn where STT = @stt and ID_GroupMatch = @id_groupMatch", new List<string>() { "currentTurn", "stt", "id_groupMatch" }, new List<object>() { currentTurn, stt, id_groupMatch });
        }

        public static int getBonusElo(int elo_1, int elo_2, bool draw = false)
        {
            int tmp = Math.Abs(elo_1 - elo_2);
            if (tmp > maxBonusElo)
            {
                tmp = maxBonusElo;
            }
            if (draw)
            {
                return tmp / 5;
            }
            return (tmp / 5) + 6;
        }

        public static List<tb_Match> getHistories(int startIndex, int endIndex, int id_account, string detailResult)
        {
            DataTable dt;
            if (string.IsNullOrEmpty(detailResult))
            {
                dt = SQL.Excute_Values("Select * from tb_Match where ID_GroupMatch in (Select ID from tb_GroupMatch where (ID_Account_1 = @id_account or ID_Account_2 = @id_account))", new List<string>() { "id_account" }, new List<object>() { id_account });
            }
            else
            {
                dt = SQL.Excute_Values("Select * from tb_Match where ID_GroupMatch in (Select ID from tb_GroupMatch where (ID_Account_1 = @id_account or ID_Account_2 = @id_account)) and DetailResult like @detailResult", new List<string>() { "id_account", "detailResult" }, new List<object>() { id_account, detailResult });
            }
            List<tb_Match> matches = new List<tb_Match>();
            for (int i = startIndex; i <= (dt.Rows.Count <= endIndex ? dt.Rows.Count - 1 : endIndex); i++)
            {
                matches.Add(new tb_Match((int)dt.Rows[i][0], (int)dt.Rows[i][1], (bool)dt.Rows[i][2], (int)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (string)dt.Rows[i][8], (string)dt.Rows[i][9], (string)dt.Rows[i][10], (int)dt.Rows[i][11], (string)dt.Rows[i][12], (string)dt.Rows[i][13], (bool)dt.Rows[i][14], (bool)dt.Rows[i][15], (bool)dt.Rows[i][16], (bool)dt.Rows[i][17], (bool)dt.Rows[i][18], (bool)dt.Rows[i][19], (DateTime)dt.Rows[i][20], (bool)dt.Rows[i][21]));
            }
            return matches;
        }
        public static int getCountHistories(int id_account, string detailResult)
        {
            if (string.IsNullOrEmpty(detailResult))
            {
                return (int)SQL.Excute_A_Value("Select Count(*) from tb_Match where ID_GroupMatch in (Select ID from tb_GroupMatch where (ID_Account_1 = @id_account or ID_Account_2 = @id_account))", new List<string>() { "id_account" }, new List<object>() { id_account });
            }
            return (int)SQL.Excute_A_Value("Select Count(*) from tb_Match where ID_GroupMatch in (Select ID from tb_GroupMatch where (ID_Account_1 = @id_account or ID_Account_2 = @id_account)) and DetailResult like @detailResult", new List<string>() { "id_account", "detailResult" }, new List<object>() { id_account, detailResult });
        }

        public int Stt { get => stt; set => stt = value; }
        public int Id_groupMatch { get => id_groupMatch; set => id_groupMatch = value; }
        public bool Account_1_white { get => account_1_white; set => account_1_white = value; }
        public int Elo_white { get => elo_white; set => elo_white = value; }
        public int Elo_black { get => elo_black; set => elo_black = value; }
        public int BonusEloWin { get => bonusEloWin; set => bonusEloWin = value; }
        public string Fen { get => fen; set => fen = value; }
        public int Result { get => result; set => result = value; }
        public string DetailResult { get => detailResult; set => detailResult = value; }
        public string Notation { get => notation; set => notation = value; }
        public int BonusEloDraw { get => bonusEloDraw; set => bonusEloDraw = value; }
        public string Move { get => move; set => move = value; }
        public string TimeEveryMove { get => timeEveryMove; set => timeEveryMove = value; }
        public string Chat { get => chat; set => chat = value; }
        public bool RequestDraw_w { get => requestDraw_w; set => requestDraw_w = value; }
        public bool RequestDraw_b { get => requestDraw_b; set => requestDraw_b = value; }
        public bool Resign_w { get => resign_w; set => resign_w = value; }
        public bool Resign_b { get => resign_b; set => resign_b = value; }
        public bool W_out { get => w_out; set => w_out = value; }
        public bool B_out { get => b_out; set => b_out = value; }
        public DateTime DateMatch { get => dateMatch; set => dateMatch = value; }
        public bool CurrentTurn { get => currentTurn; set => currentTurn = value; }
    }
}
