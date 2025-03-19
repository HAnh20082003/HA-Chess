
namespace HAChess_BetterAtChess
{
    partial class frmMatchGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatchGame));
            this.pnBotCapturePieces = new System.Windows.Forms.Panel();
            this.pnTopCapturePieces = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.lblOpponent = new System.Windows.Forms.Label();
            this.lblTimeFinding = new System.Windows.Forms.Label();
            this.btnStartFind = new System.Windows.Forms.Button();
            this.btnStopFind = new System.Windows.Forms.Button();
            this.timerFindingGame = new System.Windows.Forms.Timer(this.components);
            this.lblYou = new System.Windows.Forms.Label();
            this.fpnNotations = new System.Windows.Forms.FlowLayoutPanel();
            this.cbbTypeGame = new System.Windows.Forms.ComboBox();
            this.cbbRegimes = new System.Windows.Forms.ComboBox();
            this.btnRequestDraw = new System.Windows.Forms.Button();
            this.btnResign = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnRematch = new System.Windows.Forms.Button();
            this.gbInfoChess = new System.Windows.Forms.GroupBox();
            this.lblOutMatch = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblSignEndGame = new System.Windows.Forms.Label();
            this.lblTypeEndgame = new System.Windows.Forms.Label();
            this.lblStartTurn = new System.Windows.Forms.Label();
            this.pnPromotion = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ptrBishop = new System.Windows.Forms.PictureBox();
            this.ptrKnight = new System.Windows.Forms.PictureBox();
            this.ptrRook = new System.Windows.Forms.PictureBox();
            this.ptrQueen = new System.Windows.Forms.PictureBox();
            this.pnRequestDraw = new System.Windows.Forms.Panel();
            this.lblTimeShowRequestDraw = new System.Windows.Forms.Label();
            this.btnDeclineDraw = new System.Windows.Forms.Button();
            this.btnAcceptDraw = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.rtxChat = new System.Windows.Forms.RichTextBox();
            this.pnChat = new System.Windows.Forms.Panel();
            this.btnOutGame = new System.Windows.Forms.Button();
            this.btnTopTime = new System.Windows.Forms.Button();
            this.btnBotTime = new System.Windows.Forms.Button();
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.timerChat = new System.Windows.Forms.Timer(this.components);
            this.timerRequestDrawAndResign = new System.Windows.Forms.Timer(this.components);
            this.timerShowRequestDraw = new System.Windows.Forms.Timer(this.components);
            this.timerOutMatch = new System.Windows.Forms.Timer(this.components);
            this.timerWaitOutMatch = new System.Windows.Forms.Timer(this.components);
            this.timerRematch = new System.Windows.Forms.Timer(this.components);
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ttReverse = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrintFile = new System.Windows.Forms.ToolTip(this.components);
            this.gbInfoChess.SuspendLayout();
            this.pnPromotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).BeginInit();
            this.pnRequestDraw.SuspendLayout();
            this.pnChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBotCapturePieces
            // 
            this.pnBotCapturePieces.Location = new System.Drawing.Point(622, 702);
            this.pnBotCapturePieces.Name = "pnBotCapturePieces";
            this.pnBotCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnBotCapturePieces.TabIndex = 17;
            // 
            // pnTopCapturePieces
            // 
            this.pnTopCapturePieces.Location = new System.Drawing.Point(622, 21);
            this.pnTopCapturePieces.Name = "pnTopCapturePieces";
            this.pnTopCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnTopCapturePieces.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ghép trận online";
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(344, 91);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(600, 600);
            this.pnChessBoard.TabIndex = 14;
            // 
            // lblOpponent
            // 
            this.lblOpponent.Location = new System.Drawing.Point(6, 67);
            this.lblOpponent.Name = "lblOpponent";
            this.lblOpponent.Size = new System.Drawing.Size(301, 41);
            this.lblOpponent.TabIndex = 19;
            this.lblOpponent.Text = "Đối thủ:";
            // 
            // lblTimeFinding
            // 
            this.lblTimeFinding.AutoSize = true;
            this.lblTimeFinding.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeFinding.ForeColor = System.Drawing.Color.Crimson;
            this.lblTimeFinding.Location = new System.Drawing.Point(126, 308);
            this.lblTimeFinding.Name = "lblTimeFinding";
            this.lblTimeFinding.Size = new System.Drawing.Size(82, 38);
            this.lblTimeFinding.TabIndex = 20;
            this.lblTimeFinding.Text = "0:00";
            this.lblTimeFinding.Visible = false;
            // 
            // btnStartFind
            // 
            this.btnStartFind.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnStartFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartFind.FlatAppearance.BorderSize = 3;
            this.btnStartFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartFind.ForeColor = System.Drawing.Color.Black;
            this.btnStartFind.Location = new System.Drawing.Point(54, 82);
            this.btnStartFind.Name = "btnStartFind";
            this.btnStartFind.Size = new System.Drawing.Size(201, 45);
            this.btnStartFind.TabIndex = 21;
            this.btnStartFind.Text = "Tìm trận";
            this.btnStartFind.UseVisualStyleBackColor = false;
            this.btnStartFind.Click += new System.EventHandler(this.btnStartFind_Click);
            // 
            // btnStopFind
            // 
            this.btnStopFind.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnStopFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopFind.FlatAppearance.BorderSize = 3;
            this.btnStopFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopFind.ForeColor = System.Drawing.Color.Crimson;
            this.btnStopFind.Location = new System.Drawing.Point(54, 143);
            this.btnStopFind.Name = "btnStopFind";
            this.btnStopFind.Size = new System.Drawing.Size(201, 38);
            this.btnStopFind.TabIndex = 22;
            this.btnStopFind.Text = "Dừng tìm";
            this.btnStopFind.UseVisualStyleBackColor = false;
            this.btnStopFind.Visible = false;
            this.btnStopFind.Click += new System.EventHandler(this.btnStopFind_Click);
            // 
            // timerFindingGame
            // 
            this.timerFindingGame.Interval = 1000;
            this.timerFindingGame.Tick += new System.EventHandler(this.timerFindingGame_Tick);
            // 
            // lblYou
            // 
            this.lblYou.Location = new System.Drawing.Point(6, 26);
            this.lblYou.Name = "lblYou";
            this.lblYou.Size = new System.Drawing.Size(301, 41);
            this.lblYou.TabIndex = 18;
            this.lblYou.Text = "Tài khoản của tôi: You";
            // 
            // fpnNotations
            // 
            this.fpnNotations.AutoScroll = true;
            this.fpnNotations.Location = new System.Drawing.Point(972, 407);
            this.fpnNotations.Name = "fpnNotations";
            this.fpnNotations.Size = new System.Drawing.Size(304, 164);
            this.fpnNotations.TabIndex = 23;
            // 
            // cbbTypeGame
            // 
            this.cbbTypeGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTypeGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTypeGame.FormattingEnabled = true;
            this.cbbTypeGame.Location = new System.Drawing.Point(22, 217);
            this.cbbTypeGame.Name = "cbbTypeGame";
            this.cbbTypeGame.Size = new System.Drawing.Size(303, 27);
            this.cbbTypeGame.TabIndex = 24;
            this.cbbTypeGame.SelectedIndexChanged += new System.EventHandler(this.cbbTypeGame_SelectedIndexChanged);
            // 
            // cbbRegimes
            // 
            this.cbbRegimes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbRegimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRegimes.FormattingEnabled = true;
            this.cbbRegimes.Location = new System.Drawing.Point(22, 265);
            this.cbbRegimes.Name = "cbbRegimes";
            this.cbbRegimes.Size = new System.Drawing.Size(303, 27);
            this.cbbRegimes.TabIndex = 25;
            this.cbbRegimes.SelectedIndexChanged += new System.EventHandler(this.cbbRegimes_SelectedIndexChanged);
            // 
            // btnRequestDraw
            // 
            this.btnRequestDraw.BackColor = System.Drawing.Color.Lavender;
            this.btnRequestDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestDraw.FlatAppearance.BorderSize = 3;
            this.btnRequestDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestDraw.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnRequestDraw.Location = new System.Drawing.Point(1133, 154);
            this.btnRequestDraw.Name = "btnRequestDraw";
            this.btnRequestDraw.Size = new System.Drawing.Size(158, 41);
            this.btnRequestDraw.TabIndex = 27;
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
            this.btnResign.Location = new System.Drawing.Point(951, 154);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(158, 41);
            this.btnResign.TabIndex = 26;
            this.btnResign.Text = "Đầu hàng";
            this.btnResign.UseVisualStyleBackColor = false;
            this.btnResign.Visible = false;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewGame.FlatAppearance.BorderSize = 3;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.ForeColor = System.Drawing.Color.Black;
            this.btnNewGame.Location = new System.Drawing.Point(12, 750);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(141, 41);
            this.btnNewGame.TabIndex = 28;
            this.btnNewGame.Text = "Tìm trận mới";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Visible = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnRematch
            // 
            this.btnRematch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRematch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRematch.FlatAppearance.BorderSize = 3;
            this.btnRematch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRematch.ForeColor = System.Drawing.Color.Black;
            this.btnRematch.Location = new System.Drawing.Point(12, 802);
            this.btnRematch.Name = "btnRematch";
            this.btnRematch.Size = new System.Drawing.Size(141, 41);
            this.btnRematch.TabIndex = 29;
            this.btnRematch.Text = "Tái đấu";
            this.btnRematch.UseVisualStyleBackColor = false;
            this.btnRematch.Visible = false;
            this.btnRematch.Click += new System.EventHandler(this.btnRematch_Click);
            // 
            // gbInfoChess
            // 
            this.gbInfoChess.BackColor = System.Drawing.Color.White;
            this.gbInfoChess.Controls.Add(this.lblResult);
            this.gbInfoChess.Controls.Add(this.lblTurn);
            this.gbInfoChess.Controls.Add(this.lblSignEndGame);
            this.gbInfoChess.Controls.Add(this.lblTypeEndgame);
            this.gbInfoChess.Controls.Add(this.lblStartTurn);
            this.gbInfoChess.Controls.Add(this.lblYou);
            this.gbInfoChess.Controls.Add(this.lblOpponent);
            this.gbInfoChess.Location = new System.Drawing.Point(12, 444);
            this.gbInfoChess.Name = "gbInfoChess";
            this.gbInfoChess.Size = new System.Drawing.Size(313, 299);
            this.gbInfoChess.TabIndex = 31;
            this.gbInfoChess.TabStop = false;
            this.gbInfoChess.Text = "Thông tin ván đấu";
            // 
            // lblOutMatch
            // 
            this.lblOutMatch.BackColor = System.Drawing.Color.White;
            this.lblOutMatch.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutMatch.ForeColor = System.Drawing.Color.Crimson;
            this.lblOutMatch.Location = new System.Drawing.Point(8, 368);
            this.lblOutMatch.Name = "lblOutMatch";
            this.lblOutMatch.Size = new System.Drawing.Size(317, 60);
            this.lblOutMatch.TabIndex = 20;
            this.lblOutMatch.Text = "Đối thủ đã thoát, trận đấu sẽ huỷ trong: ";
            this.lblOutMatch.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResult.Location = new System.Drawing.Point(6, 223);
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
            this.lblTurn.Location = new System.Drawing.Point(6, 266);
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
            this.lblSignEndGame.Location = new System.Drawing.Point(6, 184);
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
            this.lblTypeEndgame.Location = new System.Drawing.Point(6, 145);
            this.lblTypeEndgame.Name = "lblTypeEndgame";
            this.lblTypeEndgame.Size = new System.Drawing.Size(117, 19);
            this.lblTypeEndgame.TabIndex = 10;
            this.lblTypeEndgame.Text = "Loại kết thúc:";
            // 
            // lblStartTurn
            // 
            this.lblStartTurn.AutoSize = true;
            this.lblStartTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTurn.Location = new System.Drawing.Point(6, 117);
            this.lblStartTurn.Name = "lblStartTurn";
            this.lblStartTurn.Size = new System.Drawing.Size(139, 19);
            this.lblStartTurn.TabIndex = 9;
            this.lblStartTurn.Text = "Lược đầu: trắng";
            // 
            // pnPromotion
            // 
            this.pnPromotion.Controls.Add(this.label2);
            this.pnPromotion.Controls.Add(this.ptrBishop);
            this.pnPromotion.Controls.Add(this.ptrKnight);
            this.pnPromotion.Controls.Add(this.ptrRook);
            this.pnPromotion.Controls.Add(this.ptrQueen);
            this.pnPromotion.Location = new System.Drawing.Point(951, 12);
            this.pnPromotion.Name = "pnPromotion";
            this.pnPromotion.Size = new System.Drawing.Size(408, 136);
            this.pnPromotion.TabIndex = 32;
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
            // pnRequestDraw
            // 
            this.pnRequestDraw.Controls.Add(this.lblTimeShowRequestDraw);
            this.pnRequestDraw.Controls.Add(this.btnDeclineDraw);
            this.pnRequestDraw.Controls.Add(this.btnAcceptDraw);
            this.pnRequestDraw.Controls.Add(this.label3);
            this.pnRequestDraw.Location = new System.Drawing.Point(972, 269);
            this.pnRequestDraw.Name = "pnRequestDraw";
            this.pnRequestDraw.Size = new System.Drawing.Size(304, 121);
            this.pnRequestDraw.TabIndex = 33;
            this.pnRequestDraw.Visible = false;
            // 
            // lblTimeShowRequestDraw
            // 
            this.lblTimeShowRequestDraw.AutoSize = true;
            this.lblTimeShowRequestDraw.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeShowRequestDraw.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblTimeShowRequestDraw.Location = new System.Drawing.Point(20, 95);
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
            this.btnDeclineDraw.Location = new System.Drawing.Point(167, 44);
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
            this.btnAcceptDraw.Location = new System.Drawing.Point(20, 44);
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
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đối thủ muốn hoà cờ với bạn";
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(11, 202);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(243, 82);
            this.txtChat.TabIndex = 34;
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            // 
            // btnSendChat
            // 
            this.btnSendChat.BackColor = System.Drawing.Color.Beige;
            this.btnSendChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendChat.FlatAppearance.BorderSize = 3;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChat.ForeColor = System.Drawing.Color.Olive;
            this.btnSendChat.Location = new System.Drawing.Point(260, 202);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(55, 44);
            this.btnSendChat.TabIndex = 36;
            this.btnSendChat.Text = "Gửi";
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // rtxChat
            // 
            this.rtxChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxChat.Location = new System.Drawing.Point(11, 3);
            this.rtxChat.Name = "rtxChat";
            this.rtxChat.ReadOnly = true;
            this.rtxChat.Size = new System.Drawing.Size(304, 182);
            this.rtxChat.TabIndex = 37;
            this.rtxChat.Text = "";
            // 
            // pnChat
            // 
            this.pnChat.Controls.Add(this.rtxChat);
            this.pnChat.Controls.Add(this.btnSendChat);
            this.pnChat.Controls.Add(this.txtChat);
            this.pnChat.Location = new System.Drawing.Point(961, 577);
            this.pnChat.Name = "pnChat";
            this.pnChat.Size = new System.Drawing.Size(330, 297);
            this.pnChat.TabIndex = 34;
            this.pnChat.Visible = false;
            // 
            // btnOutGame
            // 
            this.btnOutGame.BackColor = System.Drawing.Color.Pink;
            this.btnOutGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutGame.FlatAppearance.BorderSize = 3;
            this.btnOutGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutGame.ForeColor = System.Drawing.Color.Black;
            this.btnOutGame.Location = new System.Drawing.Point(184, 750);
            this.btnOutGame.Name = "btnOutGame";
            this.btnOutGame.Size = new System.Drawing.Size(141, 41);
            this.btnOutGame.TabIndex = 35;
            this.btnOutGame.Text = "Rời trận đấu";
            this.btnOutGame.UseVisualStyleBackColor = false;
            this.btnOutGame.Visible = false;
            this.btnOutGame.Click += new System.EventHandler(this.btnOutGame_Click);
            // 
            // btnTopTime
            // 
            this.btnTopTime.BackColor = System.Drawing.Color.White;
            this.btnTopTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopTime.FlatAppearance.BorderSize = 3;
            this.btnTopTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopTime.ForeColor = System.Drawing.Color.DimGray;
            this.btnTopTime.Location = new System.Drawing.Point(344, 21);
            this.btnTopTime.Name = "btnTopTime";
            this.btnTopTime.Size = new System.Drawing.Size(158, 41);
            this.btnTopTime.TabIndex = 36;
            this.btnTopTime.Text = "0:00";
            this.btnTopTime.UseVisualStyleBackColor = false;
            // 
            // btnBotTime
            // 
            this.btnBotTime.BackColor = System.Drawing.Color.White;
            this.btnBotTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBotTime.FlatAppearance.BorderSize = 3;
            this.btnBotTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotTime.ForeColor = System.Drawing.Color.DimGray;
            this.btnBotTime.Location = new System.Drawing.Point(344, 702);
            this.btnBotTime.Name = "btnBotTime";
            this.btnBotTime.Size = new System.Drawing.Size(158, 41);
            this.btnBotTime.TabIndex = 37;
            this.btnBotTime.Text = "0:00";
            this.btnBotTime.UseVisualStyleBackColor = false;
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
            // timerOutMatch
            // 
            this.timerOutMatch.Interval = 200;
            this.timerOutMatch.Tick += new System.EventHandler(this.timerOutMatch_Tick);
            // 
            // timerWaitOutMatch
            // 
            this.timerWaitOutMatch.Interval = 1000;
            this.timerWaitOutMatch.Tick += new System.EventHandler(this.timerWaitOutMatch_Tick);
            // 
            // timerRematch
            // 
            this.timerRematch.Interval = 200;
            this.timerRematch.Tick += new System.EventHandler(this.timerRematch_Tick);
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFriend.FlatAppearance.BorderSize = 3;
            this.btnAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFriend.ForeColor = System.Drawing.Color.Black;
            this.btnAddFriend.Location = new System.Drawing.Point(184, 802);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(141, 41);
            this.btnAddFriend.TabIndex = 38;
            this.btnAddFriend.Text = "Kết bạn";
            this.btnAddFriend.UseVisualStyleBackColor = false;
            this.btnAddFriend.Visible = false;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.FlatAppearance.BorderSize = 3;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.ForeColor = System.Drawing.Color.DimGray;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(972, 201);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(60, 60);
            this.btnReverse.TabIndex = 39;
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 3;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(1049, 201);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 60);
            this.btnPrint.TabIndex = 40;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ttReverse
            // 
            this.ttReverse.ToolTipTitle = "Lật ngược bàn cờ";
            // 
            // ttPrintFile
            // 
            this.ttPrintFile.ToolTipTitle = "Lưu trận đấu thành file *.txt";
            // 
            // frmMatchGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1356, 875);
            this.Controls.Add(this.lblOutMatch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.btnBotTime);
            this.Controls.Add(this.btnTopTime);
            this.Controls.Add(this.btnOutGame);
            this.Controls.Add(this.pnChat);
            this.Controls.Add(this.pnRequestDraw);
            this.Controls.Add(this.pnPromotion);
            this.Controls.Add(this.gbInfoChess);
            this.Controls.Add(this.btnRematch);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnRequestDraw);
            this.Controls.Add(this.btnResign);
            this.Controls.Add(this.cbbRegimes);
            this.Controls.Add(this.cbbTypeGame);
            this.Controls.Add(this.fpnNotations);
            this.Controls.Add(this.btnStopFind);
            this.Controls.Add(this.btnStartFind);
            this.Controls.Add(this.lblTimeFinding);
            this.Controls.Add(this.pnBotCapturePieces);
            this.Controls.Add(this.pnTopCapturePieces);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnChessBoard);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMatchGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMatchGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMatchGame_KeyDown);
            this.gbInfoChess.ResumeLayout(false);
            this.gbInfoChess.PerformLayout();
            this.pnPromotion.ResumeLayout(false);
            this.pnPromotion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).EndInit();
            this.pnRequestDraw.ResumeLayout(false);
            this.pnRequestDraw.PerformLayout();
            this.pnChat.ResumeLayout(false);
            this.pnChat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnBotCapturePieces;
        private System.Windows.Forms.Panel pnTopCapturePieces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.Label lblOpponent;
        private System.Windows.Forms.Label lblTimeFinding;
        private System.Windows.Forms.Button btnStartFind;
        private System.Windows.Forms.Button btnStopFind;
        private System.Windows.Forms.Timer timerFindingGame;
        private System.Windows.Forms.Label lblYou;
        private System.Windows.Forms.FlowLayoutPanel fpnNotations;
        private System.Windows.Forms.ComboBox cbbTypeGame;
        private System.Windows.Forms.ComboBox cbbRegimes;
        private System.Windows.Forms.Button btnRequestDraw;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnRematch;
        private System.Windows.Forms.GroupBox gbInfoChess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblSignEndGame;
        private System.Windows.Forms.Label lblTypeEndgame;
        private System.Windows.Forms.Label lblStartTurn;
        private System.Windows.Forms.Panel pnPromotion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptrBishop;
        private System.Windows.Forms.PictureBox ptrKnight;
        private System.Windows.Forms.PictureBox ptrRook;
        private System.Windows.Forms.PictureBox ptrQueen;
        private System.Windows.Forms.Panel pnRequestDraw;
        private System.Windows.Forms.Button btnDeclineDraw;
        private System.Windows.Forms.Button btnAcceptDraw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.RichTextBox rtxChat;
        private System.Windows.Forms.Panel pnChat;
        private System.Windows.Forms.Button btnOutGame;
        private System.Windows.Forms.Button btnTopTime;
        private System.Windows.Forms.Button btnBotTime;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.Timer timerChat;
        private System.Windows.Forms.Timer timerRequestDrawAndResign;
        private System.Windows.Forms.Timer timerShowRequestDraw;
        private System.Windows.Forms.Label lblTimeShowRequestDraw;
        private System.Windows.Forms.Timer timerOutMatch;
        private System.Windows.Forms.Label lblOutMatch;
        private System.Windows.Forms.Timer timerWaitOutMatch;
        private System.Windows.Forms.Timer timerRematch;
        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolTip ttReverse;
        private System.Windows.Forms.ToolTip ttPrintFile;
    }
}