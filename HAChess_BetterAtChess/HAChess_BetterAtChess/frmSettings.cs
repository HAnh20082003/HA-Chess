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
    public partial class frmSettings : Form
    {
        public delegate void SendChangeSettings();
        public SendChangeSettings sendChangeSettings;
        tb_Account myAccount;
        InfoSettingBoard infoSettingBoard;
        InfoSettingBoard newInfoSettingBoard;
        Chess chess;
        bool change = false;
        internal frmSettings(tb_Account myAccount)
        {
            InitializeComponent();
            this.myAccount = myAccount;
            loadChess();
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            newInfoSettingBoard = infoSettingBoard.getCoppy(); 
            cbbTypePiece.DataSource = Piece.TypesPieces;
            loadSettingBoard(infoSettingBoard);
            if (myAccount != null)
            {
                lblYourName.Text = myAccount.Name + "#" + myAccount.Id;
                lblUserName.Text = "Tên đăng nhập: " + myAccount.UserName;
                lblChangeOrCancelChangPassword.Visible = true;
            }
        }

        public void loadChess()
        {
            chess = new Chess(pnChessBoard.Width, 20);
            chess.muteSound = true;
            chess.initBoard(pnChessBoard);
            chess.setBasicChess("", 0, false, false);
        }
        private void loadSettingBoard(InfoSettingBoard infoSettingBoard)
        {
            change = false;
            cbbTypePiece.SelectedIndex = infoSettingBoard.typePiece - 1;
            ptrLightColor.BackColor = infoSettingBoard.colorLight;
            ptrDarkColor.BackColor = infoSettingBoard.colorDark;
            ptrSelectColor.BackColor = infoSettingBoard.colorSelectPiece;
            ptrPrevColor.BackColor = infoSettingBoard.colorPrevMoved;
            ptrDesColor.BackColor = infoSettingBoard.colorDesMoved;
            ptrRecommendMoveColor.BackColor = infoSettingBoard.colorRecommendMove;
            ptrRecommendCaptureColor.BackColor = infoSettingBoard.colorRecommendCapture;
            chess.paintBoard(infoSettingBoard);
            chess.freezeBoard();
            change = true;
        }

        private void lblChangeOrCancelChangPassword_Click(object sender, EventArgs e)
        {
            if (pnChangePassword.Visible)
            {
                lblChangeOrCancelChangPassword.Text = "Thay đổi mật khẩu";
            }
            else
            {
                lblChangeOrCancelChangPassword.Text = "Huỷ bỏ";
            }
            pnChangePassword.Visible = !pnChangePassword.Visible;
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar = txtNewPassword.UseSystemPasswordChar = txtReNewPassword.UseSystemPasswordChar = !txtOldPassword.UseSystemPasswordChar;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ của bạn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới của bạn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtReNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới một lần nữa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReNewPassword.Focus();
                return;
            }

            if (txtOldPassword.Text != myAccount.Password)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }
            if (txtNewPassword.Text != txtReNewPassword.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReNewPassword.Focus();
                return;
            }
            if (txtNewPassword.Text == myAccount.Password)
            {
                MessageBox.Show("Bạn đã nhập mật khẩu cũ của mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                txtReNewPassword.Clear();
                return;
            }
            myAccount.Password = txtNewPassword.Text;
            myAccount.updatePassword();
            MessageBox.Show("Đã cập nhật mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pnChangePassword.Visible = false;
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtReNewPassword.Clear();
            lblChangeOrCancelChangPassword.Text = "Thay đổi mật khẩu";
        }

        private void openColor(string color, Color oldColor)
        {
            frmChooseColor choose = new frmChooseColor(color, oldColor);
            choose.sendColor += receiveColor;
            choose.ShowDialog();
        }

        private void receiveColor(string color, int indexColor)
        {
            if (color == "Light")
            {
                newInfoSettingBoard.indexColorLight = indexColor;
                newInfoSettingBoard.colorLight = General.colors[indexColor];
            }
            else if (color == "Dark")
            {
                newInfoSettingBoard.indexColorDark = indexColor;
                newInfoSettingBoard.colorDark = General.colors[indexColor];
            }
            else if (color == "Select")
            {
                newInfoSettingBoard.indexColorSelectPiece = indexColor;
                newInfoSettingBoard.colorSelectPiece = General.colors[indexColor];
            }
            else if (color == "RecommendMove")
            {
                newInfoSettingBoard.indexColorRecomendMove = indexColor;
                newInfoSettingBoard.colorRecommendMove = General.colors[indexColor];
            }
            else if (color == "RecommendCapture")
            {
                newInfoSettingBoard.indexColorRecommendCapture = indexColor;
                newInfoSettingBoard.colorRecommendCapture = General.colors[indexColor];
            }
            else if (color == "Prev")
            {
                newInfoSettingBoard.indexColorPrevMoved = indexColor;
                newInfoSettingBoard.colorPrevMoved = General.colors[indexColor];
            }
            else
            {
                newInfoSettingBoard.indexColorDesMoved = indexColor;
                newInfoSettingBoard.colorDesMoved = General.colors[indexColor];
            }
            loadSettingBoard(newInfoSettingBoard);
            btnUpdateBoard.Enabled = btnReset.Enabled = true;
        }
        private void cbbTypePiece_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!change)
            {
                return;
            }
            newInfoSettingBoard.typePiece = cbbTypePiece.SelectedIndex + 1;
            loadSettingBoard(newInfoSettingBoard);
            btnUpdateBoard.Enabled = btnReset.Enabled = btnDefault.Enabled = true;
        }

        private void lblChangeLight_Click(object sender, EventArgs e)
        {
            openColor("Light", ptrLightColor.BackColor);
        }

        private void lblChangeDark_Click(object sender, EventArgs e)
        {
            openColor("Dark", ptrDarkColor.BackColor);
        }

        private void lblChangeSelect_Click(object sender, EventArgs e)
        {
            openColor("Select", ptrSelectColor.BackColor);
        }

        private void lblChangeRecommendMove_Click(object sender, EventArgs e)
        {
            openColor("RecommendMove", ptrRecommendMoveColor.BackColor);
        }

        private void lblChangeRecommendCapture_Click(object sender, EventArgs e)
        {
            openColor("RecommendCapture", ptrRecommendCaptureColor.BackColor);
        }

        private void lblChangePrev_Click(object sender, EventArgs e)
        {
            openColor("Prev", ptrPrevColor.BackColor);
        }

        private void lblChangeDes_Click(object sender, EventArgs e)
        {
            openColor("Des", ptrDesColor.BackColor);
        }

        private void btnUpdateBoard_Click(object sender, EventArgs e)
        {
            newInfoSettingBoard.saveChanges();
            infoSettingBoard = newInfoSettingBoard.getCoppy();
            btnUpdateBoard.Enabled = btnReset.Enabled = false;
            btnDefault.Enabled = true;
            MessageBox.Show("Đã cập nhật thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            if (sendChangeSettings != null)
            {
                sendChangeSettings();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            newInfoSettingBoard = infoSettingBoard.getCoppy();
            loadSettingBoard(infoSettingBoard);
            btnUpdateBoard.Enabled = btnReset.Enabled = false;
            btnDefault.Enabled = true;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            btnDefault.Enabled = false;
            btnUpdateBoard.Enabled = btnReset.Enabled = true;
            newInfoSettingBoard = InfoSettingBoard.typeBoards[0].getCoppy();
            loadSettingBoard(newInfoSettingBoard);
        }
    }
}
