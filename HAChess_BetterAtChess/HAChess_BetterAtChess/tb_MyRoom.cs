using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAChess_BetterAtChess
{
    class tb_MyRoom
    {
        private int id;
        private int id_opponent;
        private int indexTypeGame;
        private int indexRegime;
        private bool youWhite;
        private string fen;
        private bool startGame;
        private string move;
        private string timeEveryMove;
        private string chat;
        private bool requestDraw_you;
        private bool requestDraw_opponent;
        private bool resign_You;
        private bool resign_Opponent;
        private bool opponent_Out;
        private bool opponent_accepted;
        private bool restartGame;

        public tb_MyRoom(int id)
        {
            this.id = id;
            id_opponent = 0;
            indexTypeGame = indexRegime = 0;
            youWhite = true;
            fen = "";
            startGame = false;
            move = "";
            timeEveryMove = "";
            chat = "";
            requestDraw_you = false;
            requestDraw_opponent = false;
            resign_You = false;
            resign_Opponent = false;
            opponent_Out = false;
            restartGame = false;
        }

        public tb_MyRoom(int id, int id_opponent, int indexTypeGame, int indexRegime, bool youWhite, string fen, bool startGame, string move, string timeEveryMove, string chat, bool requestDraw_you, bool requestDraw_opponent, bool resign_You, bool resign_Opponent, bool opponent_Out, bool opponent_accepted, bool restartGame)
        {
            this.id = id;
            this.id_opponent = id_opponent;
            this.indexTypeGame = indexTypeGame;
            this.indexRegime = indexRegime;
            this.youWhite = youWhite;
            this.fen = fen;
            this.startGame = startGame;
            this.move = move;
            this.timeEveryMove = timeEveryMove;
            this.chat = chat;
            this.requestDraw_you = requestDraw_you;
            this.requestDraw_opponent = requestDraw_opponent;
            this.resign_You = resign_You;
            this.resign_Opponent = resign_Opponent;
            this.opponent_Out = opponent_Out;
            this.opponent_accepted = opponent_accepted;
            this.restartGame = restartGame;
        }

        public void createRoom()
        {
            SQL.Excute_Non_Value("Insert into tb_MyRoom values (@id, NULL, @indexTypeGame, @indexRegime, @youWhite, @fen, @startGame, @move, @timeEveryMove, @chat, @requestDrawYou, @requestDrawOpponent, @resignYou, @resignOpponent, @opponentOut, @opponent_accepted, @restartGame)", new List<string>() { "id", "indexTypeGame", "indexRegime", "youWhite", "fen", "startGame", "move", "timeEveryMove", "chat", "requestDrawYou", "requestDrawOpponent", "resignYou", "resignOpponent", "opponentOut", "opponent_accepted", "restartGame" }, new List<object>() { id, indexTypeGame, IndexRegime, youWhite, fen, startGame, move, timeEveryMove, chat, requestDraw_you, RequestDraw_opponent, resign_You, resign_Opponent, Opponent_Out, opponent_accepted, restartGame });
        }

        public static tb_MyRoom getRoom(int id_account)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id_account });
            if (dt.Rows.Count == 0)
            {
                tb_MyRoom myRoom = new tb_MyRoom(id_account);
                myRoom.createRoom();
                return myRoom;
            }
            else
            {
                int i = 0;
                int id_opponent = 0;
                if (dt.Rows[i][1] != DBNull.Value)
                {
                    id_opponent = (int)dt.Rows[i][1];
                }
                return new tb_MyRoom((int)dt.Rows[i][0], id_opponent, (int)dt.Rows[i][2], (int)dt.Rows[i][3], (bool)dt.Rows[i][4], (string)dt.Rows[i][5], (bool)dt.Rows[i][6], (string)dt.Rows[i][7], (string)dt.Rows[i][8], (string)dt.Rows[i][9], (bool)dt.Rows[i][10], (bool)dt.Rows[i][11], (bool)dt.Rows[i][12], (bool)dt.Rows[i][13], (bool)dt.Rows[i][14], (bool)dt.Rows[i][15], (bool)dt.Rows[i][16]);
            }
        }
        public static tb_MyRoom getRoomInvite(int id_account)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_MyRoom where ID_Opponent = @id_account", new List<string>() { "id_account" }, new List<object>() { id_account });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            int id_opponent = 0;
            if (dt.Rows[i][1] != DBNull.Value)
            {
                id_opponent = (int)dt.Rows[i][1];
            }
            return new tb_MyRoom((int)dt.Rows[i][0], id_opponent, (int)dt.Rows[i][2], (int)dt.Rows[i][3], (bool)dt.Rows[i][4], (string)dt.Rows[i][5], (bool)dt.Rows[i][6], (string)dt.Rows[i][7], (string)dt.Rows[i][8], (string)dt.Rows[i][9], (bool)dt.Rows[i][10], (bool)dt.Rows[i][11], (bool)dt.Rows[i][12], (bool)dt.Rows[i][13], (bool)dt.Rows[i][14], (bool)dt.Rows[i][15], (bool)dt.Rows[i][16]);
        }
        public void reloadRestart()
        {
            DataTable dt = SQL.Excute_Values("Select RestartGame from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                restartGame = (bool)dt.Rows[i][0];
            }
        }
        public void reloadMoveAndTimeEveryMove()
        {
            DataTable dt = SQL.Excute_Values("Select Move,TimeEveryMove from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                move = (string)dt.Rows[i][0];
                timeEveryMove = (string)dt.Rows[i][1];
            }
        }
        public void reloadChat()
        {
            chat = (string)SQL.Excute_A_Value("Select Chat from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
        }
        public void reloadRequestDrawAndResign()
        {
            DataTable dt = SQL.Excute_Values("Select RequestDraw_You, RequestDraw_Opponent, Resign_You, Resign_Opponent from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                requestDraw_you = (bool)dt.Rows[i][0];
                requestDraw_opponent = (bool)dt.Rows[i][1];
                resign_You = (bool)dt.Rows[i][2];
                Resign_Opponent = (bool)dt.Rows[i][3];
            }
        }
        public void reloadOpponentOut()
        {
            DataTable dt = SQL.Excute_Values("Select Opponent_Out from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                opponent_Out = (bool)dt.Rows[i][0];
            }
        }
        public void reloadOpponent()
        {
            var tmp = SQL.Excute_A_Value("Select ID_Opponent from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (tmp != DBNull.Value)
            {
                id_opponent = (int)tmp;
            }
            else
            {
                id_opponent = 0;
            }
        }
        public void reloadTurn()
        {
            youWhite = (bool)SQL.Excute_A_Value("Select YouWhite from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
        }
        public void reloadFen()
        {
            fen = (string)SQL.Excute_A_Value("Select Fen from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
        }
        public void reloadAccepted()
        {
            opponent_accepted = (bool)SQL.Excute_A_Value("Select Opponent_Accepted from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
        }
        public void reloadIndexTypeGameAndRegime()
        {
            DataTable dt = SQL.Excute_Values("Select IndexTypeGame, IndexRegime from tb_MyRoom where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                IndexTypeGame = (int)dt.Rows[i][0];
                IndexRegime = (int)dt.Rows[i][1];
            }
        }
        public void updateRestartGame()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set RestartGame = @restartGame where ID = @id", new List<string>() { "restartGame", "id" }, new List<object>() { restartGame, id });
        }
        public void updateOpponent()
        {
            if (id_opponent != 0)
            {
                SQL.Excute_Non_Value("Update tb_MyRoom Set ID_Opponent = @id_opponent where ID = @id", new List<string>() { "id_opponent", "id" }, new List<object>() { id_opponent, id });
            }
            else
            {
                SQL.Excute_Non_Value("Update tb_MyRoom Set ID_Opponent = NULL where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            }
        }
        public void updateOpponentOut()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set Opponent_Out = @Opponent_Out where ID = @id", new List<string>() { "Opponent_Out", "id" }, new List<object>() { opponent_Out, id });
        }
        public void updateAccepted()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set Opponent_Accepted = @opponent_accepted where ID = @id", new List<string>() { "opponent_accepted", "id" }, new List<object>() { opponent_accepted, id });
        }
        public void updateIndexTypeGame()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set IndexTypeGame = @indexTypeGame where ID = @id", new List<string>() { "indexTypeGame", "id" }, new List<object>() { indexTypeGame, id });
        }
        public void updateIndexRegime()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set IndexRegime = @indexRegime where ID = @id", new List<string>() { "indexRegime", "id" }, new List<object>() { indexRegime, id });
        }
        public void updateStartGame()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set StartGame = @startGame where ID = @id", new List<string>() { "startGame", "id" }, new List<object>() { startGame, id });
        }
        public void updateColorPiece()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set YouWhite = @youWhite where ID = @id", new List<string>() { "youWhite", "id" }, new List<object>() { youWhite, id });
        }

        public void updateMoveAndTimeEveryMove()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set Move = @move, TimeEveryMove = @timeEveryMove where ID = @id", new List<string>() { "move", "timeEveryMove", "id" }, new List<object>() { move, TimeEveryMove, id });
        }
        public void updateChat()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set Chat = @chat where ID = @id", new List<string>() { "chat", "id" }, new List<object>() { chat, id });
        }
        public void updateFen()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set Fen = @fen where ID = @id", new List<string>() { "fen", "id" }, new List<object>() { fen, id });
        }
        public void updateTurn()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set YouWhite = @youWhite where ID = @id", new List<string>() { "youWhite", "id" }, new List<object>() { youWhite, id });
        }
        public void updateRequestDrawAndRegisn()
        {
            SQL.Excute_Non_Value("Update tb_MyRoom Set Resign_You = @resign_You, Resign_Opponent = @resign_Opponent, RequestDraw_You = @requestDraw_You, RequestDraw_Opponent = @requestDraw_Opponent where ID = @id", new List<string>() { "resign_You", "resign_Opponent", "requestDraw_You", "requestDraw_Opponent", "id" }, new List<object>() { resign_You, Resign_Opponent, requestDraw_you, requestDraw_opponent, id });
        }

        public int Id { get => id; set => id = value; }
        public int Id_opponent { get => id_opponent; set => id_opponent = value; }
        public int IndexTypeGame { get => indexTypeGame; set => indexTypeGame = value; }
        public int IndexRegime { get => indexRegime; set => indexRegime = value; }
        public string Fen { get => fen; set => fen = value; }
        public bool StartGame { get => startGame; set => startGame = value; }
        public string Move { get => move; set => move = value; }
        public string TimeEveryMove { get => timeEveryMove; set => timeEveryMove = value; }
        public string Chat { get => chat; set => chat = value; }
        public bool RequestDraw_you { get => requestDraw_you; set => requestDraw_you = value; }
        public bool RequestDraw_opponent { get => requestDraw_opponent; set => requestDraw_opponent = value; }
        public bool Resign_You { get => resign_You; set => resign_You = value; }
        public bool Resign_Opponent { get => resign_Opponent; set => resign_Opponent = value; }
        public bool Opponent_Out { get => opponent_Out; set => opponent_Out = value; }
        public bool YouWhite { get => youWhite; set => youWhite = value; }
        public bool Opponent_accepted { get => opponent_accepted; set => opponent_accepted = value; }
        public bool RestartGame { get => restartGame; set => restartGame = value; }
    }
}
