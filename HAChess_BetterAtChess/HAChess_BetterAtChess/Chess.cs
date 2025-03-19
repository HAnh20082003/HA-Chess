using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;


namespace HAChess_BetterAtChess
{
    public class Chess
    {
        public delegate void SendResetValue();
        public SendResetValue sendReset;
        public delegate void SendReverse(bool isReverse);
        public SendReverse sendReverse;
        public delegate void SendBackBoard(bool isWhiteTurn);
        public SendBackBoard sendBackBoard;
        public delegate void SendHint(string hint);
        public SendHint sendHint;
        public delegate void SendTime(bool isTop, string time, int timeBonus);
        public SendTime sendTime;
        public delegate void SendResign(bool isWhitePlayer);
        public SendResign sendResign;
        public delegate void SendDraw();
        public SendDraw sendDraw;
        public delegate void SendTimeOut(bool isWhitePlayer);
        public SendTimeOut sendTimeOut;
        public delegate void SendExit();
        public SendExit sendExit;
        public delegate void SendMessage(string message);
        public delegate void SendEndGame(string currentScore, string result, string detailResult);
        public delegate void SendChangeTurn(bool isWhiteColor);
        public delegate void SendMove(string strMove, string namePromotion, bool isWhiteTurn);
        public delegate void SendPromotion(bool colorTurn);
        public SendPromotion sendPromotion;
        public delegate void SendUnPromotion();
        public SendUnPromotion sendUnPromotion;
        public SendMessage sendMessage;
        public SendEndGame sendEndGame;
        public SendChangeTurn sendChangeTurn;
        public SendMove sendMove;
        public delegate void SendStrNotation(string strNotation);
        public SendStrNotation sendStrNotation;

        public List<(string, string, string)> movesMatch = new List<(string, string, string)>();

        public static string folderSaveMatches = "assets/saved/matches/";

        public bool muteSound = false;

        public bool autoBotPlay = true;
        //Properities
        private int row = 8, col = 8;
        private int sizeBoard;
        private int sizeCell;
        private int sizeRuler;
        private Panel pnBoard;
        private Label[] rulerWidth, rulerHeight;
        private string[] strAlphas, strNumbers;
        private Color[,] colorCells;
        private int[,] int_board;
        private PictureBox[,] lblCells;
        private Piece[,] detailBoard;
        private Color currentColorLight = Color.White, currentColorDark = Color.DarkSeaGreen;
        private Color colorSelect = Color.Yellow, colorPrevMoved = Color.Khaki, colorDesMoved = Color.DarkKhaki, colorRecommendMove = Color.CadetBlue, colorRecommendCapture = Color.Crimson;
        private Color colorHint;
        private Color colorTextRuler = Color.Crimson;
        private Color colorBackRuler = Color.White;
        public Point currentSelect, currentPrevMoved, currentDesMoved;
        private string colorTurn;
        private bool isReverse;
        private Piece currentTakedPiece;
        private string currentNotationCastle;
        public string currentScore = null, currentResult = null, currentDetailResult = null;
        public List<Piece[,]> historyDetailBoard = new List<Piece[,]>();
        public List<Point> lstPrevMoved = new List<Point>();
        public List<Point> lstDesMoved = new List<Point>();
        private Label lblTitleWatch;
        //private List<(int, string, string)> notations = new List<(int, string, string)>();
        //private List<(int, string, string)> currentNotations = new List<(int, string, string)>();
        private string line = "-----------------------------------------------------------------";
        private List<int> countWhites = new List<int>();
        private List<int> countBlacks = new List<int>();
        private List<int> countMoveOveralls = new List<int>();
        private static List<string> typeGames = new List<string>() { "Tiêu chuẩn", "Chess960", "Custom" };
        private static string nameNoName = "Không xác định";
        private bool autoPlay = false;
        private bool isEnd = false;
        private int timeDelayWatch = 1000;
        private Timer timerWatch;
        private string[,] startAbilities;
        public string[,] abilities;
        private bool startWhiteTurn = true;
        private string typeEndWatch = null;
        private string detailEndWatch = null;
        private string namePlayer1;
        private string namePlayer2;
        private Label lblBestMoveByStockfish;
        private BotChess botPlayer1 = null, botPlayer2 = null;
        private BotChess botSoluteHint = BotChess.getBotRecommendChess(BotChess.nameStockfish16);
        private string currentNamePromotion = null;
        public static int maxRowCol = 10;
        public List<(string, string)> timeEveryMove = new List<(string, string)>();
        private string startTime;
        private bool startTimer;
        private string hint = null;
        private (Point, Point) locaHint; 

        private int countHint = 0;
        private int countMaxHint = 3;
        private bool showHint = false;


        private static string nameSoundCheckmate = "Checkmate";
        private static string nameSoundCapture = "Capture";
        private static string nameSoundCastle = "Castle";
        private static string nameSoundCheck = "Check";
        private static string nameSoundDraw_Or_Resign = "Draw_Or_Resign";
        private static string nameSoundMove = "Move";
        private static string nameSoundPromote = "Promote";
        private static string nameSoundStart = "Start";
        private static string defaultPlayer1 = "Người chơi 1";
        private static string defaultPlayer2 = "Người chơi 2";
        public static int maxSecondDelay = 10;

        private List<int>[] countWhiteCapture = new List<int>[6];
        private List<int>[] countBlackCapture = new List<int>[6];
        private List<int> indexsWhitePieceCapture = new List<int>();
        private List<int> indexsBlackPieceCapture = new List<int>();

        Point prevLocationPromotion, desLocationPromotion;

        private Timer timerPlay;
        private string topTime, botTime;

        private int startCountNoPawnNoCapture = 0, startCountMoveOverall = 0, countNoPawnNoCapture = 0, countMoveOverall = 0;

        public int timeBonus = 0;

        //internal List<tb_MoveInMatch> moves = new List<tb_MoveInMatch>();

        public List<string> saveMoves = new List<string>();
        public List<string> namePromotions = new List<string>();

