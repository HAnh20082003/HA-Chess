using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    public class BotChess
    {
        public static int defaultTimeThinking = 1000;
        public delegate void SendBestMove(string bestMove, bool recommendMove);
        public SendBestMove sendBestMove;
        private static string folderEngine = "assets/engines/";
        public static string nameStockfish15_1 = "Stockfish 15.1";
        public static string nameStockfish16 = "Stockfish 16";
        public static string nameKomodo14_1 = "Komodo 14.1";
        public static string nameFire8_2 = "Fire 8.2";
        public static string nameEthereal8_2 = "Ethereal 13";

        public static string levelEasy = "Tập sự", levelMedium = "Tiến bộ", levelHard = "Trưởng thành", levelExpert = "Kiểm soát", levelEvil = "Vươn tầm";

        private static string fileNameStockfish15_1 = folderEngine + "Stockfish 15.1/Stockfish 15.1.exe";
        private static string fileNameStockfish16 = folderEngine + "Stockfish 16/Stockfish 16.exe";
        private static string fileNameKomodo14_1 = folderEngine + "Komodo 14.1/Komodo 14.1.exe";
        private static string fileNameFire8_2 = folderEngine + "Fire 8.2/Fire 8.2.exe";
        private static string Ethereal13 = folderEngine + "Fire 8.2/Ethereal 13.exe";

        private static int eloStockfish15_1 = 4000;
        private static int eloStockfish16 = 4050;
        private static int eloKomodo14_1 = 3461;
        private static int eloFire8_2 = 3300;

        private Image avatar;

        private string fileName;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private string nameBot;
        private string colorPieces;
        private static string pathImgKomodo = folderEngine + "imgs/Komodo.png";
        private static string pathImgStockfish = folderEngine + "imgs/Stockfish.png";
        private static string pathImgFire = folderEngine + "imgs/Fire.png";
        private static string pathImgEthereal = folderEngine + "imgs/Ethereal.png";
        private static string folderBotPlayers = folderEngine + "bot players/";
        public static string[] nameBotPlayers;
        public static int[] eloBotPlayers;
        public static string[] pathImgBotPlayers;
        public static int[] levelBotPlayers;
        private int elo;
        private string bestmove;
        private bool found = false;
        private bool isRecommend;
        private Thread thread;
        public int level = -1;
        public int depth;
        public int time = 1;
        public Process cmd;

        public System.Windows.Forms.Timer Timer { get => timer; set => timer = value; }
        public string NameBot { get => nameBot; set => nameBot = value; }
        public string ColorPieces { get => colorPieces; set => colorPieces = value; }
        public int Elo { get => elo; set => elo = value; }
        public static string FileNameKomodo14_1 { get => fileNameKomodo14_1; set => fileNameKomodo14_1 = value; }
        public static int EloKomodo14_1 { get => eloKomodo14_1; set => eloKomodo14_1 = value; }
        public static string FileNameStockfish15_1 { get => fileNameStockfish15_1; set => fileNameStockfish15_1 = value; }
        public static string FileNameStockfish16 { get => fileNameStockfish16; set => fileNameStockfish16 = value; }
        public static string PathImgStockfish { get => pathImgStockfish; set => pathImgStockfish = value; }
        public static int EloStockfish15_1 { get => eloStockfish15_1; set => eloStockfish15_1 = value; }
        public static int EloStockfish16 { get => eloStockfish16; set => eloStockfish16 = value; }
        public Image Avatar { get => avatar; set => avatar = value; }
        public static string[] listBots = { nameStockfish16, nameStockfish15_1, nameKomodo14_1 };

        public BotChess()
        {
            nameBot = null;
        }

        public BotChess(string nameBot, bool isWhitePlayer, bool isRecommend, int level)
        {
            this.nameBot = nameBot;
            this.isRecommend = isRecommend;
            avatar = getAvatarBot(nameBot);
            elo = getEloBot(nameBot);
            if (NameBot == nameStockfish15_1)
            {
                fileName = fileNameStockfish15_1;
            }
            else if (NameBot == nameStockfish16)
            {
                fileName = fileNameStockfish16;
            }
            else if (NameBot == nameFire8_2)
            {
                fileName = fileNameFire8_2;
            }
            else if (nameBot == nameEthereal8_2)
            {
                fileName = Ethereal13;
            }
            else
            {
                fileName = fileNameKomodo14_1;
            }
            this.level = level;
            colorPieces = isWhitePlayer ? Piece.ColorWhite : Piece.ColorBlack;
            Timer.Tick += timerSendMove;
        }

        public BotChess(string nameBot, Image avatar, int elo, int level, string fileName, int depth)
        {
            this.nameBot = nameBot;
            this.avatar = avatar;
            this.elo = elo;
            this.fileName = fileName;
            this.level = level;
            this.depth = depth;
            Timer.Tick += timerSendMove;
        }
        public BotChess(string nameBot, Image avatar, int elo, int level, string fileName, int depth, int time)
        {
            this.nameBot = nameBot;
            this.avatar = avatar;
            this.elo = elo;
            this.fileName = fileName;
            this.level = level;
            this.depth = depth;
            this.time = time;
            Timer.Tick += timerSendMove;
        }

        public BotChess(string nameBot, bool isWhitePlayer, bool isRecommend)
        {
            this.nameBot = nameBot;
            this.isRecommend = isRecommend;
            avatar = getAvatarBot(nameBot);
            elo = getEloBot(nameBot);
            if (NameBot == nameStockfish15_1)
            {
                fileName = fileNameStockfish15_1;
            }
            else if (NameBot == nameStockfish16)
            {
                fileName = fileNameStockfish16;
            }
            else if (NameBot == nameFire8_2)
            {
                fileName = fileNameFire8_2;
            }
            else
            {
                fileName = fileNameKomodo14_1;
            }
            colorPieces = isWhitePlayer ? Piece.ColorWhite : Piece.ColorBlack;
            Timer.Tick += timerSendMove;
        }

        public BotChess(string nameBot, bool isRecommend = false)
        {
            this.nameBot = nameBot;
            this.isRecommend = isRecommend;
            avatar = getAvatarBot(nameBot);
            elo = getEloBot(nameBot);
            if (NameBot == nameStockfish15_1)
            {
                fileName = fileNameStockfish15_1;
            }
            else if (NameBot == nameStockfish16)
            {
                fileName = fileNameStockfish16;
            }
            else if (NameBot == nameFire8_2)
            {
                fileName = fileNameFire8_2;
            }
            else
            {
                fileName = fileNameKomodo14_1;
            }
            Timer.Tick += timerSendMove;
        }

        public static Image getAvatarBot(string nameBot)
        {
            if (nameBot == nameStockfish15_1)
            {
                return getAvatarStockfish();
            }
            if (nameBot == nameStockfish16)
            {
                return getAvatarStockfish();
            }
            if (nameBot == nameFire8_2)
            {
                return getAvatarFire();
            }
            if (nameBot == nameEthereal8_2)
            {
                return getAvatarEthereal();
            }
            return getAvatarKomodo();
        }
        public static int getEloBot(string nameBot)
        {
            if (nameBot == nameStockfish15_1)
            {
                return eloStockfish15_1;
            }
            if (nameBot == nameStockfish16)
            {
                return eloStockfish16;
            }
            if (nameBot == nameFire8_2)
            {
                return eloFire8_2;
            }
            return eloKomodo14_1;
        }

        public void update(string nameBot, int level)
        {
            NameBot = nameBot;
            if (NameBot == nameStockfish15_1)
            {
                fileName = fileNameStockfish15_1;
            }
            else if (NameBot == nameStockfish16)
            {
                fileName = fileNameStockfish16;
            }
            else if (NameBot == nameFire8_2)
            {
                fileName = fileNameFire8_2;
            }
            else
            {
                fileName = fileNameKomodo14_1;
            }
            avatar = getAvatarBot(nameBot);
            elo = getEloBot(nameBot);
            this.level = level;
            stop();
        }
        public void update(string nameBot)
        {
            update(nameBot, -1);
        }

        public void stop()
        {
            found = false;
            timer.Stop();
            if (thread != null)
            {
                thread.Abort();
            }
        }
        public static BotChess getBotChess(string nameBot, bool isWhitePlayer)
        {
            return new BotChess(nameBot, isWhitePlayer, false);
        }
        public static BotChess getBotChess(string nameBot, bool isWhitePlayer, int level)
        {
            return new BotChess(nameBot, isWhitePlayer, false, level);
        }
        public static BotChess getBotRecommendChess(string nameBot)
        {
            return new BotChess(nameBot, true);
        }
        public static Image getAvatarKomodo()
        {
            return Image.FromFile(pathImgKomodo);
        }
        public static Image getAvatarFire()
        {
            return Image.FromFile(pathImgFire);
        }
        public static Image getAvatarStockfish()
        {
            return Image.FromFile(pathImgStockfish);
        }
        public static Image getAvatarEthereal()
        {
            return Image.FromFile(pathImgEthereal);
        }

        public static void readFileBotPlayers()
        {
            string[] contents = File.ReadAllLines(folderBotPlayers + "Bot Players.txt");
            int length = contents.Length;
            nameBotPlayers = new string[length];
            eloBotPlayers = new int[length];
            levelBotPlayers = new int[length];
            pathImgBotPlayers = new string[length];
            for (int i = 0; i < contents.Length; i++)
            {
                string[] files = Directory.GetFiles(folderBotPlayers + contents[i] + "/");
                foreach (string path in files)
                {
                    if (path.Contains(".png"))
                    {
                        pathImgBotPlayers[i] = path;
                    }
                    else if (path.Contains(".txt"))
                    {
                        string[] content = File.ReadAllLines(path);
                        nameBotPlayers[i] = content[0].Substring(content[0].IndexOf(':') + 2);
                        eloBotPlayers[i] = int.Parse(content[1].Substring(content[1].IndexOf(':') + 2));
                        levelBotPlayers[i] = int.Parse(content[2].Substring(content[2].IndexOf(':') + 2));
                    }
                }
            }
        }

        public static Image getAvatarBotPlayer(int index)
        {
            return Image.FromFile(pathImgBotPlayers[index]);
        }
        public void startFindMove(string currentFen)
        {
            stop();
            thread = new Thread(() => {

                cmd = new Process();

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = fileName;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;

                cmd.StartInfo = startInfo;
                cmd.Start();
                if (level != -1)
                {
                    cmd.StandardInput.WriteLine("setoption name Skill Level value " + level);
                }
                cmd.StandardInput.WriteLine("position fen " + currentFen);
                cmd.StandardInput.WriteLine("go movetime " + time + " depth " + depth);
                string outputLine = "";
                while (outputLine == null || !outputLine.Contains("bestmove"))
                {
                    outputLine = cmd.StandardOutput.ReadLine();
                }
                bestmove = getBestMove(outputLine);
                found = true;
            });
            thread.IsBackground = true;
            thread.Start();
            timer.Start();
        }

        public void setUpTime(int indexName)
        {
            if (indexName == 0)
            {
                time = 3000;
            }
            else if (indexName == 1)
            {
                time = 2500;
            }
            else if (indexName == 2)
            {
                time = 1500;
            }
            else
            {
                time = 1000;
            }
        }

        private void timerSendMove(object sender, EventArgs e)
        {
            if (found)
            {
                timer.Stop();
                sendBestMove(bestmove, isRecommend);
            }
        }

        public string getBestMove(string text)
        {
            string[] tmp = text.Split(' ');
            return tmp[1];
        }

        public static List<int> getIndexsBotLevel(string level)
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < nameBotPlayers.Length; i++)
            {
                if (level == levelEasy)
                {
                    if (levelBotPlayers[i] >= 0 && levelBotPlayers[i] <= 3)
                    {
                        indexs.Add(i);
                    }
                }
                else if (level == levelMedium)
                {
                    if (levelBotPlayers[i] >= 4 && levelBotPlayers[i] <= 7)
                    {
                        indexs.Add(i);
                    }
                }
                else if (level == levelHard)
                {
                    if (levelBotPlayers[i] >= 8 && levelBotPlayers[i] <= 11)
                    {
                        indexs.Add(i);
                    }
                }
                else if (level == levelExpert)
                {
                    if (levelBotPlayers[i] >= 12 && levelBotPlayers[i] <= 15)
                    {
                        indexs.Add(i);
                    }
                }
                else if (level == levelExpert)
                {
                    if (levelBotPlayers[i] >= 12 && levelBotPlayers[i] <= 15)
                    {
                        indexs.Add(i);
                    }
                }
                else
                {
                    if (levelBotPlayers[i] >= 16)
                    {
                        indexs.Add(i);
                    }
                }
            }
            return indexs;
        }

        public static List<BotChess> getAllBots()
        {
            string[] listNamebots = File.ReadAllLines(folderBotPlayers + "Bot Players.txt");
            List<BotChess> bots = new List<BotChess>();
            for (int i = 0; i < listNamebots.Length; i++)
            {
                string[] infos = File.ReadAllLines(folderBotPlayers + listNamebots[i] + "/Info.txt");
                int j = 0;
                string name = infos[j].Substring(infos[j].IndexOf(':') + 2);
                j++;
                int elo = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                j++;
                int level = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                j++;
                string fileName = infos[j].Substring(infos[j].IndexOf(':') + 2);
                j++;
                int depth = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                bots.Add(new BotChess(name, Image.FromFile(folderBotPlayers + listNamebots[i] + "/Avatar.png"), elo, level, fileName, depth));
            }
            return bots;
        }
        public static List<BotChess> getBotChess(int startIndex, int endIndex, string keyword)
        {
            string[] listNamebots = File.ReadAllLines(folderBotPlayers + "Bot Players.txt");
            List<BotChess> bots = new List<BotChess>();
            if (string.IsNullOrEmpty(keyword))
            {
                for (int i = startIndex; i <= (listNamebots.Length <= endIndex ? listNamebots.Length - 1 : endIndex); i++)
                {
                    string[] infos = File.ReadAllLines(folderBotPlayers + listNamebots[i] + "/Info.txt");
                    int j = 0;
                    string name = infos[j].Substring(infos[j].IndexOf(':') + 2);
                    j++;
                    int elo = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                    j++;
                    int level = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                    j++;
                    string fileName = infos[j].Substring(infos[j].IndexOf(':') + 2);
                    j++;
                    int depth = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                    bots.Add(new BotChess(name, Image.FromFile(folderBotPlayers + listNamebots[i] + "/Avatar.png"), elo, level, fileName, depth));
                }
            }
            else
            {
                listNamebots = listNamebots.Where(n => n.Contains(keyword)).ToArray();
                for (int i = 0; i <= (listNamebots.Length <= endIndex ? listNamebots.Length - 1 : endIndex); i++)
                {
                    string[] infos = File.ReadAllLines(folderBotPlayers + listNamebots[i] + "/Info.txt");
                    int j = 0;
                    string name = infos[j].Substring(infos[j].IndexOf(':') + 2);
                    j++;
                    int elo = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                    j++;
                    int level = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                    j++;
                    string fileName = infos[j].Substring(infos[j].IndexOf(':') + 2);
                    j++;
                    int depth = int.Parse(infos[j].Substring(infos[j].IndexOf(':') + 2));
                    bots.Add(new BotChess(name, Image.FromFile(folderBotPlayers + listNamebots[i] + "/Avatar.png"), elo, level, fileName, depth));
                }
            }
            return bots;
        }

        public static int getCountBotChess(string keyword)
        {
            string[] listNamebots = File.ReadAllLines(folderBotPlayers + "Bot Players.txt");
            List<BotChess> bots = new List<BotChess>();
            if (string.IsNullOrEmpty(keyword))
            {
                return listNamebots.Length;
            }
            return listNamebots.Where(n => n.Contains(keyword)).Count();
        }
        public BotChess getCoppy()
        {
            return new BotChess(nameBot, avatar, elo, level, fileName, depth, time);
        }
    }
}
