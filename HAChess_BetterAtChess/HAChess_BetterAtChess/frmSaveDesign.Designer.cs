
namespace HAChess_BetterAtChess
{
    partial class frmSaveDesign
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNameFile
            // 
            this.txtNameFile.Location = new System.Drawing.Point(16, 34);
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.Size = new System.Drawing.Size(340, 27);
            this.txtNameFile.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatAppearance.BorderSize = 3;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.Color.Blue;
            this.btnAccept.Location = new System.Drawing.Point(111, 136);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(143, 41);
            this.btnAccept.TabIndex = 60;
            this.btnAccept.Text = "Lưu";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 19);
            this.lblUserName.TabIndex = 61;
            this.lblUserName.Text = "Tên file";
            // 
            // lblFen
            // 
            this.lblFen.Location = new System.Drawing.Point(17, 80);
            this.lblFen.Name = "lblFen";
            this.lblFen.Size = new System.Drawing.Size(339, 42);
            this.lblFen.TabIndex = 62;
            this.lblFen.Text = "Fen";
            // 
            // frmSaveDesign
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(373, 187);
            this.Controls.Add(this.lblFen);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtNameFile);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmSaveDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lưu thiết kế";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFen;
    }
}