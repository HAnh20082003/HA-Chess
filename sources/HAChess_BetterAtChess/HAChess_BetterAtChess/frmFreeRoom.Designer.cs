
namespace HAChess_BetterAtChess
{
    partial class frmFreeRoom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFreeRoom));
            this.btnBotTime = new System.Windows.Forms.Button();
            this.btnTopTime = new System.Windows.Forms.Button();
            this.pnBotCapturePieces = new System.Windows.Forms.Panel();
            this.pnTopCapturePieces = new System.Windows.Forms.Panel();
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.pnFriends = new System.Windows.Forms.Panel();
            this.lblCountFriends = new System.Windows.Forms.Label();
            this.btnNextFriend = new System.Windows.Forms.Button();
            this.btnReloadFriends = new System.Windows.Forms.Button();
            this.pnPagesFriends = new System.Windows.Forms.Panel();
            this.lblOpponent = new System.Windows.Forms.Label();
            this.btnPrevFriend = new System.Windows.Forms.Button();
            this.fpnFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchOpponent = new System.Windows.Forms.Button();
            this.txtSearchOpponent = new System.Windows.Forms.TextBox();
            this.pnRequestDraw = new System.Windows.Forms.Panel();
            this.lblTimeShowRequestDraw = new System.Windows.Forms.Label();
            this.btnDeclineDraw = new System.Windows.Forms.Button();
            this.btnAcceptDraw = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.fpnNotations = new System.Windows.Forms.FlowLayoutPanel();
            this.pnChat = new System.Windows.Forms.Panel();
            this.rtxChat = new System.Windows.Forms.RichTextBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.pnPromotion = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ptrBishop = new System.Windows.Forms.PictureBox();
            this.ptrKnight = new System.Windows.Forms.PictureBox();
            this.ptrRook = new System.Windows.Forms.PictureBox();
            this.ptrQueen = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnRequestDraw = new System.Windows.Forms.Button();
            this.btnResign = new System.Windows.Forms.Button();
            this.gbInfoChess = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblSignEndGame = new System.Windows.Forms.Label();
            this.lblTypeEndgame = new System.Windows.Forms.Label();
            this.lblStartTurn = new System.Windows.Forms.Label();
            this.cbbRegimes = new System.Windows.Forms.ComboBox();
            this.cbbTypeGame = new System.Windows.Forms.ComboBox();
            this.btnOutRoom = new System.Windows.Forms.Button();
            this.txtFen = new System.Windows.Forms.TextBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.timerChat = new System.Windows.Forms.Timer(this.components);
            this.timerRequestDrawAndResign = new System.Windows.Forms.Timer(this.components);
            this.timerShowRequestDraw = new System.Windows.Forms.Timer(this.components);
            this.timerWaitAcceptOpponent = new System.Windows.Forms.Timer(this.components);
            this.timerWaitRestart = new System.Windows.Forms.Timer(this.components);
            this.timerChangeIndexTypeGameAndRegime = new System.Windows.Forms.Timer(this.components);
            this.btnKickOpponent = new System.Windows.Forms.Button();
            this.timerBeKick = new System.Windows.Forms.Timer(this.components);
            this.timerOutRoom = new System.Windows.Forms.Timer(this.components);
            this.ttPrintFile = new System.Windows.Forms.ToolTip(this.components);
            this.ttReverse = new System.Windows.Forms.ToolTip(this.components);
            this.ttRestart = new System.Windows.Forms.ToolTip(this.components);
            this.ttTypeGame = new System.Windows.Forms.ToolTip(this.components);
            this.ttRegime = new System.Windows.Forms.ToolTip(this.components);
            this.pnFriends.SuspendLayout();
            this.fpnFriends.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnRequestDraw.SuspendLayout();
            this.pnChat.SuspendLayout();
            this.pnPromotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).BeginInit();
            this.gbInfoChess.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBotTime
            // 
            this.btnBotTime.BackColor = System.Drawing.Color.White;
            this.btnBotTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBotTime.FlatAppearance.BorderSize = 3;
            this.btnBotTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotTime.ForeColor = System.Drawing.Color.DimGray;
            this.btnBotTime.Location = new System.Drawing.Point(332, 692);
            this.btnBotTime.Name = "btnBotTime";
            this.btnBotTime.Size = new System.Drawing.Size(158, 41);
            this.btnBotTime.TabIndex = 42;
            this.btnBotTime.Text = "0:00";
            this.btnBotTime.UseVisualStyleBackColor = false;
            // 
            // btnTopTime
            // 
            this.btnTopTime.BackColor = System.Drawing.Color.White;
            this.btnTopTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopTime.FlatAppearance.BorderSize = 3;
            this.btnTopTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopTime.ForeColor = System.Drawing.Color.DimGray;
            this.btnTopTime.Location = new System.Drawing.Point(332, 9);
            this.btnTopTime.Name = "btnTopTime";
            this.btnTopTime.Size = new System.Drawing.Size(158, 41);
            this.btnTopTime.TabIndex = 41;
            this.btnTopTime.Text = "0:00";
            this.btnTopTime.UseVisualStyleBackColor = false;
            // 
            // pnBotCapturePieces
            // 
            this.pnBotCapturePieces.Location = new System.Drawing.Point(610, 692);
            this.pnBotCapturePieces.Name = "pnBotCapturePieces";
            this.pnBotCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnBotCapturePieces.TabIndex = 40;
            // 
            // pnTopCapturePieces
            // 
            this.pnTopCapturePieces.Location = new System.Drawing.Point(610, 9);
            this.pnTopCapturePieces.Name = "pnTopCapturePieces";
            this.pnTopCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnTopCapturePieces.TabIndex = 39;
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(332, 80);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(600, 600);
            this.pnChessBoard.TabIndex = 38;
            // 
            // pnFriends
            // 
            this.pnFriends.BackColor = System.Drawing.Color.Black;
            this.pnFriends.Controls.Add(this.lblCountFriends);
            this.pnFriends.Controls.Add(this.btnNextFriend);
            this.pnFriends.Controls.Add(this.btnReloadFriends);
            this.pnFriends.Controls.Add(this.pnPagesFriends);
            this.pnFriends.Controls.Add(this.lblOpponent);
            this.pnFriends.Controls.Add(this.btnPrevFriend);
            this.pnFriends.Controls.Add(this.fpnFriends);
            this.pnFriends.Controls.Add(this.label1);
            this.pnFriends.Controls.Add(this.btnSearchOpponent);
            this.pnFriends.Controls.Add(this.txtSearchOpponent);
            this.pnFriends.Location = new System.Drawing.Point(19, 278);
            this.pnFriends.Name = "pnFriends";
            this.pnFriends.Size = new System.Drawing.Size(289, 443);
            this.pnFriends.TabIndex = 43;
            // 
            // lblCountFriends
            // 
            this.lblCountFriends.AutoSize = true;
            this.lblCountFriends.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountFriends.ForeColor = System.Drawing.Color.White;
            this.lblCountFriends.Location = new System.Drawing.Point(9, 325);
            this.lblCountFriends.Name = "lblCountFriends";
            this.lblCountFriends.Size = new System.Drawing.Size(103, 19);
            this.lblCountFriends.TabIndex = 64;
            this.lblCountFriends.Text = "Số lượng: 0";
            // 
            // btnNextFriend
            // 
            this.btnNextFriend.BackColor = System.Drawing.Color.White;
            this.btnNextFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextFriend.FlatAppearance.BorderSize = 3;
            this.btnNextFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextFriend.ForeColor = System.Drawing.Color.DimGray;
            this.btnNextFriend.Image = ((System.Drawing.Image)(resources.GetObject("btnNextFriend.Image")));
            this.btnNextFriend.Location = new System.Drawing.Point(221, 378);
            this.btnNextFriend.Name = "btnNextFriend";
            this.btnNextFriend.Size = new System.Drawing.Size(50, 50);
            this.btnNextFriend.TabIndex = 6;
            this.btnNextFriend.UseVisualStyleBackColor = false;
            // 
            // btnReloadFriends
            // 
            this.btnReloadFriends.BackColor = System.Drawing.Color.Transparent;
            this.btnReloadFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReloadFriends.FlatAppearance.BorderSize = 3;
            this.btnReloadFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadFriends.ForeColor = System.Drawing.Color.DarkGray;
            this.btnReloadFriends.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadFriends.Image")));
            this.btnReloadFriends.Location = new System.Drawing.Point(221, 321);
            this.btnReloadFriends.Name = "btnReloadFriends";
            this.btnReloadFriends.Size = new System.Drawing.Size(50, 50);
            this.btnReloadFriends.TabIndex = 65;
            this.btnReloadFriends.UseVisualStyleBackColor = false;
            this.btnReloadFriends.Click += new System.EventHandler(this.btnReloadFriends_Click);
            // 
            // pnPagesFriends
            // 
            this.pnPagesFriends.Location = new System.Drawing.Point(63, 378);
            this.pnPagesFriends.Name = "pnPagesFriends";
            this.pnPagesFriends.Size = new System.Drawing.Size(146, 50);
            this.pnPagesFriends.TabIndex = 4;
            // 
            // lblOpponent
            // 
            this.lblOpponent.AutoSize = true;
            this.lblOpponent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponent.ForeColor = System.Drawing.Color.White;
            this.lblOpponent.Location = new System.Drawing.Point(9, 82);
            this.lblOpponent.Name = "lblOpponent";
            this.lblOpponent.Size = new System.Drawing.Size(66, 19);
            this.lblOpponent.TabIndex = 13;
            this.lblOpponent.Text = "Đối thủ";
            // 
            // btnPrevFriend
            // 
            this.btnPrevFriend.BackColor = System.Drawing.Color.White;
            this.btnPrevFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevFriend.FlatAppearance.BorderSize = 3;
            this.btnPrevFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevFriend.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrevFriend.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevFriend.Image")));
            this.btnPrevFriend.Location = new System.Drawing.Point(7, 378);
            this.btnPrevFriend.Name = "btnPrevFriend";
            this.btnPrevFriend.Size = new System.Drawing.Size(50, 50);
            this.btnPrevFriend.TabIndex = 5;
            this.btnPrevFriend.UseVisualStyleBackColor = false;
            // 
            // fpnFriends
            // 
            this.fpnFriends.Controls.Add(this.panel1);
            this.fpnFriends.Controls.Add(this.panel2);
            this.fpnFriends.Location = new System.Drawing.Point(7, 113);
            this.fpnFriends.Name = "fpnFriends";
            this.fpnFriends.Size = new System.Drawing.Size(276, 204);
            this.fpnFriends.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 93);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(73, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 32);
            this.label5.TabIndex = 21;
            this.label5.Text = "Bạn bè";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(9, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 22;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(3, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 93);
            this.panel2.TabIndex = 24;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.DimGray;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(73, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 23;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(5, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 32);
            this.label6.TabIndex = 21;
            this.label6.Text = "Bạn bè";
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.DimGray;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(9, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 22;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nhập tên # ID đối thủ";
            // 
            // btnSearchOpponent
            // 
            this.btnSearchOpponent.BackColor = System.Drawing.Color.White;
            this.btnSearchOpponent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchOpponent.FlatAppearance.BorderSize = 3;
            this.btnSearchOpponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchOpponent.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchOpponent.Location = new System.Drawing.Point(180, 39);
            this.btnSearchOpponent.Name = "btnSearchOpponent";
            this.btnSearchOpponent.Size = new System.Drawing.Size(96, 33);
            this.btnSearchOpponent.TabIndex = 19;
            this.btnSearchOpponent.Text = "Mời";
            this.btnSearchOpponent.UseVisualStyleBackColor = false;
            this.btnSearchOpponent.Click += new System.EventHandler(this.btnSearchOpponent_Click);
            // 
            // txtSearchOpponent
            // 
            this.txtSearchOpponent.Location = new System.Drawing.Point(7, 43);
            this.txtSearchOpponent.Name = "txtSearchOpponent";
            this.txtSearchOpponent.Size = new System.Drawing.Size(167, 27);
            this.txtSearchOpponent.TabIndex = 18;
            this.txtSearchOpponent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchOpponent_KeyDown);
            // 
            // pnRequestDraw
            // 
            this.pnRequestDraw.Controls.Add(this.lblTimeShowRequestDraw);
            this.pnRequestDraw.Controls.Add(this.btnDeclineDraw);
            this.pnRequestDraw.Controls.Add(this.btnAcceptDraw);
            this.pnRequestDraw.Controls.Add(this.label3);
            this.pnRequestDraw.Location = new System.Drawing.Point(963, 298);
            this.pnRequestDraw.Name = "pnRequestDraw";
            this.pnRequestDraw.Size = new System.Drawing.Size(304, 111);
            this.pnRequestDraw.TabIndex = 44;
            this.pnRequestDraw.Visible = false;
            // 
            // lblTimeShowRequestDraw
            // 
            this.lblTimeShowRequestDraw.AutoSize = true;
            this.lblTimeShowRequestDraw.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeShowRequestDraw.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblTimeShowRequestDraw.Location = new System.Drawing.Point(27, 90);
            this.lblTimeShowRequestDraw.Name = "lblTimeShowRequestDraw";
            this.lblTimeShowRequestDraw.Size = new System.Drawing.Size(42, 19);
            this.lblTimeShowRequestDraw.TabIndex = 36;
            this.lblTimeShowRequestDraw.Text = "0:00";
            // 
            // btnDeclineDraw
            // 
            this.btnDeclineDraw.BackColor = System.Drawing.Color.Crimson;
            this.btnDeclineDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeclineDraw.FlatAppearance.BorderSize = 3;
            this.btnDeclineDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeclineDraw.ForeColor = System.Drawing.Color.Black;
            this.btnDeclineDraw.Location = new System.Drawing.Point(174, 39);
            this.btnDeclineDraw.Name = "btnDeclineDraw";
            this.btnDeclineDraw.Size = new System.Drawing.Size(117, 41);
            this.btnDeclineDraw.TabIndex = 35;
            this.btnDeclineDraw.Text = "Từ chối";
            this.btnDeclineDraw.UseVisualStyleBackColor = false;
            this.btnDeclineDraw.Click += new System.EventHandler(this.btnDeclineDraw_Click);
            // 
            // btnAcceptDraw
            // 
            this.btnAcceptDraw.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAcceptDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptDraw.FlatAppearance.BorderSize = 3;
            this.btnAcceptDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptDraw.ForeColor = System.Drawing.Color.Black;
            this.btnAcceptDraw.Location = new System.Drawing.Point(27, 39);
            this.btnAcceptDraw.Name = "btnAcceptDraw";
            this.btnAcceptDraw.Size = new System.Drawing.Size(117, 41);
            this.btnAcceptDraw.TabIndex = 34;
            this.btnAcceptDraw.Text = "Chấp nhận";
            this.btnAcceptDraw.UseVisualStyleBackColor = false;
            this.btnAcceptDraw.Click += new System.EventHandler(this.btnAcceptDraw_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đối thủ muốn hoà cờ với bạn";
            // 
            // fpnNotations
            // 
            this.fpnNotations.AutoScroll = true;
            this.fpnNotations.Location = new System.Drawing.Point(963, 436);
            this.fpnNotations.Name = "fpnNotations";
            this.fpnNotations.Size = new System.Drawing.Size(304, 164);
            this.fpnNotations.TabIndex = 45;
            // 
            // pnChat
            // 
            this.pnChat.Controls.Add(this.rtxChat);
            this.pnChat.Controls.Add(this.btnSendChat);
            this.pnChat.Controls.Add(this.txtChat);
            this.pnChat.Location = new System.Drawing.Point(963, 619);
            this.pnChat.Name = "pnChat";
            this.pnChat.Size = new System.Drawing.Size(330, 244);
            this.pnChat.TabIndex = 35;
            this.pnChat.Visible = false;
            // 
            // rtxChat
            // 
            this.rtxChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxChat.Location = new System.Drawing.Point(5, 3);
            this.rtxChat.Name = "rtxChat";
            this.rtxChat.ReadOnly = true;
            this.rtxChat.Size = new System.Drawing.Size(304, 153);
            this.rtxChat.TabIndex = 37;
            this.rtxChat.Text = "";
            // 
            // btnSendChat
            // 
            this.btnSendChat.BackColor = System.Drawing.Color.Beige;
            this.btnSendChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendChat.FlatAppearance.BorderSize = 3;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChat.ForeColor = System.Drawing.Color.Olive;
            this.btnSendChat.Location = new System.Drawing.Point(254, 162);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(55, 44);
            this.btnSendChat.TabIndex = 36;
            this.btnSendChat.Text = "Gửi";
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(5, 162);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(243, 75);
            this.txtChat.TabIndex = 34;
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            // 
            // pnPromotion
            // 
            this.pnPromotion.Controls.Add(this.label2);
            this.pnPromotion.Controls.Add(this.ptrBishop);
            this.pnPromotion.Controls.Add(this.ptrKnight);
            this.pnPromotion.Controls.Add(this.ptrRook);
            this.pnPromotion.Controls.Add(this.ptrQueen);
            this.pnPromotion.Location = new System.Drawing.Point(945, 9);
            this.pnPromotion.Name = "pnPromotion";
            this.pnPromotion.Size = new System.Drawing.Size(403, 136);
            this.pnPromotion.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Phong cấp";
            // 
            // ptrBishop
            // 
            this.ptrBishop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptrBishop.Location = new System.Drawing.Point(315, 48);
            this.ptrBishop.Name = "ptrBishop";
            this.ptrBishop.Size = new System.Drawing.Size(80, 80);
            this.ptrBishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrBishop.TabIndex = 3;
            this.ptrBishop.TabStop = false;
            this.ptrBishop.Click += new System.EventHandler(this.selectPromotion);
            // 
            // ptrKnight
            // 
            this.ptrKnight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptrKnight.Location = new System.Drawing.Point(211, 48);
            this.ptrKnight.Name = "ptrKnight";
            this.ptrKnight.Size = new System.Drawing.Size(80, 80);
            this.ptrKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrKnight.TabIndex = 2;
            this.ptrKnight.TabStop = false;
            this.ptrKnight.Click += new System.EventHandler(this.selectPromotion);
            // 
            // ptrRook
            // 
            this.ptrRook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptrRook.Location = new System.Drawing.Point(107, 48);
            this.ptrRook.Name = "ptrRook";
            this.ptrRook.Size = new System.Drawing.Size(80, 80);
            this.ptrRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrRook.TabIndex = 1;
            this.ptrRook.TabStop = false;
            this.ptrRook.Click += new System.EventHandler(this.selectPromotion);
            // 
            // ptrQueen
            // 
            this.ptrQueen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptrQueen.Location = new System.Drawing.Point(5, 48);
            this.ptrQueen.Name = "ptrQueen";
            this.ptrQueen.Size = new System.Drawing.Size(80, 80);
            this.ptrQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrQueen.TabIndex = 0;
            this.ptrQueen.TabStop = false;
            this.ptrQueen.Click += new System.EventHandler(this.selectPromotion);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 3;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(1104, 217);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 60);
            this.btnPrint.TabIndex = 42;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.FlatAppearance.BorderSize = 3;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.ForeColor = System.Drawing.Color.DimGray;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(945, 217);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(60, 60);
            this.btnReverse.TabIndex = 41;
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnRequestDraw
            // 
            this.btnRequestDraw.BackColor = System.Drawing.Color.Lavender;
            this.btnRequestDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestDraw.FlatAppearance.BorderSize = 3;
            this.btnRequestDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestDraw.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnRequestDraw.Location = new System.Drawing.Point(1133, 161);
            this.btnRequestDraw.Name = "btnRequestDraw";
            this.btnRequestDraw.Size = new System.Drawing.Size(158, 41);
            this.btnRequestDraw.TabIndex = 48;
            this.btnRequestDraw.Text = "Yêu cầu hoà";
            this.btnRequestDraw.UseVisualStyleBackColor = false;
            this.btnRequestDraw.Visible = false;
            this.btnRequestDraw.Click += new System.EventHandler(this.btnRequestDraw_Click);
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnResign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResign.FlatAppearance.BorderSize = 3;
            this.btnResign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResign.ForeColor = System.Drawing.Color.Crimson;
            this.btnResign.Location = new System.Drawing.Point(945, 161);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(158, 41);
            this.btnResign.TabIndex = 47;
            this.btnResign.Text = "Đầu hàng";
            this.btnResign.UseVisualStyleBackColor = false;
            this.btnResign.Visible = false;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // gbInfoChess
            // 
            this.gbInfoChess.BackColor = System.Drawing.Color.White;
            this.gbInfoChess.Controls.Add(this.lblResult);
            this.gbInfoChess.Controls.Add(this.lblTurn);
            this.gbInfoChess.Controls.Add(this.lblSignEndGame);
            this.gbInfoChess.Controls.Add(this.lblTypeEndgame);
            this.gbInfoChess.Controls.Add(this.lblStartTurn);
            this.gbInfoChess.Location = new System.Drawing.Point(19, 57);
            this.gbInfoChess.Name = "gbInfoChess";
            this.gbInfoChess.Size = new System.Drawing.Size(289, 204);
            this.gbInfoChess.TabIndex = 49;
            this.gbInfoChess.TabStop = false;
            this.gbInfoChess.Text = "Thông tin ván đấu";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResult.Location = new System.Drawing.Point(6, 138);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(76, 19);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "Kết quả:";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.Crimson;
            this.lblTurn.Location = new System.Drawing.Point(3, 170);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(129, 19);
            this.lblTurn.TabIndex = 8;
            this.lblTurn.Text = "Lượt của trắng";
            // 
            // lblSignEndGame
            // 
            this.lblSignEndGame.AutoSize = true;
            this.lblSignEndGame.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignEndGame.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSignEndGame.Location = new System.Drawing.Point(6, 99);
            this.lblSignEndGame.Name = "lblSignEndGame";
            this.lblSignEndGame.Size = new System.Drawing.Size(69, 19);
            this.lblSignEndGame.TabIndex = 11;
            this.lblSignEndGame.Text = "Kí hiệu:";
            // 
            // lblTypeEndgame
            // 
            this.lblTypeEndgame.AutoSize = true;
            this.lblTypeEndgame.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeEndgame.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTypeEndgame.Location = new System.Drawing.Point(6, 60);
            this.lblTypeEndgame.Name = "lblTypeEndgame";
            this.lblTypeEndgame.Size = new System.Drawing.Size(117, 19);
            this.lblTypeEndgame.TabIndex = 10;
            this.lblTypeEndgame.Text = "Loại kết thúc:";
            // 
            // lblStartTurn
            // 
            this.lblStartTurn.AutoSize = true;
            this.lblStartTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTurn.Location = new System.Drawing.Point(6, 32);
            this.lblStartTurn.Name = "lblStartTurn";
            this.lblStartTurn.Size = new System.Drawing.Size(139, 19);
            this.lblStartTurn.TabIndex = 9;
            this.lblStartTurn.Text = "Lược đầu: trắng";
            // 
            // cbbRegimes
            // 
            this.cbbRegimes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbRegimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRegimes.FormattingEnabled = true;
            this.cbbRegimes.Location = new System.Drawing.Point(19, 779);
            this.cbbRegimes.Name = "cbbRegimes";
            this.cbbRegimes.Size = new System.Drawing.Size(289, 27);
            this.cbbRegimes.TabIndex = 51;
            this.cbbRegimes.SelectedIndexChanged += new System.EventHandler(this.cbbRegimes_SelectedIndexChanged);
            // 
            // cbbTypeGame
            // 
            this.cbbTypeGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTypeGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTypeGame.FormattingEnabled = true;
            this.cbbTypeGame.Location = new System.Drawing.Point(19, 737);
            this.cbbTypeGame.Name = "cbbTypeGame";
            this.cbbTypeGame.Size = new System.Drawing.Size(289, 27);
            this.cbbTypeGame.TabIndex = 50;
            this.cbbTypeGame.SelectedIndexChanged += new System.EventHandler(this.cbbTypeGame_SelectedIndexChanged);
            // 
            // btnOutRoom
            // 
            this.btnOutRoom.BackColor = System.Drawing.Color.HotPink;
            this.btnOutRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutRoom.FlatAppearance.BorderSize = 3;
            this.btnOutRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutRoom.ForeColor = System.Drawing.Color.Black;
            this.btnOutRoom.Location = new System.Drawing.Point(19, 822);
            this.btnOutRoom.Name = "btnOutRoom";
            this.btnOutRoom.Size = new System.Drawing.Size(112, 41);
            this.btnOutRoom.TabIndex = 52;
            this.btnOutRoom.Text = "Rời phòng";
            this.btnOutRoom.UseVisualStyleBackColor = false;
            this.btnOutRoom.Visible = false;
            this.btnOutRoom.Click += new System.EventHandler(this.btnOutRoom_Click);
            // 
            // txtFen
            // 
            this.txtFen.Location = new System.Drawing.Point(610, 779);
            this.txtFen.Multiline = true;
            this.txtFen.Name = "txtFen";
            this.txtFen.Size = new System.Drawing.Size(322, 50);
            this.txtFen.TabIndex = 53;
            this.txtFen.TextChanged += new System.EventHandler(this.txtFen_TextChanged);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatAppearance.BorderSize = 3;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.ForeColor = System.Drawing.Color.DimGray;
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.Location = new System.Drawing.Point(1027, 217);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(60, 60);
            this.btnRestart.TabIndex = 54;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 29);
            this.label4.TabIndex = 55;
            this.label4.Text = "Phòng của tôi";
            // 
            // timerMove
            // 
            this.timerMove.Interval = 200;
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            // 
            // timerChat
            // 
            this.timerChat.Interval = 500;
            this.timerChat.Tick += new System.EventHandler(this.timerChat_Tick);
            // 
            // timerRequestDrawAndResign
            // 
            this.timerRequestDrawAndResign.Interval = 200;
            this.timerRequestDrawAndResign.Tick += new System.EventHandler(this.timerRequestDrawAndResign_Tick);
            // 
            // timerShowRequestDraw
            // 
            this.timerShowRequestDraw.Interval = 1000;
            this.timerShowRequestDraw.Tick += new System.EventHandler(this.timerShowRequestDraw_Tick);
            // 
            // timerWaitAcceptOpponent
            // 
            this.timerWaitAcceptOpponent.Interval = 200;
            this.timerWaitAcceptOpponent.Tick += new System.EventHandler(this.timerWaitAcceptOpponent_Tick);
            // 
            // timerWaitRestart
            // 
            this.timerWaitRestart.Interval = 200;
            this.timerWaitRestart.Tick += new System.EventHandler(this.timerWaitRestart_Tick);
            // 
            // timerChangeIndexTypeGameAndRegime
            // 
            this.timerChangeIndexTypeGameAndRegime.Interval = 200;
            this.timerChangeIndexTypeGameAndRegime.Tick += new System.EventHandler(this.timerChangeIndexTypeGameAndRegime_Tick);
            // 
            // btnKickOpponent
            // 
            this.btnKickOpponent.BackColor = System.Drawing.Color.Crimson;
            this.btnKickOpponent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKickOpponent.FlatAppearance.BorderSize = 3;
            this.btnKickOpponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKickOpponent.ForeColor = System.Drawing.Color.Black;
            this.btnKickOpponent.Location = new System.Drawing.Point(181, 822);
            this.btnKickOpponent.Name = "btnKickOpponent";
            this.btnKickOpponent.Size = new System.Drawing.Size(127, 41);
            this.btnKickOpponent.TabIndex = 56;
            this.btnKickOpponent.Text = "Đuổi đối thủ";
            this.btnKickOpponent.UseVisualStyleBackColor = false;
            this.btnKickOpponent.Visible = false;
            this.btnKickOpponent.Click += new System.EventHandler(this.btnKickOpponent_Click);
            // 
            // timerBeKick
            // 
            this.timerBeKick.Interval = 200;
            this.timerBeKick.Tick += new System.EventHandler(this.timerBeKick_Tick);
            // 
            // timerOutRoom
            // 
            this.timerOutRoom.Interval = 200;
            this.timerOutRoom.Tick += new System.EventHandler(this.timerOutRoom_Tick);
            // 
            // ttPrintFile
            // 
            this.ttPrintFile.ToolTipTitle = "Lưu trận đấu thành file *.txt";
            // 
            // ttReverse
            // 
            this.ttReverse.ToolTipTitle = "Lật ngược bàn cờ";
            // 
            // ttRestart
            // 
            this.ttRestart.ToolTipTitle = "Bắt đầu lại";
            // 
            // ttTypeGame
            // 
            this.ttTypeGame.ToolTipTitle = "Lựa chọn chế độ";
            // 
            // ttRegime
            // 
            this.ttRegime.ToolTipTitle = "Lựa chọn chế độ thời gian";
            // 
            // frmFreeRoom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1356, 875);
            this.Controls.Add(this.btnKickOpponent);
            this.Controls.Add(this.gbInfoChess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.txtFen);
            this.Controls.Add(this.btnOutRoom);
            this.Controls.Add(this.cbbRegimes);
            this.Controls.Add(this.cbbTypeGame);
            this.Controls.Add(this.btnRequestDraw);
            this.Controls.Add(this.btnResign);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnPromotion);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.pnFriends);
            this.Controls.Add(this.fpnNotations);
            this.Controls.Add(this.pnRequestDraw);
            this.Controls.Add(this.pnChat);
            this.Controls.Add(this.btnBotTime);
            this.Controls.Add(this.btnTopTime);
            this.Controls.Add(this.pnBotCapturePieces);
            this.Controls.Add(this.pnTopCapturePieces);
            this.Controls.Add(this.pnChessBoard);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFreeRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFreeRoom";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFreeRoom_KeyDown);
            this.pnFriends.ResumeLayout(false);
            this.pnFriends.PerformLayout();
            this.fpnFriends.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnRequestDraw.ResumeLayout(false);
            this.pnRequestDraw.PerformLayout();
            this.pnChat.ResumeLayout(false);
            this.pnChat.PerformLayout();
            this.pnPromotion.ResumeLayout(false);
            this.pnPromotion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).EndInit();
            this.gbInfoChess.ResumeLayout(false);
            this.gbInfoChess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBotTime;
        private System.Windows.Forms.Button btnTopTime;
        private System.Windows.Forms.Panel pnBotCapturePieces;
        private System.Windows.Forms.Panel pnTopCapturePieces;
        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.Panel pnFriends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchOpponent;
        private System.Windows.Forms.TextBox txtSearchOpponent;
        private System.Windows.Forms.Panel pnRequestDraw;
        private System.Windows.Forms.Label lblTimeShowRequestDraw;
        private System.Windows.Forms.Button btnDeclineDraw;
        private System.Windows.Forms.Button btnAcceptDraw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel fpnNotations;
        private System.Windows.Forms.Panel pnChat;
        private System.Windows.Forms.RichTextBox rtxChat;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Panel pnPromotion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptrBishop;
        private System.Windows.Forms.PictureBox ptrKnight;
        private System.Windows.Forms.PictureBox ptrRook;
        private System.Windows.Forms.PictureBox ptrQueen;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnRequestDraw;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.GroupBox gbInfoChess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblSignEndGame;
        private System.Windows.Forms.Label lblTypeEndgame;
        private System.Windows.Forms.Label lblStartTurn;
        private System.Windows.Forms.ComboBox cbbRegimes;
        private System.Windows.Forms.ComboBox cbbTypeGame;
        private System.Windows.Forms.Button btnOutRoom;
        private System.Windows.Forms.TextBox txtFen;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.Timer timerChat;
        private System.Windows.Forms.Timer timerRequestDrawAndResign;
        private System.Windows.Forms.Timer timerShowRequestDraw;
        private System.Windows.Forms.Timer timerWaitAcceptOpponent;
        private System.Windows.Forms.Label lblOpponent;
        private System.Windows.Forms.FlowLayoutPanel fpnFriends;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnNextFriend;
        private System.Windows.Forms.Panel pnPagesFriends;
        private System.Windows.Forms.Button btnPrevFriend;
        private System.Windows.Forms.Label lblCountFriends;
        private System.Windows.Forms.Button btnReloadFriends;
        private System.Windows.Forms.Timer timerWaitRestart;
        private System.Windows.Forms.Timer timerChangeIndexTypeGameAndRegime;
        private System.Windows.Forms.Button btnKickOpponent;
        private System.Windows.Forms.Timer timerBeKick;
        private System.Windows.Forms.Timer timerOutRoom;
        private System.Windows.Forms.ToolTip ttPrintFile;
        private System.Windows.Forms.ToolTip ttReverse;
        private System.Windows.Forms.ToolTip ttRestart;
        private System.Windows.Forms.ToolTip ttTypeGame;
        private System.Windows.Forms.ToolTip ttRegime;
    }
}