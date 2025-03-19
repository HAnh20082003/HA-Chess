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
    public partial class frmMain : Form
    {
        tb_Account myAccount;
        Form opening;
        frmFriends friends;
        frmMatchGame matchGame;
        frmPractice practice;
        frmBot bot;
        frmRewatch rewatch;
        frmHistories histories;
        frmDesign design;
        frmFreeRoom freeRoom;
        public frmMain()
        {
            InitializeComponent();
            addTooltip();
            checkLogin();
            practice = new frmPractice();
            showForm(practice);
        }

        private void addTooltip()
        {
            ttBattleOnline.SetToolTip(btnMatchGame, "Ghép trận Online");
            ttBot.SetToolTip(btnBot, "Đấu máy");
            ttDesign.SetToolTip(btnDesign, "Thiết kế bàn cờ");
            ttFreeRoom.SetToolTip(btnFreeRoom, "Phòng của tôi");
            ttFriends.SetToolTip(btnFriends, "Bạn bè");
            ttHistories.SetToolTip(btnHistories, "Lịch sử đấu");
            ttHome.SetToolTip(btnHome, "Trang chủ");
            ttNamePlayer.SetToolTip(lblNamePlayer, "Click phải để sao chép");
            ttPractice.SetToolTip(btnPractice, "Luyện tập");
            ttRewatch.SetToolTip(btnRewatch, "Xem lại trận đấu *.txt");
            ttSetting.SetToolTip(btnSetting, "Cài đặt trò chơi");
        }

        private void checkLogin()
        {
            if (myAccount == null)
            {
                string userName = Properties.Settings.Default.UserName;
                if (!string.IsNullOrEmpty(userName))
                {
                    btnLogin.Visible = btnSignup.Visible = false;
                    btnLogout.Left = btnSignup.Left;
                    btnLogout.Visible = true;
                    myAccount = tb_Account.getAccount(userName);
                    myAccount.updateStatus(1);
                    lblNamePlayer.Text = myAccount.Name + "#" + myAccount.Id;
                    lblNamePlayer.Visible = true;
                }
                else
                {
                    btnLogin.Visible = btnSignup.Visible = true;
                    btnLogout.Visible = false;
                    lblNamePlayer.Visible = false;
                }
            }
            else
            {
                btnLogin.Visible = btnSignup.Visible = false;
                btnLogout.Left = btnSignup.Left;
                btnLogout.Visible = true;
                myAccount.updateStatus(1);
                lblNamePlayer.Text = myAccount.Name + "#" + myAccount.Id;
                lblNamePlayer.Visible = true;
            }
        }
        private void showForm(Form form)
        {
            opening = form;
            form.TopLevel = false;
            form.Parent = pnShow;
            form.Dock = DockStyle.Fill;
            form.Show();
        }


        private void btnPractice_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu quay lại luyện tập lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?");
            if (!ok)
            {
                return;
            }
            practice = new frmPractice();
            showForm(practice);

        }

        private void btnMatchGame_Click(object sender, EventArgs e)
        {
            if (myAccount == null)
            {
                MessageBox.Show("Vui lòng chọn đăng nhập để ghép trận Online!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            setRoomOnline();
            if (opening != null)
            {
                opening.Close();
            }
            matchGame = new frmMatchGame(myAccount);
            showForm(matchGame);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.sendLogin += receiveLogin;
            login.ShowDialog();
        }

        private void receiveLogin(tb_Account account)
        {
            myAccount = account;
            checkLogin();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            frmSignup signUp = new frmSignup();
            signUp.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (opening == matchGame)
            {
                if (matchGame.finding)
                {
                    MessageBox.Show("Vui lòng dừng tìm trận trước mới đăng xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (matchGame.inMatch)
                {
                    MessageBox.Show("Bạn đang trong trận đấu! Bạn có chắc muốn rời đi không?", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (opening != null)
                {
                    opening.Close();
                }
                showForm(new frmPractice());
            }
            else if (opening == friends || opening == bot || opening == histories || opening == friends || opening == freeRoom)
            {
                if (MessageBox.Show("Bạn đang sử dụng tính năng dành cho người dùng đăng nhập! Nếu đăng xuất bạn sẽ được tự động rời khỏi giao diện hiện tại! Bạn chắc chứ?", "Cảnh báo", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                if (opening == freeRoom)
                {
                    freeRoom.outRoom();
                }
                if (opening != null)
                {
                    opening.Close();
                }
                showForm(new frmPractice());
            }
            myAccount.updateStatus(0);
            Properties.Settings.Default.UserName = null;
            Properties.Settings.Default.Save();
            myAccount = null;
            checkLogin();

        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu xem danh sách bạn bè lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?", true, "Vui lòng chọn đăng nhập xem danh sách bạn bè!!");
            if (!ok)
            {
                return;
            }
            friends = new frmFriends(myAccount);
            showForm(friends);
        }

        private void btnHistories_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu xem lịch sử đấu lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?", true, "Vui lòng chọn đăng nhập để xem lịch sử đấu Online!!");
            if (!ok)
            {
                return;
            }
            histories = new frmHistories(myAccount);
            showForm(histories);
        }

        private void btnBot_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu đấu máy đấu lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?", true, "Vui lòng chọn đăng nhập để đấu với máy!!");
            if (!ok)
            {
                return;
            }
            bot = new frmBot(myAccount);
            showForm(bot);
        }

        private void btnRewatch_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu xem lại file *.txt lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?");
            if (!ok)
            {
                return;
            }
            rewatch = new frmRewatch();
            showForm(rewatch);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSettings setting = new frmSettings(myAccount);
            setting.sendChangeSettings += receiveChangeSetting;
            setting.ShowDialog();
        }

        private void receiveChangeSetting()
        {
            if (opening == practice)
            {
                practice.loadSettingBoard();
            }
            else if (opening == matchGame)
            {
                matchGame.loadSettingBoard();
            }
            else if (opening == bot)
            {
                bot.loadSettingBoard();
            }
            else if (opening == histories)
            {
                histories.loadSettingBoard();
            }
            else if (opening == rewatch)
            {
                rewatch.loadSettingBoard();
            }
            else if (opening == design)
            {
                design.loadSettingBoard();
            }
            else if (opening == freeRoom)
            {
                freeRoom.loadSettingBoard();
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu đấu máy đấu lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?");
            if (!ok)
            {
                return;
            }
            design = new frmDesign();
            showForm(design);
        }

        private void btnFreeRoom_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu vào phòng tự do lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?", true, "Vui lòng chọn đăng nhập để vào phòng tự do!!");
            if (!ok)
            {
                return;
            }
            freeRoom = new frmFreeRoom(myAccount);
            showForm(freeRoom);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bool ok = closeForm("Bạn đang đấu online!! Nếu quay về trang chủ lúc này bạn sẽ out khỏi trận đấu hiện tại!! Bạn chắc chứ?");
            if (!ok)
            {
                return;
            }
        }

        private bool closeForm(string text, bool login = false, string textLogin = null)
        {
            if (login)
            {
                if (myAccount == null)
                {
                    MessageBox.Show(textLogin, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (opening != null)
            {
                if (opening == matchGame)
                {
                    if (matchGame.inMatchGame())
                    {
                        if (MessageBox.Show(text, "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            return false;
                        }
                    }
                }

                setRoomOnline();
                opening.Close();
            }
            return true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát trờ chơi HA Chess không?", "Hỏi lại", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            setRoomOnline();
            if (myAccount != null)
            {
                myAccount.updateStatus(tb_Account.offline);
            }
        }

        private void setRoomOnline()
        {
            if (opening != null)
            {
                if (opening == matchGame)
                {
                    if (matchGame.inMatchGame())
                    {
                        matchGame.outGame();
                    }
                    else if (matchGame.isFinding())
                    {
                        myAccount.updateStatus(tb_Account.online);
                    }
                }
                if (opening == freeRoom)
                {
                    freeRoom.outRoom();
                }
            }
        }

        private void lblNamePlayer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                btnSetting.PerformClick();
            }
            else
            {
                Clipboard.SetText(lblNamePlayer.Text);
            }
        }
    }
}
