using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAChess_BetterAtChess
{
    class tb_GroupMatch
    {
        private int id;
        private int id_account_1;
        private int id_account_2;
        private string strAccount;
        private int indexTypeGame;
        private int indexRegime;
        private bool rematch_1, rematch_2;
        private DateTime date;

        public tb_GroupMatch(int id_account_1, int id_account_2, string strAccount, int indexTypeGame, int indexRegime)
        {
            this.id_account_1 = id_account_1;
            this.id_account_2 = id_account_2;
            this.strAccount = strAccount;
            this.indexTypeGame = indexTypeGame;
            this.indexRegime = indexRegime;
            rematch_1 = rematch_2 = false;
        }

        public tb_GroupMatch(int id, int id_account_1, int id_account_2, string strAccount, int indexTypeGame, int indexRegime, bool rematch_1, bool rematch_2, DateTime date)
        {
            this.id = id;
            this.id_account_1 = id_account_1;
            this.id_account_2 = id_account_2;
            this.strAccount = strAccount;
            this.indexTypeGame = indexTypeGame;
            this.indexRegime = indexRegime;
            this.rematch_1 = rematch_1;
            this.rematch_2 = rematch_2;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public int Id_account_1 { get => id_account_1; set => id_account_1 = value; }
        public int Id_account_2 { get => id_account_2; set => id_account_2 = value; }
        public int IndexTypeGame { get => indexTypeGame; set => indexTypeGame = value; }
        public int IndexRegime { get => indexRegime; set => indexRegime = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Rematch_1 { get => rematch_1; set => rematch_1 = value; }
        public bool Rematch_2 { get => rematch_2; set => rematch_2 = value; }

        public static tb_GroupMatch getGroupMatch(int id_account_1, int id_account_2, int indexTypeGame, int indexRegime)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_GroupMatch where strAccount like '%" + id_account_1 + "%' and strAccount like '%" + id_account_2 + "%' and IndexTypeGame = @indexTypeGame and IndexRegime = @indexRegime", new List<string>() { "indexTypeGame", "indexRegime" }, new List<object>() { indexTypeGame, indexRegime });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            return new tb_GroupMatch((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (bool)dt.Rows[i][6], (bool)dt.Rows[i][7], (DateTime)dt.Rows[i][8]);
        }
        public static tb_GroupMatch getGroupMatch(int id)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_GroupMatch where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            return new tb_GroupMatch((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (bool)dt.Rows[i][6], (bool)dt.Rows[i][7], (DateTime)dt.Rows[i][8]);
        }
        public void create()
        {
            SQL.Excute_Non_Value("Insert into tb_GroupMatch values (@id_account_1, @id_account_2, @strAccount, @indexTypeGame, @indexRegime, @rematch_1, @rematch_2, GETDATE())", new List<string>() { "id_account_1", "id_account_2", "strAccount", "indexTypeGame", "indexRegime", "rematch_1", "rematch_2" }, new List<object>() { id_account_1, id_account_2, strAccount, indexTypeGame, indexRegime, rematch_1, rematch_2 });
            Id = (int)SQL.Excute_A_Value("Select MAX(ID) from tb_GroupMatch");
        }

        public int getCountMatch()
        {
            return (int)SQL.Excute_A_Value("Select count(*) from tb_Match where ID_GroupMatch = @id_groupMatch", new List<string>() { "id_groupMatch" }, new List<object>() { id });
        }

        public void updateRematch()
        {
            SQL.Excute_Non_Value("Update tb_GroupMatch Set Rematch_1 = @rematch_1, Rematch_2 = @rematch_2 where ID = @id", new List<string>() { "rematch_1", "rematch_2", "id" }, new List<object>() { rematch_1, rematch_2, id });
        }

        public void reloadRematch()
        {
            DataTable dt = SQL.Excute_Values("Select Rematch_1, Rematch_2 from tb_GroupMatch where ID = @id", new List<string>() { "id" }, new List<object>() { id });
            if (dt.Rows.Count != 0)
            {
                int i = 0;
                rematch_1 = (bool)dt.Rows[i][0];
                rematch_2 = (bool)dt.Rows[i][1];
            }
        }
    }
}
