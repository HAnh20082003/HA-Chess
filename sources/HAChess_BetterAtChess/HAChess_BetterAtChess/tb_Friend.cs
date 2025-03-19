using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    class tb_Friend
    {
        public static int accepted = 1, wait = 0, none = -1;
        private int id;
        private int id_account_1;
        private int id_account_2;
        private string strAccount;
        private int id_account_send;
        private int status_1;
        private int status_2;
        private string chat;
        private DateTime date;

        public tb_Friend(int id_account_1, int id_account_2, int id_account_send)
        {
            this.id_account_1 = id_account_1;
            this.id_account_2 = id_account_2;
            StrAccount = getStrAccount(id_account_1, id_account_2);
            this.id_account_send = id_account_send;
            status_1 = status_2 = wait;
            chat = "";
        }

        public tb_Friend(int id, int id_account_1, int id_account_2, string strAccount, int id_account_send, int status_1, int status_2, string chat, DateTime date)
        {
            this.id = id;
            this.id_account_1 = id_account_1;
            this.id_account_2 = id_account_2;
            this.strAccount = strAccount;
            this.id_account_send = id_account_send;
            this.status_1 = status_1;
            this.status_2 = status_2;
            this.chat = chat;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public int Id_account_1 { get => id_account_1; set => id_account_1 = value; }
        public int Id_account_2 { get => id_account_2; set => id_account_2 = value; }
        public string StrAccount { get => strAccount; set => strAccount = value; }
        public int Status_1 { get => status_1; set => status_1 = value; }
        public int Status_2 { get => status_2; set => status_2 = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Id_account_send { get => id_account_send; set => id_account_send = value; }
        public string Chat { get => chat; set => chat = value; }

        public static string getStrAccount(int id_account_1, int id_account_2)
        {
            return id_account_1 + "-" + id_account_2;
        }

        public static tb_Friend getFriend(int id_account_1, int id_account_2)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account_1 + "%' and StrAccount like '%" + id_account_2 + "%'");
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            int i = 0;
            return new tb_Friend((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (DateTime)dt.Rows[i][8]);
        }

        public static int getCountFriends(int id_account, string keyword)
        {
            keyword = keyword.ToLower();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account + "%' and Status_1 = @status", new List<string>() { "status" }, new List<object>() { accepted });
            int i = 0;
            int count = 0;
            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (string.IsNullOrEmpty(keyword) || (("#" + account.Id).Contains(keyword) || account.Name.ToLower().Contains(keyword)))
                {
                    count++;
                }
                i++;
            }
            return count;
        }
        public static int getCountFriendsInvites(int id_account)
        {
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account + "%' and Status_1 = @status", new List<string>() { "status" }, new List<object>() { accepted });
            int i = 0;
            int count = 0;
            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                tb_MyRoom room = tb_MyRoom.getRoom(account.Id);
                if (room.Id_opponent == id_account && !room.Opponent_accepted)
                {
                    count++;
                }
                i++;
            }
            return count;
        }
        public static List<tb_Friend> getFriends(int id_account, int startIndex, int endIndex, string keyword)
        {
            keyword = keyword.ToLower();
            List<tb_Friend> friends = new List<tb_Friend>();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account + "%' and Status_1 = @status", new List<string>() { "status" }, new List<object>() { accepted });
            int i = 0;
            int j = startIndex;
            endIndex = (dt.Rows.Count <= endIndex ? dt.Rows.Count - 1 : endIndex);

            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);
                    
                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (string.IsNullOrEmpty(keyword) || (("#" + account.Id).Contains(keyword) || account.Name.ToLower().Contains(keyword)))
                {
                    if (j >= startIndex)
                    {
                        friends.Add(new tb_Friend((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (DateTime)dt.Rows[i][8]));

                        if (j == endIndex)
                        {
                            break;
                        }
                        j++;
                    }
                }
                i++;
            }
            return friends;
        }
        public static List<tb_Friend> getFriendsInvite(int id_account, int startIndex, int endIndex)
        {
            List<tb_Friend> friends = new List<tb_Friend>();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account + "%' and Status_1 = @status", new List<string>() { "status" }, new List<object>() { accepted });
            int i = 0;
            int j = startIndex;

            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (j >= startIndex)
                {
                    tb_MyRoom room = tb_MyRoom.getRoom(account.Id);
                    if (room.Id_opponent == id_account && !room.Opponent_accepted)
                    {
                        friends.Add(new tb_Friend((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (DateTime)dt.Rows[i][8]));

                        if (j == endIndex)
                        {
                            break;
                        }
                        j++;
                    }
                }
                i++;
            }
            return friends;
        }
        public static int getCountInvites(int id_account, string keyword)
        {
            keyword = keyword.ToLower();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where ID_Account_Send != @id_account and StrAccount like '%" + id_account + "%' and ((ID_Account_1 = @id_account and Status_2 = @status) or (ID_Account_2 = @id_account and Status_1 = @status)) ", new List<string>() { "id_account", "status" }, new List<object>() { id_account, wait });
            int i = 0;
            int count = 0;
            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (string.IsNullOrEmpty(keyword) || (("#" + account.Id).Contains(keyword) || account.Name.ToLower().Contains(keyword)))
                {
                    count++;
                }
                i++;
            }
            return count;
        }
        public static List<tb_Friend> getInviteds(int id_account, int startIndex, int endIndex, string keyword)
        {
            keyword = keyword.ToLower();
            List<tb_Friend> friends = new List<tb_Friend>();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where ID_Account_Send != @id_account and StrAccount like '%" + id_account + "%' and ((ID_Account_1 = @id_account and Status_2 = @status) or (ID_Account_2 = @id_account and Status_1 = @status)) ", new List<string>() { "id_account", "status" }, new List<object>() { id_account, wait });
            int i = 0;

            int j = startIndex;
            endIndex = (dt.Rows.Count <= endIndex ? dt.Rows.Count - 1 : endIndex);

            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (string.IsNullOrEmpty(keyword) || (("#" + account.Id).Contains(keyword) || account.Name.ToLower().Contains(keyword)))
                {
                    j++;
                    if (j >= startIndex)
                    {
                        if (j == endIndex)
                        {
                            break;
                        }
                        friends.Add(new tb_Friend((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (DateTime)dt.Rows[i][8]));
                    }
                }
                i++;
            }
            return friends;
        }

        public static int getCountNewFriends(int id_account, string keyword)
        {
            keyword = keyword.ToLower();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account + "%' and Status_1 = @status and Status_2 = @status", new List<string>() { "status" }, new List<object>() { wait });
            int i = 0;
            int count = 0;
            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (string.IsNullOrEmpty(keyword) || (("#" + account.Id).Contains(keyword) || account.Name.ToLower().Contains(keyword)))
                {
                    count++;
                }
                i++;
            }
            return count;
        }
        public static List<tb_Friend> getNewFriends(int id_account, int startIndex, int endIndex, string keyword)
        {
            keyword = keyword.ToLower();
            List<tb_Friend> friends = new List<tb_Friend>();
            DataTable dt = SQL.Excute_Values("Select * from tb_Friend where StrAccount like '%" + id_account + "%' and Status_1 = @status and Status_2 = @status", new List<string>() { "status" }, new List<object>() { wait });
            int i = 0;
            int j = startIndex;
            endIndex = (dt.Rows.Count <= endIndex ? dt.Rows.Count - 1 : endIndex);

            while (i < dt.Rows.Count)
            {
                tb_Account account;
                if ((int)dt.Rows[i][1] == id_account)
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][2]);

                }
                else
                {
                    account = tb_Account.getAccount((int)dt.Rows[i][1]);
                }
                if (string.IsNullOrEmpty(keyword) || (("#" + account.Id).Contains(keyword) || account.Name.ToLower().Contains(keyword)))
                {
                    j++;
                    if (j >= startIndex)
                    {
                        if (j == endIndex)
                        {
                            break;
                        }
                        friends.Add(new tb_Friend((int)dt.Rows[i][0], (int)dt.Rows[i][1], (int)dt.Rows[i][2], (string)dt.Rows[i][3], (int)dt.Rows[i][4], (int)dt.Rows[i][5], (int)dt.Rows[i][6], (string)dt.Rows[i][7], (DateTime)dt.Rows[i][8]));
                    }
                }
                i++;
            }
            return friends;
        }

        public void invite(int your_id)
        {
            tb_Friend friend = getFriend(Id_account_1, id_account_2);
            status_1 = id_account_1 == your_id ? wait : status_1;
            status_2 = id_account_2 == your_id ? wait : status_2;
            if (friend != null)
            {
                SQL.Excute_Non_Value("Update tb_Friend Set ID_Account_Send = @id_account, Status_1 = @status_1, Status_2 = @status_2 where ID = @id", new List<string>() { "id_account", "status_1", "status_2", "id" }, new List<object>() { id_account_send, status_1, status_2, friend.id });
                id = friend.id; 
            }
            else
            {
                SQL.Excute_Non_Value("Insert into tb_Friend values (@id_account_1, @id_account_2, @strAccount, @id_account_send, @status_1, @status_2, @chat, GETDATE())", new List<string>() { "id_account_1", "id_account_2", "strAccount", "id_account_send", "status_1", "status_2", "chat" }, new List<object>() { id_account_1, id_account_2, strAccount, id_account_send, status_1, status_2, chat });
            }
        }

        public void accept()
        {
            SQL.Excute_Non_Value("Update tb_Friend Set Status_1 = @status, Status_2 = @status where ID = @id", new List<string>() { "status", "id" }, new List<object>() { accepted, id });
        }
        public void decline()
        {
            SQL.Excute_Non_Value("Update tb_Friend Set Status_1 = @status, Status_2 = @status, Chat = '' where ID = @id", new List<string>() { "status", "id" }, new List<object>() { none, id });
        }

        public void reloadChats()
        {
            chat = (string)SQL.Excute_A_Value("Select Chat from tb_Friend where ID = @id", new List<string>() { "id" }, new List<object>() { id });
        }
        public void updateChats()
        {
            SQL.Excute_Non_Value("Update tb_Friend Set Chat = @chat where ID = @id", new List<string>() { "chat", "id" }, new List<object>() { chat, id });
        }
    }
}
