
namespace HAChess_BetterAtChess
{
    partial class frmPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNameFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTypeGame = new System.Windows.Forms.Label();
            this.lblRegime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxNotations = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtNameFile
            // 
            this.txtNameFile.Location = new System.Drawing.Point(16, 34);
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.Size = new System.Drawing.Size(414, 30);
            this.txtNameFile.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tên file txt";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 3;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(142, 524);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(154, 40);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "In file";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Lưu vào folder \"assets/saved/matches/\"";
            // 
            // lblTypeGame
            // 
            this.lblTypeGame.AutoSize = true;
            this.lblTypeGame.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeGame.Location = new System.Drawing.Point(12, 123);
            this.lblTypeGame.Name = "lblTypeGame";
            this.lblTypeGame.Size = new System.Drawing.Size(71, 19);
            this.lblTypeGame.TabIndex = 18;
            this.lblTypeGame.Text = "Chế độ:";
            // 
            // lblRegime
            // 
            this.lblRegime.AutoSize = true;
            this.lblRegime.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegime.Location = new System.Drawing.Point(12, 163);
            this.lblRegime.Name = "lblRegime";
            this.lblRegime.Size = new System.Drawing.Size(146, 19);
            this.lblRegime.TabIndex = 19;
            this.lblRegime.Text = "Chế độ thời gian:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Biên bản:";
            // 
            // rtxNotations
            // 
            this.rtxNotations.Location = new System.Drawing.Point(16, 237);
            this.rtxNotations.Name = "rtxNotations";
            this.rtxNotations.Size = new System.Drawing.Size(414, 260);
            this.rtxNotations.TabIndex = 22;
            this.rtxNotations.Text = "";
            // 
            // frmPrint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(443, 590);
            this.Controls.Add(this.rtxNotations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRegime);
            this.Controls.Add(this.lblTypeGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameFile);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In file lưu trữ ván đấu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTypeGame;
        private System.Windows.Forms.Label lblRegime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxNotations;
    }
}