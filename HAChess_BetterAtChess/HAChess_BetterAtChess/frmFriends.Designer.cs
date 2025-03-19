
namespace HAChess_BetterAtChess
{
    partial class frmFriends
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFriends));
            this.fpnFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pnPagesFriends = new System.Windows.Forms.Panel();
            this.btnPrevFriend = new System.Windows.Forms.Button();
            this.btnNextFriend = new System.Windows.Forms.Button();
            this.pnChat = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUnfriend = new System.Windows.Forms.Button();
            this.lblNameAccount = new System.Windows.Forms.Label();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.rtxChat = new System.Windows.Forms.RichTextBox();
            this.fpnInviteds = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNextInvited = new System.Windows.Forms.Button();
            this.btnPrevInvited = new System.Windows.Forms.Button();
            this.pnPagesInvited = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchInvited = new System.Windows.Forms.TextBox();
            this.btnSearchInvited = new System.Windows.Forms.Button();
            this.btnSearchFriend = new System.Windows.Forms.Button();
            this.txtSearchFriends = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchNewFriend = new System.Windows.Forms.Button();
            this.txtSearchNewFriend = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timerChat = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCountFriends = new System.Windows.Forms.Label();
            this.btnReloadFriends = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReloadInvited = new System.Windows.Forms.Button();
            this.lblCountNewFriends = new System.Windows.Forms.Label();
            this.fpnNewFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCountInvites = new System.Windows.Forms.Label();
            this.btnPrevNewFriends = new System.Windows.Forms.Button();
            this.btnNextNewFriends = new System.Windows.Forms.Button();
            this.timerLoadStatus = new System.Windows.Forms.Timer(this.components);
            this.ttReloadFriends = new System.Windows.Forms.ToolTip(this.components);
            this.ttReloadInviteds = new System.Windows.Forms.ToolTip(this.components);
            this.fpnFriends.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnChat.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpnFriends
            // 
            this.fpnFriends.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpnFriends.Controls.Add(this.panel1);
            this.fpnFriends.Location = new System.Drawing.Point(7, 93);
            this.fpnFriends.Name = "fpnFriends";
            this.fpnFriends.Size = new System.Drawing.Size(334, 296);
            this.fpnFriends.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 66);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(277, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 22;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 32);
            this.label4.TabIndex = 21;
            this.label4.Text = "Bạn bè";
            // 
            // pnPagesFriends
            // 
            this.pnPagesFriends.Location = new System.Drawing.Point(88, 464);
            this.pnPagesFriends.Name = "pnPagesFriends";
            this.pnPagesFriends.Size = new System.Drawing.Size(178, 50);
            this.pnPagesFriends.TabIndex = 1;
            // 
            // btnPrevFriend
            // 
            this.btnPrevFriend.BackColor = System.Drawing.Color.White;
            this.btnPrevFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevFriend.FlatAppearance.BorderSize = 3;
            this.btnPrevFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevFriend.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrevFriend.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevFriend.Image")));
            this.btnPrevFriend.Location = new System.Drawing.Point(10, 464);
            this.btnPrevFriend.Name = "btnPrevFriend";
            this.btnPrevFriend.Size = new System.Drawing.Size(50, 50);
            this.btnPrevFriend.TabIndex = 2;
            this.btnPrevFriend.UseVisualStyleBackColor = false;
            this.btnPrevFriend.Click += new System.EventHandler(this.btnPrevFriend_Click);
            // 
            // btnNextFriend
            // 
            this.btnNextFriend.BackColor = System.Drawing.Color.White;
            this.btnNextFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextFriend.FlatAppearance.BorderSize = 3;
            this.btnNextFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextFriend.ForeColor = System.Drawing.Color.DimGray;
            this.btnNextFriend.Image = ((System.Drawing.Image)(resources.GetObject("btnNextFriend.Image")));
            this.btnNextFriend.Location = new System.Drawing.Point(287, 464);
            this.btnNextFriend.Name = "btnNextFriend";
            this.btnNextFriend.Size = new System.Drawing.Size(50, 50);
            this.btnNextFriend.TabIndex = 3;
            this.btnNextFriend.UseVisualStyleBackColor = false;
            this.btnNextFriend.Click += new System.EventHandler(this.btnNextFriend_Click);
            // 
            // pnChat
            // 
            this.pnChat.BackColor = System.Drawing.Color.Transparent;
            this.pnChat.Controls.Add(this.lblStatus);
            this.pnChat.Controls.Add(this.btnUnfriend);
            this.pnChat.Controls.Add(this.lblNameAccount);
            this.pnChat.Controls.Add(this.btnSendChat);
            this.pnChat.Controls.Add(this.txtChat);
            this.pnChat.Controls.Add(this.rtxChat);
            this.pnChat.Enabled = false;
            this.pnChat.Location = new System.Drawing.Point(380, 12);
            this.pnChat.Name = "pnChat";
            this.pnChat.Size = new System.Drawing.Size(599, 851);
            this.pnChat.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblStatus.Location = new System.Drawing.Point(15, 59);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(88, 19);
            this.lblStatus.TabIndex = 41;
            this.lblStatus.Text = "Trạng thái";
            // 
            // btnUnfriend
            // 
            this.btnUnfriend.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUnfriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnfriend.FlatAppearance.BorderSize = 3;
            this.btnUnfriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnfriend.ForeColor = System.Drawing.Color.Crimson;
            this.btnUnfriend.Location = new System.Drawing.Point(437, 16);
            this.btnUnfriend.Name = "btnUnfriend";
            this.btnUnfriend.Size = new System.Drawing.Size(140, 34);
            this.btnUnfriend.TabIndex = 21;
            this.btnUnfriend.Text = "Huỷ kết bạn";
            this.btnUnfriend.UseVisualStyleBackColor = false;
            this.btnUnfriend.Click += new System.EventHandler(this.btnUnfriend_Click);
            // 
            // lblNameAccount
            // 
            this.lblNameAccount.AutoSize = true;
            this.lblNameAccount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAccount.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblNameAccount.Location = new System.Drawing.Point(15, 16);
            this.lblNameAccount.Name = "lblNameAccount";
            this.lblNameAccount.Size = new System.Drawing.Size(157, 24);
            this.lblNameAccount.TabIndex = 23;
            this.lblNameAccount.Text = "Tên người chơi";
            // 
            // btnSendChat
            // 
            this.btnSendChat.BackColor = System.Drawing.Color.LightCyan;
            this.btnSendChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendChat.FlatAppearance.BorderSize = 3;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChat.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnSendChat.Image = ((System.Drawing.Image)(resources.GetObject("btnSendChat.Image")));
            this.btnSendChat.Location = new System.Drawing.Point(522, 746);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(50, 50);
            this.btnSendChat.TabIndex = 40;
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(19, 746);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(497, 92);
            this.txtChat.TabIndex = 39;
            this.txtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChat_KeyDown);
            // 
            // rtxChat
            // 
            this.rtxChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxChat.Location = new System.Drawing.Point(19, 90);
            this.rtxChat.Name = "rtxChat";
            this.rtxChat.ReadOnly = true;
            this.rtxChat.Size = new System.Drawing.Size(558, 640);
            this.rtxChat.TabIndex = 38;
            this.rtxChat.Text = "";
            // 
            // fpnInviteds
            // 
            this.fpnInviteds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpnInviteds.Location = new System.Drawing.Point(13, 100);
            this.fpnInviteds.Name = "fpnInviteds";
            this.fpnInviteds.Size = new System.Drawing.Size(334, 204);
            this.fpnInviteds.TabIndex = 1;
            // 
            // btnNextInvited
            // 
            this.btnNextInvited.BackColor = System.Drawing.Color.White;
            this.btnNextInvited.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextInvited.FlatAppearance.BorderSize = 3;
            this.btnNextInvited.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextInvited.ForeColor = System.Drawing.Color.DimGray;
            this.btnNextInvited.Image = ((System.Drawing.Image)(resources.GetObject("btnNextInvited.Image")));
            this.btnNextInvited.Location = new System.Drawing.Point(294, 366);
            this.btnNextInvited.Name = "btnNextInvited";
            this.btnNextInvited.Size = new System.Drawing.Size(50, 50);
            this.btnNextInvited.TabIndex = 7;
            this.btnNextInvited.UseVisualStyleBackColor = false;
            this.btnNextInvited.Click += new System.EventHandler(this.btnNextInvited_Click);
            // 
            // btnPrevInvited
            // 
            this.btnPrevInvited.BackColor = System.Drawing.Color.White;
            this.btnPrevInvited.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevInvited.FlatAppearance.BorderSize = 3;
            this.btnPrevInvited.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevInvited.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrevInvited.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevInvited.Image")));
            this.btnPrevInvited.Location = new System.Drawing.Point(13, 366);
            this.btnPrevInvited.Name = "btnPrevInvited";
            this.btnPrevInvited.Size = new System.Drawing.Size(50, 50);
            this.btnPrevInvited.TabIndex = 6;
            this.btnPrevInvited.UseVisualStyleBackColor = false;
            this.btnPrevInvited.Click += new System.EventHandler(this.btnPrevInvited_Click);
            // 
            // pnPagesInvited
            // 
            this.pnPagesInvited.Location = new System.Drawing.Point(91, 366);
            this.pnPagesInvited.Name = "pnPagesInvited";
            this.pnPagesInvited.Size = new System.Drawing.Size(178, 50);
            this.pnPagesInvited.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Lời mời kết bạn";
            // 
            // txtSearchInvited
            // 
            this.txtSearchInvited.Location = new System.Drawing.Point(13, 45);
            this.txtSearchInvited.Name = "txtSearchInvited";
            this.txtSearchInvited.Size = new System.Drawing.Size(210, 27);
            this.txtSearchInvited.TabIndex = 15;
            this.txtSearchInvited.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchInvited_KeyDown);
            // 
            // btnSearchInvited
            // 
            this.btnSearchInvited.BackColor = System.Drawing.Color.White;
            this.btnSearchInvited.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchInvited.FlatAppearance.BorderSize = 3;
            this.btnSearchInvited.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchInvited.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchInvited.Location = new System.Drawing.Point(229, 42);
            this.btnSearchInvited.Name = "btnSearchInvited";
            this.btnSearchInvited.Size = new System.Drawing.Size(115, 33);
            this.btnSearchInvited.TabIndex = 16;
            this.btnSearchInvited.Text = "Tìm kiếm";
            this.btnSearchInvited.UseVisualStyleBackColor = false;
            this.btnSearchInvited.Click += new System.EventHandler(this.btnSearchInvited_Click);
            // 
            // btnSearchFriend
            // 
            this.btnSearchFriend.BackColor = System.Drawing.Color.White;
            this.btnSearchFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchFriend.FlatAppearance.BorderSize = 3;
            this.btnSearchFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchFriend.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchFriend.Location = new System.Drawing.Point(229, 41);
            this.btnSearchFriend.Name = "btnSearchFriend";
            this.btnSearchFriend.Size = new System.Drawing.Size(115, 33);
            this.btnSearchFriend.TabIndex = 19;
            this.btnSearchFriend.Text = "Tìm kiếm";
            this.btnSearchFriend.UseVisualStyleBackColor = false;
            this.btnSearchFriend.Click += new System.EventHandler(this.btnSearchFriend_Click);
            // 
            // txtSearchFriends
            // 
            this.txtSearchFriends.Location = new System.Drawing.Point(7, 43);
            this.txtSearchFriends.Name = "txtSearchFriends";
            this.txtSearchFriends.Size = new System.Drawing.Size(210, 27);
            this.txtSearchFriends.TabIndex = 18;
            this.txtSearchFriends.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchFriends_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Bạn bè";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 29);
            this.label3.TabIndex = 20;
            this.label3.Text = "BẠN BÈ CỦA TÔI";
            // 
            // btnSearchNewFriend
            // 
            this.btnSearchNewFriend.BackColor = System.Drawing.Color.White;
            this.btnSearchNewFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchNewFriend.FlatAppearance.BorderSize = 3;
            this.btnSearchNewFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchNewFriend.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchNewFriend.Location = new System.Drawing.Point(229, 457);
            this.btnSearchNewFriend.Name = "btnSearchNewFriend";
            this.btnSearchNewFriend.Size = new System.Drawing.Size(115, 33);
            this.btnSearchNewFriend.TabIndex = 21;
            this.btnSearchNewFriend.Text = "Tìm kiếm";
            this.btnSearchNewFriend.UseVisualStyleBackColor = false;
            this.btnSearchNewFriend.Click += new System.EventHandler(this.btnSearchNewFriend_Click);
            // 
            // txtSearchNewFriend
            // 
            this.txtSearchNewFriend.Location = new System.Drawing.Point(13, 460);
            this.txtSearchNewFriend.Name = "txtSearchNewFriend";
            this.txtSearchNewFriend.Size = new System.Drawing.Size(210, 27);
            this.txtSearchNewFriend.TabIndex = 22;
            this.txtSearchNewFriend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchNewFriend_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "Thêm bạn mới";
            // 
            // timerChat
            // 
            this.timerChat.Interval = 500;
            this.timerChat.Tick += new System.EventHandler(this.timerChat_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Controls.Add(this.lblCountFriends);
            this.panel2.Controls.Add(this.btnReloadFriends);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.fpnFriends);
            this.panel2.Controls.Add(this.pnPagesFriends);
            this.panel2.Controls.Add(this.btnPrevFriend);
            this.panel2.Controls.Add(this.btnSearchFriend);
            this.panel2.Controls.Add(this.btnNextFriend);
            this.panel2.Controls.Add(this.txtSearchFriends);
            this.panel2.Location = new System.Drawing.Point(12, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 523);
            this.panel2.TabIndex = 41;
            // 
            // lblCountFriends
            // 
            this.lblCountFriends.AutoSize = true;
            this.lblCountFriends.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountFriends.ForeColor = System.Drawing.Color.Black;
            this.lblCountFriends.Location = new System.Drawing.Point(6, 402);
            this.lblCountFriends.Name = "lblCountFriends";
            this.lblCountFriends.Size = new System.Drawing.Size(103, 19);
            this.lblCountFriends.TabIndex = 17;
            this.lblCountFriends.Text = "Số lượng: 0";
            // 
            // btnReloadFriends
            // 
            this.btnReloadFriends.BackColor = System.Drawing.Color.White;
            this.btnReloadFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReloadFriends.FlatAppearance.BorderSize = 3;
            this.btnReloadFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadFriends.ForeColor = System.Drawing.Color.DarkGray;
            this.btnReloadFriends.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadFriends.Image")));
            this.btnReloadFriends.Location = new System.Drawing.Point(287, 395);
            this.btnReloadFriends.Name = "btnReloadFriends";
            this.btnReloadFriends.Size = new System.Drawing.Size(50, 50);
            this.btnReloadFriends.TabIndex = 63;
            this.btnReloadFriends.UseVisualStyleBackColor = false;
            this.btnReloadFriends.Click += new System.EventHandler(this.btnReloadFriends_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Thistle;
            this.panel3.Controls.Add(this.btnReloadInvited);
            this.panel3.Controls.Add(this.lblCountNewFriends);
            this.panel3.Controls.Add(this.fpnNewFriends);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.lblCountInvites);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtSearchNewFriend);
            this.panel3.Controls.Add(this.fpnInviteds);
            this.panel3.Controls.Add(this.btnPrevNewFriends);
            this.panel3.Controls.Add(this.pnPagesInvited);
            this.panel3.Controls.Add(this.btnSearchNewFriend);
            this.panel3.Controls.Add(this.btnPrevInvited);
            this.panel3.Controls.Add(this.btnNextNewFriends);
            this.panel3.Controls.Add(this.btnNextInvited);
            this.panel3.Controls.Add(this.txtSearchInvited);
            this.panel3.Controls.Add(this.btnSearchInvited);
            this.panel3.Location = new System.Drawing.Point(985, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 810);
            this.panel3.TabIndex = 42;
            // 
            // btnReloadInvited
            // 
            this.btnReloadInvited.BackColor = System.Drawing.Color.White;
            this.btnReloadInvited.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReloadInvited.FlatAppearance.BorderSize = 3;
            this.btnReloadInvited.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadInvited.ForeColor = System.Drawing.Color.DarkGray;
            this.btnReloadInvited.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadInvited.Image")));
            this.btnReloadInvited.Location = new System.Drawing.Point(294, 310);
            this.btnReloadInvited.Name = "btnReloadInvited";
            this.btnReloadInvited.Size = new System.Drawing.Size(50, 50);
            this.btnReloadInvited.TabIndex = 64;
            this.btnReloadInvited.UseVisualStyleBackColor = false;
            this.btnReloadInvited.Click += new System.EventHandler(this.btnReloadInvited_Click);
            // 
            // lblCountNewFriends
            // 
            this.lblCountNewFriends.AutoSize = true;
            this.lblCountNewFriends.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountNewFriends.ForeColor = System.Drawing.Color.Black;
            this.lblCountNewFriends.Location = new System.Drawing.Point(9, 718);
            this.lblCountNewFriends.Name = "lblCountNewFriends";
            this.lblCountNewFriends.Size = new System.Drawing.Size(103, 19);
            this.lblCountNewFriends.TabIndex = 24;
            this.lblCountNewFriends.Text = "Số lượng: 0";
            // 
            // fpnNewFriends
            // 
            this.fpnNewFriends.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpnNewFriends.Location = new System.Drawing.Point(13, 505);
            this.fpnNewFriends.Name = "fpnNewFriends";
            this.fpnNewFriends.Size = new System.Drawing.Size(334, 204);
            this.fpnNewFriends.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(91, 747);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(178, 50);
            this.panel5.TabIndex = 5;
            // 
            // lblCountInvites
            // 
            this.lblCountInvites.AutoSize = true;
            this.lblCountInvites.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountInvites.ForeColor = System.Drawing.Color.Black;
            this.lblCountInvites.Location = new System.Drawing.Point(9, 320);
            this.lblCountInvites.Name = "lblCountInvites";
            this.lblCountInvites.Size = new System.Drawing.Size(103, 19);
            this.lblCountInvites.TabIndex = 20;
            this.lblCountInvites.Text = "Số lượng: 0";
            // 
            // btnPrevNewFriends
            // 
            this.btnPrevNewFriends.BackColor = System.Drawing.Color.White;
            this.btnPrevNewFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevNewFriends.FlatAppearance.BorderSize = 3;
            this.btnPrevNewFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevNewFriends.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrevNewFriends.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevNewFriends.Image")));
            this.btnPrevNewFriends.Location = new System.Drawing.Point(13, 747);
            this.btnPrevNewFriends.Name = "btnPrevNewFriends";
            this.btnPrevNewFriends.Size = new System.Drawing.Size(50, 50);
            this.btnPrevNewFriends.TabIndex = 6;
            this.btnPrevNewFriends.UseVisualStyleBackColor = false;
            this.btnPrevNewFriends.Click += new System.EventHandler(this.btnPrevNewFriends_Click);
            // 
            // btnNextNewFriends
            // 
            this.btnNextNewFriends.BackColor = System.Drawing.Color.White;
            this.btnNextNewFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextNewFriends.FlatAppearance.BorderSize = 3;
            this.btnNextNewFriends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextNewFriends.ForeColor = System.Drawing.Color.DimGray;
            this.btnNextNewFriends.Image = ((System.Drawing.Image)(resources.GetObject("btnNextNewFriends.Image")));
            this.btnNextNewFriends.Location = new System.Drawing.Point(294, 747);
            this.btnNextNewFriends.Name = "btnNextNewFriends";
            this.btnNextNewFriends.Size = new System.Drawing.Size(50, 50);
            this.btnNextNewFriends.TabIndex = 7;
            this.btnNextNewFriends.UseVisualStyleBackColor = false;
            this.btnNextNewFriends.Click += new System.EventHandler(this.btnNextNewFriends_Click);
            // 
            // timerLoadStatus
            // 
            this.timerLoadStatus.Interval = 1000;
            this.timerLoadStatus.Tick += new System.EventHandler(this.timerLoadStatus_Tick);
            // 
            // ttReloadFriends
            // 
            this.ttReloadFriends.ToolTipTitle = "Load lại danh sách bạn bè";
            // 
            // ttReloadInviteds
            // 
            this.ttReloadInviteds.ToolTipTitle = "Load lại danh sách lời mời kết bạn";
            // 
            // frmFriends
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1354, 875);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnChat);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFriends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFriends";
            this.fpnFriends.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnChat.ResumeLayout(false);
            this.pnChat.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnFriends;
        private System.Windows.Forms.Panel pnPagesFriends;
        private System.Windows.Forms.Button btnPrevFriend;
        private System.Windows.Forms.Button btnNextFriend;
        private System.Windows.Forms.Panel pnChat;
        private System.Windows.Forms.FlowLayoutPanel fpnInviteds;
        private System.Windows.Forms.Button btnNextInvited;
        private System.Windows.Forms.Button btnPrevInvited;
        private System.Windows.Forms.Panel pnPagesInvited;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchInvited;
        private System.Windows.Forms.Button btnSearchInvited;
        private System.Windows.Forms.Button btnSearchFriend;
        private System.Windows.Forms.TextBox txtSearchFriends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxChat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameAccount;
        private System.Windows.Forms.Button btnUnfriend;
        private System.Windows.Forms.Button btnSearchNewFriend;
        private System.Windows.Forms.TextBox txtSearchNewFriend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerChat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel fpnNewFriends;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnPrevNewFriends;
        private System.Windows.Forms.Button btnNextNewFriends;
        private System.Windows.Forms.Label lblCountFriends;
        private System.Windows.Forms.Label lblCountNewFriends;
        private System.Windows.Forms.Label lblCountInvites;
        private System.Windows.Forms.Timer timerLoadStatus;
        private System.Windows.Forms.Button btnReloadFriends;
        private System.Windows.Forms.Button btnReloadInvited;
        private System.Windows.Forms.ToolTip ttReloadFriends;
        private System.Windows.Forms.ToolTip ttReloadInviteds;
    }
}