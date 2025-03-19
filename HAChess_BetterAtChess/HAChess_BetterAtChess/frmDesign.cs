using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public partial class frmDesign : Form
    {
        Chess chess;
        InfoSettingBoard infoSettingBoard;
        bool loadFen = false; 
        PagedList pages;
        int count1Page = 3;
        int maxPageShow = 3;
        int currentPage = 1;
        int currentIntPiece = -10;
        (int, int) currentCell = (-1, -1);
        bool loadCastle = false;
        string[] designs;
        int indexDesign = -1;
        Color colorSelect = Color.LightBlue;
        Color colorNormal = Color.White;
        public frmDesign()
        {
            InitializeComponent(); 
            loadChess();
            loadSettingBoard();
            setUpDesign();
            pages = new PagedList(pnPages, count1Page, maxPageShow, Color.Yellow, Color.Black, Color.White, Color.Navy);
            pages.sendPageNumber += receivePage;
            loadSavedFen(currentPage, txtSearch.Text);
            addToolTip();
            KeyPreview = true;
        }
        private void addToolTip()
        {
            ttSaveDesign.SetToolTip(btnSaveDesign, "Ctrl + S");
            ttReverse.SetToolTip(btnReverse, "Ctrl + 2");
            ttClearPieces.SetToolTip(btnClearPiece, "Ctrl + BackSpace");
            ttReset.SetToolTip(btnResetBasic, "Ctrl + Enter");
            ttTurn.SetToolTip(cbbStartTurn, "Chọn lượt đi tiếp theo cho quân nào");
        }
        private void receivePage(int page)
        {
            currentPage = page;
            loadSavedFen(currentPage, txtSearch.Text);
        }

        private void loadSavedFen(int page, string keyword)
        {
            fpnDesigns.Controls.Clear();
            int startIndex = (page - 1) * count1Page;
            int endIndex = startIndex + count1Page - 1;
            designs = Directory.GetFiles("assets/saved/designs/").Where(n => n.Contains(".txt")).ToArray(); ;

            if (string.IsNullOrEmpty(keyword))
            {
                for (int i = startIndex; i <= (designs.Length <= endIndex ? designs.Length - 1 : endIndex); i++)
                {
                    var tmp = designs[i].Split('/');
                    string name = tmp[tmp.Length - 1].Substring(0, tmp[tmp.Length - 1].LastIndexOf('.'));
                    string fen = File.ReadAllText(designs[i]);
                    Panel pn = new Panel()
                    {
                        Size = new Size(329, 110),
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand,
                        Tag = i,
                    };

                    if (i != indexDesign)
                    {
                        pn.BackColor = colorNormal;
                    }
                    else
                    {
                        pn.BackColor = colorSelect;
                    }
                    pn.Click += selectDesign;
                    fpnDesigns.Controls.Add(pn);

                    Label lbl = new Label()
                    {
                        AutoSize = false,
                        TextAlign = ContentAlignment.TopLeft,
                        Size = new Size(251, 28),
                        Text = name,
                        Location = new Point(5, 8),
                        ForeColor = Color.DarkCyan,
                        Tag = i,
                    };
                    pn.Controls.Add(lbl);
                    lbl.Click += selectDesign;

                    Label lblFen = new Label()
                    {
                        AutoSize = false,
                        TextAlign = ContentAlignment.TopLeft,
                        Size = new Size(251, 56),
                        Text = fen,
                        Location = new Point(9, 46),
                        ForeColor = Color.Black,
                        Tag = i,
                    };
                    pn.Controls.Add(lblFen);
                    lblFen.Click += selectDesign;


                    Button btn = new Button()
                    {
                        Size = new Size(50, 50),
                        Location = new Point(276, 5),
                        FlatStyle = FlatStyle.Flat,
                        Image = Image.FromFile("assets/imgs/decline.png"),
                        Tag = i,
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    pn.Controls.Add(btn);
                    btn.Click += deleteDesign;

                }
                int countPages = (designs.Length - 1) / count1Page + 1;
                if (countPages < currentPage)
                {
                    if (currentPage != 1)
                    {
                        currentPage--;
                    }
                }
                pages.initPagedList(designs.Length, currentPage);

            }
            else
            {
                int count = 0;
                int countFull = 0;
                for (int i = 0; i < designs.Length; i++)
                {
                    var tmp = designs[i].Split('/');
                    string name = tmp[tmp.Length - 1].Substring(0, tmp[tmp.Length - 1].LastIndexOf('.'));
                    if (name.Contains(keyword))
                    {
                        countFull++;
                        if (count >= startIndex && count <= endIndex)
                        {
                            Panel pn = new Panel()
                            {
                                Size = new Size(329, 68),
                                BorderStyle = BorderStyle.FixedSingle,
                                ForeColor = Color.DarkCyan,
                                Cursor = Cursors.Hand,
                                Tag = i,
                            };

                            if (i != indexDesign)
                            {
                                pn.BackColor = colorNormal;
                            }
                            else
                            {
                                pn.BackColor = colorSelect;
                            }
                            pn.Click += selectDesign;
                            fpnDesigns.Controls.Add(pn);

                            Label lbl = new Label()
                            {
                                AutoSize = false,
                                TextAlign = ContentAlignment.TopLeft,
                                Size = new Size(251, 44),
                                Text = name,
                                Location = new Point(5, 8),
                                Tag = i,
                            };
                            pn.Controls.Add(lbl);
                            lbl.Click += selectDesign;

                            Button btn = new Button()
                            {
                                Size = new Size(50, 50),
                                Location = new Point(276, 5),
                                FlatStyle = FlatStyle.Flat,
                                Image = Image.FromFile("assets/imgs/decline.png"),
                                Tag = i,
                            };
                            btn.FlatAppearance.BorderSize = 0;
                            pn.Controls.Add(btn);
                            btn.Click += deleteDesign;
                        }
                        count++;
                    }

                }
                int countPages = (countFull - 1) / count1Page + 1;
                if (countPages < currentPage)
                {
                    if (currentPage != 1)
                    {
                        currentPage--;
                    }
                }
                pages.initPagedList(countFull, currentPage);
            }
        }

        private void selectDesign(object sender, EventArgs e)
        {
            indexDesign = (int)((Control)sender).Tag; 
            for (int i = 0; i < fpnDesigns.Controls.Count; i++)
            {
                if ((int)fpnDesigns.Controls[i].Tag == indexDesign)
                {
                    fpnDesigns.Controls[i].BackColor = colorSelect;
                }
                else
                {
                    fpnDesigns.Controls[i].BackColor = colorNormal;
                }
            }
            string fen = File.ReadAllText(designs[indexDesign]);
            var board = Chess.convertFenToBoard(fen);
            if (board.Item1 != null)
            {
                chess.setChess(2, "", 0, chess.IsReverse, false, board.Item1, board.Item2, board.Item5, board.Item3, board.Item4, board.Item6, board.Item7);
                
                loadFen = false;
                cbbStartTurn.SelectedIndex = chess.StartWhiteTurn ? 0 : 1;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
            }
        }

        private void deleteDesign(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá thiết kế này không?", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            int index = (int)((Control)sender).Tag;
            File.Delete(designs[index]);
            if (index == indexDesign)
            {
                indexDesign = -1;
            }
            loadSavedFen(currentPage, txtSearch.Text);
        }

        private void setUpDesign()
        {
            ptrWhiteRook.Tag = Piece.ValueRook;
            ptrWhiteRook.Image = Image.FromFile(Piece.getPathImg(Piece.NameRook, Piece.ColorWhite));
            ptrWhiteRook.Click += selectPiece;
            ptrWhiteKnight.Tag = Piece.ValueKnight;
            ptrWhiteKnight.Image = Image.FromFile(Piece.getPathImg(Piece.NameKnight, Piece.ColorWhite));
            ptrWhiteKnight.Click += selectPiece;
            ptrWhiteBishop.Tag = Piece.ValueBishop;
            ptrWhiteBishop.Image = Image.FromFile(Piece.getPathImg(Piece.NameBishop, Piece.ColorWhite));
            ptrWhiteBishop.Click += selectPiece;
            ptrWhiteQueen.Tag = Piece.ValueQueen;
            ptrWhiteQueen.Image = Image.FromFile(Piece.getPathImg(Piece.NameQueen, Piece.ColorWhite));
            ptrWhiteQueen.Click += selectPiece;
            ptrWhiteKing.Tag = Piece.ValueKing;
            ptrWhiteKing.Image = Image.FromFile(Piece.getPathImg(Piece.NameKing, Piece.ColorWhite));
            ptrWhiteKing.Click += selectPiece;
            ptrWhitePawn.Tag = Piece.ValuePawn;
            ptrWhitePawn.Image = Image.FromFile(Piece.getPathImg(Piece.NamePawn, Piece.ColorWhite));
            ptrWhitePawn.Click += selectPiece;

            ptrBlackRook.Tag = -Piece.ValueRook;
            ptrBlackRook.Image = Image.FromFile(Piece.getPathImg(Piece.NameRook, Piece.ColorBlack));
            ptrBlackRook.Click += selectPiece;
            ptrBlackKnight.Tag = -Piece.ValueKnight;
            ptrBlackKnight.Image = Image.FromFile(Piece.getPathImg(Piece.NameKnight, Piece.ColorBlack));
            ptrBlackKnight.Click += selectPiece;
            ptrBlackBishop.Tag = -Piece.ValueBishop;
            ptrBlackBishop.Image = Image.FromFile(Piece.getPathImg(Piece.NameBishop, Piece.ColorBlack));
            ptrBlackBishop.Click += selectPiece;
            ptrBlackQueen.Tag = -Piece.ValueQueen;
            ptrBlackQueen.Image = Image.FromFile(Piece.getPathImg(Piece.NameQueen, Piece.ColorBlack));
            ptrBlackQueen.Click += selectPiece;
            ptrBlackKing.Tag = -Piece.ValueKing;
            ptrBlackKing.Image = Image.FromFile(Piece.getPathImg(Piece.NameKing, Piece.ColorBlack));
            ptrBlackKing.Click += selectPiece;
            ptrBlackPawn.Tag = -Piece.ValuePawn;
            ptrBlackPawn.Image = Image.FromFile(Piece.getPathImg(Piece.NamePawn, Piece.ColorBlack));
            ptrBlackPawn.Click += selectPiece;
            cbbStartTurn.SelectedIndex = 0;

            loadFen = false;
            txtFen.Text = chess.getCurrentFen();
            loadFen = true;
        }
        private void freezeBoard()
        {
            chess.cleanEvent();
            for (int i = 0; i < chess.Row; i++)
            {
                for (int j = 0; j < chess.Col; j++)
                {
                    chess.LblCells[i, j].Tag = (i, j);
                    chess.LblCells[i, j].Cursor = Cursors.Hand;
                    chess.LblCells[i, j].Click -= selectCellToChange;
                    chess.LblCells[i, j].Click += selectCellToChange;
                }
            }
            if (currentCell.Item1 != -1)
            {
                chess.LblCells[currentCell.Item1, currentCell.Item2].BackColor = chess.ColorSelect;
            }
        }
        private void selectCellToChange(object sender, EventArgs e)
        {
            freezeBoard();
            chess.clearColors();
            var tmp = ((int, int))((Control)sender).Tag;
            if (currentIntPiece == -10)
            {
                if (currentCell.Item1 == -1)
                {
                    currentCell = tmp;
                    chess.LblCells[currentCell.Item1, currentCell.Item2].BackColor = chess.ColorSelect;
                }
                else
                {
                    if (currentCell == tmp || chess.Int_board[currentCell.Item1, currentCell.Item2] == Piece.ValueNone)
                    {
                        currentCell = (-1, -1);
                        return;
                    }
                    int value = chess.Int_board[currentCell.Item1, currentCell.Item2];
                    chess.setCellFreeze(currentCell.Item1, currentCell.Item2, Piece.ValueNone);
                    chess.setCellFreeze(tmp.Item1, tmp.Item2, value);
                    if (chess.DetailBoard[tmp.Item1, tmp.Item2].Name == Piece.NamePawn)
                    {
                        if (chess.DetailBoard[tmp.Item1, tmp.Item2].Color == Piece.ColorWhite)
                        {
                            if (chess.IsReverse)
                            {
                                if (tmp.Item1 != 1)
                                {
                                    Pawn pawn = (Pawn)chess.DetailBoard[tmp.Item1, tmp.Item2];
                                    pawn.Step = 1;
                                    chess.DetailBoard[tmp.Item1, tmp.Item2] = pawn;
                                }
                            }
                            else
                            {
                                if (tmp.Item1 != chess.Row - 2)
                                {
                                    Pawn pawn = (Pawn)chess.DetailBoard[tmp.Item1, tmp.Item2];
                                    pawn.Step = 1;
                                    chess.DetailBoard[tmp.Item1, tmp.Item2] = pawn;
                                }
                            }
                        }
                        else
                        {
                            if (chess.IsReverse)
                            {
                                if (tmp.Item1 != chess.Row - 2)
                                {
                                    Pawn pawn = (Pawn)chess.DetailBoard[tmp.Item1, tmp.Item2];
                                    pawn.Step = 1;
                                    chess.DetailBoard[tmp.Item1, tmp.Item2] = pawn;
                                }
                            }
                            else
                            {
                                if (tmp.Item1 != 1)
                                {
                                    Pawn pawn = (Pawn)chess.DetailBoard[tmp.Item1, tmp.Item2];
                                    pawn.Step = 1;
                                    chess.DetailBoard[tmp.Item1, tmp.Item2] = pawn;
                                }
                            }
                        }
                    }
                    currentCell = (-1, -1);
                    loadFen = false;
                    txtFen.Text = chess.getCurrentFen();
                    loadFen = true;
                }
            }
            else
            {
                chess.setCellFreeze(tmp.Item1, tmp.Item2, currentIntPiece);
                loadFen = false;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
            }
        }
        private void selectPiece(object sender, EventArgs e)
        {
            for (int i = 0; i < pnWhitePieces.Controls.Count; i++)
            {
                pnWhitePieces.Controls[i].BackColor = pnBlackPieces.Controls[i].BackColor = Color.Transparent;
            }
            var tmp = (int)((Control)sender).Tag;
            if (currentIntPiece == tmp)
            {
                currentIntPiece = -10;
                return;
            }
            chess.clearColors();
            currentIntPiece = tmp;
            currentCell = (-1, -1);
            ((Control)sender).BackColor = chess.ColorSelect;
        }

        public void loadSettingBoard()
        {
            infoSettingBoard = InfoSettingBoard.getInfoSetting();
            chess.paintBoard(infoSettingBoard);
        }
        public void loadChess()
        {
            chess = new Chess(pnChessBoard.Width, 20);
            chess.muteSound = true;
            chess.initBoard(pnChessBoard);
            chess.setBasicChess("", 0, false, chess.IsReverse);
            freezeBoard();
        }



        private void cbbStartTurn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadFen)
            {
                chess.StartWhiteTurn = cbbStartTurn.SelectedIndex == 0;
                chess.ColorTurn = chess.StartWhiteTurn ? Piece.ColorWhite : Piece.ColorBlack;
                txtFen.Text = chess.getCurrentFen();
            }
        }


        private void btnClearPiece_Click(object sender, EventArgs e)
        {
            chess.clearPieces();

            loadFen = false;
            txtFen.Clear();
            loadFen = true;
        }

        private void btnSaveDesign_Click(object sender, EventArgs e)
        {
            frmSaveDesign save = new frmSaveDesign(chess.getCurrentFen());
            save.sendSaved += receiveSaveDesign;
            save.ShowDialog();
        }

        private void receiveSaveDesign()
        {
            loadSavedFen(currentPage, txtSearch.Text);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            chess.reverseBoard();
            freezeBoard();
        }

        private void btnResetBasic_Click(object sender, EventArgs e)
        {
            currentCell = (-1, -1);
            chess.setBasicChess("", 0, false, chess.IsReverse);
            freezeBoard();
            cbbStartTurn.SelectedIndex = chess.StartWhiteTurn ? 0 : 1;
            loadCastle = false;
            cbBlackLongCastle.Checked = cbBlackNearCastle.Checked = cbWhiteLongCastle.Checked = cbWhiteNearCastle.Checked = true;
            loadCastle = true;

            loadFen = false;
            txtFen.Text = chess.getCurrentFen();
            loadFen = true;
        }

        private void cbWhiteNearCastle_CheckedChanged(object sender, EventArgs e)
        {
            if (loadCastle)
            {
                //lấy king ra cho phép nhập thành

                loadFen = false;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
            }
        }

        private void cbWhiteLongCastle_CheckedChanged(object sender, EventArgs e)
        {
            if (loadCastle)
            {
                //lấy king ra cho phép nhập thành

                loadFen = false;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
            }
        }

        private void cbBlackNearCastle_CheckedChanged(object sender, EventArgs e)
        {
            if (loadCastle)
            {
                //lấy king ra cho phép nhập thành

                loadFen = false;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
            }
        }

        private void cbBlackLongCastle_CheckedChanged(object sender, EventArgs e)
        {
            if (loadCastle)
            {
                //lấy king ra cho phép nhập thành

                loadFen = false;
                txtFen.Text = chess.getCurrentFen();
                loadFen = true;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadSavedFen(currentPage, txtSearch.Text);
        }

        private void frmDesign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSaveDesign.PerformClick();
                        break;
                    case Keys.D2:
                        btnReverse.PerformClick();
                        break;
                    case Keys.Back:
                        btnClearPiece.PerformClick();
                        break;
                    case Keys.Enter:
                        btnResetBasic.PerformClick();
                        break;
                }
            }
        }
    }
}
