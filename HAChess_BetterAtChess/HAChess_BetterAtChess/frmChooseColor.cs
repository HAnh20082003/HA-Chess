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
    public partial class frmChooseColor : Form
    {
        public delegate void SendColor(string color, int indexColor);
        public SendColor sendColor;
        int indexColor = -1;
        string color;
        public frmChooseColor(string color, Color oldColor)
        {
            InitializeComponent();
            loadColors();
            this.color = color;
            indexColor = General.getIndexByColor(oldColor);
            selectColor(indexColor);
        }

        private void loadColors()
        {
            for (int i = 0; i < General.colors.Count;i ++)
            {
                Button btn = new Button()
                {
                    Size = new Size(40, 40),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = General.colors[i],
                    Cursor = Cursors.Hand,
                    Tag = i,
                };
                btn.FlatAppearance.BorderSize = 1;
                fpnColors.Controls.Add(btn);
                btn.Click += selectColor;
            }

        }

        private void selectColor(int index)
        {
            ptrColorSelect.BackColor = General.colors[index];
        }

        private void selectColor(object sender, EventArgs e)
        {
            indexColor = (int)((Control)sender).Tag;
            selectColor(indexColor);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (sendColor != null)
            {
                sendColor(color, indexColor);
            }
            Close();
        }
    }
}
