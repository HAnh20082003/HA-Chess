using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAChess_BetterAtChess
{
    class tb_Account
    {
        public static int online = 1, offline = 0, inMatch = -1, finding = -2;
        private int id;
        private string name;
        private string userName;
        private string password;
        private int status;
        private int indexTypeGame;
        private int indexNameRegime;
        private int id_matchAccount;

        public tb_Account(int id, string name, string userName, string password, int status, int indexTypeGame, int indexNameRegime, int id_matchAccount)
        {
            this.id = id;
            this.name = name;
            this.userName = userName;
            this.password = password;
            this.status = status;
            this.indexTypeGame = indexTypeGame;
            this.indexNameRegime = indexNameRegime;
            this.id_matchAccount = id_matchAccount;
        }

        public tb_Account(string name, string userName, string password)
        {
            this.name = name;
            this.userName = userName;
            this.password = password;
        }
        
        public tb_Account()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int Status { get => status; set => status = value; }
        public int IndexTypeGame { get => indexTypeGame; set => indexTypeGame = value; }
        public int IndexNameRegime { get => indexNameRegime; set => indexNameRegime = value; }
        public int Id_matchAccount { get => id_matchAccount; set => id_matchAccount = value; }

        public string getName()
        {
            return name + "#" + id;
        }

        public static tb_Account getAccount(int id)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Account where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            int id_matchAccount = 0;
            if (dt.Rows[i][7] != DBNull.Value)
            {
                id_matchAccount = (int)dt.Rows[i][7];
            }
            return new tb_Account((int)dt.Rows[i][0], (string)dt.Rows[i][1], (string)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], id_matchAccount);
        }
        public static tb_Account getAccountSearch(int id_account, string keyword)
        {
            keyword = keyword.ToLower();
            DataTable dt = SQL.Excute_Values("Select * from tb_Account where ID != @id", new List<string>() { "id" }, new List<object>() { id_account });
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((string)dt.Rows[i][1] + "#" + (int)dt.Rows[i][0] == keyword)
                {
                    int id_matchAccount = 0;
                    if (dt.Rows[i][7] != DBNull.Value)
                    {
                        id_matchAccount = (int)dt.Rows[i][7];
                    }
                    return new tb_Account((int)dt.Rows[i][0], (string)dt.Rows[i][1], (string)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], id_matchAccount);
                }
            }
            return null;
        }
        public static tb_Account getAccount(string userName)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Account where UserName = @userName", new List<string>() { "userName" }, new List<object>() { userName });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            int id_matchAccount = 0;
            if (dt.Rows[i][7] != DBNull.Value)
            {
                id_matchAccount = (int)dt.Rows[i][7];
            }
            return new tb_Account((int)dt.Rows[i][0], (string)dt.Rows[i][1], (string)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], id_matchAccount);
        }
        public static tb_Account getAccount(string userName, string password)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Account where UserName = @userName and Password = @password", new List<string>() { "userName", "password" }, new List<object>() { userName, password });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            int id_matchAccount = 0;
            if (dt.Rows[i][7] != DBNull.Value)
            {
                id_matchAccount = (int)dt.Rows[i][7];
            }
            return new tb_Account((int)dt.Rows[i][0], (string)dt.Rows[i][1], (string)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], id_matchAccount);
        }

        public tb_Account getAccountsMatchYou()
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Account where ID != @id and IndexTypeGame = @indexTypeGame and IndexNameRegime = @indexNameRegime and ID_MatchAccount is NULL and Status = -2", new List<string>() { "id", "indexTypeGame", "indexNameRegime" }, new List<object>() { id, indexTypeGame, indexNameRegime });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            return new tb_Account((int)dt.Rows[i][0], (string)dt.Rows[i][1], (string)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], id_matchAccount);
        }

        public void updateMatchAccount(int id_matchAccount)
        {
            this.id_matchAccount = id_matchAccount;
            if (id_matchAccount == 0)
            {
                SQL.Excute_Non_Value("Update tb_Account Set ID_MatchAccount = NULL where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            }
            else
            {
                SQL.Excute_Non_Value("Update tb_Account Set ID_MatchAccount = @id_matchAccount where ID = @id", new List<string>() { "id_matchAccount", "id" }, new List<object>() { id_matchAccount, id });
            }
        }
        public void updatePassword()
        {
            SQL.Excute_Non_Value("Update tb_Account Set Password = @password where ID = @id", new List<string>() { "password", "id" }, new List<object>() { password, id });
        }
        public void updateStatus(int status)
        {
            this.status = status;
            SQL.Excute_Non_Value("Update tb_Account Set Status = @status where ID = @id", new List<string>() { "status", "id" }, new List<object>() { status, id });
        }
        public void updateIndexTypeGame(int indexTypeGame)
        {
            this.indexTypeGame = indexTypeGame;
            SQL.Excute_Non_Value("Update tb_Account Set IndexTypeGame = @indexTypeGame where ID = @id", new List<string>() { "indexTypeGame", "id" }, new List<object>() { indexTypeGame, id });
        }
        public void updateIndexNameRegime(int indexNameRegime)
        {
            this.indexNameRegime = indexNameRegime;
            SQL.Excute_Non_Value("Update tb_Account Set IndexNameRegime = @indexNameRegime where ID = @id", new List<string>() { "indexNameRegime", "id" }, new List<object>() { indexNameRegime, id });
        }
        public void reloadMatchAccount()
        {
            object tmp = SQL.Excute_A_Value("Select ID_MatchAccount from tb_Account where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (tmp == DBNull.Value)
            {
                id_matchAccount = 0;
            }
            else
            {
                id_matchAccount = (int)tmp;
            }
        }
        public void reloadStatus()
        {
            status = (int) SQL.Excute_A_Value("Select Status from tb_Account where ID = @id", new List<string>() { "id" }, new List<object>() { id });
        }

        public void signUp()
        {
            SQL.Excute_Non_Value("Insert into tb_Account values (@name, @userName, @password, @status, @indexTypeGame, @indexNameRegime, NULL, NULL)", new List<string>() { "name", "userName", "password", "status", "indexTypeGame", "indexNameRegime" }, new List<object>() { name, userName, password, status, indexTypeGame, indexNameRegime });
        }
    }
}
