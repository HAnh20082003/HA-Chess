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
    public partial class frmFriends : Form
    {
        int indexFriend = -1;
        int id_friend = -1;
        List<tb_Friend> friends;
        List<tb_Friend> invites;
        List<tb_Friend> newFriends;
        PagedList pagesFriends, pagesInviteds, pagesNewFriends;
        int count1Page = 3;
        int maxPageShow = 3;
        int currentPageFriends = 1;
        int currentPageInvites = 1;
        int currentPageNewFriends = 1;

        Color colorSelect = Color.LightBlue;
        Color colorNormal = Color.White;

        int indexChat = 0;
        tb_Account myAccount;
        tb_Account currentAccount;
        internal frmFriends(tb_Account myAccount)
        {
            InitializeComponent();
            this.myAccount = myAccount;
            pagesFriends = new PagedList(pnPagesFriends, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pagesFriends.sendPageNumber += receivePageFriends;
            loadFriends(currentPageFriends, txtSearchFriends.Text);
            pagesInviteds = new PagedList(pnPagesInvited, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pagesInviteds.sendPageNumber += receivePageInviteds;
            loadInviteds(currentPageInvites, txtSearchInvited.Text);
            pagesNewFriends = new PagedList(pnPagesInvited, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pagesNewFriends.sendPageNumber += receivePageNewFriends;
            loadNewFriends(currentPageNewFriends, txtSearchNewFriend.Text);
            addToolTip();
        }
        private void addToolTip()
        {
            ttReloadFriends.SetToolTip(btnReloadFriends, " ");
            ttReloadInviteds.SetToolTip(btnReloadInvited, " ");
        }


        private void receivePageFriends(int page)
        {
            currentPageFriends = page;
            loadFriends(page, txtSearchFriends.Text);
        }
        private void receivePageInviteds(int page)
        {
            currentPageInvites = page;
            loadInviteds(page, txtSearchInvited.Text);
        }
        private void receivePageNewFriends(int page)
        {
            currentPageNewFriends = page;
            loadInviteds(page, txtSearchNewFriend.Text);
        }

        private void loadFriends(int page, string keyword)
        {
            fpnFriends.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            friends = tb_Friend.getFriends(myAccount.Id, startIndex, endIndex, keyword);
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
                Panel pn = new Panel()
                {
                    Size = new Size(329, 66),
                    ForeColor = Color.DarkCyan,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = (i, account),
                    Cursor = Cursors.Hand,
                };
                if (friends[i].Id == id_friend)
                {
                    pn.BackColor = colorSelect;
                }
                else
                {
                    pn.BackColor = colorNormal;
                }
                pn.Click += chat;

                Label lbl = new Label()
                {
                    Location = new Point(5, 10),
                    AutoSize = false,
                    Text = account.Name + "(#" + account.Id + ")",
                    Size = new Size(251, 32),
                    TextAlign = ContentAlignment.TopLeft,
                    Tag = (i, account),
                };
                pn.Controls.Add(lbl);
                lbl.Click += chat;
                Button btn = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(277, 14),
                    Image = Image.FromFile("assets/imgs/decline.png"),
                    Tag = i,
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += unfriend;
                pn.Controls.Add(btn);
                fpnFriends.Controls.Add(pn);
            }
            int count = tb_Friend.getCountFriends(myAccount.Id, keyword);
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

        private void txtSearchFriends_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadFriends(currentPageFriends, txtSearchFriends.Text);
            }
        }
        private void btnSearchFriend_Click(object sender, EventArgs e)
        {
            loadFriends(currentPageFriends, txtSearchFriends.Text);
        }

        private void btnPrevFriend_Click(object sender, EventArgs e)
        {
            pagesFriends.prevPage();
        }

        private void btnNextFriend_Click(object sender, EventArgs e)
        {
            pagesFriends.nextPage();
        }

        private void chat(object sender, EventArgs e)
        {
            var info = ((int, tb_Account))((Control)sender).Tag;
            currentAccount = info.Item2;
            indexFriend = info.Item1;
            id_friend = friends[indexFriend].Id;
            for (int i = 0; i < friends.Count; i++)
            {
                if (i != indexFriend)
                {
                    fpnFriends.Controls[i].BackColor = colorNormal;
                }
                else
                {
                    fpnFriends.Controls[i].BackColor = colorSelect;
                }
            }
            loadMessages(info.Item2);
            pnChat.Enabled = true;
            loadStatus();
            timerLoadStatus.Start();
        }

        private void loadStatus()
        {
            currentAccount.reloadStatus();
            if (currentAccount.Status == tb_Account.online)
            {
                lblStatus.Text = "Online";
                lblStatus.ForeColor = Color.SteelBlue;
            }
            else if (currentAccount.Status == tb_Account.offline)
            {
                lblStatus.Text = "Offline";
                lblStatus.ForeColor = Color.Crimson;
            }
            else if (currentAccount.Status == tb_Account.inMatch)
            {
                lblStatus.Text = "Trong trận";
                lblStatus.ForeColor = Color.SaddleBrown;
            }
            else
            {
                lblStatus.Text = "Đang tìm trận";
                lblStatus.ForeColor = Color.DimGray;
            }
        }

        private void timerLoadStatus_Tick(object sender, EventArgs e)
        {
            loadStatus();
        }

        private void unfriend(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn huỷ kết bạn với người này không? Huỷ kết bạn tin nhắn cũng sẽ bị xoá", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            int index = (int)((Control)sender).Tag;
            friends[index].decline();
            if (index == indexFriend)
            {
                unSelectAccount();
            }
            loadFriends(currentPageFriends, txtSearchFriends.Text);
        }

        private void unSelectAccount()
        {
            timerChat.Stop();
            indexFriend = -1;
            id_friend = -1;
            pnChat.Enabled = false;
            lblNameAccount.Text = "Tên người chơi";
            lblStatus.Text = "Trạng thái";
            txtChat.Clear();
            rtxChat.Clear();
            timerLoadStatus.Stop();
        }

        private void loadInviteds(int page, string keyword)
        {
            fpnInviteds.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            invites = tb_Friend.getInviteds(myAccount.Id, startIndex, endIndex, keyword);
            for (int i = 0; i < invites.Count; i++)
            {
                tb_Account account;
                if (invites[i].Id_account_1 == myAccount.Id)
                {
                    account = tb_Account.getAccount(invites[i].Id_account_2);
                }
                else
                {
                    account = tb_Account.getAccount(invites[i].Id_account_1);
                }
                Panel pn = new Panel()
                {
                    Size = new Size(329, 69),
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
                    Size = new Size(203, 44),
                    TextAlign = ContentAlignment.TopLeft,
                };
                pn.Controls.Add(lbl);
                Button btnA = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(214, 14),
                    Image = Image.FromFile("assets/imgs/accept.png"),
                    Tag = i,
                    Cursor = Cursors.Hand,
                };
                btnA.FlatAppearance.BorderSize = 0;
                btnA.Click += accept;
                pn.Controls.Add(btnA);

                Button btnD = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(277, 14),
                    Image = Image.FromFile("assets/imgs/decline.png"),
                    Tag = i,
                    Cursor = Cursors.Hand,
                };
                btnD.FlatAppearance.BorderSize = 0;
                btnD.Click += decline;
                pn.Controls.Add(btnA);
                fpnInviteds.Controls.Add(pn);
            }
            int count = tb_Friend.getCountInvites(myAccount.Id, keyword);
            lblCountInvites.Text = "Số lượng: " + count;

            if ((count - 1) / count1Page + 1 < page)
            {
                if (currentPageInvites != 1)
                {
                    currentPageInvites--;
                }
            }
            pagesInviteds.initPagedList(count, currentPageInvites);
        }

        private void txtSearchInvited_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadInviteds(currentPageInvites, txtSearchInvited.Text);
            }
        }

        private void btnSearchInvited_Click(object sender, EventArgs e)
        {
            loadInviteds(currentPageInvites, txtSearchInvited.Text);
        }

        private void btnPrevInvited_Click(object sender, EventArgs e)
        {
            pagesInviteds.prevPage();
        }

        private void btnNextInvited_Click(object sender, EventArgs e)
        {
            pagesInviteds.nextPage();
        }

        private void accept(object sender, EventArgs e)
        {
            int index = (int)((Control)sender).Tag;
            invites[index].accept();
            loadFriends(currentPageFriends, txtSearchFriends.Text);
            loadInviteds(currentPageInvites, txtSearchInvited.Text);
        }
        private void decline(object sender, EventArgs e)
        {
            int index = (int)((Control)sender).Tag;
            invites[index].decline();
            loadInviteds(currentPageInvites, txtSearchInvited.Text);
        }
        private void loadNewFriends(int page, string keyword)
        {
            fpnNewFriends.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            newFriends = tb_Friend.getNewFriends(myAccount.Id, startIndex, endIndex, keyword);
            for (int i = 0; i < newFriends.Count; i++)
            {
                tb_Account account;
                if (newFriends[i].Id_account_1 == myAccount.Id)
                {
                    account = tb_Account.getAccount(newFriends[i].Id_account_2);
                }
                else
                {
                    account = tb_Account.getAccount(newFriends[i].Id_account_1);
                }
                Panel pn = new Panel()
                {
                    Size = new Size(329, 66),
                    ForeColor = Color.DarkCyan,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                };

                Label lbl = new Label()
                {
                    Location = new Point(5, 10),
                    AutoSize = false,
                    Text = account.Name + "(#" + account.Id + ")",
                    Size = new Size(251, 32),
                    TextAlign = ContentAlignment.TopLeft,
                };
                pn.Controls.Add(lbl);
                Button btn = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(214, 14),
                    Image = Image.FromFile("assets/imgs/invite_friend.png"),
                    Tag = i,
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += inviteFriend;
                fpnFriends.Controls.Add(pn);
            }
            int count = tb_Friend.getCountNewFriends(myAccount.Id, keyword);
            lblCountNewFriends.Text = "Số lượng: " + count;
            pagesNewFriends.initPagedList(count, page);
        }

        private void btnPrevNewFriends_Click(object sender, EventArgs e)
        {
            pagesNewFriends.prevPage();
        }

        private void btnNextNewFriends_Click(object sender, EventArgs e)
        {
            pagesNewFriends.nextPage();
        }

        private void inviteFriend(object sender, EventArgs e)
        {
            int index = (int)((Control)sender).Tag;
            invites[index].invite(myAccount.Id);
            loadNewFriends(currentPageNewFriends, txtSearchNewFriend.Text);
        }

        private void txtSearchNewFriend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadNewFriends(currentPageNewFriends, txtSearchNewFriend.Text);
            }
        }


        private void btnSearchNewFriend_Click(object sender, EventArgs e)
        {
            loadNewFriends(currentPageNewFriends, txtSearchNewFriend.Text);
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
            showMessage("", txtChat.Text, true);
            friends[indexFriend].Chat += myAccount.Name + "," + txtChat.Text + "|";
            friends[indexFriend].updateChats();
            txtChat.Clear();
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

        private void loadMessages(tb_Account account)
        {
            indexChat = 0;
            lblNameAccount.Text = account.Name + "(#" + account.Id + ")";
            string[] chats = friends[indexFriend].Chat.Split('|');
            for (int i = 0; i <= chats.Length - 2; i++)
            {
                string[] tmp = chats[i].Split(',');
                if (tmp[0] == myAccount.Name)
                {
                    showMessage("", tmp[1], true);
                }
                else
                {
                    showMessage(tmp[0], tmp[1], false);
                }
            }
            indexChat = chats.Length - 1;
            timerChat.Start();
        }
        private void timerChat_Tick(object sender, EventArgs e)
        {
            timerChat.Stop();
            friends[indexFriend].reloadChats();
            string[] chats = friends[indexFriend].Chat.Split('|');
            if (indexChat == chats.Length - 2)
            {
                string[] tmp = chats[chats.Length - 2].Split(',');
                showMessage(tmp[0], tmp[1], false);
            }
            timerChat.Start();
        }

        private void btnReloadFriends_Click(object sender, EventArgs e)
        {
            loadFriends(currentPageFriends, txtSearchFriends.Text);
        }

        private void btnReloadInvited_Click(object sender, EventArgs e)
        {
            loadInviteds(currentPageInvites, txtSearchInvited.Text);
        }

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void btnUnfriend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn huỷ kết bạn với người này không? Huỷ kết bạn tin nhắn cũng sẽ bị xoá", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            unSelectAccount();
            loadFriends(currentPageFriends, txtSearchFriends.Text);
        }
    }
}
