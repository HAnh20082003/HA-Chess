using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public partial class frmSaveDesign : Form
    {
        public delegate void SendSaved();
        public SendSaved sendSaved;
        string fen;
        public frmSaveDesign(string fen)
        {
            InitializeComponent();
            this.fen = fen;
            lblFen.Text = fen;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameFile.Text))
            {
                MessageBox.Show("Vui lòng nhập tên file!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (File.Exists("assets/saved/designs/" + txtNameFile.Text + ".txt"))
            {
                int i = 1;
                while (File.Exists("assets/saved/designs/" + txtNameFile.Text + " (" + i + ")" + ".txt"))
                {
                    i++;
                }
                File.WriteAllText("assets/saved/designs/" + txtNameFile.Text + " (" + i + ")" + ".txt", fen);
            }
            else
            {
                File.WriteAllText("assets/saved/designs/" + txtNameFile.Text + ".txt", fen);
            }
            MessageBox.Show("Đã lưu thiết kế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (sendSaved != null)
            {
                sendSaved();
            }
            Close();
        }
    }
}
