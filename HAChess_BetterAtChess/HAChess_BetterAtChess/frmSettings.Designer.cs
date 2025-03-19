
namespace HAChess_BetterAtChess
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.ptrAvatar = new System.Windows.Forms.PictureBox();
            this.lblYourName = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblChangeOrCancelChangPassword = new System.Windows.Forms.Label();
            this.pnChangePassword = new System.Windows.Forms.Panel();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.txtReNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbTypePiece = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptrDesColor = new System.Windows.Forms.PictureBox();
            this.lblDesColor = new System.Windows.Forms.Label();
            this.ptrPrevColor = new System.Windows.Forms.PictureBox();
            this.lblPrevColor = new System.Windows.Forms.Label();
            this.ptrRecommendCaptureColor = new System.Windows.Forms.PictureBox();
            this.lblRecommendCaptureColor = new System.Windows.Forms.Label();
            this.ptrRecommendMoveColor = new System.Windows.Forms.PictureBox();
            this.lblRecommendMoveColor = new System.Windows.Forms.Label();
            this.ptrSelectColor = new System.Windows.Forms.PictureBox();
            this.lblSelectColor = new System.Windows.Forms.Label();
            this.ptrDarkColor = new System.Windows.Forms.PictureBox();
            this.lblDarkColor = new System.Windows.Forms.Label();
            this.ptrLightColor = new System.Windows.Forms.PictureBox();
            this.lblColorLight = new System.Windows.Forms.Label();
            this.btnUpdateBoard = new System.Windows.Forms.Button();
            this.lblChangeLight = new System.Windows.Forms.Label();
            this.lblChangeDark = new System.Windows.Forms.Label();
            this.lblChangeSelect = new System.Windows.Forms.Label();
            this.lblChangeRecommendMove = new System.Windows.Forms.Label();
            this.lblChangeRecommendCapture = new System.Windows.Forms.Label();
            this.lblChangePrev = new System.Windows.Forms.Label();
            this.lblChangeDes = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptrAvatar)).BeginInit();
            this.pnChangePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrDesColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrPrevColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRecommendCaptureColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRecommendMoveColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrSelectColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrDarkColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrLightColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(738, 31);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(400, 400);
            this.pnChessBoard.TabIndex = 1;
            // 
            // ptrAvatar
            // 
            this.ptrAvatar.Image = ((System.Drawing.Image)(resources.GetObject("ptrAvatar.Image")));
            this.ptrAvatar.Location = new System.Drawing.Point(28, 31);
            this.ptrAvatar.Name = "ptrAvatar";
            this.ptrAvatar.Size = new System.Drawing.Size(150, 150);
            this.ptrAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrAvatar.TabIndex = 2;
            this.ptrAvatar.TabStop = false;
            // 
            // lblYourName
            // 
            this.lblYourName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblYourName.Location = new System.Drawing.Point(24, 208);
            this.lblYourName.Name = "lblYourName";
            this.lblYourName.Size = new System.Drawing.Size(276, 42);
            this.lblYourName.TabIndex = 3;
            this.lblYourName.Text = "Tài khoản ẩn danh";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(7, 27);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(265, 27);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(24, 261);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(126, 19);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "Tên đăng nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 19);
            this.label10.TabIndex = 7;
            this.label10.Text = "Mật khẩu cũ";
            // 
            // lblChangeOrCancelChangPassword
            // 
            this.lblChangeOrCancelChangPassword.AutoSize = true;
            this.lblChangeOrCancelChangPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeOrCancelChangPassword.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeOrCancelChangPassword.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeOrCancelChangPassword.Location = new System.Drawing.Point(24, 294);
            this.lblChangeOrCancelChangPassword.Name = "lblChangeOrCancelChangPassword";
            this.lblChangeOrCancelChangPassword.Size = new System.Drawing.Size(151, 19);
            this.lblChangeOrCancelChangPassword.TabIndex = 8;
            this.lblChangeOrCancelChangPassword.Text = "Thay đổi mật khẩu";
            this.lblChangeOrCancelChangPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeOrCancelChangPassword.Visible = false;
            this.lblChangeOrCancelChangPassword.Click += new System.EventHandler(this.lblChangeOrCancelChangPassword_Click);
            // 
            // pnChangePassword
            // 
            this.pnChangePassword.Controls.Add(this.btnUpdatePassword);
            this.pnChangePassword.Controls.Add(this.cbShowPassword);
            this.pnChangePassword.Controls.Add(this.txtReNewPassword);
            this.pnChangePassword.Controls.Add(this.label2);
            this.pnChangePassword.Controls.Add(this.txtNewPassword);
            this.pnChangePassword.Controls.Add(this.label4);
            this.pnChangePassword.Controls.Add(this.txtOldPassword);
            this.pnChangePassword.Controls.Add(this.label10);
            this.pnChangePassword.Location = new System.Drawing.Point(28, 331);
            this.pnChangePassword.Name = "pnChangePassword";
            this.pnChangePassword.Size = new System.Drawing.Size(280, 288);
            this.pnChangePassword.TabIndex = 9;
            this.pnChangePassword.Visible = false;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.BackColor = System.Drawing.Color.Gold;
            this.btnUpdatePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatePassword.FlatAppearance.BorderSize = 2;
            this.btnUpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePassword.ForeColor = System.Drawing.Color.DimGray;
            this.btnUpdatePassword.Location = new System.Drawing.Point(65, 236);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(124, 37);
            this.btnUpdatePassword.TabIndex = 4;
            this.btnUpdatePassword.Text = "Cập nhật";
            this.btnUpdatePassword.UseVisualStyleBackColor = false;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.Location = new System.Drawing.Point(129, 194);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(143, 23);
            this.cbShowPassword.TabIndex = 3;
            this.cbShowPassword.Text = "Hiện mật khẩu";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.cbShowPassword_CheckedChanged);
            // 
            // txtReNewPassword
            // 
            this.txtReNewPassword.Location = new System.Drawing.Point(7, 158);
            this.txtReNewPassword.Name = "txtReNewPassword";
            this.txtReNewPassword.Size = new System.Drawing.Size(265, 27);
            this.txtReNewPassword.TabIndex = 2;
            this.txtReNewPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nhập lại mật khẩu";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(7, 91);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(265, 27);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mật khẩu mới";
            // 
            // cbbTypePiece
            // 
            this.cbbTypePiece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTypePiece.FormattingEnabled = true;
            this.cbbTypePiece.Location = new System.Drawing.Point(362, 60);
            this.cbbTypePiece.Name = "cbbTypePiece";
            this.cbbTypePiece.Size = new System.Drawing.Size(294, 27);
            this.cbbTypePiece.TabIndex = 10;
            this.cbbTypePiece.SelectedIndexChanged += new System.EventHandler(this.cbbTypePiece_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Thiết kế quân cờ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(362, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Thiết kế màu sắc";
            // 
            // ptrDesColor
            // 
            this.ptrDesColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrDesColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrDesColor.Location = new System.Drawing.Point(567, 472);
            this.ptrDesColor.Name = "ptrDesColor";
            this.ptrDesColor.Size = new System.Drawing.Size(40, 40);
            this.ptrDesColor.TabIndex = 50;
            this.ptrDesColor.TabStop = false;
            // 
            // lblDesColor
            // 
            this.lblDesColor.AutoSize = true;
            this.lblDesColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDesColor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesColor.ForeColor = System.Drawing.Color.Black;
            this.lblDesColor.Location = new System.Drawing.Point(365, 483);
            this.lblDesColor.Name = "lblDesColor";
            this.lblDesColor.Size = new System.Drawing.Size(134, 19);
            this.lblDesColor.TabIndex = 49;
            this.lblDesColor.Text = "Màu ô đích đến:";
            // 
            // ptrPrevColor
            // 
            this.ptrPrevColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrPrevColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrPrevColor.Location = new System.Drawing.Point(567, 420);
            this.ptrPrevColor.Name = "ptrPrevColor";
            this.ptrPrevColor.Size = new System.Drawing.Size(40, 40);
            this.ptrPrevColor.TabIndex = 48;
            this.ptrPrevColor.TabStop = false;
            // 
            // lblPrevColor
            // 
            this.lblPrevColor.AutoSize = true;
            this.lblPrevColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrevColor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevColor.ForeColor = System.Drawing.Color.Black;
            this.lblPrevColor.Location = new System.Drawing.Point(365, 431);
            this.lblPrevColor.Name = "lblPrevColor";
            this.lblPrevColor.Size = new System.Drawing.Size(138, 19);
            this.lblPrevColor.TabIndex = 47;
            this.lblPrevColor.Text = "Màu ô trước đó:";
            // 
            // ptrRecommendCaptureColor
            // 
            this.ptrRecommendCaptureColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrRecommendCaptureColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrRecommendCaptureColor.Location = new System.Drawing.Point(567, 366);
            this.ptrRecommendCaptureColor.Name = "ptrRecommendCaptureColor";
            this.ptrRecommendCaptureColor.Size = new System.Drawing.Size(40, 40);
            this.ptrRecommendCaptureColor.TabIndex = 46;
            this.ptrRecommendCaptureColor.TabStop = false;
            // 
            // lblRecommendCaptureColor
            // 
            this.lblRecommendCaptureColor.AutoSize = true;
            this.lblRecommendCaptureColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecommendCaptureColor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendCaptureColor.ForeColor = System.Drawing.Color.Black;
            this.lblRecommendCaptureColor.Location = new System.Drawing.Point(365, 377);
            this.lblRecommendCaptureColor.Name = "lblRecommendCaptureColor";
            this.lblRecommendCaptureColor.Size = new System.Drawing.Size(189, 19);
            this.lblRecommendCaptureColor.TabIndex = 45;
            this.lblRecommendCaptureColor.Text = "Màu ô có thể ăn quân: ";
            // 
            // ptrRecommendMoveColor
            // 
            this.ptrRecommendMoveColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrRecommendMoveColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrRecommendMoveColor.Location = new System.Drawing.Point(567, 314);
            this.ptrRecommendMoveColor.Name = "ptrRecommendMoveColor";
            this.ptrRecommendMoveColor.Size = new System.Drawing.Size(40, 40);
            this.ptrRecommendMoveColor.TabIndex = 44;
            this.ptrRecommendMoveColor.TabStop = false;
            // 
            // lblRecommendMoveColor
            // 
            this.lblRecommendMoveColor.AutoSize = true;
            this.lblRecommendMoveColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecommendMoveColor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendMoveColor.ForeColor = System.Drawing.Color.Black;
            this.lblRecommendMoveColor.Location = new System.Drawing.Point(365, 322);
            this.lblRecommendMoveColor.Name = "lblRecommendMoveColor";
            this.lblRecommendMoveColor.Size = new System.Drawing.Size(140, 19);
            this.lblRecommendMoveColor.TabIndex = 43;
            this.lblRecommendMoveColor.Text = "Màu ô có thể đi: ";
            // 
            // ptrSelectColor
            // 
            this.ptrSelectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrSelectColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrSelectColor.Location = new System.Drawing.Point(567, 261);
            this.ptrSelectColor.Name = "ptrSelectColor";
            this.ptrSelectColor.Size = new System.Drawing.Size(40, 40);
            this.ptrSelectColor.TabIndex = 42;
            this.ptrSelectColor.TabStop = false;
            // 
            // lblSelectColor
            // 
            this.lblSelectColor.AutoSize = true;
            this.lblSelectColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectColor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectColor.ForeColor = System.Drawing.Color.Black;
            this.lblSelectColor.Location = new System.Drawing.Point(365, 269);
            this.lblSelectColor.Name = "lblSelectColor";
            this.lblSelectColor.Size = new System.Drawing.Size(140, 19);
            this.lblSelectColor.TabIndex = 41;
            this.lblSelectColor.Text = "Màu chọn quân: ";
            // 
            // ptrDarkColor
            // 
            this.ptrDarkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrDarkColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrDarkColor.Location = new System.Drawing.Point(567, 208);
            this.ptrDarkColor.Name = "ptrDarkColor";
            this.ptrDarkColor.Size = new System.Drawing.Size(40, 40);
            this.ptrDarkColor.TabIndex = 40;
            this.ptrDarkColor.TabStop = false;
            // 
            // lblDarkColor
            // 
            this.lblDarkColor.AutoSize = true;
            this.lblDarkColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDarkColor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDarkColor.ForeColor = System.Drawing.Color.Black;
            this.lblDarkColor.Location = new System.Drawing.Point(365, 216);
            this.lblDarkColor.Name = "lblDarkColor";
            this.lblDarkColor.Size = new System.Drawing.Size(92, 19);
            this.lblDarkColor.TabIndex = 39;
            this.lblDarkColor.Text = "Màu ô tối: ";
            // 
            // ptrLightColor
            // 
            this.ptrLightColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptrLightColor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptrLightColor.Location = new System.Drawing.Point(567, 154);
            this.ptrLightColor.Name = "ptrLightColor";
            this.ptrLightColor.Size = new System.Drawing.Size(40, 40);
            this.ptrLightColor.TabIndex = 38;
            this.ptrLightColor.TabStop = false;
            // 
            // lblColorLight
            // 
            this.lblColorLight.AutoSize = true;
            this.lblColorLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblColorLight.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorLight.ForeColor = System.Drawing.Color.Black;
            this.lblColorLight.Location = new System.Drawing.Point(365, 162);
            this.lblColorLight.Name = "lblColorLight";
            this.lblColorLight.Size = new System.Drawing.Size(110, 19);
            this.lblColorLight.TabIndex = 37;
            this.lblColorLight.Text = "Màu ô sáng: ";
            // 
            // btnUpdateBoard
            // 
            this.btnUpdateBoard.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateBoard.Enabled = false;
            this.btnUpdateBoard.FlatAppearance.BorderSize = 2;
            this.btnUpdateBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateBoard.ForeColor = System.Drawing.Color.White;
            this.btnUpdateBoard.Location = new System.Drawing.Point(362, 535);
            this.btnUpdateBoard.Name = "btnUpdateBoard";
            this.btnUpdateBoard.Size = new System.Drawing.Size(113, 37);
            this.btnUpdateBoard.TabIndex = 12;
            this.btnUpdateBoard.Text = "Cập nhật";
            this.btnUpdateBoard.UseVisualStyleBackColor = false;
            this.btnUpdateBoard.Click += new System.EventHandler(this.btnUpdateBoard_Click);
            // 
            // lblChangeLight
            // 
            this.lblChangeLight.AutoSize = true;
            this.lblChangeLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeLight.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeLight.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeLight.Location = new System.Drawing.Point(622, 162);
            this.lblChangeLight.Name = "lblChangeLight";
            this.lblChangeLight.Size = new System.Drawing.Size(76, 19);
            this.lblChangeLight.TabIndex = 51;
            this.lblChangeLight.Text = "Thay đổi";
            this.lblChangeLight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeLight.Click += new System.EventHandler(this.lblChangeLight_Click);
            // 
            // lblChangeDark
            // 
            this.lblChangeDark.AutoSize = true;
            this.lblChangeDark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeDark.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDark.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeDark.Location = new System.Drawing.Point(622, 216);
            this.lblChangeDark.Name = "lblChangeDark";
            this.lblChangeDark.Size = new System.Drawing.Size(76, 19);
            this.lblChangeDark.TabIndex = 52;
            this.lblChangeDark.Text = "Thay đổi";
            this.lblChangeDark.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeDark.Click += new System.EventHandler(this.lblChangeDark_Click);
            // 
            // lblChangeSelect
            // 
            this.lblChangeSelect.AutoSize = true;
            this.lblChangeSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeSelect.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeSelect.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeSelect.Location = new System.Drawing.Point(622, 269);
            this.lblChangeSelect.Name = "lblChangeSelect";
            this.lblChangeSelect.Size = new System.Drawing.Size(76, 19);
            this.lblChangeSelect.TabIndex = 53;
            this.lblChangeSelect.Text = "Thay đổi";
            this.lblChangeSelect.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeSelect.Click += new System.EventHandler(this.lblChangeSelect_Click);
            // 
            // lblChangeRecommendMove
            // 
            this.lblChangeRecommendMove.AutoSize = true;
            this.lblChangeRecommendMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeRecommendMove.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeRecommendMove.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeRecommendMove.Location = new System.Drawing.Point(622, 322);
            this.lblChangeRecommendMove.Name = "lblChangeRecommendMove";
            this.lblChangeRecommendMove.Size = new System.Drawing.Size(76, 19);
            this.lblChangeRecommendMove.TabIndex = 54;
            this.lblChangeRecommendMove.Text = "Thay đổi";
            this.lblChangeRecommendMove.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeRecommendMove.Click += new System.EventHandler(this.lblChangeRecommendMove_Click);
            // 
            // lblChangeRecommendCapture
            // 
            this.lblChangeRecommendCapture.AutoSize = true;
            this.lblChangeRecommendCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeRecommendCapture.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeRecommendCapture.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeRecommendCapture.Location = new System.Drawing.Point(622, 376);
            this.lblChangeRecommendCapture.Name = "lblChangeRecommendCapture";
            this.lblChangeRecommendCapture.Size = new System.Drawing.Size(76, 19);
            this.lblChangeRecommendCapture.TabIndex = 55;
            this.lblChangeRecommendCapture.Text = "Thay đổi";
            this.lblChangeRecommendCapture.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeRecommendCapture.Click += new System.EventHandler(this.lblChangeRecommendCapture_Click);
            // 
            // lblChangePrev
            // 
            this.lblChangePrev.AutoSize = true;
            this.lblChangePrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangePrev.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePrev.ForeColor = System.Drawing.Color.Navy;
            this.lblChangePrev.Location = new System.Drawing.Point(622, 431);
            this.lblChangePrev.Name = "lblChangePrev";
            this.lblChangePrev.Size = new System.Drawing.Size(76, 19);
            this.lblChangePrev.TabIndex = 56;
            this.lblChangePrev.Text = "Thay đổi";
            this.lblChangePrev.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangePrev.Click += new System.EventHandler(this.lblChangePrev_Click);
            // 
            // lblChangeDes
            // 
            this.lblChangeDes.AutoSize = true;
            this.lblChangeDes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChangeDes.Font = new System.Drawing.Font("Arial", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDes.ForeColor = System.Drawing.Color.Navy;
            this.lblChangeDes.Location = new System.Drawing.Point(622, 482);
            this.lblChangeDes.Name = "lblChangeDes";
            this.lblChangeDes.Size = new System.Drawing.Size(76, 19);
            this.lblChangeDes.TabIndex = 57;
            this.lblChangeDes.Text = "Thay đổi";
            this.lblChangeDes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblChangeDes.Click += new System.EventHandler(this.lblChangeDes_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Enabled = false;
            this.btnReset.FlatAppearance.BorderSize = 2;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(498, 535);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 37);
            this.btnReset.TabIndex = 58;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefault.FlatAppearance.BorderSize = 2;
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.ForeColor = System.Drawing.Color.White;
            this.btnDefault.Location = new System.Drawing.Point(603, 535);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(95, 37);
            this.btnDefault.TabIndex = 59;
            this.btnDefault.Text = "Mặc định";
            this.btnDefault.UseVisualStyleBackColor = false;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1144, 633);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblChangeDes);
            this.Controls.Add(this.lblChangePrev);
            this.Controls.Add(this.lblChangeRecommendCapture);
            this.Controls.Add(this.lblChangeRecommendMove);
            this.Controls.Add(this.lblChangeSelect);
            this.Controls.Add(this.lblChangeDark);
            this.Controls.Add(this.lblChangeLight);
            this.Controls.Add(this.btnUpdateBoard);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblColorLight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ptrLightColor);
            this.Controls.Add(this.cbbTypePiece);
            this.Controls.Add(this.pnChangePassword);
            this.Controls.Add(this.lblDarkColor);
            this.Controls.Add(this.lblChangeOrCancelChangPassword);
            this.Controls.Add(this.ptrDesColor);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.ptrDarkColor);
            this.Controls.Add(this.lblYourName);
            this.Controls.Add(this.lblDesColor);
            this.Controls.Add(this.ptrAvatar);
            this.Controls.Add(this.lblSelectColor);
            this.Controls.Add(this.pnChessBoard);
            this.Controls.Add(this.ptrPrevColor);
            this.Controls.Add(this.lblRecommendCaptureColor);
            this.Controls.Add(this.ptrSelectColor);
            this.Controls.Add(this.ptrRecommendMoveColor);
            this.Controls.Add(this.lblPrevColor);
            this.Controls.Add(this.ptrRecommendCaptureColor);
            this.Controls.Add(this.lblRecommendMoveColor);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt trò chơi";
            ((System.ComponentModel.ISupportInitialize)(this.ptrAvatar)).EndInit();
            this.pnChangePassword.ResumeLayout(false);
            this.pnChangePassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrDesColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrPrevColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRecommendCaptureColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRecommendMoveColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrSelectColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrDarkColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrLightColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.PictureBox ptrAvatar;
        private System.Windows.Forms.Label lblYourName;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblChangeOrCancelChangPassword;
        private System.Windows.Forms.Panel pnChangePassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.TextBox txtReNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.ComboBox cbbTypePiece;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateBoard;
        private System.Windows.Forms.PictureBox ptrDesColor;
        private System.Windows.Forms.Label lblDesColor;
        private System.Windows.Forms.PictureBox ptrPrevColor;
        private System.Windows.Forms.Label lblPrevColor;
        private System.Windows.Forms.PictureBox ptrRecommendCaptureColor;
        private System.Windows.Forms.Label lblRecommendCaptureColor;
        private System.Windows.Forms.PictureBox ptrRecommendMoveColor;
        private System.Windows.Forms.Label lblRecommendMoveColor;
        private System.Windows.Forms.PictureBox ptrSelectColor;
        private System.Windows.Forms.Label lblSelectColor;
        private System.Windows.Forms.PictureBox ptrDarkColor;
        private System.Windows.Forms.Label lblDarkColor;
        private System.Windows.Forms.PictureBox ptrLightColor;
        private System.Windows.Forms.Label lblColorLight;
        private System.Windows.Forms.Label lblChangeLight;
        private System.Windows.Forms.Label lblChangeDark;
        private System.Windows.Forms.Label lblChangeSelect;
        private System.Windows.Forms.Label lblChangeRecommendMove;
        private System.Windows.Forms.Label lblChangeRecommendCapture;
        private System.Windows.Forms.Label lblChangePrev;
        private System.Windows.Forms.Label lblChangeDes;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDefault;
    }
}