using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public partial class frmPrint : Form
    {
        int indexTypeGame, indexRegime;
        string notation;
        Chess chess;
        public frmPrint(Chess chess, int indexTypeGame, int indexRegime, string notation)
        {
            InitializeComponent();
            this.chess = chess;
            this.indexTypeGame = indexTypeGame;
            this.indexRegime = indexRegime;
            this.notation = notation;
            rtxNotations.Text = notation;
            if (indexTypeGame == 2)
            {
                lblTypeGame.Text = "Chế độ: Bàn cờ tự nhập";
            }
            else
            {
                lblTypeGame.Text = "Chế độ: " + TypeGame.typeGames[indexTypeGame];
            }
            if (indexRegime != -1)
            {
                lblRegime.Text = "Chế độ thời gian: " + Regime.regimes[indexRegime].ToShortString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameFile.Text))
            {
                MessageBox.Show("Vui lòng nhập tên file để lưu", "Cảnh báo", MessageBoxButtons.OK);
                txtNameFile.Focus();
                return;
            }
            string path = Chess.printFile(txtNameFile.Text, indexTypeGame, indexRegime, chess.Row, chess.Col, Chess.convertBoardToFen(chess.historyDetailBoard[0], chess.Row, chess.Col, chess.IsReverse, chess.StartWhiteTurn, chess.StartCountNoPawnNoCapture, chess.StartCountMoveOverall), chess.getStartInt(false), chess.getStartAbilities(false), chess.StartWhiteTurn, chess.StartCountNoPawnNoCapture, chess.StartCountMoveOverall, chess.currentResult, chess.currentDetailResult, notation, chess.saveMoves, chess.namePromotions);
            MessageBox.Show("Đã lưu thành công file game đấu tại địa chỉ: " + path + " trong folder game");
            Close();
        }
    }
}
