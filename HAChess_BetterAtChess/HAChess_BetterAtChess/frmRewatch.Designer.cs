
namespace HAChess_BetterAtChess
{
    partial class frmRewatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRewatch));
            this.pnBotCapturePieces = new System.Windows.Forms.Panel();
            this.pnTopCapturePieces = new System.Windows.Forms.Panel();
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.btnPlayAndPause = new System.Windows.Forms.Button();
            this.btnNextMove = new System.Windows.Forms.Button();
            this.btnGoToEnd = new System.Windows.Forms.Button();
            this.btnBackMove = new System.Windows.Forms.Button();
            this.btnGoToFirstMove = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCountFriends = new System.Windows.Forms.Label();
            this.fpnFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnPages = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gbInfoChess = new System.Windows.Forms.GroupBox();
            this.lblWhite = new System.Windows.Forms.Label();
            this.lblBlack = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblSignEndGame = new System.Windows.Forms.Label();
            this.lblTypeEndgame = new System.Windows.Forms.Label();
            this.lblStartTurn = new System.Windows.Forms.Label();
            this.fpnNotations = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReverse = new System.Windows.Forms.Button();
            this.timerPlaying = new System.Windows.Forms.Timer(this.components);
            this.btnRestart = new System.Windows.Forms.Button();
            this.ttRestart = new System.Windows.Forms.ToolTip(this.components);
            this.ttReverse = new System.Windows.Forms.ToolTip(this.components);
            this.ttPlayOrPause = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrevMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttNextMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttFirstMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttLastMove = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.fpnFiles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbInfoChess.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBotCapturePieces
            // 
            this.pnBotCapturePieces.Location = new System.Drawing.Point(677, 703);
            this.pnBotCapturePieces.Name = "pnBotCapturePieces";
            this.pnBotCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnBotCapturePieces.TabIndex = 53;
            // 
            // pnTopCapturePieces
            // 
            this.pnTopCapturePieces.Location = new System.Drawing.Point(677, 12);
            this.pnTopCapturePieces.Name = "pnTopCapturePieces";
            this.pnTopCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnTopCapturePieces.TabIndex = 51;
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(399, 85);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(600, 600);
            this.pnChessBoard.TabIndex = 50;
            // 
            // btnPlayAndPause
            // 
            this.btnPlayAndPause.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPlayAndPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayAndPause.FlatAppearance.BorderSize = 3;
            this.btnPlayAndPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAndPause.ForeColor = System.Drawing.Color.DimGray;
            this.btnPlayAndPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayAndPause.Image")));
            this.btnPlayAndPause.Location = new System.Drawing.Point(585, 783);
            this.btnPlayAndPause.Name = "btnPlayAndPause";
            this.btnPlayAndPause.Size = new System.Drawing.Size(60, 60);
            this.btnPlayAndPause.TabIndex = 59;
            this.btnPlayAndPause.UseVisualStyleBackColor = false;
            this.btnPlayAndPause.Visible = false;
            this.btnPlayAndPause.Click += new System.EventHandler(this.btnPlayAndPause_Click);
            // 
            // btnNextMove
            // 
            this.btnNextMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnNextMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextMove.FlatAppearance.BorderSize = 3;
            this.btnNextMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnNextMove.Image = ((System.Drawing.Image)(resources.GetObject("btnNextMove.Image")));
            this.btnNextMove.Location = new System.Drawing.Point(664, 783);
            this.btnNextMove.Name = "btnNextMove";
            this.btnNextMove.Size = new System.Drawing.Size(60, 60);
            this.btnNextMove.TabIndex = 57;
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
            this.btnGoToEnd.Location = new System.Drawing.Point(821, 783);
            this.btnGoToEnd.Name = "btnGoToEnd";
            this.btnGoToEnd.Size = new System.Drawing.Size(60, 60);
            this.btnGoToEnd.TabIndex = 58;
            this.btnGoToEnd.UseVisualStyleBackColor = false;
            this.btnGoToEnd.Visible = false;
            this.btnGoToEnd.Click += new System.EventHandler(this.btnGoToEnd_Click);
            // 
            // btnBackMove
            // 
            this.btnBackMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnBackMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackMove.FlatAppearance.BorderSize = 3;
            this.btnBackMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnBackMove.Image = ((System.Drawing.Image)(resources.GetObject("btnBackMove.Image")));
            this.btnBackMove.Location = new System.Drawing.Point(505, 783);
            this.btnBackMove.Name = "btnBackMove";
            this.btnBackMove.Size = new System.Drawing.Size(60, 60);
            this.btnBackMove.TabIndex = 55;
            this.btnBackMove.UseVisualStyleBackColor = false;
            this.btnBackMove.Visible = false;
            this.btnBackMove.Click += new System.EventHandler(this.btnBackMove_Click);
            // 
            // btnGoToFirstMove
            // 
            this.btnGoToFirstMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGoToFirstMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToFirstMove.FlatAppearance.BorderSize = 3;
            this.btnGoToFirstMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToFirstMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnGoToFirstMove.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToFirstMove.Image")));
            this.btnGoToFirstMove.Location = new System.Drawing.Point(743, 783);
            this.btnGoToFirstMove.Name = "btnGoToFirstMove";
            this.btnGoToFirstMove.Size = new System.Drawing.Size(60, 60);
            this.btnGoToFirstMove.TabIndex = 56;
            this.btnGoToFirstMove.UseVisualStyleBackColor = false;
            this.btnGoToFirstMove.Visible = false;
            this.btnGoToFirstMove.Click += new System.EventHandler(this.btnGoToFirstMove_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(16, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 27);
            this.txtSearch.TabIndex = 60;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.lblCountFriends);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.fpnFiles);
            this.panel2.Controls.Add(this.pnPages);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Location = new System.Drawing.Point(12, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 612);
            this.panel2.TabIndex = 61;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReload.FlatAppearance.BorderSize = 3;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.ForeColor = System.Drawing.Color.DarkGray;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(300, 483);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(50, 50);
            this.btnReload.TabIndex = 61;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 3;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearch.Location = new System.Drawing.Point(244, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 33);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCountFriends
            // 
            this.lblCountFriends.AutoSize = true;
            this.lblCountFriends.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountFriends.ForeColor = System.Drawing.Color.White;
            this.lblCountFriends.Location = new System.Drawing.Point(15, 483);
            this.lblCountFriends.Name = "lblCountFriends";
            this.lblCountFriends.Size = new System.Drawing.Size(103, 19);
            this.lblCountFriends.TabIndex = 17;
            this.lblCountFriends.Text = "Số lượng: 0";
            // 
            // fpnFiles
            // 
            this.fpnFiles.Controls.Add(this.panel1);
            this.fpnFiles.Location = new System.Drawing.Point(16, 76);
            this.fpnFiles.Name = "fpnFiles";
            this.fpnFiles.Size = new System.Drawing.Size(334, 389);
            this.fpnFiles.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 68);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(308, 44);
            this.label4.TabIndex = 21;
            this.label4.Text = "A#123 (1000)";
            // 
            // pnPages
            // 
            this.pnPages.Location = new System.Drawing.Point(98, 545);
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
            this.btnPrev.Location = new System.Drawing.Point(16, 545);
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
            this.btnNext.Location = new System.Drawing.Point(300, 545);
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
            this.label3.Location = new System.Drawing.Point(35, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 29);
            this.label3.TabIndex = 62;
            this.label3.Text = "Xem lại *.txt";
            // 
            // gbInfoChess
            // 
            this.gbInfoChess.BackColor = System.Drawing.Color.White;
            this.gbInfoChess.Controls.Add(this.lblWhite);
            this.gbInfoChess.Controls.Add(this.lblBlack);
            this.gbInfoChess.Controls.Add(this.lblResult);
            this.gbInfoChess.Controls.Add(this.lblTurn);
            this.gbInfoChess.Controls.Add(this.lblSignEndGame);
            this.gbInfoChess.Controls.Add(this.lblTypeEndgame);
            this.gbInfoChess.Controls.Add(this.lblStartTurn);
            this.gbInfoChess.Location = new System.Drawing.Point(1041, 85);
            this.gbInfoChess.Name = "gbInfoChess";
            this.gbInfoChess.Size = new System.Drawing.Size(309, 280);
            this.gbInfoChess.TabIndex = 63;
            this.gbInfoChess.TabStop = false;
            this.gbInfoChess.Text = "Thông tin ván đấu";
            // 
            // lblWhite
            // 
            this.lblWhite.Location = new System.Drawing.Point(8, 25);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(295, 41);
            this.lblWhite.TabIndex = 20;
            this.lblWhite.Text = "Tên player cờ trắng";
            // 
            // lblBlack
            // 
            this.lblBlack.Location = new System.Drawing.Point(8, 66);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(295, 41);
            this.lblBlack.TabIndex = 21;
            this.lblBlack.Text = "Tên player cờ đen";
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
            // fpnNotations
            // 
            this.fpnNotations.AutoScroll = true;
            this.fpnNotations.Location = new System.Drawing.Point(1041, 483);
            this.fpnNotations.Name = "fpnNotations";
            this.fpnNotations.Size = new System.Drawing.Size(304, 282);
            this.fpnNotations.TabIndex = 64;
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.FlatAppearance.BorderSize = 3;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.ForeColor = System.Drawing.Color.DimGray;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(1041, 392);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(70, 70);
            this.btnReverse.TabIndex = 65;
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
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
            this.btnRestart.Location = new System.Drawing.Point(1132, 392);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(70, 70);
            this.btnRestart.TabIndex = 66;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // ttRestart
            // 
            this.ttRestart.ToolTipTitle = "Xem lại từ đầu";
            // 
            // ttReverse
            // 
            this.ttReverse.ToolTipTitle = "Lật ngược bàn cờ";
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
            // frmRewatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1474, 875);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.fpnNotations);
            this.Controls.Add(this.gbInfoChess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPlayAndPause);
            this.Controls.Add(this.btnNextMove);
            this.Controls.Add(this.btnGoToEnd);
            this.Controls.Add(this.btnBackMove);
            this.Controls.Add(this.btnGoToFirstMove);
            this.Controls.Add(this.pnBotCapturePieces);
            this.Controls.Add(this.pnTopCapturePieces);
            this.Controls.Add(this.pnChessBoard);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRewatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRewatch";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRewatch_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.fpnFiles.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbInfoChess.ResumeLayout(false);
            this.gbInfoChess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnBotCapturePieces;
        private System.Windows.Forms.Panel pnTopCapturePieces;
        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.Button btnPlayAndPause;
        private System.Windows.Forms.Button btnNextMove;
        private System.Windows.Forms.Button btnGoToEnd;
        private System.Windows.Forms.Button btnBackMove;
        private System.Windows.Forms.Button btnGoToFirstMove;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCountFriends;
        private System.Windows.Forms.FlowLayoutPanel fpnFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnPages;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbInfoChess;
        private System.Windows.Forms.Label lblWhite;
        private System.Windows.Forms.Label lblBlack;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblSignEndGame;
        private System.Windows.Forms.Label lblTypeEndgame;
        private System.Windows.Forms.Label lblStartTurn;
        private System.Windows.Forms.FlowLayoutPanel fpnNotations;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Timer timerPlaying;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ToolTip ttRestart;
        private System.Windows.Forms.ToolTip ttReverse;
        private System.Windows.Forms.ToolTip ttPlayOrPause;
        private System.Windows.Forms.ToolTip ttPrevMove;
        private System.Windows.Forms.ToolTip ttNextMove;
        private System.Windows.Forms.ToolTip ttFirstMove;
        private System.Windows.Forms.ToolTip ttLastMove;
    }
}