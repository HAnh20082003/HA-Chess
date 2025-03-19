
namespace HAChess_BetterAtChess
{
    partial class frmChooseColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseColor));
            this.fpnColors = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.ptrColorSelect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptrColorSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // fpnColors
            // 
            this.fpnColors.AutoScroll = true;
            this.fpnColors.Location = new System.Drawing.Point(97, 14);
            this.fpnColors.Name = "fpnColors";
            this.fpnColors.Size = new System.Drawing.Size(296, 185);
            this.fpnColors.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Teal;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatAppearance.BorderSize = 2;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(401, 14);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(124, 37);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Xác nhận";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ptrColorSelect
            // 
            this.ptrColorSelect.Location = new System.Drawing.Point(15, 14);
            this.ptrColorSelect.Name = "ptrColorSelect";
            this.ptrColorSelect.Size = new System.Drawing.Size(70, 70);
            this.ptrColorSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrColorSelect.TabIndex = 14;
            this.ptrColorSelect.TabStop = false;
            // 
            // frmChooseColor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(532, 231);
            this.Controls.Add(this.ptrColorSelect);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.fpnColors);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChooseColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn màu sắc";
            ((System.ComponentModel.ISupportInitialize)(this.ptrColorSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnColors;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.PictureBox ptrColorSelect;
    }
}