
namespace HAChess_BetterAtChess
{
    partial class frmHistories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistories));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbFilterDetailEnd = new System.Windows.Forms.ComboBox();
            this.cbFilterDetailEnd = new System.Windows.Forms.CheckBox();
            this.lblCountFriends = new System.Windows.Forms.Label();
            this.fpnMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnPages = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.pnTopCapturePieces = new System.Windows.Forms.Panel();
            this.btnTopTime = new System.Windows.Forms.Button();
            this.btnBotTime = new System.Windows.Forms.Button();
            this.pnBotCapturePieces = new System.Windows.Forms.Panel();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnGoToFirstMove = new System.Windows.Forms.Button();
            this.btnBackMove = new System.Windows.Forms.Button();
            this.fpnNotations = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNextMove = new System.Windows.Forms.Button();
            this.btnGoToEnd = new System.Windows.Forms.Button();
            this.btnPlayAndPause = new System.Windows.Forms.Button();
            this.gbInfoChess = new System.Windows.Forms.GroupBox();
            this.lblYou = new System.Windows.Forms.Label();
            this.lblOpponent = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblSignEndGame = new System.Windows.Forms.Label();
            this.lblTypeEndgame = new System.Windows.Forms.Label();
            this.lblStartTurn = new System.Windows.Forms.Label();
            this.timerPlaying = new System.Windows.Forms.Timer(this.components);
            this.btnRestart = new System.Windows.Forms.Button();
            this.ttRestart = new System.Windows.Forms.ToolTip(this.components);
            this.ttReverse = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrintFile = new System.Windows.Forms.ToolTip(this.components);
            this.ttPlayOrPause = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrevMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttNextMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttFirstMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttLastMove = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.fpnMatches.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbInfoChess.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.cbbFilterDetailEnd);
            this.panel2.Controls.Add(this.cbFilterDetailEnd);
            this.panel2.Controls.Add(this.lblCountFriends);
            this.panel2.Controls.Add(this.fpnMatches);
            this.panel2.Controls.Add(this.pnPages);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Location = new System.Drawing.Point(21, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 707);
            this.panel2.TabIndex = 42;
            // 
            // cbbFilterDetailEnd
            // 
            this.cbbFilterDetailEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterDetailEnd.FormattingEnabled = true;
            this.cbbFilterDetailEnd.Location = new System.Drawing.Point(28, 65);
            this.cbbFilterDetailEnd.Name = "cbbFilterDetailEnd";
            this.cbbFilterDetailEnd.Size = new System.Drawing.Size(316, 27);
            this.cbbFilterDetailEnd.TabIndex = 31;
            this.cbbFilterDetailEnd.SelectedIndexChanged += new System.EventHandler(this.cbbFilterDetailEnd_SelectedIndexChanged);
            // 
            // cbFilterDetailEnd
            // 
            this.cbFilterDetailEnd.AutoSize = true;
            this.cbFilterDetailEnd.ForeColor = System.Drawing.Color.Gold;
            this.cbFilterDetailEnd.Location = new System.Drawing.Point(13, 26);
            this.cbFilterDetailEnd.Name = "cbFilterDetailEnd";
            this.cbFilterDetailEnd.Size = new System.Drawing.Size(201, 23);
            this.cbFilterDetailEnd.TabIndex = 30;
            this.cbFilterDetailEnd.Text = "Lọc theo loại kết thúc";
            this.cbFilterDetailEnd.UseVisualStyleBackColor = true;
            this.cbFilterDetailEnd.CheckedChanged += new System.EventHandler(this.cbFilterDetailEnd_CheckedChanged);
            // 
            // lblCountFriends
            // 
            this.lblCountFriends.AutoSize = true;
            this.lblCountFriends.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountFriends.ForeColor = System.Drawing.Color.White;
            this.lblCountFriends.Location = new System.Drawing.Point(12, 577);
            this.lblCountFriends.Name = "lblCountFriends";
            this.lblCountFriends.Size = new System.Drawing.Size(103, 19);
            this.lblCountFriends.TabIndex = 17;
            this.lblCountFriends.Text = "Số lượng: 0";
            // 
            // fpnMatches
            // 
            this.fpnMatches.Controls.Add(this.panel1);
            this.fpnMatches.Controls.Add(this.panel3);
            this.fpnMatches.Controls.Add(this.panel4);
            this.fpnMatches.Location = new System.Drawing.Point(13, 126);
            this.fpnMatches.Name = "fpnMatches";
            this.fpnMatches.Size = new System.Drawing.Size(334, 435);
            this.fpnMatches.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 133);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Chế độ: ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 34);
            this.label5.TabIndex = 25;
            this.label5.Text = "Chi tiết kết quả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(5, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Kết quả";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(308, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "A#123 (1000)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(3, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(329, 133);
            this.panel3.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(5, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "Chế độ: ";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(307, 34);
            this.label7.TabIndex = 25;
            this.label7.Text = "Chi tiết kết quả";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(5, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 24;
            this.label8.Text = "Kết quả";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(5, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(308, 28);
            this.label9.TabIndex = 21;
            this.label9.Text = "A#123 (1000)";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(3, 281);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(329, 133);
            this.panel4.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "Chế độ: ";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(307, 34);
            this.label11.TabIndex = 25;
            this.label11.Text = "Chi tiết kết quả";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(5, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "Kết quả";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkCyan;
            this.label13.Location = new System.Drawing.Point(5, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(308, 28);
            this.label13.TabIndex = 21;
            this.label13.Text = "A#123 (1000)";
            // 
            // pnPages
            // 
            this.pnPages.Location = new System.Drawing.Point(94, 613);
            this.pnPages.Name = "pnPages";
            this.pnPages.Size = new System.Drawing.Size(178, 50);
            this.pnPages.TabIndex = 1;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatAppearance.BorderSize = 3;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(16, 613);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 50);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 3;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.DimGray;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(293, 613);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 50);
            this.btnNext.TabIndex = 3;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 29);
            this.label3.TabIndex = 43;
            this.label3.Text = "LỊCH SỬ ĐẤU";
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(412, 96);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(600, 600);
            this.pnChessBoard.TabIndex = 45;
            // 
            // pnTopCapturePieces
            // 
            this.pnTopCapturePieces.Location = new System.Drawing.Point(690, 23);
            this.pnTopCapturePieces.Name = "pnTopCapturePieces";
            this.pnTopCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnTopCapturePieces.TabIndex = 46;
            // 
            // btnTopTime
            // 
            this.btnTopTime.BackColor = System.Drawing.Color.White;
            this.btnTopTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopTime.FlatAppearance.BorderSize = 3;
            this.btnTopTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopTime.ForeColor = System.Drawing.Color.DimGray;
            this.btnTopTime.Location = new System.Drawing.Point(412, 30);
            this.btnTopTime.Name = "btnTopTime";
            this.btnTopTime.Size = new System.Drawing.Size(158, 41);
            this.btnTopTime.TabIndex = 47;
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
            this.btnBotTime.Location = new System.Drawing.Point(412, 714);
            this.btnBotTime.Name = "btnBotTime";
            this.btnBotTime.Size = new System.Drawing.Size(158, 41);
            this.btnBotTime.TabIndex = 49;
            this.btnBotTime.Text = "0:00";
            this.btnBotTime.UseVisualStyleBackColor = false;
            // 
            // pnBotCapturePieces
            // 
            this.pnBotCapturePieces.Location = new System.Drawing.Point(690, 714);
            this.pnBotCapturePieces.Name = "pnBotCapturePieces";
            this.pnBotCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnBotCapturePieces.TabIndex = 48;
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.FlatAppearance.BorderSize = 3;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.ForeColor = System.Drawing.Color.DimGray;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(1038, 319);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(70, 70);
            this.btnReverse.TabIndex = 20;
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
            this.btnPrint.Location = new System.Drawing.Point(1222, 319);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 70);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnGoToFirstMove
            // 
            this.btnGoToFirstMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGoToFirstMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToFirstMove.FlatAppearance.BorderSize = 3;
            this.btnGoToFirstMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToFirstMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnGoToFirstMove.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToFirstMove.Image")));
            this.btnGoToFirstMove.Location = new System.Drawing.Point(762, 793);
            this.btnGoToFirstMove.Name = "btnGoToFirstMove";
            this.btnGoToFirstMove.Size = new System.Drawing.Size(60, 60);
            this.btnGoToFirstMove.TabIndex = 18;
            this.btnGoToFirstMove.UseVisualStyleBackColor = false;
            this.btnGoToFirstMove.Visible = false;
            this.btnGoToFirstMove.Click += new System.EventHandler(this.btnGoToFirstMove_Click);
            // 
            // btnBackMove
            // 
            this.btnBackMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnBackMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackMove.FlatAppearance.BorderSize = 3;
            this.btnBackMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnBackMove.Image = ((System.Drawing.Image)(resources.GetObject("btnBackMove.Image")));
            this.btnBackMove.Location = new System.Drawing.Point(520, 793);
            this.btnBackMove.Name = "btnBackMove";
            this.btnBackMove.Size = new System.Drawing.Size(60, 60);
            this.btnBackMove.TabIndex = 17;
            this.btnBackMove.UseVisualStyleBackColor = false;
            this.btnBackMove.Visible = false;
            this.btnBackMove.Click += new System.EventHandler(this.btnBackMove_Click);
            // 
            // fpnNotations
            // 
            this.fpnNotations.AutoScroll = true;
            this.fpnNotations.Location = new System.Drawing.Point(1038, 414);
            this.fpnNotations.Name = "fpnNotations";
            this.fpnNotations.Size = new System.Drawing.Size(304, 282);
            this.fpnNotations.TabIndex = 51;
            // 
            // btnNextMove
            // 
            this.btnNextMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnNextMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextMove.FlatAppearance.BorderSize = 3;
            this.btnNextMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnNextMove.Image = ((System.Drawing.Image)(resources.GetObject("btnNextMove.Image")));
            this.btnNextMove.Location = new System.Drawing.Point(679, 793);
            this.btnNextMove.Name = "btnNextMove";
            this.btnNextMove.Size = new System.Drawing.Size(60, 60);
            this.btnNextMove.TabIndex = 52;
            this.btnNextMove.UseVisualStyleBackColor = false;
            this.btnNextMove.Visible = false;
            this.btnNextMove.Click += new System.EventHandler(this.btnNextMove_Click);
            // 
            // btnGoToEnd
            // 
            this.btnGoToEnd.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGoToEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToEnd.FlatAppearance.BorderSize = 3;
            this.btnGoToEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToEnd.ForeColor = System.Drawing.Color.DimGray;
            this.btnGoToEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToEnd.Image")));
            this.btnGoToEnd.Location = new System.Drawing.Point(839, 793);
            this.btnGoToEnd.Name = "btnGoToEnd";
            this.btnGoToEnd.Size = new System.Drawing.Size(60, 60);
            this.btnGoToEnd.TabIndex = 53;
            this.btnGoToEnd.UseVisualStyleBackColor = false;
            this.btnGoToEnd.Visible = false;
            this.btnGoToEnd.Click += new System.EventHandler(this.btnGoToEnd_Click);
            // 
            // btnPlayAndPause
            // 
            this.btnPlayAndPause.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPlayAndPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayAndPause.FlatAppearance.BorderSize = 3;
            this.btnPlayAndPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAndPause.ForeColor = System.Drawing.Color.DimGray;
            this.btnPlayAndPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayAndPause.Image")));
            this.btnPlayAndPause.Location = new System.Drawing.Point(600, 793);
            this.btnPlayAndPause.Name = "btnPlayAndPause";
            this.btnPlayAndPause.Size = new System.Drawing.Size(60, 60);
            this.btnPlayAndPause.TabIndex = 54;
            this.btnPlayAndPause.UseVisualStyleBackColor = false;
            this.btnPlayAndPause.Visible = false;
            this.btnPlayAndPause.Click += new System.EventHandler(this.btnPlayAndPause_Click);
            // 
            // gbInfoChess
            // 
            this.gbInfoChess.BackColor = System.Drawing.Color.White;
            this.gbInfoChess.Controls.Add(this.lblYou);
            this.gbInfoChess.Controls.Add(this.lblOpponent);
            this.gbInfoChess.Controls.Add(this.lblResult);
            this.gbInfoChess.Controls.Add(this.lblTurn);
            this.gbInfoChess.Controls.Add(this.lblSignEndGame);
            this.gbInfoChess.Controls.Add(this.lblTypeEndgame);
            this.gbInfoChess.Controls.Add(this.lblStartTurn);
            this.gbInfoChess.Location = new System.Drawing.Point(1038, 19);
            this.gbInfoChess.Name = "gbInfoChess";
            this.gbInfoChess.Size = new System.Drawing.Size(309, 280);
            this.gbInfoChess.TabIndex = 55;
            this.gbInfoChess.TabStop = false;
            this.gbInfoChess.Text = "Thông tin ván đấu";
            // 
            // lblYou
            // 
            this.lblYou.Location = new System.Drawing.Point(8, 25);
            this.lblYou.Name = "lblYou";
            this.lblYou.Size = new System.Drawing.Size(295, 41);
            this.lblYou.TabIndex = 20;
            this.lblYou.Text = "Tài khoản của tôi: You";
            // 
            // lblOpponent
            // 
            this.lblOpponent.Location = new System.Drawing.Point(8, 66);
            this.lblOpponent.Name = "lblOpponent";
            this.lblOpponent.Size = new System.Drawing.Size(295, 41);
            this.lblOpponent.TabIndex = 21;
            this.lblOpponent.Text = "Đối thủ:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResult.Location = new System.Drawing.Point(11, 217);
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
            this.lblTurn.Location = new System.Drawing.Point(11, 251);
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
            this.lblSignEndGame.Location = new System.Drawing.Point(11, 179);
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
            this.lblTypeEndgame.Location = new System.Drawing.Point(11, 141);
            this.lblTypeEndgame.Name = "lblTypeEndgame";
            this.lblTypeEndgame.Size = new System.Drawing.Size(117, 19);
            this.lblTypeEndgame.TabIndex = 10;
            this.lblTypeEndgame.Text = "Loại kết thúc:";
            // 
            // lblStartTurn
            // 
            this.lblStartTurn.AutoSize = true;
            this.lblStartTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTurn.Location = new System.Drawing.Point(11, 112);
            this.lblStartTurn.Name = "lblStartTurn";
            this.lblStartTurn.Size = new System.Drawing.Size(139, 19);
            this.lblStartTurn.TabIndex = 9;
            this.lblStartTurn.Text = "Lược đầu: trắng";
            // 
            // timerPlaying
            // 
            this.timerPlaying.Interval = 1000;
            this.timerPlaying.Tick += new System.EventHandler(this.timerPlaying_Tick);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatAppearance.BorderSize = 3;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.ForeColor = System.Drawing.Color.DimGray;
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.Location = new System.Drawing.Point(1131, 319);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(70, 70);
            this.btnRestart.TabIndex = 56;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
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
            // ttPlayOrPause
            // 
            this.ttPlayOrPause.ToolTipTitle = "Phát tự động trận đấu";
            // 
            // ttPrevMove
            // 
            this.ttPrevMove.ToolTipTitle = "Quay lại nước trước";
            // 
            // ttNextMove
            // 
            this.ttNextMove.ToolTipTitle = "Nước kế tiếp";
            // 
            // ttFirstMove
            // 
            this.ttFirstMove.ToolTipTitle = "Nước đầu tiên";
            // 
            // ttLastMove
            // 
            this.ttLastMove.ToolTipTitle = "Nước cuối cùng";
            // 
            // frmHistories
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1354, 875);
            this.Controls.Add(this.btnBackMove);
            this.Controls.Add(this.btnNextMove);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnPlayAndPause);
            this.Controls.Add(this.gbInfoChess);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnGoToEnd);
            this.Controls.Add(this.btnGoToFirstMove);
            this.Controls.Add(this.fpnNotations);
            this.Controls.Add(this.btnBotTime);
            this.Controls.Add(this.pnBotCapturePieces);
            this.Controls.Add(this.btnTopTime);
            this.Controls.Add(this.pnTopCapturePieces);
            this.Controls.Add(this.pnChessBoard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHistories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHistories";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHistories_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.fpnMatches.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbInfoChess.ResumeLayout(false);
            this.gbInfoChess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCountFriends;
        private System.Windows.Forms.FlowLayoutPanel fpnMatches;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnPages;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.Panel pnTopCapturePieces;
        private System.Windows.Forms.Button btnTopTime;
        private System.Windows.Forms.Button btnBotTime;
        private System.Windows.Forms.Panel pnBotCapturePieces;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnGoToFirstMove;
        private System.Windows.Forms.Button btnBackMove;
        private System.Windows.Forms.FlowLayoutPanel fpnNotations;
        private System.Windows.Forms.Button btnNextMove;
        private System.Windows.Forms.Button btnGoToEnd;
        private System.Windows.Forms.Button btnPlayAndPause;
        private System.Windows.Forms.GroupBox gbInfoChess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblSignEndGame;
        private System.Windows.Forms.Label lblTypeEndgame;
        private System.Windows.Forms.Label lblStartTurn;
        private System.Windows.Forms.Label lblYou;
        private System.Windows.Forms.Label lblOpponent;
        private System.Windows.Forms.ComboBox cbbFilterDetailEnd;
        private System.Windows.Forms.CheckBox cbFilterDetailEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerPlaying;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ToolTip ttRestart;
        private System.Windows.Forms.ToolTip ttReverse;
        private System.Windows.Forms.ToolTip ttPrintFile;
        private System.Windows.Forms.ToolTip ttPlayOrPause;
        private System.Windows.Forms.ToolTip ttPrevMove;
        private System.Windows.Forms.ToolTip ttNextMove;
        private System.Windows.Forms.ToolTip ttFirstMove;
        private System.Windows.Forms.ToolTip ttLastMove;
    }
}