        //Getter Setter
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public int[,] Int_board { get => int_board; set => int_board = value; }
        public bool IsReverse { get => isReverse; set => isReverse = value; }
        public Label LblTitleWatch { get => lblTitleWatch; set => lblTitleWatch = value; }
        public string Line { get => line; set => line = value; }
        public Panel PnBoard { get => pnBoard; set => pnBoard = value; }
        public static List<string> TypeGames { get => typeGames; set => typeGames = value; }
        public bool AutoPlay { get => autoPlay; set => autoPlay = value; }
        public bool IsEnd { get => isEnd; set => isEnd = value; }
        public static string NameNoName { get => nameNoName; set => nameNoName = value; }
        public int TimeDelayWatchTxt { get => timeDelayWatch; set => timeDelayWatch = value; }
        public Timer TimerWatchTxt { get => timerWatch; set => timerWatch = value; }
        public string ColorTurn { get => colorTurn; set => colorTurn = value; }
        public Color CurrentColorLight { get => currentColorLight; set => currentColorLight = value; }
        public Color CurrentColorDark { get => currentColorDark; set => currentColorDark = value; }
        public Color ColorSelect { get => colorSelect; set => colorSelect = value; }
        public Color ColorRecommendMove { get => colorRecommendMove; set => colorRecommendMove = value; }
        public Color ColorRecommendCapture { get => colorRecommendCapture; set => colorRecommendCapture = value; }
        public Color ColorPrevMoved { get => colorPrevMoved; set => colorPrevMoved = value; }
        public Color ColorDesMoved { get => colorDesMoved; set => colorDesMoved = value; }
        public PictureBox[,] LblCells { get => lblCells; set => lblCells = value; }
        internal Piece[,] DetailBoard { get => detailBoard; set => detailBoard = value; }
        public Color[,] ColorCells { get => colorCells; set => colorCells = value; }
        public string[,] StartAbilities { get => startAbilities; set => startAbilities = value; }
        public bool StartWhiteTurn { get => startWhiteTurn; set => startWhiteTurn = value; }
        public string TypeEndWatch { get => typeEndWatch; set => typeEndWatch = value; }
        public string NamePlayer1 { get => namePlayer1; set => namePlayer1 = value; }
        public string NamePlayer2 { get => namePlayer2; set => namePlayer2 = value; }
        public static string DefaultPlayer1 { get => defaultPlayer1; set => defaultPlayer1 = value; }
        public static string DefaultPlayer2 { get => defaultPlayer2; set => defaultPlayer2 = value; }
        public List<int> CountWhites { get => countWhites; set => countWhites = value; }
        public List<int> CountBlacks { get => countBlacks; set => countBlacks = value; }
        public List<int> CountMoveOveralls { get => countMoveOveralls; set => countMoveOveralls = value; }
        public Label LblBestMoveByStockfish { get => lblBestMoveByStockfish; set => lblBestMoveByStockfish = value; }
        internal BotChess BotPlayer1 { get => botPlayer1; set => botPlayer1 = value; }
        internal BotChess BotPlayer2 { get => botPlayer2; set => botPlayer2 = value; }
        public string DetailEndWatch { get => detailEndWatch; set => detailEndWatch = value; }
        public Timer TimerPlay { get => timerPlay; set => timerPlay = value; }
        public bool StartTimer { get => startTimer; set => startTimer = value; }
        public string TopTime { get => topTime; set => topTime = value; }
        public string BotTime { get => botTime; set => botTime = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public Color ColorHint { get => colorHint; set => colorHint = value; }
        public int CountHint { get => countHint; set => countHint = value; }
        public int CountMaxHint { get => countMaxHint; set => countMaxHint = value; }
        public (Point, Point) LocaHint { get => locaHint; set => locaHint = value; }
        //public List<(int, string, string)> CurrentNotations { get => currentNotations; set => currentNotations = value; }
        public int StartCountNoPawnNoCapture { get => startCountNoPawnNoCapture; set => startCountNoPawnNoCapture = value; }
        public int StartCountMoveOverall { get => startCountMoveOverall; set => startCountMoveOverall = value; }
        public int CountNoPawnNoCapture { get => countNoPawnNoCapture; set => countNoPawnNoCapture = value; }
        public int CountMoveOverall { get => countMoveOverall; set => countMoveOverall = value; }



        //Generator
        public Chess(int sizeBoard, int sizeRuler, Color colorLight, Color colorDark, Color colorSelect, Color colorPrevMoved, Color colorDesMoved, Color colorRecommendMove, Color colorRecommendCapture, Color colorHint, bool isReverse = false)
        {
            this.sizeBoard = sizeBoard;
            this.sizeRuler = sizeRuler;
            sizeCell = (sizeBoard - sizeRuler) / Row;
            createColorBoard(colorLight, colorDark);
            this.colorSelect = colorSelect;
            this.colorPrevMoved = colorPrevMoved;
            this.colorDesMoved = colorDesMoved;
            this.colorRecommendMove = colorRecommendMove;
            this.colorRecommendCapture = colorRecommendCapture;
            this.colorHint = colorHint;
            IsReverse = isReverse;
            timerWatch = new Timer();
            timerWatch.Interval = timeDelayWatch;
            timerWatch.Tick += timerWatchTick;
            timerPlay = new Timer();
            timerPlay.Interval = 1000;
            timerPlay.Tick += timerPlay_Tick;
            botSoluteHint.sendBestMove += moveByStrLocate;
        }
        public Chess(int sizeBoard, int sizeRuler, bool isReverse = false)
        {
            this.sizeBoard = sizeBoard;
            this.sizeRuler = sizeRuler;
            createColorBoard(currentColorLight, CurrentColorDark);
            sizeCell = (sizeBoard - sizeRuler) / Row;
            IsReverse = isReverse;
            timerWatch = new Timer();
            timerWatch.Interval = timeDelayWatch;
            timerWatch.Tick += timerWatchTick;
            timerPlay = new Timer();
            timerPlay.Interval = 1000;
            timerPlay.Tick += timerPlay_Tick;
            botSoluteHint.sendBestMove += moveByStrLocate;
        }

        //METHODS
        private PictureBox getNoneCell(int locaX, int locaY, object tag, Color color)
        {
            return new PictureBox()
            {
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(sizeCell, sizeCell),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(locaX, locaY),
                BackColor = color,
                Tag = tag,
            };
        }

        private void createRuler()
        {
            rulerWidth = new Label[Col];
            rulerHeight = new Label[Row];
            strAlphas = new string[Col];
            strNumbers = new string[Row];
            for (int i = 0; i < Col; i++)
            {
                strAlphas[i] = ((char)('A' + i)).ToString();
                rulerWidth[i] = new Label()
                {
                    Text = strAlphas[i],
                    AutoSize = false,
                    Size = new Size(sizeCell, sizeRuler),
                    Location = new Point(sizeRuler + sizeCell * i, sizeBoard - sizeRuler),
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                    ForeColor = colorTextRuler,
                    BackColor = colorBackRuler,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                PnBoard.Controls.Add(rulerWidth[i]);
            }
            for (int i = 0; i < Row; i++)
            {
                strNumbers[i] = (Row - i).ToString();
                rulerHeight[i] = new Label()
                {
                    Text = strNumbers[i],
                    AutoSize = false,
                    Size = new Size(sizeRuler, sizeCell),
                    Location = new Point(0, sizeCell * i),
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                    ForeColor = colorTextRuler,
                    BackColor = colorBackRuler,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                PnBoard.Controls.Add(rulerHeight[i]);
            }
        }

        public void clearEvent(Point location)
        {
            if (location.X < 0 || location.Y >= Row || location.Y < 0 || location.Y >= Col)
            {
                return;
            }
            lblCells[location.X, location.Y].MouseClick -= selectPiece;
            lblCells[location.X, location.Y].MouseClick -= selectMoveTo;
            lblCells[location.X, location.Y].MouseClick -= selectCapture;
            lblCells[location.X, location.Y].MouseClick -= selectNonePiece;
        }

        public void setCell(int i, int j, int value)
        {
            Piece piece = new Piece(i, j, i, j, value);
            detailBoard[i, j] = piece.findPiece();
            clearEvent(new Point(i, j));
            if (detailBoard[i, j] == null) //ô rỗng
            {
                lblCells[i, j].Image = null;
                try
                {
                    lblCells[i, j].Invoke((Action)(() => {
                        lblCells[i, j].Cursor = Cursors.Hand;
                        lblCells[i, j].MouseClick += selectNonePiece;
                    }));
                }
                catch
                {
                    lblCells[i, j].Cursor = Cursors.Hand;
                    lblCells[i, j].MouseClick += selectNonePiece;
                }
            }
            else
            {
                if (detailBoard[i, j].Name == Piece.NamePawn)
                {
                    if (isReverse)
                    {
                        if (detailBoard[i, j].Color == Piece.ColorWhite)
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = true;
                            detailBoard[i, j] = pawn;
                        }
                        else
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = false;
                            detailBoard[i, j] = pawn;
                        }
                    }
                    else
                    {
                        if (detailBoard[i, j].Color == Piece.ColorWhite)
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = false;
                            detailBoard[i, j] = pawn;
                        }
                        else
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = true;
                            detailBoard[i, j] = pawn;
                        }
                    }
                }
                detailBoard[i, j].Row = row;
                detailBoard[i, j].Col = col;

                lblCells[i, j].Image = Image.FromFile(piece.getPathImg());
                try
                {
                    lblCells[i, j].Invoke((Action)(() => {
                        lblCells[i, j].Cursor = Cursors.Hand;
                        lblCells[i, j].MouseClick += selectPiece;
                    }));
                }
                catch
                {
                    lblCells[i, j].Cursor = Cursors.Hand;
                    lblCells[i, j].MouseClick += selectPiece;
                }
            }
        }
        public void setCellFreeze(int i, int j, int value)
        {
            Piece piece = new Piece(i, j, i, j, value);
            detailBoard[i, j] = piece.findPiece();
            int_board[i, j] = value;
            if (detailBoard[i, j] != null) //ô rỗng
            {
                if (detailBoard[i, j].Name == Piece.NamePawn)
                {
                    if (isReverse)
                    {
                        if (detailBoard[i, j].Color == Piece.ColorWhite)
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = true;
                            detailBoard[i, j] = pawn;
                        }
                        else
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = false;
                            detailBoard[i, j] = pawn;
                        }
                    }
                    else
                    {
                        if (detailBoard[i, j].Color == Piece.ColorWhite)
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = false;
                            detailBoard[i, j] = pawn;
                        }
                        else
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            pawn.IsUp = true;
                            detailBoard[i, j] = pawn;
                        }
                    }
                }
                detailBoard[i, j].Row = row;
                detailBoard[i, j].Col = col;

                lblCells[i, j].Image = Image.FromFile(piece.getPathImg());
            }
            else
            {
                lblCells[i, j].Image = null;
            }
        }

        //Reset giá trị mặc định
        private void resetValues()
        {
            abilities = (string[,])startAbilities.Clone();
            saveMoves.Clear();
            namePromotions.Clear();
            countNoPawnNoCapture = startCountNoPawnNoCapture;
            countMoveOverall = startCountMoveOverall;
            locaHint.Item1 = new Point(-1, -1);
            locaHint.Item2 = new Point(-1, -1);
            countHint = 0;
            timerPlay.Stop();
            IsEnd = false;
            currentScore = currentResult = currentDetailResult = null;
            currentTakedPiece = null;
            //CurrentNotations.Clear();
            updateTime(startTime, startTime, timeBonus);
            timeEveryMove.Clear();
            currentDesMoved = new Point(-1, -1);
            currentPrevMoved = new Point(-1, -1);
            currentSelect = new Point(-1, -1);
            lstDesMoved.Clear();
            lstPrevMoved.Clear();
            clearColor(true);
            countWhites.Clear();
            countBlacks.Clear();
            countMoveOveralls.Clear();
            CountWhites.Add(0);
            countBlacks.Add(0);
            countMoveOveralls.Add(1);
            indexsWhitePieceCapture.Clear();
            indexsBlackPieceCapture.Clear();
            indexsWhitePieceCapture.Add(-1);
            indexsBlackPieceCapture.Add(-1);
            for (int i = 0; i < countWhiteCapture.Length; i++)
            {
                if (countWhiteCapture[i] == null)
                {
                    countWhiteCapture[i] = new List<int>();
                }
                else
                {
                    countWhiteCapture[i].Clear();
                }
                countWhiteCapture[i].Add(0);
            }

            for (int i = 0; i < countBlackCapture.Length; i++)
            {
                if (countBlackCapture[i] == null)
                {
                    countBlackCapture[i] = new List<int>();
                }
                else
                {
                    countBlackCapture[i].Clear();
                }
                countBlackCapture[i].Add(0);
            }

            colorTurn = startWhiteTurn ? Piece.ColorWhite : Piece.ColorBlack;
            if (sendChangeTurn != null)
            {
                sendChangeTurn(ColorTurn == Piece.ColorWhite);
            }
            historyDetailBoard.Clear();
        }

        //Sao chép y hệt chi tiết bàn cờ hiện tại
        private Piece[,] getCoppyDetailBoard(Piece[,] board = null)
        {
            Piece[,] tmp = new Piece[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (board == null)
                    {
                        if (detailBoard[i, j] == null)
                        {
                            tmp[i, j] = null;
                        }
                        else
                        {
                            tmp[i, j] = detailBoard[i, j].getCoppy();
                        }
                    }
                    else
                    {
                        if (board[i, j] == null)
                        {
                            tmp[i, j] = null;
                        }
                        else
                        {
                            tmp[i, j] = board[i, j].getCoppy();
                        }
                    }
                }
            }
            return tmp;
        }

        //Dọn dẹp màu và chuẩn hoá lại sự kiện
        private void clearColor(bool clearHint)
        {
            if (clearHint)
            {
                showHint = false;
            }
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    clearEvent(new Point(i, j));
                    if (detailBoard[i, j] == null)
                    {
                        try
                        {
                            lblCells[i, j].Invoke((Action)(() => {
                                lblCells[i, j].Cursor = Cursors.Hand;
                                lblCells[i, j].MouseClick += selectNonePiece;
                            }));
                        }
                        catch
                        {
                            lblCells[i, j].Cursor = Cursors.Hand;
                            lblCells[i, j].MouseClick += selectNonePiece;
                        }
                    }
                    else
                    {
                        if (detailBoard[i, j].Color != colorTurn)
                        {
                            try
                            {
                                lblCells[i, j].Invoke((Action)(() => {
                                    lblCells[i, j].Cursor = Cursors.Default;
                                }));
                            }
                            catch
                            {
                                lblCells[i, j].Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            try
                            {
                                lblCells[i, j].Invoke((Action)(() => {
                                    lblCells[i, j].Cursor = Cursors.Hand;
                                    lblCells[i, j].MouseClick += selectPiece;
                                }));
                            }
                            catch
                            {
                                lblCells[i, j].Cursor = Cursors.Hand;
                                lblCells[i, j].MouseClick += selectPiece;
                            }
                        }
                    }
                    if (showHint && ((locaHint.Item1.X == i && locaHint.Item1.Y == j) || (locaHint.Item2.X == i && locaHint.Item2.Y == j)))
                    {
                        lblCells[i, j].BackColor = ColorHint;
                    }
                    else if (i == currentDesMoved.X && j == currentDesMoved.Y)
                    {
                        lblCells[i, j].BackColor = colorDesMoved;
                    }
                    else if (i == currentPrevMoved.X && j == currentPrevMoved.Y)
                    {
                        lblCells[i, j].BackColor = colorPrevMoved;
                    }
                    else
                    {
                        lblCells[i, j].BackColor = colorCells[i, j];
                    }
                }
            }
        }
        public void cleanEvent()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    clearEvent(new Point(i, j));
                    lblCells[i, j].BackColor = colorCells[i, j];
                }
            }
        }
        public void clearColors()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    lblCells[i, j].BackColor = colorCells[i, j];
                }
            }
        }

        //Chuyển lượt: Trắng -> Đen, Đen -> Trắng
        private void changeTurn()
        {
            colorTurn = colorTurn == Piece.ColorWhite ? Piece.ColorBlack : Piece.ColorWhite;
            if (sendChangeTurn != null)
            {
                sendChangeTurn(ColorTurn == Piece.ColorWhite);
            }
            freezeBoardByTurn();
        }

        //Đóng băng đối phương
        public void freezeBoardByTurn()
        {
            if (IsEnd)
            {
                freezeBoard();
                return;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    clearEvent(new Point(i, j));
                    if (detailBoard[i, j] != null)
                    {
                        if (detailBoard[i, j].Color != colorTurn)
                        {
                            try
                            {
                                lblCells[i, j].Invoke((Action)(() => {
                                    lblCells[i, j].Cursor = Cursors.Default;
                                }));
                            }
                            catch
                            {
                                lblCells[i, j].Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            try
                            {
                                lblCells[i, j].Invoke((Action)(() => {
                                    lblCells[i, j].Cursor = Cursors.Hand;
                                    lblCells[i, j].MouseClick += selectPiece;
                                }));
                            }
                            catch
                            {
                                lblCells[i, j].Cursor = Cursors.Hand;
                                lblCells[i, j].MouseClick += selectPiece;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            lblCells[i, j].Invoke((Action)(() => {
                                lblCells[i, j].Cursor = Cursors.Hand;
                                lblCells[i, j].MouseClick += selectNonePiece;
                            }));
                        }
                        catch
                        {
                            lblCells[i, j].Cursor = Cursors.Hand;
                            lblCells[i, j].MouseClick += selectNonePiece;
                        }
                    }
                }
            }
        }

        //Đóng băng bàn cờ
        public void freezeBoard()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    clearEvent(new Point(i, j));

                    lblCells[i, j].Cursor = Cursors.Default;
                }
            }
        }

       

        //Hiển thị đề xuất các vị trí đi được | ăn được khi chọn 1 quân để di chuyển
        private void showRecommend()
        {
            List<Point> moveTo = detailBoard[currentSelect.X, currentSelect.Y].getLocaMoveTo(detailBoard, IsReverse);
            List<Point> capture = detailBoard[currentSelect.X, currentSelect.Y].getLocaCapture(detailBoard);
            for (int i = 0; i < moveTo.Count; i++)
            {
                clearEvent(moveTo[i]);

                lblCells[moveTo[i].X, moveTo[i].Y].BackColor = colorRecommendMove;
                lblCells[moveTo[i].X, moveTo[i].Y].Cursor = Cursors.Hand;
                lblCells[moveTo[i].X, moveTo[i].Y].MouseClick += selectMoveTo;
            }
            for (int i = 0; i < capture.Count; i++)
            {
                clearEvent(capture[i]);

                lblCells[capture[i].X, capture[i].Y].BackColor = colorRecommendCapture;
                lblCells[capture[i].X, capture[i].Y].Cursor = Cursors.Hand;
                lblCells[capture[i].X, capture[i].Y].MouseClick += selectCapture;
            }
        }

        //Thay đổi ô thành quân cờ hoặc ô trống
        private void changeCell(Point locationStart, Point location, int value)
        {
            Piece piece = new Piece(location.X, location.Y, locationStart.X, locationStart.Y, value);
            detailBoard[location.X, location.Y] = piece.findPiece();
            try
            {
                LblCells[location.X, location.Y].Invoke((Action)(() => {
                    if (detailBoard[location.X, location.Y] == null)
                    {
                        lblCells[location.X, location.Y].Image = null;
                        lblCells[location.X, location.Y].Cursor = Cursors.Default;

                    }
                    else
                    {
                        lblCells[location.X, location.Y].Image = Image.FromFile(piece.getPathImg());
                        lblCells[location.X, location.Y].Cursor = Cursors.Hand;
                        lblCells[location.X, location.Y].MouseClick += selectPiece;
                    }
                }));
            }
            catch
            {

                if (detailBoard[location.X, location.Y] == null)
                {
                    lblCells[location.X, location.Y].Image = null;
                    lblCells[location.X, location.Y].Cursor = Cursors.Default;

                }
                else
                {
                    lblCells[location.X, location.Y].Image = Image.FromFile(piece.getPathImg());
                    lblCells[location.X, location.Y].Cursor = Cursors.Hand;
                    lblCells[location.X, location.Y].MouseClick += selectPiece;
                }
            }
            Int_board[location.X, location.Y] = piece.Value;
        }
        private void changeCell(Point location, Piece piece)
        {
            detailBoard[location.X, location.Y] = piece;
            if (piece == null)
            {
                lblCells[location.X, location.Y] = null;
                lblCells[location.X, location.Y].Cursor = Cursors.Default;
            }
            else
            {
                detailBoard[location.X, location.Y].I = location.X;
                detailBoard[location.X, location.Y].J = location.Y;

                lblCells[location.X, location.Y].Image = Image.FromFile(piece.getPathImg());
                lblCells[location.X, location.Y].Cursor = Cursors.Hand;
                lblCells[location.X, location.Y].MouseClick += selectPiece;
            }
            Int_board[location.X, location.Y] = piece.Value;
        }

        //Di chuyển quân cờ từ vị trí này sang vị trí kia
        private void moveTo(Point currentLoca, Point desLoca)
        {
            int step = detailBoard[currentLoca.X, currentLoca.Y].Step;
            bool isUp = false;
            if (detailBoard[currentLoca.X, currentLoca.Y].Name == Piece.NamePawn)
            {
                Pawn pawn = (Pawn)detailBoard[currentLoca.X, currentLoca.Y];
                isUp = pawn.IsUp;

            }
            changeCell(new Point(detailBoard[currentLoca.X, currentLoca.Y].StartI, detailBoard[currentLoca.X, currentLoca.Y].StartJ), desLoca, detailBoard[currentLoca.X, currentLoca.Y].Value);
            changeCell(currentLoca, currentLoca, Piece.ValueNone);
            if (detailBoard[desLoca.X, desLoca.Y] != null && detailBoard[desLoca.X, desLoca.Y].Name == Piece.NamePawn)
            {
                Pawn pawn = (Pawn)detailBoard[desLoca.X, desLoca.Y];
                pawn.IsUp = isUp;
                detailBoard[desLoca.X, desLoca.Y] = pawn;
            }
            if (detailBoard[desLoca.X, desLoca.Y] != null)
            {
                detailBoard[desLoca.X, desLoca.Y].Step = step + 1;
            }
        }

        //Kiểm tra vua đối thủ có bị mình chiếu ko
        private bool checkForCheck()
        {
            string color = colorTurn == Piece.ColorWhite ? Piece.ColorBlack : Piece.ColorWhite;
            List<King> kings = Piece.getKing(row, col, color, detailBoard);
            for (int i = 0; i < kings.Count; i++)
            {
                if (kings[i].beCheck(kings[i].I, kings[i].J, detailBoard))
                {
                    return true;
                }
            }
            return false;
        }

        //Cập nhật lại số nước đi mỗi bên để xét luật hoà cờ với 50 nước
        private void updateCount()
        {
            bool isWhite = ColorTurn == Piece.ColorBlack;
            if (startWhiteTurn != isWhite)
            {
                countMoveOveralls.Add(CountMoveOveralls[CountMoveOveralls.Count - 1] + 1);
                countMoveOverall++;
            }
            else
            {
                countMoveOveralls.Add(CountMoveOveralls[CountMoveOveralls.Count - 1]);
            }
            if ((detailBoard[currentDesMoved.X, currentDesMoved.Y] != null && detailBoard[currentDesMoved.X, currentDesMoved.Y].Name == Piece.NamePawn) || historyDetailBoard[historyDetailBoard.Count - 2][currentDesMoved.X, currentDesMoved.Y] != null)
            {
                countWhites.Add(0);
                countBlacks.Add(0);
                countNoPawnNoCapture = 0;
                return;
            }
            if (colorTurn == Piece.ColorWhite)
            {
                countWhites.Add(countWhites[countWhites.Count - 1] + 1);
                CountBlacks.Add(CountBlacks[CountBlacks.Count - 1]);
            }
            else
            {
                countBlacks.Add(countBlacks[countBlacks.Count - 1] + 1);
                countWhites.Add(CountBlacks[CountBlacks.Count - 1]);
            }
        }

        private string getStrNotationMove(Piece[,] detailBoard, string strCastle, string strPromote, bool isCapture, bool isCheck, bool isCheckmate, Point preLocation, Point desLocation)
        {

            string strPiece;
            string strTail = null;
            if (strCastle != null)
            {
                strPiece = strCastle;
            }
            else
            {
                strPiece = detailBoard[preLocation.X, preLocation.Y].TextNotation;

                if (detailBoard[preLocation.X, preLocation.Y].Name == Piece.NamePawn)
                {
                    if (isCapture)
                    {
                        strPiece += rulerWidth[preLocation.Y].Text.ToLower();
                    }
                }
                else
                {
                    List<Piece> pieces = detailBoard[preLocation.X, preLocation.Y].getSamePiece(detailBoard);
                    string identity = null;
                    for (int i = 0; i < pieces.Count; i++)
                    {
                        if (pieces[i].I != preLocation.X || pieces[i].J != preLocation.Y)
                        {
                            if (isCapture)
                            {
                                if (pieces[i].canCapTure(desLocation.X, desLocation.Y, detailBoard))
                                {
                                    if (pieces[i].J != preLocation.Y)
                                    {
                                        identity = rulerWidth[preLocation.Y].Text.ToLower();
                                        break;
                                    }
                                    else
                                    {
                                        identity = rulerHeight[preLocation.X].Text;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (pieces[i].canMoveTo(currentDesMoved.X, currentDesMoved.Y, historyDetailBoard[historyDetailBoard.Count - 1]))
                                {
                                    if (pieces[i].J != currentPrevMoved.Y)
                                    {
                                        identity = rulerWidth[detailBoard[preLocation.X, preLocation.Y].J].Text.ToLower();
                                    }
                                    else
                                    {
                                        identity = rulerHeight[detailBoard[preLocation.X, preLocation.Y].I].Text;
                                    }
                                }
                            }
                        }
                    }
                    strPiece += identity;
                }
                if (isCapture)
                {
                    strPiece += "x";
                }
                strPiece += rulerWidth[desLocation.Y].Text.ToLower() + rulerHeight[desLocation.X].Text;
                if (strPromote != null)
                {
                    strPiece += "=" + strPromote;
                }
            }
            if (isCheckmate)
            {
                strTail = "#";
            }
            else if (isCheck)
            {
                strTail = "+";
            }
            strPiece += strTail;
            return strPiece;
        }


        //Thêm biên bảng
        private void addNotation(Piece pieceCapture, bool isCheck, bool isCheckmate)
        {
            Piece[,] detailBoard = getCoppyDetailBoard(historyDetailBoard[historyDetailBoard.Count - 1]);
            string strNotationMove = getStrNotationMove(detailBoard, currentNotationCastle, currentNamePromotion, pieceCapture != null, isCheck, isCheckmate, currentPrevMoved, currentDesMoved);

            if (sendStrNotation != null)
            {
                sendStrNotation(strNotationMove);
            }

            //string time;

            //if (colorTurn == Piece.ColorWhite)
            //{
            //    if (isReverse)
            //    {
            //        time = topTime;
            //    }
            //    else
            //    {
            //        time = botTime;
            //    }
            //}
            //else
            //{
            //    if (isReverse)
            //    {
            //        time = botTime;
            //    }
            //    else
            //    {
            //        time = topTime;
            //    }
            //}

            //if (StartWhiteTurn)
            //{
            //    if (ColorTurn == Piece.ColorWhite)
            //    {
            //        timeEveryMove.Add((time, null));
            //    }
            //    else
            //    {
            //        (string, string) newValue = (timeEveryMove[timeEveryMove.Count - 1].Item1, time);
            //        timeEveryMove[timeEveryMove.Count - 1] = newValue;
            //    }
            //}
            //else
            //{
            //    if (ColorTurn == Piece.ColorBlack)
            //    {
            //        timeEveryMove.Add((time, null));
            //    }
            //    else
            //    {
            //        (string, string) newValue = (timeEveryMove[timeEveryMove.Count - 1].Item1, time);
            //        timeEveryMove[timeEveryMove.Count - 1] = newValue;
            //    }
            //}
            //int countItems = CurrentNotations.Count;
            //(int, string, string) newNotation;
            //if (countItems != 0 && string.IsNullOrEmpty(CurrentNotations[countItems - 1].Item3))
            //{
            //    newNotation.Item1 = CurrentNotations[countItems - 1].Item1;
            //    newNotation.Item2 = CurrentNotations[countItems - 1].Item2;
            //    newNotation.Item3 = strNotationMove;
            //    CurrentNotations[countItems - 1] = newNotation;
            //}
            //else
            //{
            //    newNotation.Item1 = countItems + 1;
            //    newNotation.Item2 = strNotationMove;
            //    newNotation.Item3 = "";
            //    CurrentNotations.Add(newNotation);
            //}
            //if (sendNotation != null)
            //{
            //    sendNotation(newNotation);
            //}
        }

        //Xoá biên bản nước vừa đi
        //private void removeLastNotation()
        //{
        //    int count = CurrentNotations.Count;
        //    if (count == 0)
        //    {
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(CurrentNotations[count - 1].Item3))
        //    {
        //        CurrentNotations.RemoveAt(count - 1);
        //    }
        //    else
        //    {
        //        (int, string, string) newValue = (CurrentNotations[count - 1].Item1, CurrentNotations[count - 1].Item2, "");
        //        CurrentNotations[count - 1] = newValue;
        //    }
        //}

        //Kiểm tra game kết thúc chưa, kết thúc với kết quả gì
        private bool checkForEnd()
        {
            string end = EndGame.checkForEndGame(colorTurn == Piece.ColorWhite ? Piece.ColorBlack : Piece.ColorWhite, Row, Col, detailBoard, historyDetailBoard, countNoPawnNoCapture, IsReverse);
            if (end != null)
            {
                if (end == EndGame.checkmate)
                {
                    playSound(nameSoundCheckmate);
                }
                else
                {
                    playSound(nameSoundDraw_Or_Resign);
                }
                endGame(end, ColorTurn);
                return true;
            }
            currentScore = currentResult = currentDetailResult = null;
            return false;
        }

        //Tìm toạ độ từ kí hiệu cột dòng
        private static int getLocationAlphasBySign(string alpha, int col, Label[] rulerWidth)
        {
            for (int i = 0; i < col; i++)
            {
                if (rulerWidth[i].Text.ToLower() == alpha.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        private static int getLocationNumbersBySign(string number, int row, Label[] rulerHeight)
        {
            for (int i = 0; i < row; i++)
            {
                if (rulerHeight[i].Text == number)
                {
                    return i;
                }
            }
            return -1;
        }

        //Những hành động liên quan tới nhập thành
        private bool castle()
        {
            currentNotationCastle = null;
            if (detailBoard[currentPrevMoved.X, currentPrevMoved.Y].Name != Piece.NameKing || currentPrevMoved.X != currentDesMoved.X)
            {
                return false;
            }

            King king = (King)detailBoard[currentPrevMoved.X, currentPrevMoved.Y];
            Piece piece = null;

            (int, int) canCastle = king.findCastle(detailBoard, IsReverse);
            bool isPiece = false;

            if (currentPrevMoved.Y == currentDesMoved.Y)
            {
                if (isReverse)
                {
                    if (currentDesMoved.Y == King.desLocaLeftReverse)
                    {
                        for (int i = currentDesMoved.Y - 1; i >= 0; i--)
                        {
                            if (detailBoard[currentPrevMoved.X, i] != null)
                            {
                                piece = detailBoard[currentPrevMoved.X, i].getCoppy();
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = currentDesMoved.Y + 1; i < col; i++)
                        {
                            if (detailBoard[currentPrevMoved.X, i] != null)
                            {
                                piece = detailBoard[currentPrevMoved.X, i].getCoppy();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (currentDesMoved.Y == King.desLocaLeft)
                    {
                        for (int i = currentDesMoved.Y - 1; i >= 0; i--)
                        {
                            if (detailBoard[currentPrevMoved.X, i] != null)
                            {
                                piece = detailBoard[currentPrevMoved.X, i].getCoppy();
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = currentDesMoved.Y + 1; i < col; i++)
                        {
                            if (detailBoard[currentPrevMoved.X, i] != null)
                            {
                                piece = detailBoard[currentPrevMoved.X, i].getCoppy();
                                break;
                            }
                        }
                    }
                }
                currentDesMoved.Y = piece.J;
            }
            if (currentPrevMoved.Y > currentDesMoved.Y) // nhập thành trái
            {
                if (currentDesMoved.Y == canCastle.Item1)
                {
                    if (detailBoard[currentPrevMoved.X, canCastle.Item1] != null)
                    {
                        isPiece = true;
                        piece = detailBoard[currentPrevMoved.X, canCastle.Item1].getCoppy();
                    }
                    else
                    {
                        for (int i = currentPrevMoved.Y - 1; i >= 0; i--)
                        {
                            if (detailBoard[currentPrevMoved.X, i] != null)
                            {
                                piece = detailBoard[currentPrevMoved.X, i].getCoppy();
                                break;
                            }
                        }
                    }
                    changeCell(new Point(-1, -1), new Point(king.I, king.J), Piece.ValueNone);
                    changeCell(new Point(-1, -1), new Point(piece.I, piece.J), Piece.ValueNone);
                    if (isPiece)
                    {
                        if (isReverse)
                        {
                            changeCell(new Point(currentDesMoved.X, King.desLocaLeftReverse + 1), piece);
                            changeCell(new Point(currentDesMoved.X, King.desLocaLeftReverse), king);
                            detailBoard[currentDesMoved.X, King.desLocaLeftReverse + 1].Step++;
                            detailBoard[currentDesMoved.X, King.desLocaLeftReverse].Step++;
                            abilities[currentDesMoved.X, King.desLocaLeftReverse] = convertBoolAbilityToStr(false, false, true);
                            ((King)detailBoard[currentDesMoved.X, King.desLocaLeftReverse]).AllowCastleLeft = ((King)detailBoard[currentDesMoved.X, King.desLocaLeftReverse]).AllowCastleRight = false;
                            currentDesMoved.Y = King.desLocaLeftReverse;
                        }
                        else
                        {
                            changeCell(new Point(currentDesMoved.X, King.desLocaLeft + 1), piece);
                            changeCell(new Point(currentDesMoved.X, King.desLocaLeft), king);
                            detailBoard[currentDesMoved.X, King.desLocaLeft + 1].Step++;
                            detailBoard[currentDesMoved.X, King.desLocaLeft].Step++;
                            abilities[currentDesMoved.X, King.desLocaLeft] = convertBoolAbilityToStr(false, false, true);
                            ((King)detailBoard[currentDesMoved.X, King.desLocaLeft]).AllowCastleLeft = ((King)detailBoard[currentDesMoved.X, King.desLocaLeft]).AllowCastleRight = false;
                            currentDesMoved.Y = King.desLocaLeft;
                        }
                    }
                    else
                    {
                        changeCell(new Point(currentDesMoved.X, currentDesMoved.Y + 1), piece);
                        changeCell(new Point(currentDesMoved.X, currentDesMoved.Y), king);
                        detailBoard[currentDesMoved.X, currentDesMoved.Y + 1].Step++;
                        detailBoard[currentDesMoved.X, currentDesMoved.Y].Step++;
                        abilities[currentDesMoved.X, currentDesMoved.Y] = convertBoolAbilityToStr(false, false, true);
                        ((King)detailBoard[currentDesMoved.X, currentDesMoved.Y]).AllowCastleLeft = ((King)detailBoard[currentDesMoved.X, currentDesMoved.Y]).AllowCastleRight = false;
                    }
                    if (IsReverse)
                    {
                        currentNotationCastle = "O-O";
                    }
                    else
                    {
                        currentNotationCastle = "O-O-O";
                    }
                    currentTakedPiece = null;
                    return true;
                }
            }
            else //nhập thành phải
            {
                if (currentDesMoved.Y == canCastle.Item2)
                {
                    if (detailBoard[currentPrevMoved.X, canCastle.Item2] != null)
                    {
                        isPiece = true;
                        piece = detailBoard[currentPrevMoved.X, canCastle.Item2].getCoppy();
                    }
                    else
                    {
                        for (int i = currentPrevMoved.Y + 1; i < col; i++)
                        {
                            if (detailBoard[currentPrevMoved.X, i] != null)
                            {
                                piece = detailBoard[currentPrevMoved.X, i].getCoppy();
                                break;
                            }
                        }
                    }
                    changeCell(new Point(-1, -1), new Point(king.I, king.J), Piece.ValueNone);
                    changeCell(new Point(-1, -1), new Point(piece.I, piece.J), Piece.ValueNone);
                    if (isPiece)
                    {
                        if (isReverse)
                        {
                            changeCell(new Point(currentDesMoved.X, King.desLocaRightReverse - 1), piece);
                            changeCell(new Point(currentDesMoved.X, King.desLocaRightReverse), king);
                            detailBoard[currentDesMoved.X, King.desLocaRightReverse - 1].Step++;
                            detailBoard[currentDesMoved.X, King.desLocaRightReverse].Step++;
                            abilities[currentDesMoved.X, King.desLocaRightReverse] = convertBoolAbilityToStr(false, false, true);
                            ((King)detailBoard[currentDesMoved.X, King.desLocaRightReverse]).AllowCastleLeft = ((King)detailBoard[currentDesMoved.X, King.desLocaRightReverse]).AllowCastleRight = false;
                            currentDesMoved.Y = King.desLocaRightReverse;
                        }
                        else
                        {
                            changeCell(new Point(currentDesMoved.X, King.desLocaRight - 1), piece);
                            changeCell(new Point(currentDesMoved.X, King.desLocaRight), king);
                            detailBoard[currentDesMoved.X, King.desLocaRight - 1].Step++;
                            detailBoard[currentDesMoved.X, King.desLocaRight].Step++;
                            abilities[currentDesMoved.X, King.desLocaRight] = convertBoolAbilityToStr(false, false, true);
                            ((King)detailBoard[currentDesMoved.X, King.desLocaRight]).AllowCastleLeft = ((King)detailBoard[currentDesMoved.X, King.desLocaRight]).AllowCastleRight = false;
                            currentDesMoved.Y = King.desLocaRight;
                        }
                    }
                    else
                    {
                        changeCell(new Point(currentDesMoved.X, currentDesMoved.Y - 1), piece);
                        changeCell(new Point(currentDesMoved.X, currentDesMoved.Y), king);
                        detailBoard[currentDesMoved.X, currentDesMoved.Y - 1].Step++;
                        detailBoard[currentDesMoved.X, currentDesMoved.Y].Step++;
                        abilities[currentDesMoved.X, currentDesMoved.Y] = convertBoolAbilityToStr(false, false, true);
                        ((King)detailBoard[currentDesMoved.X, currentDesMoved.Y]).AllowCastleLeft = ((King)detailBoard[currentDesMoved.X, currentDesMoved.Y]).AllowCastleRight = false;
                    }
                    if (IsReverse)
                    {
                        currentNotationCastle = "O-O-O";
                    }
                    else
                    {
                        currentNotationCastle = "O-O";
                    }
                    currentTakedPiece = null;
                    return true;
                }
            }
            return false;
        }

        //Những hành động liên quan tới bắt tốt qua đường
        private bool enpassant()
        {
            if (detailBoard[currentPrevMoved.X, currentPrevMoved.Y].Name != Piece.NamePawn)
            {
                return false;

            }
            Pawn pawn = (Pawn)detailBoard[currentPrevMoved.X, currentPrevMoved.Y];
            var locaMoveEnpassant = pawn.getLocaMoveEnpassant();
            var locaCaptureEnpassant = pawn.getLocaCaptureEnpassant();
            if (detailBoard[currentDesMoved.X, currentDesMoved.Y] == null)
            {
                if (locaMoveEnpassant.Item1.X == currentDesMoved.X && locaMoveEnpassant.Item1.Y == currentDesMoved.Y)
                {
                    currentTakedPiece = detailBoard[locaCaptureEnpassant.Item1.X, locaCaptureEnpassant.Item1.Y].getCoppy(); //quân sẽ bị ăn
                    moveTo(currentPrevMoved, currentDesMoved);
                    changeCell(new Point(-1, -1), locaCaptureEnpassant.Item1, Piece.ValueNone);
                    return true;
                }
                if (locaMoveEnpassant.Item2.X == currentDesMoved.X && locaMoveEnpassant.Item2.Y == currentDesMoved.Y)
                {
                    currentTakedPiece = detailBoard[locaCaptureEnpassant.Item2.X, locaCaptureEnpassant.Item2.Y].getCoppy(); //quân sẽ bị ăn
                    moveTo(currentPrevMoved, currentDesMoved);
                    changeCell(new Point(-1, -1), locaCaptureEnpassant.Item2, Piece.ValueNone);
                    return true;
                }
            }
            else
            {
                if (locaCaptureEnpassant.Item1.X == currentDesMoved.X && locaCaptureEnpassant.Item1.Y == currentDesMoved.Y)
                {
                    currentTakedPiece = detailBoard[currentDesMoved.X, currentDesMoved.Y].getCoppy(); //quân sẽ bị ăn
                    moveTo(currentPrevMoved, locaMoveEnpassant.Item1);
                    changeCell(new Point(-1, -1), currentDesMoved, Piece.ValueNone);
                    currentDesMoved = new Point(locaMoveEnpassant.Item1.X, locaMoveEnpassant.Item1.Y);
                    return true;
                }
                if (locaCaptureEnpassant.Item2.X == currentDesMoved.X && locaCaptureEnpassant.Item2.Y == currentDesMoved.Y)
                {
                    currentTakedPiece = detailBoard[currentDesMoved.X, currentDesMoved.Y].getCoppy(); //quân sẽ bị ăn
                    moveTo(currentPrevMoved, locaMoveEnpassant.Item2);
                    changeCell(new Point(-1, -1), currentDesMoved, Piece.ValueNone);
                    currentDesMoved = new Point(locaMoveEnpassant.Item2.X, locaMoveEnpassant.Item2.Y);
                    return true;
                }
            }
            return false;
        }

        //Tốt phong cấp
        private (bool, bool) promote(string notation = null)
        {
            currentNamePromotion = null;
            if (detailBoard[currentPrevMoved.X, currentPrevMoved.Y].Name == Piece.NamePawn)
            {
                Pawn pawn = (Pawn)detailBoard[currentPrevMoved.X, currentPrevMoved.Y];
                if (pawn.canPromote(currentDesMoved.X, currentDesMoved.Y, detailBoard))
                {
                    if (notation != null)
                    {
                        Piece piece = Piece.getPieceByNotation(notation, colorTurn, pawn.StartI, pawn.StartJ, currentDesMoved.X, currentDesMoved.Y);
                        changeCell(new Point(pawn.StartI, pawn.StartJ), currentDesMoved, piece.Value);
                        changeCell(currentPrevMoved, currentPrevMoved, Piece.ValueNone);
                        currentNamePromotion = notation;
                        return (true, true);
                    }
                    else
                    {
                        prevLocationPromotion = new Point(currentPrevMoved.X, currentPrevMoved.Y);
                        desLocationPromotion = new Point(currentDesMoved.X, currentDesMoved.Y);
                        currentPrevMoved = new Point(-1, -1);
                        currentDesMoved = new Point(-1, -1);
                        clearColor(true);
                        if (sendPromotion != null)
                        {
                            sendPromotion(isWhiteTurn());
                        }


                        return (true, false);
                    }
                }
            }
            return (false, false);
        }

        public void promotionPiece(string name, bool whitePiece)
        {
            currentPrevMoved = new Point(prevLocationPromotion.X, prevLocationPromotion.Y);
            currentDesMoved = new Point(desLocationPromotion.X, desLocationPromotion.Y);
            Pawn pawn = (Pawn)detailBoard[currentPrevMoved.X, currentPrevMoved.Y];
            Piece piece = new Piece(currentDesMoved.X, currentDesMoved.Y, pawn.StartI, pawn.StartJ, name, whitePiece ? Piece.ColorWhite : Piece.ColorBlack);
            currentNamePromotion = piece.TextNotation;
            changeCell(new Point(pawn.StartI, pawn.StartJ), currentDesMoved, piece.Value);
            changeCell(currentPrevMoved, currentPrevMoved, Piece.ValueNone);
            namePromotions[namePromotions.Count - 1] = piece.TextNotation;

            processAfterMove(true, currentNamePromotion);
            if (sendMessage != null)
            {
                sendMessage("Phong " + piece.getVNName() + "!");
            }
        }

        //Qua lượt không cho phép bắt tốt nữa
        private void unenableEnpassant()
        {
            List<Piece> pawns = Piece.getPieces(Piece.NamePawn, colorTurn, Row, Col, detailBoard);
            for (int i = 0; i < pawns.Count; i++)
            {
                Pawn pawn = (Pawn)pawns[i];
                var enpassant = pawn.findEnpassant(detailBoard, Row, Col);
                if (enpassant.Item1 != null)
                {
                    pawn.AllowEnpassantLeft = false;
                }
                if (enpassant.Item2 != null)
                {
                    pawn.AllowEnpassantRight = false;
                }
                detailBoard[pawn.I, pawn.J] = pawn;
                abilities[pawn.I, pawn.J] = convertBoolAbilityToStr(pawn.AllowEnpassantLeft, pawn.AllowEnpassantRight, false);
            }
        }

        private void reverseRuler()
        {
            for (int i = 0; i < Row; i++)
            {
                if (IsReverse)
                {
                    try
                    {
                        rulerHeight[i].Invoke((Action)(() => {
                            rulerHeight[i].Text = strNumbers[Row - i - 1];
                        }));
                    }
                    catch
                    {
                        rulerHeight[i].Text = strNumbers[Row - i - 1];
                    }
                }
                else
                {
                    try
                    {
                        rulerHeight[i].Invoke((Action)(() => {
                            rulerHeight[i].Text = strNumbers[i];
                        }));
                    }
                    catch
                    {
                        rulerHeight[i].Text = strNumbers[i];
                    }
                }
            }
            for (int i = 0; i < Col; i++)
            {
                if (IsReverse)
                {
                    try
                    {
                        rulerWidth[i].Invoke((Action)(() => {
                            rulerWidth[i].Text = strAlphas[Col - i - 1];
                        }));
                    }
                    catch
                    {
                        rulerWidth[i].Text = strAlphas[Col - i - 1];
                    }
                }
                else
                {
                    try
                    {
                        rulerWidth[i].Invoke((Action)(() => {
                            rulerWidth[i].Text = strAlphas[i];
                        }));
                    }
                    catch
                    {
                        rulerWidth[i].Text = strAlphas[i];
                    }
                }
            }
        }
        private void reverseRuler(bool isReverse)
        {
            for (int i = 0; i < Row; i++)
            {
                if (isReverse)
                {
                    rulerHeight[i].Text = strNumbers[Row - i - 1];
                }
                else
                {
                    rulerHeight[i].Text = strNumbers[i];
                }
            }
            for (int i = 0; i < Col; i++)
            {
                if (isReverse)
                {
                    rulerWidth[i].Text = strAlphas[Col - i - 1];
                }
                else
                {
                    rulerWidth[i].Text = strAlphas[i];
                }
            }
        }

        private int[,] convertToInt(Piece[,] board)
        {
            int[,] int_board = new int[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (board[i, j] == null)
                    {
                        int_board[i, j] = Piece.ValueNone;
                    }
                    else
                    {
                        int_board[i, j] = board[i, j].Value;
                    }
                }
            }
            return int_board;
        }

        //Tính năng game
        public void createColorBoard(Color colorLight, Color colorDark)
        {
            CurrentColorLight = colorLight;
            CurrentColorDark = colorDark;
            colorCells = new Color[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            colorCells[i, j] = CurrentColorLight;
                        }
                        else
                        {
                            if (colorCells[i - 1, j] == CurrentColorLight)
                            {
                                colorCells[i, j] = CurrentColorDark;
                            }
                            else
                            {
                                colorCells[i, j] = CurrentColorLight;
                            }
                        }
                    }
                    else
                    {
                        if (colorCells[i, j - 1] == CurrentColorLight)
                        {
                            colorCells[i, j] = CurrentColorDark;
                        }
                        else
                        {
                            colorCells[i, j] = CurrentColorLight;
                        }
                    }
                }
            }
        }
        public void paintBoard(int typePiece, Color colorLight, Color colorDark, Color colorSelect, Color colorRecommendMove, Color colorRecommendCapture, Color colorPrevMoved, Color colorDesMoved, Color colorHint)
        {
            Piece.TypePiece = typePiece;
            createColorBoard(colorLight, colorDark);
            this.colorSelect = colorSelect;
            this.colorRecommendMove = colorRecommendMove;
            this.colorRecommendCapture = colorRecommendCapture;
            this.colorPrevMoved = colorPrevMoved;
            this.colorDesMoved = colorDesMoved;
            this.colorHint = colorHint;
            reloadChessBoard();
            clearColor(false);
        }
        internal void paintBoard(InfoSettingBoard info)
        {
            Piece.TypePiece = info.typePiece;
            createColorBoard(info.colorLight, info.colorDark);
            colorSelect = info.colorSelectPiece;
            colorRecommendMove = info.colorRecommendMove;
            colorRecommendCapture = info.colorRecommendCapture;
            colorPrevMoved = info.colorPrevMoved;
            colorDesMoved = info.colorDesMoved;
            colorHint = info.colorHint;
            reloadChessBoard();
            clearColor(false);
        }


        public void initBoard(Panel pnChessBoard)
        {
            PnBoard = pnChessBoard;
            currentScore = currentResult = currentDetailResult = null;
            colorTurn = Piece.ColorWhite;
            currentSelect = new Point(-1, -1);
            currentPrevMoved = new Point(-1, -1);
            currentDesMoved = new Point(-1, -1);
            PnBoard.Controls.Clear();
            createRuler();
            int XStart = sizeRuler;
            int locaX = XStart, locaY = 0;
            lblCells = new PictureBox[row, col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    lblCells[i, j] = getNoneCell(locaX, locaY, i + "-" + j, colorCells[i, j]);
                    PnBoard.Controls.Add(lblCells[i, j]);
                    locaX += sizeCell;
                }
                locaX = XStart;
                locaY += sizeCell;
            }
        }
        public void createSetupBoard(Panel pnChessBoard, int row, int col)
        {
            Row = row;
            Col = col;
            PnBoard = pnChessBoard;
            PnBoard.Controls.Clear();
            createRuler();
            int XStart = sizeRuler;
            int locaX = XStart, locaY = 0;
            lblCells = new PictureBox[row, col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    lblCells[i, j] = new PictureBox()
                    {
                        AutoSize = false,
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(sizeCell, sizeCell),
                        Location = new Point(locaX, locaY),
                        BackColor = colorCells[i, j],
                        SizeMode = PictureBoxSizeMode.Zoom,
                    };
                    PnBoard.Controls.Add(lblCells[i, j]);
                    locaX += sizeCell;
                }
                locaX = XStart;
                locaY += sizeCell;
            }
            IsReverse = false;
            reverseRuler();
        }

        public void createModelBoard(Panel pnChessBoard, int[,] int_board, bool isReverse, Point preMove, Point desMove)
        {
            Int_board = int_board;
            PnBoard = pnChessBoard;
            PnBoard.Controls.Clear();
            createRuler();
            int fontSize = pnChessBoard.Width / 50;
            for (int i = 0; i < Col; i++)
            {
                rulerWidth[i].Font = new Font("Times New Roman", fontSize, FontStyle.Bold);
            }
            for (int i = 0; i < Row; i++)
            {
                rulerHeight[i].Font = new Font("Times New Roman", fontSize, FontStyle.Bold);
            }
            this.isReverse = isReverse;
            reverseRuler(isReverse);
            int XStart = sizeRuler;
            int locaX = XStart, locaY = 0;
            PictureBox[,] ptr = new PictureBox[row, col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Piece piece = new Piece(0, 0, 0, 0, int_board[i, j]);
                    ptr[i, j] = new PictureBox()
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(sizeCell, sizeCell),
                        Location = new Point(locaX, locaY),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = colorCells[i, j],
                    };
                    if (piece.Value != Piece.ValueNone)
                    {
                        ptr[i, j].Image = Image.FromFile(piece.getPathImg());
                    }
                    PnBoard.Controls.Add(ptr[i, j]);
                    locaX += sizeCell;
                }
                locaX = XStart;
                locaY += sizeCell;
            }
            if (preMove.X != -1)
            {
                ptr[preMove.X, preMove.Y].BackColor = ColorPrevMoved;
                ptr[desMove.X, desMove.Y].BackColor = ColorDesMoved;
            }
        }

        private void sendResetValue()
        {
            if (sendReset != null)
            {
                sendReset();
            }
        }

        public void restartBoard()
        {
            loadPlayer();
            playSound(nameSoundStart);
            currentScore = currentResult = currentDetailResult = null;
            if (historyDetailBoard.Count != 0)
            {
                Int_board = convertToInt(historyDetailBoard[0]);
            }
            setPieceByInt(Int_board);
            reverseRuler();
            resetValues();
            freezeBoardByTurnBot(colorTurn);
            historyDetailBoard.Add(getCoppyDetailBoard());
            setAllowCastleEnpassant(StartAbilities);
            autoBotPlayMove();
            startFindHint();
            sendResetValue();
        }

        public void clearPieces()
        {
            if (Int_board != null)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Int_board[i, j] = Piece.ValueNone;
                        lblCells[i, j].Image = null;
                        if (detailBoard[i, j] != null)
                        {
                            clearEvent(new Point(i, j));
                            detailBoard[i, j] = null;
                        }
                    }
                }
            }
        }

        public void setPieceByDetailBoard(Piece[,] detailBoard)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] == null)
                    {
                        lblCells[i, j].Image = null;
                    }
                    else
                    {
                        lblCells[i, j].Image = Image.FromFile(detailBoard[i, j].getPathImg());
                    }
                }
            }
        }

        //Sắp quân cờ vào theo mảng số nguyên
        public void setPieceByInt(int[,] int_board)
        {
            detailBoard = new Piece[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    setCell(i, j, int_board[i, j]);
                }
            }
        }

        private static int[,] coppyArrayIntBoard(int[,] board, int row, int col)
        {
            int[,] result = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = board[i, j];
                }
            }
            return result;
        }
        private static string[,] coppyArrayAbilities(string[,] abilities, int row, int col)
        {
            string[,] result = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = abilities[i, j];
                }
            }
            return result;
        }

        public void reloadAbilities()
        {
            setAllowCastleEnpassant(StartAbilities);
        }

        private void setAllowCastleEnpassant(string[,] abilities)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (int_board[i, j] != 0)
                    {
                        var lr = convertStrAbilityToBool(abilities[i, j]);
                        if (Math.Abs(int_board[i, j]) == Piece.ValueKing)
                        {
                            King king = (King)detailBoard[i, j].getCoppy();
                            if (!lr.Item1)
                            {
                                king.AllowCastleLeft = false;
                            }
                            else
                            {
                                king.AllowCastleLeft = true;
                            }
                            if (!lr.Item2)
                            {
                                king.AllowCastleRight = false;
                            }
                            else
                            {
                                king.AllowCastleRight = true;
                            }
                            detailBoard[i, j] = king;
                        }
                        else if (Math.Abs(int_board[i, j]) == Piece.ValuePawn)
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j].getCoppy();
                            if (!lr.Item1)
                            {
                                pawn.AllowEnpassantLeft = false;
                            }
                            else
                            {
                                pawn.AllowEnpassantLeft = true;
                                if (j - 1 >= 0 && detailBoard[i, j - 1] is Pawn)
                                {
                                    Pawn pawnLeft = (Pawn)detailBoard[i, j - 1].getCoppy();
                                    if (pawnLeft.IsUp)
                                    {
                                        if (pawnLeft.StartI >= 2)
                                        {
                                            pawnLeft.StartI -= 2;
                                            pawnLeft.Step = 1;
                                        }
                                    }
                                    else
                                    {
                                        if (pawnLeft.StartI <= row - 3)
                                        {
                                            pawnLeft.StartI += 2;
                                            pawnLeft.Step = 1;
                                        }
                                    }
                                    detailBoard[i, j - 1] = pawnLeft;
                                }
                            }
                            if (!lr.Item2)
                            {
                                pawn.AllowEnpassantRight = false;
                            }
                            else
                            {
                                pawn.AllowEnpassantRight = true;
                                if (j + 1 < row && detailBoard[i, j + 1] is Pawn)
                                {
                                    Pawn pawnRight = (Pawn)detailBoard[i, j + 1].getCoppy();
                                    if (pawnRight.IsUp)
                                    {
                                        if (pawnRight.StartI >= 2)
                                        {
                                            pawnRight.StartI -= 2;
                                            pawnRight.Step = 1;
                                        }
                                    }
                                    else
                                    {
                                        if (pawnRight.StartI <= row - 3)
                                        {
                                            pawnRight.StartI += 2;
                                            pawnRight.Step = 1;
                                        }
                                    }
                                    detailBoard[i, j + 1] = pawnRight;
                                }
                            }
                            if (!lr.Item3)
                            {
                                pawn.Step = 1;
                            }
                            else
                            {
                                pawn.Step = 0;
                            }
                            detailBoard[i, j] = pawn;
                        }
                    }
                }
            }
        }

        private void resizeRuler()
        {
            if (rulerWidth == null || lblCells == null)
            {
                return;
            }
            for (int i = 0; i < rulerWidth.Length; i++)
            {
                rulerWidth[i].Top = lblCells[Row - 1, Col - 1].Top + sizeCell;
            }
        }

        //Đặt quân lên bàn cờ theo tiêu chuẩn cờ bth

        public void setChess(int indexTypeGame, string startTime, int time_bonus, bool isReverse = false, bool startTimer = true, int[,] int_board = null, string[,] startAbilities = null, bool startWhiteTurn = true, int row = 8, int col = 8, int countNoPawnNoCapture = 0, int countMoveOverall = 0)
        {
            if (indexTypeGame == 0)
            {
                setBasicChess(startTime, time_bonus, startTimer, isReverse);
            }
            else if (indexTypeGame == 1)
            {
                if (int_board != null)
                {
                    setCustomChess(int_board, startAbilities, startWhiteTurn, row, col, isReverse, countNoPawnNoCapture, countMoveOverall, startTime, time_bonus, startTimer);
                }
                else
                {
                    setChess960(startTime, time_bonus, startTimer, isReverse);
                }
            }
            else
            {
                setCustomChess(int_board, startAbilities, startWhiteTurn, row, col, isReverse, countNoPawnNoCapture, countMoveOverall, startTime, time_bonus, startTimer);
            }
        }


        public void setChess(int indexTypeGame, bool isReverse = false, bool startTimer = true)
        {
            if (indexTypeGame == 0)
            {
                setBasicChess(startTime, timeBonus, startTimer, isReverse);
            }
            else if (indexTypeGame == 1)
            {
                setChess960(startTime, timeBonus, startTimer, isReverse);
            }
            else
            {

            }
        }

        public void setBasicChess(string startTime, int time_bonus, bool startTimer, bool isReverse)
        {
            StartCountNoPawnNoCapture = 0;
            StartCountMoveOverall = 1;
            this.isReverse = isReverse;
            this.startTime = startTime;
            timeBonus = time_bonus;
            this.startTimer = startTimer;
            playSound(nameSoundStart);
            Row = Col = 8;
            Int_board = getBasicIntBoard(IsReverse);
            setPieceByInt(Int_board);
            startAbilities = getBasicAbilities(IsReverse);
            setAllowCastleEnpassant(startAbilities);
            reverseRuler(isReverse);
            StartWhiteTurn = true;
            resetValues();
            freezeBoardByTurn();
            historyDetailBoard.Add(getCoppyDetailBoard());
            resizeRuler();
            autoBotPlayMove();
            sendResetValue();
        }

        public void setCustomChess(int[,] int_board, string[,] startAbilities, bool startWhiteTurn, int row, int col, bool isReverse, int countNoPawnNoCapture = 0, int countMoveOverall = 0, string startTime = "0:00", int timeBonus = 0, bool startTimer = false)
        {
            this.startTime = startTime;
            this.startTimer = startTimer;
            this.timeBonus = timeBonus;
            playSound(nameSoundStart);
            Row = row;
            Col = col;
            IsReverse = isReverse;
            if (isReverse)
            {
                Int_board = getReverseIntBoard(int_board, row, col);
            }
            else
            {
                Int_board = coppyArrayIntBoard(int_board, row, col);
            }
            setPieceByInt(Int_board);

            if (isReverse)
            {
                StartAbilities = getReverseAbilities(startAbilities, row, col);
            }
            else
            {
                StartAbilities = coppyArrayAbilities(startAbilities, row, col);
            }
            reverseRuler(isReverse);
            StartWhiteTurn = startWhiteTurn;
            startCountMoveOverall = countMoveOverall;
            startCountNoPawnNoCapture = countNoPawnNoCapture;
            resetValues();
            freezeBoardByTurn();
            setAllowCastleEnpassant(StartAbilities);
            historyDetailBoard.Add(getCoppyDetailBoard());
            resizeRuler();
            autoBotPlayMove();
            sendResetValue();

        }
        public void setChess960(string startTime, int time_bonus, bool startTimer, bool isReverse)
        {
            StartCountNoPawnNoCapture = 0;
            StartCountMoveOverall = 1;
            this.isReverse = isReverse;
            this.startTime = startTime;
            timeBonus = time_bonus;
            this.startTimer = startTimer;
            playSound(nameSoundStart);
            Row = Col = 8;
            Int_board = getChess960IntBoard(IsReverse, row, col);
            setPieceByInt(Int_board);
            startAbilities = getChess960Abilities(IsReverse, row, col);
            setAllowCastleEnpassant(startAbilities);
            StartWhiteTurn = true;
            reverseRuler(isReverse);
            resetValues();
            freezeBoardByTurn();
            historyDetailBoard.Add(getCoppyDetailBoard());
            autoBotPlayMove();
            sendResetValue();
        }

        public string getCurrentFen()
        {
            return convertBoardToFen(detailBoard, Row, Col, isReverse, isWhiteTurn(), CountNoPawnNoCapture, CountMoveOverall);
        }

        public static int randomLocation(int i, List<int> jExpect, int col)
        {
            int j;
            Random rnd = new Random();
            while (true)
            {
                bool isOk = true;
                j = rnd.Next(0, col);
                foreach (int index in jExpect)
                {
                    if (index == j)
                    {
                        isOk = false;
                    }
                }
                if (isOk)
                {
                    break;
                }
            }
            return j;
        }

        //Phát âm thanh file .wav
        public void playSound(string name)
        {
            if (!muteSound)
            {
                SoundPlayer sound = new SoundPlayer("assets/sounds/" + name + ".wav");
                sound.Play();
            }
        }

        public void reverseBoard(bool reverse)
        {
            if (reverse == isReverse)
            {
                return;
            }
            reverseBoard();
        }

        public static string[,] getReverseAbilities(string[,] abilities, int row, int col)
        {
            string[,] tmp_abilities = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp_abilities[i, j] = abilities[row - i - 1, col - j - 1];
                }
            }
            return tmp_abilities;
        }
        public static int[,] getReverseIntBoard(int[,] int_board, int row, int col)
        {
            int[,] tmp_int_board = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp_int_board[i, j] = int_board[row - i - 1, col - j - 1];
                }
            }
            return tmp_int_board;
        }

        private static Piece[,] getReverseDetailBoard(Piece[,] detailBoard, int row, int col)
        {
            Piece[,] tmpBoard = new Piece[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[row - i - 1, col - j - 1] != null)
                    {
                        tmpBoard[i, j] = detailBoard[row - i - 1, col - j - 1].getCoppy(new Point(i, j));
                        tmpBoard[i, j].StartI = row - tmpBoard[i, j].StartI - 1;
                        tmpBoard[i, j].StartJ = col - tmpBoard[i, j].StartJ - 1;
                        if (tmpBoard[i, j].Name == Piece.NamePawn)
                        {
                            Pawn pawn = (Pawn)tmpBoard[i, j];
                            pawn.IsUp = !pawn.IsUp;
                            bool isAllowEnpassntRight = pawn.AllowEnpassantRight;
                            pawn.AllowEnpassantRight = pawn.AllowEnpassantLeft;
                            pawn.AllowEnpassantLeft = isAllowEnpassntRight;
                            tmpBoard[i, j] = pawn;
                        }
                        else if (tmpBoard[i, j].Name == Piece.NameKing)
                        {
                            King king = (King)tmpBoard[i, j];
                            bool isAllowCaslteRight = king.AllowCastleRight;
                            king.AllowCastleRight = king.AllowCastleLeft;
                            king.AllowCastleLeft = isAllowCaslteRight;
                            tmpBoard[i, j] = king;
                        }
                    }
                    else
                    {
                        tmpBoard[i, j] = null;
                    }
                }
            }
            return tmpBoard;
        }

        private void reverseHistoriesDetailBoard()
        {
            for (int i = 0; i < historyDetailBoard.Count; i++)
            {
                historyDetailBoard[i] = getReverseDetailBoard(historyDetailBoard[i], Row, Col);
            }
        }

        private void reversePrevDesMove()
        {
            currentSelect = new Point(Row - currentSelect.X - 1, Col - currentSelect.Y - 1);
            if (currentPrevMoved.X != -1)
            {
                currentPrevMoved = new Point(Row - currentPrevMoved.X - 1, Col - currentPrevMoved.Y - 1);
                currentDesMoved = new Point(Row - currentDesMoved.X - 1, Col - currentDesMoved.Y - 1);
            }
            for (int i = 0; i < lstPrevMoved.Count; i++)
            {
                lstPrevMoved[i] = new Point(Row - lstPrevMoved[i].X - 1, Col - lstPrevMoved[i].Y - 1);
                lstDesMoved[i] = new Point(Row - lstDesMoved[i].X - 1, Col - lstDesMoved[i].Y - 1);
            }
        }

        public void reverseBoard()
        {
            if (detailBoard == null)
            {
                return;
            }
            isReverse = !isReverse;
            reverseRuler();
            reverseHistoriesDetailBoard();
            detailBoard = getReverseDetailBoard(detailBoard, row, col);
            StartAbilities = getReverseAbilities(StartAbilities, row, col);
            Int_board = getReverseIntBoard(Int_board, row, col);
            setPieceByDetailBoard(detailBoard);
            reversePrevDesMove();
            clearColor(true);
            startFindHint();
            freezeBoardByTurn();
            string tmp = topTime;
            topTime = botTime;
            botTime = tmp;
            if (sendReverse != null)
            {
                sendReverse(isReverse);
            }
        }

        public bool canBackChess()
        {
            if (historyDetailBoard.Count < 2)
            {
                return false;
            }
            return true;
        }
        public bool canBackChess(int count)
        {
            if (historyDetailBoard.Count < count + 1)
            {
                return false;
            }
            return true;
        }

        //Quay lại một nước trước đó
        public bool backMove()
        {
            if (!canBackChess())
            {
                return false;
            }
            int countBoard = historyDetailBoard.Count;
            if (countBoard == 1)
            {
                return false;
            }
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (historyDetailBoard[countBoard - 2][i, j] != null)
                    {
                        detailBoard[i, j] = historyDetailBoard[countBoard - 2][i, j].getCoppy();
                    }
                    else
                    {
                        detailBoard[i, j] = null;
                    }
                }
            }
            setPieceByDetailBoard(detailBoard);
            countMoveOveralls.RemoveAt(countMoveOveralls.Count - 1);
            countWhites.RemoveAt(countWhites.Count - 1);
            countBlacks.RemoveAt(countBlacks.Count - 1);

            for (int i = 0; i < countBlackCapture.Length; i++)
            {
                countBlackCapture[i].RemoveAt(countBlackCapture[i].Count - 1);
                countWhiteCapture[i].RemoveAt(countWhiteCapture[i].Count - 1);
            }

            indexsWhitePieceCapture.RemoveAt(indexsWhitePieceCapture.Count - 1);
            indexsBlackPieceCapture.RemoveAt(indexsBlackPieceCapture.Count - 1);

            changeTurn();
            historyDetailBoard.RemoveAt(countBoard - 1);
            lstPrevMoved.RemoveAt(lstPrevMoved.Count - 1);
            lstDesMoved.RemoveAt(lstDesMoved.Count - 1);
            if (lstPrevMoved.Count != 0)
            {
                currentPrevMoved = lstPrevMoved[lstPrevMoved.Count - 1];
                currentDesMoved = lstDesMoved[lstDesMoved.Count - 1];
            }
            else
            {
                currentPrevMoved = new Point(-1, -1);
                currentDesMoved = new Point(-1, -1);
            }
            //removeLastNotation();

            clearColor(true);
            startFindHint();
            IsEnd = false;
            currentScore = currentResult = currentDetailResult = null;
            saveMoves.RemoveAt(saveMoves.Count - 1);
            namePromotions.RemoveAt(namePromotions.Count - 1);
            if (sendBackBoard != null)
            {
                sendBackBoard(colorTurn == Piece.ColorWhite);
            }
            return true;
        }

        public bool backMove(int count)
        {
            if (!canBackChess(count))
            {
                return false;
            }
            int countBoard = historyDetailBoard.Count;
            int space = count;
            if (count >= countBoard)
            {
                space = countBoard - 1;
            }
            if (space != 0)
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (historyDetailBoard[countBoard - 1 - space][i, j] != null)
                        {
                            detailBoard[i, j] = historyDetailBoard[countBoard - 1 - space][i, j].getCoppy();
                        }
                        else
                        {
                            detailBoard[i, j] = null;
                        }
                    }
                }
                setPieceByDetailBoard(detailBoard); 
                for (int i = 0; i < space; i++)
                {
                    saveMoves.RemoveAt(saveMoves.Count - 1);
                    countMoveOveralls.RemoveAt(countMoveOveralls.Count - 1);
                    countWhites.RemoveAt(countWhites.Count - 1);
                    countBlacks.RemoveAt(countBlacks.Count - 1);
                    for (int j = 0; j < countBlackCapture.Length; j++)
                    {
                        countBlackCapture[j].RemoveAt(countBlackCapture[j].Count - 1);
                        countWhiteCapture[j].RemoveAt(countWhiteCapture[j].Count - 1);
                    }
                    indexsWhitePieceCapture.RemoveAt(indexsWhitePieceCapture.Count - 1);
                    indexsBlackPieceCapture.RemoveAt(indexsBlackPieceCapture.Count - 1);
                    historyDetailBoard.RemoveAt(countBoard - 1);
                    countBoard--;
                    lstPrevMoved.RemoveAt(lstPrevMoved.Count - 1);
                    lstDesMoved.RemoveAt(lstDesMoved.Count - 1);
                    if (lstPrevMoved.Count != 0)
                    {
                        currentPrevMoved = lstPrevMoved[lstPrevMoved.Count - 1];
                        currentDesMoved = lstDesMoved[lstDesMoved.Count - 1];
                    }
                    else
                    {
                        currentPrevMoved = new Point(-1, -1);
                        currentDesMoved = new Point(-1, -1);
                    }
                    namePromotions.RemoveAt(namePromotions.Count - 1);
                }

                
                if (space % 2 != 0)
                {
                    changeTurn();
                }
                else
                {
                    freezeBoardByTurn();
                }

            }

            //removeLastNotation();

            clearColor(true);
            startFindHint();
            IsEnd = false;
            currentScore = currentResult = currentDetailResult = null;
           
            if (sendBackBoard != null)
            {
                sendBackBoard(colorTurn == Piece.ColorWhite);
            }
            return true;
        }

        public void resign(bool isWhitePlayer, bool send = true)
        {
            if (isEnd)
            {
                return;
            }
            endGame(EndGame.resign, isWhitePlayer ? Piece.ColorWhite : Piece.ColorBlack);
            if (send)
            {
                if (sendResign != null)
                {
                    sendResign(isWhitePlayer);
                }
            }
        }
        public void giveUp(bool isWhitePlayer)
        {
            if (isEnd)
            {
                return;
            }
            endGame(EndGame.giveUp, isWhitePlayer ? Piece.ColorWhite : Piece.ColorBlack);
        }
        public void resign()
        {
            if (isEnd)
            {
                return;
            }
            endGame(EndGame.resign, ColorTurn);
            if (sendResign != null)
            {
                sendResign(ColorTurn == Piece.ColorWhite);
            }
        }

        public void draw()
        {
            if (isEnd)
            {
                return;
            }
            endGame(EndGame.requestDraw, Piece.ColorWhite);
            if (sendDraw != null)
            {
                sendDraw();
            }
        }

        public void timeOut(bool isWhitePlayer)
        {
            timerPlay.Stop();
            if (isEnd)
            {
                return;
            }
            endGame(EndGame.timeOut, isWhitePlayer ? Piece.ColorWhite : Piece.ColorBlack);
            bool isTop;
            string resetTime = "0:00";
            if ((isWhitePlayer && IsReverse) || (!isWhitePlayer && !IsReverse))
            {
                topTime = resetTime;
                isTop = true;
            }
            else
            {
                botTime = resetTime;
                isTop = false;
            }
            if (sendTimeOut != null)
            {
                sendTimeOut(isWhitePlayer);
            }
            if (sendTime != null)
            {
                sendTime(isTop, resetTime, timeBonus);
            }
        }

        private bool isNameNotation(char c)
        {
            return Piece.getPieceByNotation(c.ToString(), colorTurn, 1, 1, 1, 1) != null;
        }
        private bool isInAlphas(char c)
        {
            if (char.IsLetter(c))
            {
                for (int i = 0; i < Col; i++)
                {
                    if (c.ToString().ToLower() == strAlphas[i].ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool isInNumbers(char c)
        {
            if (char.IsNumber(c))
            {
                for (int i = 0; i < Row; i++)
                {
                    if (c.ToString().ToLower() == strNumbers[i].ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool nextMoveByStrNotation(string strMove)
        {
            if (string.IsNullOrEmpty(strMove))
            {
                return false;
            }
            string nameNotation = "";
            string identity = null;
            bool isCapture = false;
            string notationPromote = null;
            bool isCastle = false;
            if (strMove.Contains('='))
            {
                notationPromote = strMove[strMove.LastIndexOf('=') + 1].ToString();
            }
            if (isNameNotation(strMove[0])) //R1d5 hoặc R1xd5 hoặc Rd5 hoặc Raxd5 hoặc Rad5 hoặc Rxd5
            {
                nameNotation = strMove[0].ToString();
                if (isInNumbers(strMove[1]))//R1d5 hoặc R1xd5
                {
                    identity = strMove[1].ToString();
                    if (strMove[2] != 'x') //R1d5
                    {
                        currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
                    }
                    else //R1xd5
                    {
                        isCapture = true;
                        currentDesMoved = new Point(getLocationNumbersBySign(strMove[4].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[3].ToString(), col, rulerWidth));
                    }
                }
                else if (isInAlphas(strMove[1])) //Rd5 hoặc Raxd5 hoặc Rad5 hoặc Rxd5
                {
                    if (strMove[1] != 'x')//Rd5 hoặc Raxd5 hoặc Rad5
                    {
                        if (isInNumbers(strMove[2])) //Rd5
                        {
                            currentDesMoved = new Point(getLocationNumbersBySign(strMove[2].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[1].ToString(), col, rulerWidth));
                        }
                        else if (strMove[2] == 'x')//Raxd5
                        {
                            isCapture = true;
                            identity = strMove[1].ToString();
                            currentDesMoved = new Point(getLocationNumbersBySign(strMove[4].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[3].ToString(), col, rulerWidth));
                        }
                        else //Rad5
                        {
                            identity = strMove[1].ToString();
                            currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
                        }
                    }
                    else//Rxd5
                    {
                        isCapture = true;
                        currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
                    }
                }
                else //Rxd5
                {
                    isCapture = true;
                    currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
                }
            }
            else //dxe5 hoặc xe5 hoặc e5 hoặc O-O hoăc 0-0-0
            {
                if (strMove[0] == 'O')
                {
                    isCastle = true;
                    nameNotation = Piece.NotationKing;
                    List<King> kings = Piece.getKing(Row, Col, colorTurn, detailBoard);
                    if (strMove.Length >= "O-O-O".ToString().Length && strMove[4] == 'O') //O-O-O
                    {
                        for (int i = 0; i < kings.Count; i++)
                        {
                            var castle = kings[i].findCastle(detailBoard, IsReverse);
                            if (castle.Item1 != -1 && !IsReverse)
                            {
                                currentDesMoved = new Point(kings[i].I, castle.Item1);
                                currentPrevMoved = new Point(kings[i].I, kings[i].J);
                                break;
                            }
                            else if (castle.Item2 != -1 && IsReverse)
                            {
                                currentDesMoved = new Point(kings[i].I, castle.Item2);
                                currentPrevMoved = new Point(kings[i].I, kings[i].J);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < kings.Count; i++)
                        {
                            var castle = kings[i].findCastle(detailBoard, IsReverse);
                            if (castle.Item2 != -1 && !IsReverse)
                            {
                                currentDesMoved = new Point(kings[i].I, castle.Item2);
                                currentPrevMoved = new Point(kings[i].I, kings[i].J);
                                break;
                            }
                            else if (castle.Item1 != -1 && IsReverse)
                            {
                                currentDesMoved = new Point(kings[i].I, castle.Item1);
                                currentPrevMoved = new Point(kings[i].I, kings[i].J);
                                break;
                            }
                        }
                    }
                }
                else //dxe5 hoặc e5
                {
                    if (strMove[1] == 'x') //dxe5
                    {
                        isCapture = true;
                        identity = strMove[0].ToString();
                        currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
                    }
                    else //e5
                    {
                        currentDesMoved = new Point(getLocationNumbersBySign(strMove[1].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[0].ToString(), col, rulerWidth));
                    }
                }
            }
            if (!isCastle)
            {
                currentPrevMoved.X = -1;
                Piece piece = Piece.getPieceByNotation(nameNotation, colorTurn, currentDesMoved.X, currentDesMoved.Y, currentDesMoved.X, currentDesMoved.Y);
                List<Piece> otherPieces = piece.getSamePiece(detailBoard);
                for (int i = 0; i < otherPieces.Count; i++)
                {
                    if (!isCapture && otherPieces[i].canMoveTo(currentDesMoved.X, currentDesMoved.Y, detailBoard))
                    {
                        if (identity != null)
                        {
                            if (getLocationAlphasBySign(identity, col, rulerWidth) == otherPieces[i].J || getLocationNumbersBySign(identity, row, rulerHeight) == otherPieces[i].I)
                            {
                                currentPrevMoved = new Point(otherPieces[i].I, otherPieces[i].J);
                                break;
                            }
                        }
                        else
                        {
                            currentPrevMoved = new Point(otherPieces[i].I, otherPieces[i].J);
                            break;
                        }
                    }
                    else if (isCapture)
                    {
                        if (otherPieces[i].canCapTure(currentDesMoved.X, currentDesMoved.Y, detailBoard))
                        {
                            if (identity != null)
                            {
                                if (getLocationAlphasBySign(identity, col, rulerWidth) == otherPieces[i].J || getLocationNumbersBySign(identity, row, rulerHeight) == otherPieces[i].I)
                                {
                                    currentPrevMoved = new Point(otherPieces[i].I, otherPieces[i].J);
                                    break;
                                }
                            }
                            else
                            {
                                currentPrevMoved = new Point(otherPieces[i].I, otherPieces[i].J);
                                break;
                            }
                        }
                        else if (otherPieces[i].canMoveTo(currentDesMoved.X, currentDesMoved.Y, detailBoard))
                        {
                            if (identity != null)
                            {
                                if (getLocationAlphasBySign(identity, col, rulerWidth) == otherPieces[i].J || getLocationNumbersBySign(identity, row, rulerHeight) == otherPieces[i].I)
                                {
                                    currentPrevMoved = new Point(otherPieces[i].I, otherPieces[i].J);
                                    break;
                                }
                            }
                            else
                            {
                                currentPrevMoved = new Point(otherPieces[i].I, otherPieces[i].J);
                                break;
                            }
                        }
                    }
                }
            }
            move(notationPromote);
            return true;
        }

        private string cutSignHeadTail(string text, char sign)
        {
            int startIndex = -1, endIndex = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != sign && text[i] != '|')
                {
                    if (startIndex == -1)
                    {
                        startIndex = i;
                    }
                    endIndex = i;
                }
            }
            if (startIndex == -1 || endIndex == -1)
            {
                return text;
            }
            return text.Substring(startIndex, endIndex + 1 - startIndex);
        }

        //Căn giữa văn bản bằng thêm kí tự sign
        private string getAlignText(string text, char sign, int maxCount)
        {
            int count = maxCount - text.Length;
            if (count <= 0)
            {
                return text;
            }
            for (int i = 0; i < count / 2; i++)
            {
                text = sign + text;
            }
            for (int i = 0; i < count / 2; i++)
            {
                text += sign;
            }
            if (count % 2 != 0)
            {
                text += sign;
            }
            return text;
        }

        //public (List<(int, string, string)>, string) getNotation(string detailEnd)
        //{
        //    string result = "Kết quả: " + (currentResult == null ? "" : (currentResult + " | " + detailEnd));
        //    return (CurrentNotations, result);
        //}

        //public (List<string>, string, string) getListNotation(string nameFile, string detailEnd)
        //{
        //    var save = getNotation(detailEnd);
        //    List<string> contents = new List<string>();
        //    contents.Add("Tên trận đấu: " + nameFile);
        //    contents.Add("Bàn cờ: " + convertToStrBoard(getStartInt(IsReverse), row, col));
        //    contents.Add("Khả năng: " + convertToStrAbilities(getStartAbilities(IsReverse), row, col));
        //    contents.Add("Thời gian bắt đầu: " + startTime);
        //    contents.Add("Thời gian quá trình: " + convertToStrTimeEveryMove(timeEveryMove));
        //    contents.Add("Lật ngược: " + (IsReverse ? 1 : 0));
        //    contents.Add("Quân trắng đi trước: " + (startWhiteTurn ? 1 : 0));
        //    contents.Add("Tên người chơi cầm quân trắng: " + namePlayer1);
        //    contents.Add("Tên người chơi cầm quân đen: " + namePlayer2);
        //    contents.Add(save.Item2);
        //    contents.Add("Ngày lưu: " + DateTime.Now.ToString());
        //    contents.Add(Line);
        //    for (int i = 0; i < save.Item1.Count; i++)
        //    {
        //        string item1 = save.Item1[i].Item1 + ". " + save.Item1[i].Item2;
        //        string content = "|                   " + item1;
        //        for (int j = 0; j < 20 - item1.Length; j++)
        //        {
        //            content += ' ';
        //        }
        //        content += save.Item1[i].Item3;
        //        content += getAlignText(" ", ' ', Line.Length - 1 - content.Length) + "|";
        //        contents.Add(content);
        //    }
        //    contents.Add(Line);
        //    string result = "";
        //    for (int i = 0; i < contents.Count; i++)
        //    {
        //        result += contents[i];
        //        if (i != contents.Count - 1)
        //        {
        //            result += Environment.NewLine;
        //        }
        //    }
        //    return (contents, result, save.Item2);
        //}

        public void updateTimePlay(bool startTimer, string newTime = null)
        {
            this.startTimer = startTimer;
            if (startTimer)
            {
                timerPlay.Start();
            }
            else
            {
                timerPlay.Stop();
            }
            if (newTime != null)
            {
                topTime = botTime = newTime;
            }
        }

        //Lưu biên bản
        //public void saveNotation(string nameFile, string pathFolder)
        //{
        //    pathFolder += "/";
        //    if (File.Exists(pathFolder + nameFile + ".txt"))
        //    {
        //        int i = 1;
        //        while (File.Exists(pathFolder + nameFile + " (" + i + ").txt"))
        //        {
        //            i++;
        //        }
        //        nameFile = nameFile + " (" + i + ")";
        //    }
        //    string detailEnd;
        //    if (IsEnd)
        //    {
        //        detailEnd = currentDetailResult;
        //    }
        //    else
        //    {
        //        detailEnd = null;
        //    }
        //    var contents = getListNotation(nameFile, detailEnd);
        //    File.WriteAllLines(pathFolder + nameFile + ".txt", contents.Item1);
        //}

        //public bool translateNotation(string[] lines)
        //{
        //    try
        //    {
        //        int index = 0;
        //        if (LblTitleWatch != null)
        //        {
        //            LblTitleWatch.Text = lines[index].Substring(lines[index].IndexOf(':') + 2);
        //        }

        //        notations.Clear();

        //        index++;
        //        var board = convertToArrayBoard(lines[index].Substring(lines[index].IndexOf(':') + 2));
        //        Int_board = board.Item1;
        //        Row = board.Item2;
        //        Col = board.Item3;

        //        index++;
        //        StartAbilities = convertToArrayAbililies(lines[index].Substring(lines[index].IndexOf(':') + 2));

        //        index++;
        //        startTime = lines[index].Substring(lines[index].IndexOf(':') + 2);

        //        index++;
        //        timeBonus = int.Parse(lines[index].Substring(lines[index].IndexOf(':') + 2));

        //        index++;
        //        if (lines[index].Substring(lines[index].IndexOf(':')) != ":")
        //        {
        //            timeEveryMove = convertToTimeEveryMove(lines[index].Substring(lines[index].IndexOf(':') + 2));
        //        }
        //        index++;
        //        IsReverse = lines[index].Substring(lines[index].IndexOf(':') + 2) == "1" ? true : false;

        //        index++;
        //        StartWhiteTurn = lines[index].Substring(lines[index].IndexOf(':') + 2) == "1" ? true : false;

        //        index++;
        //        NamePlayer1 = lines[index].Substring(lines[index].IndexOf(':') + 2);

        //        index++;
        //        NamePlayer2 = lines[index].Substring(lines[index].IndexOf(':') + 2);

        //        index++;
        //        string[] results = lines[index].Substring(lines[index].IndexOf(':') + 2).Split('|');
        //        typeEndWatch = detailEndWatch = null;
        //        if (!string.IsNullOrEmpty(results[0]))
        //        {
        //            typeEndWatch = results[0].Substring(0, results[0].Length - 1);
        //        }
        //        if (results.Length > 1 && !string.IsNullOrEmpty(results[1]) && results[1].Length > 1)
        //        {
        //            detailEndWatch = results[1].Substring(1);
        //        }
        //        index += 3;
        //        while (lines[index] != Line)
        //        {
        //            string line = cutSignHeadTail(lines[index], ' ');
        //            int stt = int.Parse(line.Substring(0, line.IndexOf('.')));
        //            line = line.Substring(line.IndexOf('.') + 2);
        //            string notaW = "", notaB = "";
        //            string tmp = "";
        //            for (int j = 0; j < line.Length; j++)
        //            {
        //                if ((line[j] == ' ' || j == line.Length - 1) && notaW == "")
        //                {
        //                    notaW = tmp;
        //                    if (line[j] != ' ')
        //                    {
        //                        notaW += line[j];
        //                    }
        //                    tmp = "";
        //                }
        //                if (j == line.Length - 1 && notaW != "" && tmp != "")
        //                {
        //                    notaB = tmp + line[j];
        //                    break;
        //                }
        //                if (line[j] != ' ')
        //                {
        //                    tmp += line[j];
        //                }
        //            }
        //            notations.Add((stt, notaW, notaB));
        //            index++;
        //        }
        //        sendCurrentTime(startTime, timeBonus, Piece.ColorWhite);
        //        sendCurrentTime(startTime, timeBonus, Piece.ColorBlack);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool translateNotation(List<(int, string, string)> notations)
        //{
        //    this.notations.Clear();
        //    for (int i = 0; i < notations.Count; i++)
        //    {
        //        this.notations.Add((notations[i].Item1, notations[i].Item2, notations[i].Item3));
        //    }
        //    return true;
        //}
        public void sendCurrentTime(string time, int timeBonus, string colorTurn)
        {
            if (sendTime == null)
            {
                return;
            }
            bool isTop;
            if (colorTurn == Piece.ColorWhite)
            {
                if (IsReverse)
                {
                    isTop = true;
                }
                else
                {
                    isTop = false;
                }
            }
            else
            {
                if (IsReverse)
                {
                    isTop = false;
                }
                else
                {
                    isTop = true;
                }
            }
            sendTime(isTop, time, timeBonus);
        }

        //public void setGameInTime(List<(int, string, string)> notations, List<(string, string)> timeEveryMove, string startTime, string topTime, string botTime, bool startTimer)
        //{
        //    this.notations = notations;
        //    this.startTime = startTime;
        //    this.topTime = topTime;
        //    this.botTime = botTime;
        //    this.startTimer = startTimer;
        //    this.timeEveryMove = timeEveryMove;
        //    lastMove();
        //    if (startTimer)
        //    {
        //        timerPlay.Start();
        //    }
        //}

        //public bool startWatchTxt(string pathFile)
        //{
        //    string[] lines = File.ReadAllLines(pathFile);
        //    if (!translateNotation(lines))
        //    {
        //        return false;
        //    }
        //    historyDetailBoard.Clear();
        //    initBoard(PnBoard);
        //    detailBoard = new Piece[Row, Col];
        //    restartBoard();
        //    freezeBoard();
        //    sendResetValue();
        //    return true;
        //}


        //internal bool startWatchHistories(tb_InfoHistory infoHistory)
        //{
        //    if (!translateNotation(infoHistory.Notations))
        //    {
        //        return false;
        //    }
        //    initBoard(PnBoard);
        //    detailBoard = new Piece[Row, Col];
        //    var infoBoard = convertToArrayBoard(infoHistory.Board);
        //    setCustomChess(infoBoard.Item1, convertToArrayAbililies(infoHistory.Abilities), infoHistory.StartWhiteTurn, infoBoard.Item2, infoBoard.Item3, !infoHistory.StartWhiteTurn);
        //    typeEndWatch = infoHistory.Result;
        //    detailEndWatch = infoHistory.DetailEnd;
        //    timeEveryMove = infoHistory.TimeEveryMove;
        //    startTime = Regime.regimes[infoHistory.Index_regime].getTime();
        //    timeBonus = Regime.regimes[infoHistory.Index_regime].time_bonus;
        //    sendCurrentTime(startTime, timeBonus, Piece.ColorWhite);
        //    sendCurrentTime(startTime, timeBonus, Piece.ColorBlack);
        //    freezeBoard();
        //    sendResetValue();
        //    return true;
        //}

        //internal bool startHistories(tb_Match match, int indexTypeGame, int indexRegime, bool isReverse)
        //{
        //    moves.Clear();
        //    moves = tb_MoveInMatch.getAllMove(match.id);
        //    initBoard(PnBoard);
        //    detailBoard = new Piece[Row, Col];
        //    TypeGame typeGame = new TypeGame(TypeGame.typeGames[indexTypeGame]);
        //    var infoBoard = convertToArrayBoard(typeGame.board);
        //    setChess(indexTypeGame, Regime.regimes[indexRegime].getTime(), Regime.regimes[indexRegime].time_bonus, isReverse, false, infoBoard.Item1, convertToArrayAbililies(typeGame.abilities), typeGame.startWhiteTurn, infoBoard.Item2, infoBoard.Item3, typeGame.countNoPawnNoCapture, typeGame.countMoveOverall);
        //    typeEndWatch = tb_Match.getStrResultByInt(match.result);
        //    detailEndWatch = match.detailResult;
        //    sendCurrentTime(startTime, timeBonus, Piece.ColorWhite);
        //    sendCurrentTime(startTime, timeBonus, Piece.ColorBlack);
        //    freezeBoard();
        //    sendResetValue();
        //    return true;
        //}

        public bool backMoveWatch(int index)
        {
            if (index > movesMatch.Count)
            {
                IsEnd = false;
                freezeBoard();
                return true;
            }
            if (backMove())
            {
                freezeBoard();
                return true;
            }
            return false;
        }

        public bool canNextMove(int index = 0)
        {
            if (IsEnd || movesMatch.Count == 0 || index > movesMatch.Count)
            {
                return false;
            }
            return true;

        }

        public bool nextMove(bool isWhitePiece, int index = 0)
        {
            if (IsEnd || movesMatch.Count == 0 || index > movesMatch.Count)
            {
                return false;
            }
            if (index == movesMatch.Count)
            {
                endGame(DetailEndWatch, isWhitePiece);
                return true;
            }
            sendCurrentTime(movesMatch[index].Item3, timeBonus, ColorTurn);
            moveByLocation(movesMatch[index].Item1, movesMatch[index].Item2);
            freezeBoard();
            return true;
        }
        
        public bool canGoToWatchFirstMove()
        {
            return movesMatch.Count != 0;
        }
        public bool canGoToFirstMove()
        {
            return saveMoves.Count > 1;
        }

        public bool goToWatchFirstMove(bool isWhitePiece)
        {
            if (!canGoToWatchFirstMove())
            {
                return false;
            }
            restartBoard();
            nextMove(isWhitePiece);
            return true;
        }

        public bool goToFirstMove()
        {
            if (!canGoToFirstMove())
            {
                return false;
            }
            string move = saveMoves[0];
            string namePromotion = namePromotions[0];
            restartBoard();
            moveByLocation(move, namePromotion);
            return true;
        }
        //public void lastMove()
        //{
        //    while (nextMove())
        //    {

        //    }
        //}

        public int goToEndGame(bool isWhitePiece, int index = 0)
        {
            while (nextMove(isWhitePiece, index))
            {
                index++;
            }
            return index;
        }

        public void reWatch()
        {
            restartBoard();
            freezeBoard();
        }

        //EVENTS
        private void selectNonePiece(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clearColor(false);
                //string[] index = ((Control)sender).Tag.ToString().Split('-');
                //int i = int.Parse(index[0]);
                //int j = int.Parse(index[1]);
                //if (detailBoard[i, j] != null)
                //{
                //    lblCells[i, j].BackColor = Color.
                //}
                currentSelect = new Point(-1, -1);
            }
        }

        //Chọn quân cần di chuyển
        private void selectPiece(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int lastIndex = lstPrevMoved.Count - 1;
                if (lastIndex != -1)
                {
                    currentPrevMoved.X = lstPrevMoved[lastIndex].X;
                    currentPrevMoved.Y = lstPrevMoved[lastIndex].Y;
                    currentDesMoved.X = lstDesMoved[lastIndex].X;
                    currentDesMoved.Y = lstDesMoved[lastIndex].Y;
                }
                clearColor(false);
                string[] index = ((Control)sender).Tag.ToString().Split('-');
                int i = int.Parse(index[0]);
                int j = int.Parse(index[1]);
                lblCells[i, j].BackColor = colorSelect;
                currentSelect = new Point(i, j);
                showRecommend();
                if (sendUnPromotion != null)
                {
                    sendUnPromotion();
                }
            }
        }

        //Chọn ô muốn đi tới
        private void selectMoveTo(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string[] index = ((Control)sender).Tag.ToString().Split('-');
                int i = int.Parse(index[0]);
                int j = int.Parse(index[1]);
                currentPrevMoved = currentSelect;
                currentDesMoved = new Point(i, j);
                move();
            }
        }

        //Chọn ô muốn ăn quân
        private void selectCapture(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string[] index = ((Control)sender).Tag.ToString().Split('-');
                int i = int.Parse(index[0]);
                int j = int.Parse(index[1]);
                currentPrevMoved = currentSelect;
                currentDesMoved = new Point(i, j);
                move();
            }
        }

        public void moveByLocation(string[] preMove, string[] desMove, string namePromotion)
        {
            currentPrevMoved = new Point(getLocationNumbersBySign(preMove[1], row, rulerHeight), getLocationAlphasBySign(preMove[0], col, rulerWidth));
            currentDesMoved = new Point(getLocationNumbersBySign(desMove[1], row, rulerHeight), getLocationAlphasBySign(desMove[0], col, rulerWidth));
            move(namePromotion);
        }
        public void moveByLocation(string strMove, string namePromotion)
        {
            currentPrevMoved = new Point(getLocationNumbersBySign(strMove[1].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[0].ToString(), col, rulerWidth));
            currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
            move(namePromotion);
        }
        public void moveByLocation(string strMove, string namePromotion, bool send)
        {
            currentPrevMoved = new Point(getLocationNumbersBySign(strMove[1].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[0].ToString(), col, rulerWidth));
            currentDesMoved = new Point(getLocationNumbersBySign(strMove[3].ToString(), row, rulerHeight), getLocationAlphasBySign(strMove[2].ToString(), col, rulerWidth));
            move(namePromotion, send);
        }

        private void move(string notationPromote = null, bool send = true)
        {
            do
            {

            } while (detailBoard[currentPrevMoved.X, currentPrevMoved.Y] == null);
            currentTakedPiece = null;
            bool isCapture = false;
            bool isEnpassant = enpassant();
            bool isCastle = false;
            bool isPromote = false;
            if (isEnpassant || detailBoard[currentDesMoved.X, currentDesMoved.Y] != null)
            {
                isCapture = true;
            }
            if (isCapture)
            {
                if (!isEnpassant)
                {
                    isCastle = castle();
                    if (!isCastle)
                    {
                        currentTakedPiece = detailBoard[currentDesMoved.X, currentDesMoved.Y].getCoppy();
                        var tmp = promote(notationPromote);
                        if (tmp.Item1 && !tmp.Item2)
                        {
                            return;
                        }
                        isPromote = tmp.Item1;
                        if (!isPromote)
                        {
                            moveTo(currentPrevMoved, currentDesMoved);
                        }
                    }
                }
            }
            else
            {
                isCastle = castle();
                if (!isCastle)
                {
                    var tmp = promote(notationPromote);
                    if (tmp.Item1 && !tmp.Item2)
                    {
                        return;
                    }
                    isPromote = tmp.Item1;
                    if (!isPromote)
                    {
                        moveTo(currentPrevMoved, currentDesMoved);
                    }
                }
            }
            processAfterMove(send, notationPromote, isPromote, isCapture, isCastle, isEnpassant);
        }

        private void processAfterMove(bool send, string notationPromote, bool isPromote = true, bool isCapture = false, bool isCastle = false, bool isEnpassant = false)
        {
            if (isCapture && !isCastle)
            {
                int changeIndex;
                if (currentTakedPiece.Name == Piece.NamePawn)
                {
                    changeIndex = 0;
                }
                else if (currentTakedPiece.Name == Piece.NameRook)
                {
                    changeIndex = 1;
                }
                else if (currentTakedPiece.Name == Piece.NameKnight)
                {
                    changeIndex = 2;
                }
                else if (currentTakedPiece.Name == Piece.NameBishop)
                {
                    changeIndex = 3;
                }
                else if (currentTakedPiece.Name == Piece.NameQueen)
                {
                    changeIndex = 4;
                }
                else
                {
                    changeIndex = 5;
                }
                if (currentTakedPiece.Color == Piece.ColorWhite)
                {
                    indexsWhitePieceCapture.Add(changeIndex);
                    indexsBlackPieceCapture.Add(-1);
                    for (int i = 0; i < countWhiteCapture.Length; i++)
                    {
                        if (i == changeIndex)
                        {
                            countWhiteCapture[i].Add(countWhiteCapture[i][countWhiteCapture[i].Count - 1] + 1);
                        }
                        else
                        {
                            countWhiteCapture[i].Add(countWhiteCapture[i][countWhiteCapture[i].Count - 1]);
                        }
                        countBlackCapture[i].Add(countBlackCapture[i][countBlackCapture[i].Count - 1]);
                    }
                }
                else
                {
                    indexsBlackPieceCapture.Add(changeIndex);
                    indexsWhitePieceCapture.Add(-1);
                    for (int i = 0; i < countBlackCapture.Length; i++)
                    {
                        if (i == changeIndex)
                        {
                            countBlackCapture[i].Add(countBlackCapture[i][countBlackCapture[i].Count - 1] + 1);
                        }
                        else
                        {
                            countBlackCapture[i].Add(countBlackCapture[i][countBlackCapture[i].Count - 1]);
                        }
                        countWhiteCapture[i].Add(countWhiteCapture[i][countWhiteCapture[i].Count - 1]);
                    }
                }
            }
            else
            {
                indexsWhitePieceCapture.Add(-1);
                indexsBlackPieceCapture.Add(-1);
                for (int i = 0; i < countWhiteCapture.Length; i++)
                {
                    countWhiteCapture[i].Add(countWhiteCapture[i][countWhiteCapture[i].Count - 1]);
                }
                for (int i = 0; i < countBlackCapture.Length; i++)
                {
                    countBlackCapture[i].Add(countBlackCapture[i][countBlackCapture[i].Count - 1]);
                }
            }
            bool isCheck = checkForCheck();
            if (isCheck)
            {
                playSound(nameSoundCheck);
            }
            else
            {
                if (isCastle)
                {
                    playSound(nameSoundCastle);
                }
                else if (isEnpassant || isCapture)
                {
                    playSound(nameSoundCapture);
                }
                else if (isPromote)
                {
                    playSound(nameSoundPromote);
                }
                else
                {
                    playSound(nameSoundMove);
                }
            }
            checkForEnd();
            addNotation(currentTakedPiece, isCheck, currentDetailResult == EndGame.checkmate);

            currentSelect = new Point(-1, -1);
            lstPrevMoved.Add(currentPrevMoved);
            lstDesMoved.Add(currentDesMoved);
            clearColor(true);
            unenableEnpassant();
            historyDetailBoard.Add(getCoppyDetailBoard());
            updateCount();
            changeTurn();
            startFindHint();
            freezeBoardByTurnBot(ColorTurn);
            autoBotPlayMove();
            if (startTimer)
            {
                timerPlay.Start();
            }
            string move = rulerWidth[currentPrevMoved.Y].Text + rulerHeight[currentPrevMoved.X].Text + rulerWidth[currentDesMoved.Y].Text + rulerHeight[currentDesMoved.X].Text + notationPromote;
            saveMoves.Add(move);
            namePromotions.Add(notationPromote);
            if (send)
            {
                if (sendMove != null)
                {
                    sendMove(move, notationPromote, colorTurn == Piece.ColorBlack);
                }
                if (StartTimer)
                {
                    if ((IsReverse && colorTurn == Piece.ColorBlack) || (!IsReverse && ColorTurn == Piece.ColorWhite))
                    {
                        Time time = Time.convertStrTimeRealTime(topTime);
                        int second = time.getSeconds() + timeBonus;
                        updateTime(Time.convertRealTimeToStr(second), botTime, timeBonus);
                    }
                    else
                    {
                        Time time = Time.convertStrTimeRealTime(botTime);
                        int second = time.getSeconds() + timeBonus;
                        updateTime(topTime, Time.convertRealTimeToStr(second), timeBonus);
                    }
                }
            }
        }

        private void startFindHint()
        {
            locaHint.Item1 = new Point(-1, -1);
            locaHint.Item2 = new Point(-1, -1);
            hint = null;
            if (!IsEnd)
            {
                botSoluteHint.startFindMove(getCurrentFen());
            }
        }


        public void saveAllBoardToFile(string fileName)
        {
            string tmp = "";
            for (int i = 0; i < historyDetailBoard.Count; i++)
            {
                for (int k = 0; k < row; k++)
                {
                    for (int l = 0; l < col; l++)
                    {
                        if (historyDetailBoard[i][k, l] == null)
                        {
                            tmp += Piece.ValueNone + " ";
                        }
                        else
                        {
                            tmp += historyDetailBoard[i][k, l].Value + " ";
                        }
                    }
                    tmp += Environment.NewLine;
                }
                File.AppendAllText(fileName + ".txt", tmp + Environment.NewLine);
            }
        }

        public string getMoveFen(Point preMove, Point desMove)
        {
            return rulerWidth[preMove.Y].Text.ToLower() + rulerHeight[preMove.X].Text + rulerWidth[desMove.Y].Text.ToLower() + rulerHeight[desMove.X].Text;
        }

        public static string getStrLocation(Point location, bool isReverse, int row, int col, bool upperAlpha = false)
        {
            string[] widthRuler = new string[col];
            string[] heightRuler = new string[row];
            for (int i = 0; i < row; i++)
            {
                heightRuler[row - i - 1] = (i + 1).ToString();
            }
            for (int i = 0; i < col; i++)
            {
                widthRuler[i] = ((char)('a' + i)).ToString();
            }

            if (isReverse)
            {
                if (upperAlpha)
                {
                    return (widthRuler[col - location.Y - 1] + heightRuler[row - location.X - 1]).ToUpper();
                }
                return widthRuler[col - location.Y - 1] + heightRuler[row - location.X - 1];
            }
            if (upperAlpha)
            {
                return (widthRuler[location.Y] + heightRuler[location.X]).ToUpper();
            }
            return widthRuler[location.Y] + heightRuler[location.X];

        }

        public static string convertBoardToFen(Piece[,] detailBoard, int row, int col, bool isReverse, bool startWhiteTurn, int countNoPawnNoCapture, int countMove)
        {
            bool allowWhiteCastleKingSide = false, allowWhiteCastleQueenSide = false, allowBlackCastleKingSide = false, allowBlackCastleQueenSide = false;
            string locaEnpassantCaptureLeft = null, locaEnpassantCaptureRight = null;
            if (isReverse)
            {
                detailBoard = getReverseDetailBoard(detailBoard, row, col);
            }
            string fen = "";
            for (int i = 0; i < row; i++)
            {
                int countNoneCell = 0;
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null)
                    {
                        if (countNoneCell != 0)
                        {
                            fen += countNoneCell;
                            countNoneCell = 0;
                        }
                        fen += detailBoard[i, j].Fen;
                        if (detailBoard[i, j].Name == Piece.NameKing)
                        {
                            var tmp = ((King)detailBoard[i, j]).checkAllowCastle(detailBoard);
                            if (tmp.Item1)
                            {
                                if (detailBoard[i, j].Color == Piece.ColorWhite)
                                {
                                    allowWhiteCastleQueenSide = true;
                                }
                                else
                                {
                                    allowBlackCastleQueenSide = true;
                                }
                            }
                            if (tmp.Item2)
                            {
                                if (detailBoard[i, j].Color == Piece.ColorWhite)
                                {
                                    allowWhiteCastleKingSide = true;
                                }
                                else
                                {
                                    allowBlackCastleKingSide = true;
                                }
                            }
                        }
                        else if (detailBoard[i, j].Name == Piece.NamePawn)
                        {
                            Pawn pawn = (Pawn)detailBoard[i, j];
                            var enpassant = pawn.findEnpassant(detailBoard, row, col);
                            if (enpassant.Item1 != null)
                            {
                                var location = pawn.getLocaMoveEnpassant();
                                locaEnpassantCaptureLeft = getStrLocation(location.Item1, false, row, col);
                            }
                            else if (enpassant.Item2 != null)
                            {
                                var location = pawn.getLocaMoveEnpassant();
                                locaEnpassantCaptureRight = getStrLocation(location.Item2, false, row, col);
                            }
                        }
                    }
                    else
                    {
                        countNoneCell++;
                        if (j == col - 1)
                        {
                            fen += countNoneCell;
                        }
                    }
                }
                if (i != row - 1)
                {
                    fen += "/";
                }
            }

            fen += " " + (startWhiteTurn ? "w" : "b") + " ";

            if (allowWhiteCastleKingSide || allowWhiteCastleQueenSide || allowBlackCastleKingSide || allowBlackCastleQueenSide)
            {
                if (allowWhiteCastleKingSide)
                {
                    fen += Piece.FenKing;
                }
                if (allowWhiteCastleQueenSide)
                {
                    fen += Piece.FenQueen;
                }
                if (allowBlackCastleKingSide)
                {
                    fen += Piece.FenKing.ToLower();
                }
                if (allowBlackCastleQueenSide)
                {
                    fen += Piece.FenQueen.ToLower();
                }
            }
            else
            {
                fen += "-";
            }

            fen += " ";

            if (locaEnpassantCaptureLeft != null)
            {
                fen += locaEnpassantCaptureLeft;
            }
            else if (locaEnpassantCaptureRight != null)
            {
                fen += locaEnpassantCaptureRight;
            }
            else
            {
                fen += "-";
            }
            fen += " " + countNoPawnNoCapture + " " + countMove;
            return fen;
        }

        //n1QBq1k1/5p1p/5KP1/p7/8/8/8/8 w - - 0 1
        //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
        public static (int[,], string[,], int, int, bool, int, int) convertFenToBoard(string fen)
        {
            try
            {
                string[] tmp = fen.Split(' ');//0: bàn cờ, 1 màu quân đi trước, 2 nhập thành cho trắng - cho đen, 3 bắt tốt qua đường, 4 countNoPawnNoCapture, 5 countMoveOverall
                string[] tmp2 = tmp[0].Split('/');
                int row = tmp2.Length;
                string board = "";
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < tmp2[i].Length; j++)
                    {
                        int number;
                        if (int.TryParse(tmp2[i][j].ToString(), out number))
                        {
                            for (int k = 0; k < number; k++)
                            {
                                board += Piece.ValueNone;
                                board += ",";
                            }
                            if (j == tmp2[i].Length - 1 && i != row - 1)
                            {
                                board = board.Substring(0, board.Length - 1) + "|";
                            }
                        }
                        else
                        {
                            board += Piece.convertFenToValuePiece(tmp2[i][j].ToString());
                            if (j != tmp2[i].Length - 1)
                            {
                                board += ",";
                            }
                            else if (i != row - 1)
                            {
                                board += "|";
                            }
                        }
                    }
                }

                var arrayBoard = convertToArrayBoard(board);
                int col = arrayBoard.Item3;
                bool startWhiteTurn = tmp[1] == "w";
                int[,] int_board = arrayBoard.Item1;

                int countNoPawnNoCapture = int.Parse(tmp[4]);
                int countMoveOverall = int.Parse(tmp[5]);
                string[,] abilities = new string[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (int_board[i, j] == Piece.ValueKing)
                        {
                            abilities[i, j] = convertBoolAbilityToStr(tmp[2].Contains(Piece.FenQueen), tmp[2].Contains(Piece.FenKing));
                        }
                        else if (int_board[i, j] == -Piece.ValueKing)
                        {
                            abilities[i, j] = convertBoolAbilityToStr(tmp[2].Contains(Piece.FenQueen.ToLower()), tmp[2].Contains(Piece.FenKing.ToLower()));
                        }
                        else if (Math.Abs(int_board[i, j]) == Piece.ValuePawn)
                        {
                            bool left = true, right = true, twomove = (int_board[i, j] > 0 && i == row - 2) || (int_board[i, j] < 0 && i == 1);
                            if (j != 0 && int_board[i, j] * int_board[i, j - 1] < 0)
                            {
                                left = false;
                            }
                            if (j != col - 1 && int_board[i, j] * int_board[i, j + 1] < 0)
                            {
                                right = false;
                            }
                            abilities[i, j] = convertBoolAbilityToStr(left, right, twomove);

                        }
                        else
                        {
                            abilities[i, j] = convertBoolAbilityToStr(true, true);
                        }
                    }
                }
                if (tmp[3] != "-")
                {
                    Point location = getLocationRuler(tmp[3][0].ToString(), int.Parse(tmp[3][1].ToString()), row, col, false);
                    if (location.X < row / 2)
                    {
                        if (location.X != row - 1)
                        {
                            if (location.Y != 0 && int_board[location.X + 1, location.Y - 1] == Piece.ValuePawn)
                            {
                                var boolability = convertStrAbilityToBool(abilities[location.X + 1, location.Y - 1]);
                                boolability.Item2 = true;
                                abilities[location.X + 1, location.Y - 1] = convertBoolAbilityToStr(boolability.Item1, boolability.Item2, boolability.Item3);
                            }
                            if (location.Y != col - 1 && int_board[location.X + 1, location.Y + 1] == Piece.ValuePawn)
                            {
                                var boolability = convertStrAbilityToBool(abilities[location.X + 1, location.Y + 1]);
                                boolability.Item1 = true;
                                abilities[location.X + 1, location.Y + 1] = convertBoolAbilityToStr(boolability.Item1, boolability.Item2, boolability.Item3);
                            }
                        }
                    }
                    else
                    {
                        if (location.X != 0)
                        {
                            if (location.Y != 0 && int_board[location.X - 1, location.Y - 1] == Piece.ValuePawn)
                            {
                                var boolability = convertStrAbilityToBool(abilities[location.X - 1, location.Y - 1]);
                                boolability.Item2 = true;
                                abilities[location.X - 1, location.Y - 1] = convertBoolAbilityToStr(boolability.Item1, boolability.Item2, boolability.Item3);
                            }
                            if (location.Y != col - 1 && int_board[location.X - 1, location.Y + 1] == Piece.ValuePawn)
                            {
                                var boolability = convertStrAbilityToBool(abilities[location.X - 1, location.Y + 1]);
                                boolability.Item1 = true;
                                abilities[location.X - 1, location.Y + 1] = convertBoolAbilityToStr(boolability.Item1, boolability.Item2, boolability.Item3);
                            }
                        }
                    }
                }

                return (arrayBoard.Item1, abilities, row, col, startWhiteTurn, countNoPawnNoCapture, countMoveOverall);
            }
            catch
            {
                return (null, null, -1, -1, false, -1, -1);
            }
        }

        public static Point getLocationRuler(string alpha, int number, int row, int col, bool isReverse)
        {
            char start = 'A';
            Point location = new Point(-1, -1);
            for (int i = 0; i < col; i++)
            {
                if (start.ToString().ToLower() == alpha.ToLower())
                {
                    location.Y = i;
                    break;
                }
                start = (char)(start + 1);
            }
            location.X = row - number - 2;
            if (isReverse)
            {
                return new Point(row - location.X - 1, col - location.Y - 1);
            }
            return location;
        }
        //public void updateAutoPlay(bool autoPlay)
        //{
        //    timerWatch.Stop();
        //    this.autoPlay = autoPlay;
        //    if (autoPlay)
        //    {
        //        nextMove();
        //        timerWatch.Start();
        //    }
        //}
        public void freezeBoardByTurnBot()
        {
            if (isEnd)
            {
                freezeBoard();
                return;
            }
            bool isWhitePlayer;
            if (colorTurn == Piece.ColorWhite)
            {
                isWhitePlayer = true;
            }
            else
            {
                isWhitePlayer = false;
            }
            freezeBoardByTurnBot(isWhitePlayer);
        }

        public void freezeBoardByTurnBot(string colorTurn)
        {
            if (isEnd)
            {
                freezeBoard();
                return;
            }
            bool isWhitePlayer;
            if (colorTurn == Piece.ColorWhite)
            {
                isWhitePlayer = true;
            }
            else
            {
                isWhitePlayer = false;
            }
            freezeBoardByTurnBot(isWhitePlayer);
        }
        public void freezeBoardByTurnBot(bool isWhitePlayer)
        {
            if (botPlayer1 != null && botPlayer2 != null)
            {
                freezeBoard();
            }
            else
            {
                if (isWhitePlayer)
                {
                    if (botPlayer1 == null)
                    {
                        freezeBoardByTurn();
                        return;
                    }
                    freezeBoard();
                }
                else
                {
                    if (botPlayer2 == null)
                    {
                        freezeBoardByTurn();
                        return;
                    }
                    freezeBoard();
                }
            }
        }

        //Sử dụng stockfish
        public void setBotChess(string nameBot, bool isWhitePlayer)
        {
            if (isWhitePlayer)
            {
                if (botPlayer1 == null)
                {
                    botPlayer1 = BotChess.getBotChess(nameBot, isWhitePlayer);
                    botPlayer1.sendBestMove += moveByStrLocate;
                }
                else
                {
                    botPlayer1.update(nameBot);
                }
            }
            else
            {
                if (botPlayer2 == null)
                {
                    botPlayer2 = BotChess.getBotChess(nameBot, isWhitePlayer);
                    botPlayer2.sendBestMove += moveByStrLocate;
                }
                else
                {
                    botPlayer2.update(nameBot);
                }
            }
            freezeBoardByTurnBot(isWhitePlayer);
        }

        public void setBotChess(int level, bool isWhitePlayer)
        {
            if (isWhitePlayer)
            {
                if (botPlayer1 == null)
                {
                    botPlayer1 = BotChess.getBotChess(BotChess.nameStockfish16, isWhitePlayer, level);
                    botPlayer1.sendBestMove += moveByStrLocate;
                }
                else
                {
                    botPlayer1.update(BotChess.nameStockfish16, level);
                }
            }
            else
            {
                if (botPlayer2 == null)
                {
                    botPlayer2 = BotChess.getBotChess(BotChess.nameStockfish16, isWhitePlayer, level);
                    botPlayer2.sendBestMove += moveByStrLocate;
                }
                else
                {
                    botPlayer2.update(BotChess.nameStockfish16, level);
                }
            }
            freezeBoardByTurnBot(isWhitePlayer);
        }

        internal void setBotChess(BotChess bot, bool isWhitePlayer)
        {
            bot.ColorPieces = isWhitePlayer ? Piece.ColorWhite : Piece.ColorBlack;
            if (isWhitePlayer)
            {
                botPlayer1 = bot.getCoppy();
                botPlayer1.sendBestMove += moveByStrLocate;
            }
            else
            {
                botPlayer2 = bot.getCoppy();
                botPlayer2.sendBestMove += moveByStrLocate;
            }
        }

        public void cancelBot(bool isWhitePlayer)
        {
            if (isWhitePlayer)
            {
                if (botPlayer1 == null)
                {
                    return;
                }
                botPlayer1.stop();
                botPlayer1 = null;
            }
            else
            {
                if (botPlayer2 == null)
                {
                    return;
                }
                botPlayer2.stop();
                botPlayer2 = null;
            }
        }

        public void moveByStrLocate(string moveLocate, bool isRecommend = false)
        {
            if (IsEnd)
            {
                return;
            }
            string pre = moveLocate.Substring(0, 2); //d2
            string des = moveLocate.Substring(2); //d4 hay d8Q
            string notationPromote = null;
            if (des.Length > 2)
            {
                notationPromote = des[2].ToString().ToUpper();
                des = des.Substring(0, 2);
            }
            Point prevLocation = new Point(getLocationNumbersBySign(pre[1].ToString(), row, rulerHeight), getLocationAlphasBySign(pre[0].ToString(), col, rulerWidth));
            Point desLocation = new Point(getLocationNumbersBySign(des[1].ToString(), row, rulerHeight), getLocationAlphasBySign(des[0].ToString(), col, rulerWidth));
            if (isRecommend)
            {
                if (detailBoard[prevLocation.X, prevLocation.Y] != null)
                {
                    string namePiece = Piece.getNameVN(detailBoard[prevLocation.X, prevLocation.Y].Name);
                    hint = namePiece + " tại ô " + pre[0] + pre[1] + " đi đến ô " + des[0] + des[1];
                    locaHint.Item1 = prevLocation;
                    locaHint.Item2 = desLocation;
                }
            }
            else
            {
                currentPrevMoved = prevLocation;
                currentDesMoved = desLocation;
                move(notationPromote);
            }
        }
        public void moveByStrLocate(string strMove, string namePromotion, bool isRecommend = false)
        {
            if (IsEnd)
            {
                return;
            }
            string pre = strMove.Substring(0, 2); //d2
            string des = strMove.Substring(2); //d4 hay d8
            Point prevLocation = new Point(getLocationNumbersBySign(pre[1].ToString(), row, rulerHeight), getLocationAlphasBySign(pre[0].ToString(), col, rulerWidth));
            Point desLocation = new Point(getLocationNumbersBySign(des[1].ToString(), row, rulerHeight), getLocationAlphasBySign(des[0].ToString(), col, rulerWidth));
            if (isRecommend)
            {
                if (detailBoard[prevLocation.X, prevLocation.Y] != null)
                {
                    string namePiece = Piece.getNameVN(detailBoard[prevLocation.X, prevLocation.Y].Name);
                    hint = namePiece + " tại ô " + pre[0] + pre[1] + " đi đến ô " + des[0] + des[1];
                    locaHint.Item1 = prevLocation;
                    locaHint.Item2 = desLocation;
                }
            }
            else
            {
                currentPrevMoved = prevLocation;
                currentDesMoved = desLocation;
                move(namePromotion, false);
            }
        }

        public string getHint()
        {
            if (IsEnd || countHint == countMaxHint)
            {
                return null;
            }
            if (hint != null)
            {
                LblCells[locaHint.Item1.X, locaHint.Item1.Y].BackColor = ColorHint;
                LblCells[locaHint.Item2.X, locaHint.Item2.Y].BackColor = ColorHint;
                showHint = true;
                countHint++;
            }
            return hint;
        }

        private void autoBotPlayMove()
        {
            if (IsEnd)
            {
                return;
            }
            if (autoBotPlay)
            {
                nextMoveByBot();
            }
        }

        public void firstMoveByBot()
        {
            if (IsEnd)
            {
                return;
            }
            if (startWhiteTurn)
            {
                nextMoveByBot();
            }
            else
            {
                nextMoveByBot();
            }
        }

        public void nextMoveByBot()
        {
            if (colorTurn == Piece.ColorWhite)
            {
                if (botPlayer1 != null)
                {
                    botPlayer1.startFindMove(getCurrentFen());
                }
            }
            else
            {
                if (botPlayer2 != null)
                {
                    botPlayer2.startFindMove(getCurrentFen());
                }
            }
        }
        public void stopStockfish(bool isWhitePlayer)
        {
            if (isWhitePlayer)
            {
                if (botPlayer1 != null)
                {
                    botPlayer1.stop();
                }
                if (botPlayer2 != null)
                {
                    botPlayer2.stop();
                }
            }
        }

        public bool updateTimeWatch(int second)
        {
            if (second < 1 || second > maxSecondDelay)
            {
                return false;
            }
            timerWatch.Stop();
            timeDelayWatch = second * 1000;
            timerWatch.Interval = timeDelayWatch;
            if (AutoPlay)
            {
                timerWatch.Start();
            }
            return true;
        }

        private void timerWatchTick(object sender, EventArgs e)
        {
            //nextMove();
            if (IsEnd)
            {
                timerWatch.Stop();
            }
        }
        private void timerPlay_Tick(object sender, EventArgs e)
        {
            if (IsEnd)
            {
                timerPlay.Stop();
                return;
            }
            bool isTop;
            string strtime;
            if (ColorTurn == Piece.ColorWhite)
            {
                if (IsReverse)
                {
                    strtime = topTime;
                    isTop = true;
                }
                else
                {
                    strtime = botTime;
                    isTop = false;
                }
            }
            else
            {
                if (IsReverse)
                {
                    strtime = botTime;
                    isTop = false;
                }
                else
                {
                    strtime = topTime;
                    isTop = true;
                }
            }
            Time time = Time.convertStrTimeRealTime(strtime);

            if (time.seconds == 0)
            {
                if (time.minutes == 0)
                {
                    if (time.hours == 0)
                    {
                        timeOut(colorTurn == Piece.ColorWhite);
                        return;
                    }
                    else
                    {
                        time.hours--;
                        time.minutes = 59;
                        time.seconds = 59;
                    }
                }
                else
                {
                    time.minutes--;
                    time.seconds = 59;
                }
            }
            else
            {
                time.seconds--;
            }
            string newTime = Time.convertRealTimeToStr(time);
            if (isTop)
            {
                topTime = newTime;
            }
            else
            {
                botTime = newTime;
            }
            if (sendTime != null)
            {
                sendTime(isTop, newTime, timeBonus);
            }
        }


        public void reloadChessBoard()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (detailBoard[i, j] != null)
                    {
                        lblCells[i, j].Image = Image.FromFile(detailBoard[i, j].getPathImg());
                    }
                    LblCells[i, j].BackColor = ColorCells[i, j];
                }
            }
        }
        public static string[,] getBasicAbilities(bool isReverse)
        {
            string[,] result = new string[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result[i, j] = "1.1.1";
                }
            }
            if (isReverse)
            {
                return getReverseAbilities(result, 8, 8);
            }
            return result;
        }
        public static int[,] getBasicIntBoard(bool isReverse)
        {
            int[,] tmp_board = new int[,] {
                { - Piece.ValueRook, - Piece.ValueKnight, - Piece.ValueBishop, - Piece.ValueQueen, - Piece.ValueKing,  - Piece.ValueBishop, - Piece.ValueKnight, - Piece.ValueRook },
                { - Piece.ValuePawn, - Piece.ValuePawn,   - Piece.ValuePawn,   - Piece.ValuePawn,  - Piece.ValuePawn,  - Piece.ValuePawn,   - Piece.ValuePawn,   - Piece.ValuePawn, },
                {   Piece.ValueNone,   Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone,    Piece.ValueNone,    Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone, },
                {   Piece.ValueNone,   Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone,    Piece.ValueNone,    Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone, },
                {   Piece.ValueNone,   Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone,    Piece.ValueNone,    Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone, },
                {   Piece.ValueNone,   Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone,    Piece.ValueNone,    Piece.ValueNone,     Piece.ValueNone,     Piece.ValueNone, },
                {   Piece.ValuePawn,   Piece.ValuePawn,     Piece.ValuePawn,     Piece.ValuePawn,    Piece.ValuePawn,    Piece.ValuePawn,     Piece.ValuePawn,     Piece.ValuePawn, },
                {   Piece.ValueRook,   Piece.ValueKnight,   Piece.ValueBishop,   Piece.ValueQueen,   Piece.ValueKing,    Piece.ValueBishop,   Piece.ValueKnight,   Piece.ValueRook },
            };
            int[,] result;
            if (isReverse)
            {
                result = new int[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        result[i, j] = tmp_board[7 - i, 7 - j];
                    }
                }
            }
            else
            {
                result = tmp_board;
            }
            return result;
        }
        public static string[,] getChess960Abilities(bool isReverse, int row, int col)
        {
            string[,] abilities = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    abilities[i, j] = "1.1.1";
                }
            }
            if (isReverse)
            {
                return getReverseAbilities(abilities, row, col);
            }
            return abilities;
        }

        public static int[,] getChess960IntBoard(bool isReverse, int row, int col)
        {
            int[,] tmp_board = new int[row, col];
            if (row < 2 || col < 1)
            {
                return tmp_board;
            }
            for (int j = 0; j < col; j++)
            {
                tmp_board[1, j] = -Piece.ValuePawn;
                tmp_board[row - 2, j] = Piece.ValuePawn;
            }
            //Vị trí King
            int yKing = randomLocation(0, new List<int>() { 0, col - 1 }, col);

            //Vị trí Rook
            int yRook1 = randomLocation(0, new List<int>() { yKing }, col);
            int yRook2;
            if (yRook1 < yKing)
            {
                List<int> smaller = new List<int>();
                for (int i = yKing; i >= 0; i--)
                {
                    smaller.Add(i);
                }
                yRook2 = randomLocation(0, smaller, col);
            }
            else
            {
                List<int> bigger = new List<int>();
                for (int i = yKing; i < row; i++)
                {
                    bigger.Add(i);
                }
                yRook2 = randomLocation(0, bigger, col);
            }

            //Vị trí Bishop
            List<int> chan = new List<int>() { yKing, yRook1, yRook2, 0, 2, 4, 6 };
            List<int> le = new List<int>() { yKing, yRook1, yRook2, 1, 3, 5, 7 };
            int yBishop1 = randomLocation(0, new List<int>() { yKing, yRook1, yRook2 }, col);
            int yBishop2;
            if (yBishop1 % 2 == 0)
            {
                yBishop2 = randomLocation(0, chan, col);
            }
            else
            {
                yBishop2 = randomLocation(0, le, col);
            }

            //Vị trí Knight
            int yKnight1 = randomLocation(0, new List<int>() { yKing, yRook1, yRook2, yBishop1, yBishop2 }, col);

            int yKnight2 = randomLocation(0, new List<int>() { yKing, yRook1, yRook2, yBishop1, yBishop2, yKnight1 }, col);

            int yQueen = randomLocation(0, new List<int>() { yKing, yRook1, yRook2, yBishop1, yBishop2, yKnight1, yKnight2 }, col);

            tmp_board[0, yKing] = -Piece.ValueKing;
            tmp_board[row - 1, yKing] = Piece.ValueKing;

            tmp_board[0, yRook1] = -Piece.ValueRook;
            tmp_board[row - 1, yRook1] = Piece.ValueRook;
            tmp_board[0, yRook2] = -Piece.ValueRook;
            tmp_board[row - 1, yRook2] = Piece.ValueRook;

            tmp_board[0, yBishop1] = -Piece.ValueBishop;
            tmp_board[row - 1, yBishop1] = Piece.ValueBishop;
            tmp_board[0, yBishop2] = -Piece.ValueBishop;
            tmp_board[row - 1, yBishop2] = Piece.ValueBishop;

            tmp_board[0, yKnight1] = -Piece.ValueKnight;
            tmp_board[row - 1, yKnight1] = Piece.ValueKnight;
            tmp_board[0, yKnight2] = -Piece.ValueKnight;
            tmp_board[row - 1, yKnight2] = Piece.ValueKnight;

            tmp_board[0, yQueen] = -Piece.ValueQueen;
            tmp_board[row - 1, yQueen] = Piece.ValueQueen;

            if (isReverse)
            {
                return getReverseIntBoard(tmp_board, row, col);
            }

            return tmp_board;
        }

        private Piece[,] convertToDetailBoard(int[,] intBoard, string[,] abilities)
        {
            Piece[,] detailBoard = new Piece[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (intBoard[i, j] != 0)
                    {
                        if (intBoard[i, j] == Piece.ValueKing)
                        {
                            King king = new King(i, j, i, j, intBoard[i, j]);
                            if (abilities[i, j][0] == '0')
                            {
                                king.AllowCastleLeft = false;
                            }
                            if (abilities[i, j][1] == '0')
                            {
                                king.AllowCastleRight = false;
                            }
                            detailBoard[i, j] = king;
                        }
                        else if (intBoard[i, j] == Piece.ValuePawn)
                        {
                            Pawn pawn = new Pawn(i, j, i, j, intBoard[i, j]);
                            if (abilities[i, j][0] == '0')
                            {
                                pawn.AllowEnpassantLeft = false;
                            }
                            if (abilities[i, j][1] == '0')
                            {
                                pawn.AllowEnpassantRight = false;
                            }
                            detailBoard[i, j] = pawn;
                        }
                        else
                        {
                            Piece piece = new Piece(i, j, i, j, intBoard[i, j]);
                            detailBoard[i, j] = piece;
                        }
                    }
                }
            }
            return detailBoard;
        }

        public void updateTime(string topTime, string botTime, int timeBonus)
        {
            this.topTime = topTime;
            this.botTime = botTime;
            this.timeBonus = timeBonus;
            if (sendTime != null)
            {
                sendTime(true, TopTime, timeBonus);
                sendTime(false, botTime, timeBonus);
            }
        }

        public void startTimerPlay(bool start)
        {
            StartTimer = start;
            if (start)
            {
                timerPlay.Start();
            }
            else
            {
                timerPlay.Stop();
            }
        }

        public void endGame(string detailEnd, string color)
        {
            currentDetailResult = detailEnd;
            if (detailEnd == EndGame.checkmate)
            {
                playSound(nameSoundCheckmate);
            }
            else
            {
                playSound(nameSoundDraw_Or_Resign);
            }
            freezeBoard();
            timerPlay.Stop();
            IsEnd = true;
            string tmp = EndGame.getScore(detailEnd, color);
            if (tmp != null)
            {
                currentScore = tmp;
                currentResult = EndGame.getResultByScore(currentScore);
                if (sendEndGame != null)
                {
                    sendEndGame(currentScore, currentResult, currentDetailResult);
                }
            }
        }
        public void endGame(string detailEnd, bool isWhitePiece)
        {
            currentDetailResult = detailEnd;
            if (detailEnd == EndGame.checkmate)
            {
                playSound(nameSoundCheckmate);
            }
            else
            {
                playSound(nameSoundDraw_Or_Resign);
            }
            freezeBoard();
            timerPlay.Stop();
            IsEnd = true;
            string tmp = EndGame.getScore(detailEnd, isWhitePiece ? Piece.ColorWhite : Piece.ColorBlack);
            if (tmp != null)
            {
                currentScore = tmp;
                currentResult = EndGame.getResultByScore(currentScore);
                if (sendEndGame != null)
                {
                    sendEndGame(currentScore, currentResult, currentDetailResult);
                }
            }
        }

        public int[,] getStartInt(bool isReverse)
        {
            if (IsReverse == isReverse)
            {
                return convertToInt(historyDetailBoard[0]);
            }
            int[,] tmp = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (historyDetailBoard[0][row - i - 1, col - i - 1] != null)
                    {
                        tmp[i, j] = historyDetailBoard[0][row - i - 1, col - j - 1].Value;
                    }
                    else
                    {
                        tmp[i, j] = Piece.ValueNone;
                    }
                }
            }
            return tmp;
        }

        public string[,] getStartAbilities(bool isReverse)
        {
            if (IsReverse == isReverse)
            {
                return startAbilities;
            }
            return getReverseAbilities(startAbilities, row, col);
        } //--0,0,0,0,0,0,0|0,-1,-2 => 
        public static (int[,], int, int) convertToArrayBoard(string board)
        {
            string[] tmp = board.Split('|');
            int row = tmp.Length;
            int col = tmp[0].Split(',').Length;
            int[,] result = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                string[] cols = tmp[i].Split(',');
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = int.Parse(cols[j]);
                }
            }
            return (result, row, col);
        }
        public static string convertToStrBoard(int[,] board, int row, int col)
        {
            string tmp = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp += board[i, j];
                    if (j != col - 1)
                    {
                        tmp += ",";
                    }
                }
                if (i != row - 1)
                {
                    tmp += "|";
                }
            }
            return tmp;
        }

        public static List<(string, string)> convertToTimeEveryMove(string timeEveryMove)
        {
            List<(string, string)> result = new List<(string, string)>();
            if (!string.IsNullOrEmpty(timeEveryMove))
            {
                string[] splits = timeEveryMove.Split('|');
                for (int i = 0; i < splits.Length; i++)
                {
                    string[] tmp = splits[i].Split(',');
                    result.Add((tmp[0], tmp[1]));
                }
            }
            return result;
        }

        public static string convertToStrTimeEveryMove(List<(string, string)> timeEveryMove)
        {
            string result = "";
            for (int i = 0; i < timeEveryMove.Count; i++)
            {
                result += timeEveryMove[i].Item1 + "," + timeEveryMove[i].Item2;
                if (i != timeEveryMove.Count - 1)
                {
                    result += "|";
                }
            }
            return result;
        }

        //--1,abc,def|2,ada,dad
        public static List<(int, string, string)> convertToListNotation(string notations)
        {
            List<(int, string, string)> result = new List<(int, string, string)>();
            if (string.IsNullOrEmpty(notations))
            {
                return result;
            }
            string[] tmp = notations.Split('|');
            for (int i = 0; i < tmp.Length; i++)
            {
                string[] cols = tmp[i].Split(',');
                result.Add((int.Parse(cols[0]), cols[1], cols[2]));
            }
            return result;
        }
        public static string convertToStrNotation(List<(int, string, string)> notations)
        {
            string tmp = "";
            int count = notations.Count;
            for (int i = 0; i < count; i++)
            {
                tmp += notations[i].Item1 + "," + notations[i].Item2 + "," + notations[i].Item3;
                if (i != count - 1)
                {
                    tmp += "|";
                }
            }
            return tmp;
        }
        public static string[,] convertToArrayAbililies(string abilities)
        {
            string[] tmp = abilities.Split('|');
            int row = tmp.Length;
            int col = tmp[0].Split(',').Length;
            string[,] result = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                string[] cols = tmp[i].Split(',');
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = cols[j];
                }
            }
            return result;
        }
        public static string convertToStrAbilities(string[,] abilities, int row, int col)
        {
            string result = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result += abilities[i, j];
                    if (j != col - 1)
                    {
                        result += ",";
                    }
                }
                if (i != row - 1)
                {
                    result += "|";
                }
            }
            return result;
        }

        public void loadPlayer()
        {
            if (botPlayer1 != null)
            {
                botPlayer1.stop();
            }
            if (botPlayer2 != null)
            {
                botPlayer2.stop();
            }
        }


        public static string[,] getDefaultAbilities(int row, int col)
        {
            string[,] result = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = "1.1.1";
                }
            }
            return result;
        }

        public (int[], int) getStrPieceCapture(bool isWhitePiece)
        {
            int[] count_capture = new int[6];
            if (isWhitePiece)
            {
                for (int i = 0; i < countWhiteCapture.Length; i++)
                {
                    count_capture[i] = countWhiteCapture[i][countWhiteCapture[i].Count - 1];
                }
            }
            else
            {
                for (int i = 0; i < countBlackCapture.Length; i++)
                {
                    count_capture[i] = countBlackCapture[i][countBlackCapture[i].Count - 1];
                }
            }

            int index = indexsWhitePieceCapture.Count - 1;
            int index_capture = -1;
            if (isWhitePiece)
            {
                if (indexsWhitePieceCapture[index] != -1)
                {
                    index_capture = indexsWhitePieceCapture[index];
                }
            }
            else
            {
                if (indexsBlackPieceCapture[index] != -1)
                {
                    index_capture = indexsBlackPieceCapture[index];
                }
            }

            return (count_capture, index_capture);
        }

        //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
        public static (int[,], string[,], int, int, bool, int, int) getSetupBoardByFen(string fen)
        {
            string[] tmp1 = fen.Split('/');
            string[] tmp2 = tmp1[tmp1.Length - 1].Split(' ');
            string endRow = tmp2[0];
            bool startWhite = tmp2[1] == "w" ? true : false;
            string notationEnpassant = null;
            bool whiteKingCastle = false, whiteQueenCastle = false, blackKingCastle = false, blackQueenCastle = false;
            //CountWhites[CountWhites.Count - 1], CountBlacks[CountBlacks.Count - 1], CountMoveOveralls[CountMoveOveralls.Count - 1]
            int countNoPawnNoCapture = -1, countMove = -1;
            for (int i = 2; i < tmp2.Length; i++)
            {
                if (char.ToUpper(tmp2[i][0]) == 'K' || char.ToUpper(tmp2[i][0]) == 'Q')
                {
                    for (int j = 0; j < tmp2[i].Length; j++)
                    {
                        if (tmp2[i][j] == 'K')
                        {
                            blackKingCastle = true;
                        }
                        else if (tmp2[i][j] == 'Q')
                        {
                            blackQueenCastle = true;
                        }
                        else if (tmp2[i][j] == 'k')
                        {
                            whiteKingCastle = true;
                        }
                        else
                        {
                            whiteQueenCastle = true;
                        }
                    }
                }
                else if (char.IsNumber(tmp2[i][0]))
                {
                    if (countNoPawnNoCapture == -1)
                    {
                        countNoPawnNoCapture = int.Parse(tmp2[i]);
                    }
                    else
                    {
                        countMove = int.Parse(tmp2[i]);
                    }
                }
                else if (tmp2[i] != "-")
                {
                    notationEnpassant = tmp2[i];
                }
            }
            int row, col;
            row = tmp1.Length;
            col = 0;
            for (int i = 0; i < tmp1[0].Length; i++)
            {
                if (char.IsDigit(tmp1[0][i]))
                {
                    col += int.Parse(tmp1[0][i].ToString());
                }
                else
                {
                    col++;
                }
            }
            int[,] int_board = new int[row, col];
            string[,] abiblies = new string[row, col];

            for (int i = 0; i < row - 1; i++)
            {
                int j = 0;
                while (j < tmp1[i].Length)
                {
                    if (char.IsDigit(tmp1[i][j]))
                    {
                        int number = int.Parse(tmp1[i][j].ToString());
                        for (int k = j; k < j + number; k++)
                        {
                            int_board[i, j] = Piece.ValueNone;
                            abiblies[i, j] = "1.1.1";
                            j++;
                        }
                    }
                    else
                    {
                        if (tmp1[i][j].ToString() == Piece.FenPawn)
                        {
                            int_board[i, j] = Piece.ValuePawn;
                            abiblies[i, j] = "1.1.1";
                        }
                        else if (tmp1[i][j].ToString() == Piece.FenRook)
                        {
                            int_board[i, j] = Piece.ValueRook;
                            abiblies[i, j] = "1.1.1";
                        }
                        else if (tmp1[i][j].ToString() == Piece.FenKnight)
                        {
                            int_board[i, j] = Piece.ValueKnight;
                            abiblies[i, j] = "1.1.1";
                        }
                        else if (tmp1[i][j].ToString() == Piece.FenBishop)
                        {
                            int_board[i, j] = Piece.ValueBishop;
                            abiblies[i, j] = "1.1.1";
                        }
                        else if (tmp1[i][j].ToString() == Piece.FenQueen)
                        {
                            int_board[i, j] = Piece.ValueQueen;
                            abiblies[i, j] = "1.1.1";
                        }
                        else
                        {
                            int_board[i, j] = Piece.ValueKing;
                            abiblies[i, j] = "1.1.1";
                        }
                        if (char.IsUpper(tmp1[i][j]))
                        {
                            int_board[i, j] = -int_board[i, j];
                        }
                        j++;
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (int_board[i, j] != 0)
                    {
                        bool twoMove = false;
                        if (int_board[i, j] > 0)
                        {
                            if (i == row - 2)
                            {
                                twoMove = true;
                            }
                        }
                        else
                        {
                            if (i == 1)
                            {
                                twoMove = true;
                            }
                        }
                        if (Math.Abs(int_board[i, j]) == Piece.ValuePawn)
                        {
                            bool left = true, right = true;
                            if (int_board[i, j] < 0)
                            {
                                if (i + 1 < col)
                                {
                                    if (j - 1 >= 0 && int_board[i + 1, j - 1] == 0 && int_board[i, j - 1] != 0 && int_board[i, j - 1] == Piece.ValuePawn)
                                    {
                                        if (notationEnpassant == null)
                                        {
                                            left = false;
                                        }
                                    }

                                    if (j + 1 < col && int_board[i - 1, j + 1] == 0 && int_board[i, j + 1] != 0 && int_board[i, j + 1] == Piece.ValuePawn)
                                    {
                                        if (notationEnpassant == null)
                                        {
                                            right = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (i - 1 >= 0)
                                {
                                    if (j - 1 >= 0 && int_board[i - 1, j - 1] == 0 && int_board[i, j - 1] != 0 && int_board[i, j - 1] == -Piece.ValuePawn)
                                    {
                                        if (notationEnpassant == null)
                                        {
                                            left = false;
                                        }
                                    }

                                    if (j + 1 < col && int_board[i + 1, j + 1] == 0 && int_board[i, j + 1] != 0 && int_board[i, j + 1] == -Piece.ValuePawn)
                                    {
                                        if (notationEnpassant == null)
                                        {
                                            right = false;
                                        }
                                    }
                                }
                            }
                            abiblies[i, j] = convertBoolAbilityToStr(left, right, twoMove);
                        }
                        else if (Math.Abs(int_board[i, j]) == Piece.ValueKing)
                        {
                            bool left, right;
                            if (int_board[i, j] < 0)
                            {
                                left = blackQueenCastle;
                                right = blackKingCastle;
                            }
                            else
                            {
                                left = whiteQueenCastle;
                                right = whiteKingCastle;
                            }
                            abiblies[i, j] = convertBoolAbilityToStr(left, right, twoMove);
                        }
                    }
                }
            }

            return (null, null, row, col, startWhite, countNoPawnNoCapture, countMove);
        }

        public void cancelMatch()
        {
            IsEnd = true;
            if (sendMessage != null)
            {
                sendMessage("Ván đấu bị huỷ");
            }
            freezeBoard();
        }

        public static (bool, bool, bool) convertStrAbilityToBool(string ability)
        {
            string[] splits = ability.Split('.');
            bool twoMove;
            if (splits.Length == 2)
            {
                twoMove = true;
            }
            else
            {
                twoMove = splits[2] == "1";
            }
            return (splits[0] == "1", splits[1] == "1", twoMove);
        }

        public static string convertBoolAbilityToStr(bool left, bool right, bool twoMove = true)
        {
            return (left ? "1" : "0") + "." + (right ? "1" : "0") + "." + (twoMove ? "1" : "0");
        }

        public int[,] getCurrentIntBoard(bool isReverse)
        {
            if (IsReverse == isReverse)
            {
                return int_board;
            }
            int[,] tmp = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp[i, j] = int_board[row - i - 1, col - j - 1];
                }
            }
            return tmp;
        }
        public string[,] getCurrentAbilites(bool isReverse)
        {
            if (IsReverse == isReverse)
            {
                return abilities;
            }
            string[,] tmp = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp[i, j] = abilities[row - i - 1, col - j - 1];
                }
            }
            return tmp;
        }

        public bool isWhiteTurn()
        {
            return ColorTurn == Piece.ColorWhite;
        }

        public static string convertListToStrMoves(List<string> moves, List<string> namePromotions)
        {
            string tmp = "";
            for (int i = 0; i < moves.Count; i++)
            {
                tmp += moves[i] + "." + namePromotions[i];
                if (i != moves.Count - 1)
                {
                    tmp += "|";
                }
            }
            return tmp;
        }

        public static string printFile(string nameFile, int indexTypeGame, int indexRegime, int row, int col, string fen, int [,] board, string[,] startAbilities, bool startWhiteTurn, int countNoPawnNoCapture, int countMoveOverall, string result, string detailResult, string notation, List<string> moves, List<string> namePromotions)
        {
            string path;
            if (File.Exists(folderSaveMatches + nameFile + ".txt"))
            {
                int i = 1;
                while (File.Exists(folderSaveMatches + nameFile + "(" + i  + ").txt"))
                {
                    i++;
                }
                path = folderSaveMatches + nameFile + "(" + i + ").txt";
            }
            else
            {
                path = folderSaveMatches + nameFile + ".txt";
            }
            List<string> contents = new List<string>();
            contents.Add(indexTypeGame + "/" + indexRegime);
            contents.Add(fen);
            contents.Add(convertToStrBoard(board, row, col));
            contents.Add( convertToStrAbilities(startAbilities, row, col));
            contents.Add(startWhiteTurn ? "1" : "0");
            contents.Add(countNoPawnNoCapture + "-" + countMoveOverall);
            contents.Add(result + "-" + detailResult);
            contents.Add(convertListToStrMoves(moves, namePromotions));
            contents.Add(notation);
            File.WriteAllLines(path, contents);
            return path;
        }


        public static (int, int, int, int, int[,], string[,], bool, int, int, string, string, string[], string) getInfoBoardByReadFileTxt(string path)
        {
            try
            {
                string[] contents = File.ReadAllLines(path);
                string[] strIndexTypeGameRegime = contents[0].Split('/');
                int indexTypeGame = int.Parse(strIndexTypeGameRegime[0]);
                int indexRegime = int.Parse(strIndexTypeGameRegime[1]);
                var tmp = convertToArrayBoard(contents[2]);
                int[,] intBoard = tmp.Item1;
                int row = tmp.Item2;
                int col = tmp.Item3;
                string[,] abilities = convertToArrayAbililies(contents[3]);
                bool startWhiteTurn = contents[4] == "1";
                string[] strCount = contents[5].Split('-');
                int countNoPawnNoCapture = int.Parse(strCount[0]);
                int countMoveOverall = int.Parse(strCount[1]);
                string[] strResult = contents[6].Split('-');
                string result = strResult[0];
                string detailResult = strResult[1];
                var moveAndNamePromotions = contents[7].Split('|');
                string notations = "";

                int index = 8;
                while (index != contents.Length)
                {
                    notations += contents[index++];
                }
                return (indexTypeGame, indexRegime, row, col, intBoard, abilities, startWhiteTurn, countNoPawnNoCapture, countMoveOverall, result, detailResult, moveAndNamePromotions, notations);
            }
            catch
            {
                return (-1, -1, -1, -1, null, null, false, -1, -1, null, null, null, null);
            }
        }

        //internal void setPreviewChess(int row, int col, int[,] board, Point prevMove, Point desMove, InfoSettingBoard info)
        //{
        //    this.row = row;
        //    this.col = col;
        //    setPieceByInt(board);
        //    paintBoard(info);
        //    freezeBoard();
        //    currentPrevMoved = prevMove;
        //    currentDesMoved = desMove;
        //}

        public (int, int, int[,], Point, Point) getBoardByIndex(int index)
        {
            int[,] intBoard = convertToInt(historyDetailBoard[index]);
            return (row, col, intBoard, lstPrevMoved[index - 1], lstDesMoved[index - 1]);
        }

        public (Point, Point) getLocationByStrMove(string move)
        {
            Point prev = new Point(getLocationNumbersBySign(move[1].ToString(), row, rulerHeight), getLocationAlphasBySign(move[0].ToString(), col, rulerWidth));
            Point des = new Point(getLocationNumbersBySign(move[3].ToString(), row, rulerHeight), getLocationAlphasBySign(move[2].ToString(), col, rulerWidth));
            return (prev, des);
        }
    }
}
