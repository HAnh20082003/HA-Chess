using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAChess_BetterAtChess
{
    class tb_Elo
    {
        public static int defaultValue = 1000;
        private int id;
        private int id_account;
        private int indexTypeGame;
        private int indexNameRegime;
        private string strAccount;
        private int value;

        public int Id { get => id; set => id = value; }
        public int Id_account { get => id_account; set => id_account = value; }
        public int IndexTypeGame { get => indexTypeGame; set => indexTypeGame = value; }
        public int IndexNameRegime { get => indexNameRegime; set => indexNameRegime = value; }
        public string StrAccount { get => strAccount; set => strAccount = value; }
        public int Value { get => value; set => this.value = value; }

        public tb_Elo(int id_account, int indexTypeGame, int indexNameRegime, int value)
        {
            this.id_account = id_account;
            this.indexTypeGame = indexTypeGame;
            this.indexNameRegime = indexNameRegime;
            strAccount = getStrAccount(id_account, indexTypeGame, indexNameRegime);
            this.value = value;
        }

        public tb_Elo(int id, int id_account, int indexTypeGame, int indexNameRegime, string strAccount, int value)
        {
            this.id = id;
            this.id_account = id_account;
            this.indexTypeGame = indexTypeGame;
            this.indexNameRegime = indexNameRegime;
            this.strAccount = strAccount;
            this.value = value;
        }
        public static string getStrAccount(int id_account, int indexTypeGame, int indexNameRegime)
        {
            return id_account + "-" + indexTypeGame + "-" + indexNameRegime;
        }
        public void create()
        {
            SQL.Excute_Non_Value("Insert into tb_Elo values (@id_account, @indexTypeGame, @indexNameRegime, @strAccount, @value)", new List<string>() { "id_account", "indexTypeGame", "indexNameRegime", "strAccount", "value" }, new List<object>() { id_account, indexTypeGame, indexNameRegime, strAccount, value });
            id = (int)SQL.Excute_A_Value("Select MAX(ID) from tb_Elo");
        }

        public static tb_Elo getElo(int id_account, int indexTypeGame, int indexNameRegime)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Elo where StrAccount like '" + getStrAccount(id_account, indexTypeGame, indexNameRegime) + "'");
            if (dt.Rows.Count == 0)
            {
                tb_Elo elo = new tb_Elo(id_account, indexTypeGame, indexNameRegime, defaultValue);
                elo.create();
                return elo;
            }
            int i = 0;
            return new tb_Elo((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (int)dt.Rows[i][3], (string)dt.Rows[i][4], (int)dt.Rows[i][5]);
        }

        public void updateElo()
        {
            SQL.Excute_Non_Value("Update tb_Elo Set Value = @elo where ID = @id", new List<string>() { "elo", "id" }, new List<object>() { value, id });
        }
    }
}
