
namespace HAChess_BetterAtChess
{
    partial class frmPractice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPractice));
            this.pnChessBoard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnResign = new System.Windows.Forms.Button();
            this.btnMakeDraw = new System.Windows.Forms.Button();
            this.pnPromotion = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ptrBishop = new System.Windows.Forms.PictureBox();
            this.ptrKnight = new System.Windows.Forms.PictureBox();
            this.ptrRook = new System.Windows.Forms.PictureBox();
            this.ptrQueen = new System.Windows.Forms.PictureBox();
            this.pnTopCapturePieces = new System.Windows.Forms.Panel();
            this.pnBotCapturePieces = new System.Windows.Forms.Panel();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblStartTurn = new System.Windows.Forms.Label();
            this.gbInfoChess = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblSignEndGame = new System.Windows.Forms.Label();
            this.lblTypeEndgame = new System.Windows.Forms.Label();
            this.fpnNotations = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBackChess = new System.Windows.Forms.Button();
            this.btnGoToFirstMove = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbbTypeGame = new System.Windows.Forms.ComboBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.txtFen = new System.Windows.Forms.TextBox();
            this.ttRestart = new System.Windows.Forms.ToolTip(this.components);
            this.ttReverse = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrintFile = new System.Windows.Forms.ToolTip(this.components);
            this.ttPrevMove = new System.Windows.Forms.ToolTip(this.components);
            this.ttFirstMove = new System.Windows.Forms.ToolTip(this.components);
            this.pnPromotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrQueen)).BeginInit();
            this.gbInfoChess.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnChessBoard
            // 
            this.pnChessBoard.Location = new System.Drawing.Point(109, 92);
            this.pnChessBoard.Name = "pnChessBoard";
            this.pnChessBoard.Size = new System.Drawing.Size(700, 700);
            this.pnChessBoard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Luyện tập với cờ vua";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatAppearance.BorderSize = 3;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.ForeColor = System.Drawing.Color.DimGray;
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.Location = new System.Drawing.Point(21, 264);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(70, 70);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnResign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResign.FlatAppearance.BorderSize = 3;
            this.btnResign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResign.ForeColor = System.Drawing.Color.Crimson;
            this.btnResign.Location = new System.Drawing.Point(860, 424);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(146, 41);
            this.btnResign.TabIndex = 3;
            this.btnResign.Text = "Trắng đầu hàng";
            this.btnResign.UseVisualStyleBackColor = false;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // btnMakeDraw
            // 
            this.btnMakeDraw.BackColor = System.Drawing.Color.Lavender;
            this.btnMakeDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakeDraw.FlatAppearance.BorderSize = 3;
            this.btnMakeDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeDraw.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnMakeDraw.Location = new System.Drawing.Point(1069, 424);
            this.btnMakeDraw.Name = "btnMakeDraw";
            this.btnMakeDraw.Size = new System.Drawing.Size(146, 41);
            this.btnMakeDraw.TabIndex = 4;
            this.btnMakeDraw.Text = "Kết quả hoà";
            this.btnMakeDraw.UseVisualStyleBackColor = false;
            this.btnMakeDraw.Click += new System.EventHandler(this.btnMakeDraw_Click);
            // 
            // pnPromotion
            // 
            this.pnPromotion.Controls.Add(this.label2);
            this.pnPromotion.Controls.Add(this.ptrBishop);
            this.pnPromotion.Controls.Add(this.ptrKnight);
            this.pnPromotion.Controls.Add(this.ptrRook);
            this.pnPromotion.Controls.Add(this.ptrQueen);
            this.pnPromotion.Location = new System.Drawing.Point(860, 12);
            this.pnPromotion.Name = "pnPromotion";
            this.pnPromotion.Size = new System.Drawing.Size(421, 136);
            this.pnPromotion.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Phong cấp";
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
            // pnTopCapturePieces
            // 
            this.pnTopCapturePieces.Location = new System.Drawing.Point(486, 22);
            this.pnTopCapturePieces.Name = "pnTopCapturePieces";
            this.pnTopCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnTopCapturePieces.TabIndex = 6;
            // 
            // pnBotCapturePieces
            // 
            this.pnBotCapturePieces.Location = new System.Drawing.Point(487, 798);
            this.pnBotCapturePieces.Name = "pnBotCapturePieces";
            this.pnBotCapturePieces.Size = new System.Drawing.Size(322, 62);
            this.pnBotCapturePieces.TabIndex = 7;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.Crimson;
            this.lblTurn.Location = new System.Drawing.Point(21, 208);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(129, 19);
            this.lblTurn.TabIndex = 8;
            this.lblTurn.Text = "Lượt của trắng";
            // 
            // lblStartTurn
            // 
            this.lblStartTurn.AutoSize = true;
            this.lblStartTurn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTurn.Location = new System.Drawing.Point(21, 44);
            this.lblStartTurn.Name = "lblStartTurn";
            this.lblStartTurn.Size = new System.Drawing.Size(139, 19);
            this.lblStartTurn.TabIndex = 9;
            this.lblStartTurn.Text = "Lược đầu: trắng";
            // 
            // gbInfoChess
            // 
            this.gbInfoChess.BackColor = System.Drawing.Color.White;
            this.gbInfoChess.Controls.Add(this.lblResult);
            this.gbInfoChess.Controls.Add(this.lblTurn);
            this.gbInfoChess.Controls.Add(this.lblSignEndGame);
            this.gbInfoChess.Controls.Add(this.lblTypeEndgame);
            this.gbInfoChess.Controls.Add(this.lblStartTurn);
            this.gbInfoChess.Location = new System.Drawing.Point(860, 164);
            this.gbInfoChess.Name = "gbInfoChess";
            this.gbInfoChess.Size = new System.Drawing.Size(355, 240);
            this.gbInfoChess.TabIndex = 10;
            this.gbInfoChess.TabStop = false;
            this.gbInfoChess.Text = "Thông tin ván đấu";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResult.Location = new System.Drawing.Point(21, 165);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(76, 19);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "Kết quả:";
            // 
            // lblSignEndGame
            // 
            this.lblSignEndGame.AutoSize = true;
            this.lblSignEndGame.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignEndGame.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSignEndGame.Location = new System.Drawing.Point(21, 126);
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
            this.lblTypeEndgame.Location = new System.Drawing.Point(21, 86);
            this.lblTypeEndgame.Name = "lblTypeEndgame";
            this.lblTypeEndgame.Size = new System.Drawing.Size(117, 19);
            this.lblTypeEndgame.TabIndex = 10;
            this.lblTypeEndgame.Text = "Loại kết thúc:";
            // 
            // fpnNotations
            // 
            this.fpnNotations.AutoScroll = true;
            this.fpnNotations.Location = new System.Drawing.Point(885, 542);
            this.fpnNotations.Name = "fpnNotations";
            this.fpnNotations.Size = new System.Drawing.Size(304, 305);
            this.fpnNotations.TabIndex = 11;
            // 
            // btnBackChess
            // 
            this.btnBackChess.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnBackChess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackChess.FlatAppearance.BorderSize = 3;
            this.btnBackChess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackChess.ForeColor = System.Drawing.Color.DimGray;
            this.btnBackChess.Image = ((System.Drawing.Image)(resources.GetObject("btnBackChess.Image")));
            this.btnBackChess.Location = new System.Drawing.Point(21, 92);
            this.btnBackChess.Name = "btnBackChess";
            this.btnBackChess.Size = new System.Drawing.Size(70, 70);
            this.btnBackChess.TabIndex = 12;
            this.btnBackChess.UseVisualStyleBackColor = false;
            this.btnBackChess.Click += new System.EventHandler(this.btnBackChess_Click);
            // 
            // btnGoToFirstMove
            // 
            this.btnGoToFirstMove.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGoToFirstMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToFirstMove.FlatAppearance.BorderSize = 3;
            this.btnGoToFirstMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToFirstMove.ForeColor = System.Drawing.Color.DimGray;
            this.btnGoToFirstMove.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToFirstMove.Image")));
            this.btnGoToFirstMove.Location = new System.Drawing.Point(21, 176);
            this.btnGoToFirstMove.Name = "btnGoToFirstMove";
            this.btnGoToFirstMove.Size = new System.Drawing.Size(70, 70);
            this.btnGoToFirstMove.TabIndex = 13;
            this.btnGoToFirstMove.UseVisualStyleBackColor = false;
            this.btnGoToFirstMove.Click += new System.EventHandler(this.btnGoToFirstMove_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 3;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(21, 447);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 70);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbbTypeGame
            // 
            this.cbbTypeGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTypeGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTypeGame.FormattingEnabled = true;
            this.cbbTypeGame.Location = new System.Drawing.Point(860, 490);
            this.cbbTypeGame.Name = "cbbTypeGame";
            this.cbbTypeGame.Size = new System.Drawing.Size(355, 27);
            this.cbbTypeGame.TabIndex = 15;
            this.cbbTypeGame.SelectedIndexChanged += new System.EventHandler(this.cbbTypeGame_SelectedIndexChanged);
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.FlatAppearance.BorderSize = 3;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverse.ForeColor = System.Drawing.Color.DimGray;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(21, 355);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(70, 70);
            this.btnReverse.TabIndex = 16;
            this.btnReverse.UseVisualStyleBackColor = false;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // txtFen
            // 
            this.txtFen.Location = new System.Drawing.Point(109, 808);
            this.txtFen.Multiline = true;
            this.txtFen.Name = "txtFen";
            this.txtFen.Size = new System.Drawing.Size(372, 47);
            this.txtFen.TabIndex = 17;
            this.txtFen.TextChanged += new System.EventHandler(this.txtFen_TextChanged);
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
            // ttPrevMove
            // 
            this.ttPrevMove.ToolTipTitle = "Quay lại nước trước";
            // 
            // ttFirstMove
            // 
            this.ttFirstMove.ToolTipTitle = "Nước đầu tiên";
            // 
            // frmPractice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1294, 875);
            this.Controls.Add(this.txtFen);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.cbbTypeGame);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnGoToFirstMove);
            this.Controls.Add(this.btnBackChess);
            this.Controls.Add(this.fpnNotations);
            this.Controls.Add(this.gbInfoChess);
            this.Controls.Add(this.pnBotCapturePieces);
            this.Controls.Add(this.pnTopCapturePieces);
            this.Controls.Add(this.pnPromotion);
            this.Controls.Add(this.btnMakeDraw);
            this.Controls.Add(this.btnResign);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnChessBoard);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPractice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPractice";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPractice_KeyDown);
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

        private System.Windows.Forms.Panel pnChessBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.Button btnMakeDraw;
        private System.Windows.Forms.Panel pnPromotion;
        private System.Windows.Forms.PictureBox ptrBishop;
        private System.Windows.Forms.PictureBox ptrKnight;
        private System.Windows.Forms.PictureBox ptrRook;
        private System.Windows.Forms.PictureBox ptrQueen;
        private System.Windows.Forms.Panel pnTopCapturePieces;
        private System.Windows.Forms.Panel pnBotCapturePieces;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblStartTurn;
        private System.Windows.Forms.GroupBox gbInfoChess;
        private System.Windows.Forms.Label lblTypeEndgame;
        private System.Windows.Forms.Label lblSignEndGame;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.FlowLayoutPanel fpnNotations;
        private System.Windows.Forms.Button btnBackChess;
        private System.Windows.Forms.Button btnGoToFirstMove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbbTypeGame;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.TextBox txtFen;
        private System.Windows.Forms.ToolTip ttRestart;
        private System.Windows.Forms.ToolTip ttReverse;
        private System.Windows.Forms.ToolTip ttPrintFile;
        private System.Windows.Forms.ToolTip ttPrevMove;
        private System.Windows.Forms.ToolTip ttFirstMove;
    }
}