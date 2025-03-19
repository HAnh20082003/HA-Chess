
namespace HAChess_BetterAtChess
{
    partial class frmBot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBot));
            this.btnBotTime = new System.Windows.Forms.Button();
            this.btnTopTime = new System.Windows.Forms.Button();
            this.pnBotCapturePieces = new System.Windows.Forms.Panel();
            this.pnTopCapturePieces = new System.Windows.Forms.Panel();
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.fpnNotations = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInfoChess = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblSignEndGame = new System.Windows.Forms.Label();
            this.lblTypeEndgame = new System.Windows.Forms.Label();
            this.lblStartTurn = new System.Windows.Forms.Label();
            this.pnPromotion = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ptrBishop = new System.Windows.Forms.PictureBox();
            this.ptrKnight = new System.Windows.Forms.PictureBox();
            this.ptrRook = new System.Windows.Forms.PictureBox();
            this.ptrQueen = new System.Windows.Forms.PictureBox();
            this.cbbTypeGame = new System.Windows.Forms.ComboBox();
            this.btnResign = new System.Windows.Forms.Button();
            this.cbbRegimes = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNameWhite = new System.Windows.Forms.Label();
            this.ptrWhite = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblNameBlack = new System.Windows.Forms.Label();
            this.ptrBlack = new System.Windows.Forms.PictureBox();
            this.cbbWhite = new System.Windows.Forms.ComboBox();
            this.cbbBlack = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ttRestart = new System.Windows.Forms.ToolTip(this.components);
            this.ttReverse = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrintFile = new System.Windows.Forms.ToolTip(this.components);
            this.timerWaitSetup = new System.Windows.Forms.Timer(this.components);
            this.ttCbbWhite = new System.Windows.Forms.ToolTip(this.components);
            this.ttCbbBlack = new System.Windows.Forms.ToolTip(this.components);
            this.txtFen = new System.Windows.Forms.TextBox();
            this.gbInfoChess.SuspendLayout();
            this.pnPromotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrWhite)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBlack)).BeginInit();
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
            this.btnBotTime.Location = new System.Drawing.Point(311, 700);
            this.btnBotTime.Name = "btnBotTime";
            this.btnBotTime.Size = new System.Drawing.Size(136, 41);
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
            this.btnTopTime.Location = new System.Drawing.Point(311, 19);
            this.btnTopTime.Name = "btnTopTime";
            this.btnTopTime.Size = new System.Drawing.Size(136, 41);
            this.btnTopTime.TabIndex = 41;
            this.btnTopTime.Text = "0:00";
            this.btnTopTime.UseVisualStyleBackColor = false;
            // 
            // pnBotCapturePieces
            // 
            this.pnBotCapturePieces.Location = new System.Drawing.Point(589, 700);
            this.pnBotCapturePieces.Name = "pnBotCapturePieces";
            this.pnBotCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnBotCapturePieces.TabIndex = 40;
            // 
            // pnTopCapturePieces
            // 
            this.pnTopCapturePieces.Location = new System.Drawing.Point(589, 14);
            this.pnTopCapturePieces.Name = "pnTopCapturePieces";
            this.pnTopCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnTopCapturePieces.TabIndex = 39;
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(311, 89);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(600, 600);
            this.pnChessBoard.TabIndex = 38;
            // 
            // fpnNotations
            // 
            this.fpnNotations.AutoScroll = true;
            this.fpnNotations.Location = new System.Drawing.Point(973, 629);
            this.fpnNotations.Name = "fpnNotations";
            this.fpnNotations.Size = new System.Drawing.Size(304, 216);
            this.fpnNotations.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 19);
            this.label1.TabIndex = 49;
            this.label1.Text = "Chess engine bot";
            // 
            // gbInfoChess
            // 
            this.gbInfoChess.BackColor = System.Drawing.Color.White;
            this.gbInfoChess.Controls.Add(this.lblResult);
            this.gbInfoChess.Controls.Add(this.lblTurn);
            this.gbInfoChess.Controls.Add(this.lblSignEndGame);
            this.gbInfoChess.Controls.Add(this.lblTypeEndgame);
            this.gbInfoChess.Controls.Add(this.lblStartTurn);
            this.gbInfoChess.Location = new System.Drawing.Point(973, 162);
            this.gbInfoChess.Name = "gbInfoChess";
            this.gbInfoChess.Size = new System.Drawing.Size(304, 227);
            this.gbInfoChess.TabIndex = 50;
            this.gbInfoChess.TabStop = false;
            this.gbInfoChess.Text = "Thông tin ván đấu";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResult.Location = new System.Drawing.Point(6, 139);
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
            this.lblTurn.Location = new System.Drawing.Point(6, 182);
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
            this.lblSignEndGame.Location = new System.Drawing.Point(6, 100);
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
            this.lblTypeEndgame.Location = new System.Drawing.Point(6, 61);
            this.lblTypeEndgame.Name = "lblTypeEndgame";
            this.lblTypeEndgame.Size = new System.Drawing.Size(117, 19);
            this.lblTypeEndgame.TabIndex = 10;
            this.lblTypeEndgame.Text = "Loại kết thúc:";
            // 
            // lblStartTurn
            // 
            this.lblStartTurn.AutoSize = true;
            this.lblStartTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTurn.Location = new System.Drawing.Point(6, 33);
            this.lblStartTurn.Name = "lblStartTurn";
            this.lblStartTurn.Size = new System.Drawing.Size(139, 19);
            this.lblStartTurn.TabIndex = 9;
            this.lblStartTurn.Text = "Lược đầu: trắng";
            // 
            // pnPromotion
            // 
            this.pnPromotion.Controls.Add(this.label3);
            this.pnPromotion.Controls.Add(this.ptrBishop);
            this.pnPromotion.Controls.Add(this.ptrKnight);
            this.pnPromotion.Controls.Add(this.ptrRook);
            this.pnPromotion.Controls.Add(this.ptrQueen);
            this.pnPromotion.Location = new System.Drawing.Point(920, 14);
            this.pnPromotion.Name = "pnPromotion";
            this.pnPromotion.Size = new System.Drawing.Size(407, 136);
            this.pnPromotion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Phong cấp";
            // 
            // ptrBishop
            // 
            this.ptrBishop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptrBishop.Location = new System.Drawing.Point(323, 45);
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
            this.ptrKnight.Location = new System.Drawing.Point(219, 45);
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
            this.ptrRook.Location = new System.Drawing.Point(115, 45);
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
            this.ptrQueen.Location = new System.Drawing.Point(13, 45);
            this.ptrQueen.Name = "ptrQueen";
            this.ptrQueen.Size = new System.Drawing.Size(80, 80);
            this.ptrQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrQueen.TabIndex = 0;
            this.ptrQueen.TabStop = false;
            this.ptrQueen.Click += new System.EventHandler(this.selectPromotion);
            // 
            // cbbTypeGame
            // 
            this.cbbTypeGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTypeGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTypeGame.FormattingEnabled = true;
            this.cbbTypeGame.Location = new System.Drawing.Point(973, 522);
            this.cbbTypeGame.Name = "cbbTypeGame";
            this.cbbTypeGame.Size = new System.Drawing.Size(304, 27);
            this.cbbTypeGame.TabIndex = 52;
            this.cbbTypeGame.SelectedIndexChanged += new System.EventHandler(this.cbbTypeGame_SelectedIndexChanged);
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnResign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResign.FlatAppearance.BorderSize = 3;
            this.btnResign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResign.ForeColor = System.Drawing.Color.Crimson;
            this.btnResign.Location = new System.Drawing.Point(973, 438);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(146, 41);
            this.btnResign.TabIndex = 53;
            this.btnResign.Text = "Đầu hàng";
            this.btnResign.UseVisualStyleBackColor = false;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // cbbRegimes
            // 
            this.cbbRegimes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbRegimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRegimes.FormattingEnabled = true;
            this.cbbRegimes.Location = new System.Drawing.Point(973, 572);
            this.cbbRegimes.Name = "cbbRegimes";
            this.cbbRegimes.Size = new System.Drawing.Size(304, 27);
            this.cbbRegimes.TabIndex = 54;
            this.cbbRegimes.SelectedIndexChanged += new System.EventHandler(this.cbbRegimes_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNameWhite);
            this.panel3.Controls.Add(this.ptrWhite);
            this.panel3.Location = new System.Drawing.Point(16, 128);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 136);
            this.panel3.TabIndex = 52;
            // 
            // lblNameWhite
            // 
            this.lblNameWhite.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameWhite.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNameWhite.Location = new System.Drawing.Point(118, 13);
            this.lblNameWhite.Name = "lblNameWhite";
            this.lblNameWhite.Size = new System.Drawing.Size(159, 54);
            this.lblNameWhite.TabIndex = 49;
            this.lblNameWhite.Text = "Số lượng: 0";
            // 
            // ptrWhite
            // 
            this.ptrWhite.Image = ((System.Drawing.Image)(resources.GetObject("ptrWhite.Image")));
            this.ptrWhite.Location = new System.Drawing.Point(12, 13);
            this.ptrWhite.Name = "ptrWhite";
            this.ptrWhite.Size = new System.Drawing.Size(100, 100);
            this.ptrWhite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrWhite.TabIndex = 0;
            this.ptrWhite.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblNameBlack);
            this.panel4.Controls.Add(this.ptrBlack);
            this.panel4.Location = new System.Drawing.Point(16, 357);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 136);
            this.panel4.TabIndex = 53;
            // 
            // lblNameBlack
            // 
            this.lblNameBlack.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameBlack.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNameBlack.Location = new System.Drawing.Point(118, 13);
            this.lblNameBlack.Name = "lblNameBlack";
            this.lblNameBlack.Size = new System.Drawing.Size(159, 54);
            this.lblNameBlack.TabIndex = 49;
            this.lblNameBlack.Text = "Số lượng: 0";
            // 
            // ptrBlack
            // 
            this.ptrBlack.Image = ((System.Drawing.Image)(resources.GetObject("ptrBlack.Image")));
            this.ptrBlack.Location = new System.Drawing.Point(12, 13);
            this.ptrBlack.Name = "ptrBlack";
            this.ptrBlack.Size = new System.Drawing.Size(100, 100);
            this.ptrBlack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrBlack.TabIndex = 0;
            this.ptrBlack.TabStop = false;
            // 
            // cbbWhite
            // 
            this.cbbWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbWhite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWhite.FormattingEnabled = true;
            this.cbbWhite.Location = new System.Drawing.Point(16, 281);
            this.cbbWhite.Name = "cbbWhite";
            this.cbbWhite.Size = new System.Drawing.Size(280, 27);
            this.cbbWhite.TabIndex = 57;
            this.cbbWhite.SelectedIndexChanged += new System.EventHandler(this.cbbWhite_SelectedIndexChanged);
            // 
            // cbbBlack
            // 
            this.cbbBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbBlack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBlack.FormattingEnabled = true;
            this.cbbBlack.Location = new System.Drawing.Point(16, 508);
            this.cbbBlack.Name = "cbbBlack";
            this.cbbBlack.Size = new System.Drawing.Size(280, 27);
            this.cbbBlack.TabIndex = 58;
            this.cbbBlack.SelectedIndexChanged += new System.EventHandler(this.cbbBlack_SelectedIndexChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatAppearance.BorderSize = 3;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.Color.Blue;
            this.btnAccept.Location = new System.Drawing.Point(16, 570);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(280, 41);
            this.btnAccept.TabIndex = 59;
            this.btnAccept.Text = "Thiết lập";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 29);
            this.label2.TabIndex = 60;
            this.label2.Text = "Trận chiến engine";
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.White;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.FlatAppearance.BorderSize = 3;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.ForeColor = System.Drawing.Color.DimGray;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(118, 630);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(70, 70);
            this.btnReverse.TabIndex = 19;
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.White;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatAppearance.BorderSize = 3;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.ForeColor = System.Drawing.Color.DimGray;
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.Location = new System.Drawing.Point(17, 630);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(70, 70);
            this.btnRestart.TabIndex = 17;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 3;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(224, 630);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 70);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(13, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cờ trắng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(13, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 61;
            this.label5.Text = "Cờ đen";
            // 
            // ttRestart
            // 
            this.ttRestart.ToolTipTitle = "Bắt đầu lại";
            // 
            // ttReverse
            // 
            this.ttReverse.ToolTipTitle = "Lật ngược bàn cờ";
            // 
            // ttPrintFile
            // 
            this.ttPrintFile.ToolTipTitle = "Lưu trận đấu thành file *.txt";
            // 
            // timerWaitSetup
            // 
            this.timerWaitSetup.Interval = 1000;
            this.timerWaitSetup.Tick += new System.EventHandler(this.timerWaitSetup_Tick);
            // 
            // ttCbbWhite
            // 
            this.ttCbbWhite.ToolTipTitle = "Lựa chọn người chơi cầm quân trắng";
            // 
            // ttCbbBlack
            // 
            this.ttCbbBlack.ToolTipTitle = "Lựa chọn người chơi cầm quân đen";
            // 
            // txtFen
            // 
            this.txtFen.Location = new System.Drawing.Point(311, 788);
            this.txtFen.Multiline = true;
            this.txtFen.Name = "txtFen";
            this.txtFen.Size = new System.Drawing.Size(600, 47);
            this.txtFen.TabIndex = 62;
            this.txtFen.TextChanged += new System.EventHandler(this.txtFen_TextChanged);
            // 
            // frmBot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1330, 867);
            this.Controls.Add(this.txtFen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cbbBlack);
            this.Controls.Add(this.cbbWhite);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cbbRegimes);
            this.Controls.Add(this.btnResign);
            this.Controls.Add(this.cbbTypeGame);
            this.Controls.Add(this.pnPromotion);
            this.Controls.Add(this.gbInfoChess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fpnNotations);
            this.Controls.Add(this.btnBotTime);
            this.Controls.Add(this.btnTopTime);
            this.Controls.Add(this.pnBotCapturePieces);
            this.Controls.Add(this.pnTopCapturePieces);
            this.Controls.Add(this.pnChessBoard);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBot";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBot_KeyDown);
            this.gbInfoChess.ResumeLayout(false);
            this.gbInfoChess.PerformLayout();
            this.pnPromotion.ResumeLayout(false);
            this.pnPromotion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptrWhite)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptrBlack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBotTime;
        private System.Windows.Forms.Button btnTopTime;
        private System.Windows.Forms.Panel pnBotCapturePieces;
        private System.Windows.Forms.Panel pnTopCapturePieces;
        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.FlowLayoutPanel fpnNotations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInfoChess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblSignEndGame;
        private System.Windows.Forms.Label lblTypeEndgame;
        private System.Windows.Forms.Label lblStartTurn;
        private System.Windows.Forms.Panel pnPromotion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox ptrBishop;
        private System.Windows.Forms.PictureBox ptrKnight;
        private System.Windows.Forms.PictureBox ptrRook;
        private System.Windows.Forms.PictureBox ptrQueen;
        private System.Windows.Forms.ComboBox cbbTypeGame;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.ComboBox cbbRegimes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNameWhite;
        private System.Windows.Forms.PictureBox ptrWhite;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblNameBlack;
        private System.Windows.Forms.PictureBox ptrBlack;
        private System.Windows.Forms.ComboBox cbbWhite;
        private System.Windows.Forms.ComboBox cbbBlack;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ttRestart;
        private System.Windows.Forms.ToolTip ttReverse;
        private System.Windows.Forms.ToolTip ttPrintFile;
        private System.Windows.Forms.Timer timerWaitSetup;
        private System.Windows.Forms.ToolTip ttCbbWhite;
        private System.Windows.Forms.ToolTip ttCbbBlack;
        private System.Windows.Forms.TextBox txtFen;
    }
}