using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace HAChess_BetterAtChess
{
    class InfoSettingBoard
    {
        public static List<InfoSettingBoard> typeBoards = new List<InfoSettingBoard>() {
            new InfoSettingBoard("Mặc định", 163, 60, 91, 119, 46, 85, 165, 36, 1),

            new InfoSettingBoard("Tự chọn", 163, 60, 91, 119, 46, 85, 165, 36, 1),
        };

        public static string fileSetting = "assets/config/board.txt";
        public string name;
        public int indexColorLight, indexColorDark, indexColorSelectPiece, indexColorRecomendMove, indexColorRecommendCapture, indexColorPrevMoved, indexColorDesMoved, indexColorHint;

        public Color colorLight, colorDark, colorSelectPiece, colorRecommendMove, colorRecommendCapture, colorPrevMoved, colorDesMoved, colorHint;

        public int typePiece;
        
        public InfoSettingBoard(string name, int indexColorLight, int indexColorDark, int indexColorSelectPiece, int indexColorRecomendMove, int indexColorRecommendCapture, int indexColorPrevMoved, int indexColorDesMoved, int indexColorHint, int typePiece)
        {
            this.name = name;
            this.indexColorLight = indexColorLight;
            this.indexColorDark = indexColorDark;
            this.indexColorSelectPiece = indexColorSelectPiece;
            this.indexColorRecomendMove = indexColorRecomendMove;
            this.indexColorRecommendCapture = indexColorRecommendCapture;
            this.indexColorPrevMoved = indexColorPrevMoved;
            this.indexColorDesMoved = indexColorDesMoved;
            this.indexColorHint = indexColorHint;
            this.typePiece = typePiece;
            colorLight = General.getColorByIndex(indexColorLight);
            colorDark = General.getColorByIndex(indexColorDark);
            colorSelectPiece = General.getColorByIndex(indexColorSelectPiece);
            colorRecommendMove = General.getColorByIndex(indexColorRecomendMove);
            colorRecommendCapture = General.getColorByIndex(indexColorRecommendCapture);
            colorPrevMoved = General.getColorByIndex(indexColorPrevMoved);
            colorDesMoved = General.getColorByIndex(indexColorDesMoved);
            colorHint = General.getColorByIndex(indexColorHint);
        }

        public InfoSettingBoard(string name, Color colorLight, Color colorDark, Color colorSelectPiece, Color colorRecommendMove, Color colorRecommendCapture, Color colorPrevMoved, Color colorDesMoved, Color colorHint, int typePiece)
        {
            this.name = name;
            this.colorLight = colorLight;
            this.colorDark = colorDark;
            this.colorSelectPiece = colorSelectPiece;
            this.colorRecommendMove = colorRecommendMove;
            this.colorRecommendCapture = colorRecommendCapture;
            this.colorPrevMoved = colorPrevMoved;
            this.colorDesMoved = colorDesMoved;
            this.colorHint = colorHint;
            this.typePiece = typePiece;
            indexColorLight = General.getIndexByColor(colorLight);
            indexColorDark = General.getIndexByColor(colorDark);
            indexColorSelectPiece = General.getIndexByColor(colorSelectPiece);
            indexColorRecomendMove = General.getIndexByColor(colorRecommendMove);
            indexColorRecommendCapture = General.getIndexByColor(colorRecommendCapture);
            indexColorPrevMoved = General.getIndexByColor(colorPrevMoved);
            indexColorDesMoved = General.getIndexByColor(colorDesMoved);
            indexColorHint = General.getIndexByColor(colorHint);
        }

        public InfoSettingBoard getCoppy()
        {
            return new InfoSettingBoard(name, indexColorLight, indexColorDark, indexColorSelectPiece, indexColorRecomendMove, indexColorRecommendCapture, indexColorPrevMoved, indexColorDesMoved, indexColorHint, typePiece);
        }

        public static InfoSettingBoard getInfoSetting()
        {
            if (File.Exists(fileSetting))
            {
                string[] contents = File.ReadAllLines(fileSetting);
                int i = 0;
                int indexTypeBoard = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorLight = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorDark = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorSelectPiece = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorRecomendMove = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorRecommendCapture = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorPrevMoved = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorDesMoved = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int indexColorHint = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                i++;
                int typePiece = int.Parse(contents[i].Substring(contents[i].IndexOf(':') + 2));
                return new InfoSettingBoard(typeBoards[indexTypeBoard].name, indexColorLight, indexColorDark, indexColorSelectPiece, indexColorRecomendMove, indexColorRecommendCapture, indexColorPrevMoved, indexColorDesMoved, indexColorHint, typePiece);
            }
            return typeBoards[0].getCoppy();
        }

        public static int getIndexOfTypeBoards(string name)
        {
            return typeBoards.IndexOf(typeBoards.SingleOrDefault(n => n.name == name));
        }


        public void saveChanges()
        {
            List<string> content = new List<string>();
            content.Add("Vị trí loại bàn cờ: " + getIndexOfTypeBoards(name));
            content.Add("Vị trí màu ô sáng: " + indexColorLight);
            content.Add("Vị trí màu ô tối: " + indexColorDark);
            content.Add("Vị trí màu chọn quân: " + indexColorSelectPiece);
            content.Add("Vị trí màu gợi ý di chuyển: " + indexColorRecomendMove);
            content.Add("Vị trí màu gợi ý ăn quân: " + indexColorRecommendCapture);
            content.Add("Vị trí màu nước trước: " + indexColorPrevMoved);
            content.Add("Vị trí màu nước đến: " + indexColorDesMoved);
            content.Add("Vị trí màu ô gợi ý nước đi: " + indexColorHint);
            content.Add("Kiểu quân cờ: " + typePiece);
            //content.Add("Lật ngược: " + (isReverse ? "1" : "0"));
            //content.Add("Index thể loại chơi: " + indexTypeGame);
            //content.Add("Index chế độ chơi: " + indexRegime);
            //content.Add("Tên file lưu biên bản: " + nameFile);
            //content.Add("Vị trí lưu file biên bản: " + location);
            //content.Add("Tên lưu player 1: " + namePlayer1);
            //content.Add("Tên lưu player 2: " + namePlayer2);
            //content.Add("Bàn cờ: " + board);
            //content.Add("Khả năng: " + abilities);
            //content.Add("Quân trắng đi trước: " + (startWhiteTurn ? "1" : "0"));
            //content.Add("Số nước đi không tốt và không ăn quân: " + countNoPawnNoCapture);
            //content.Add("Số nước đi tổng quát: " + countMoveOverall);
            //content.Add("Bật đếm thời gian: " + (startTimer ? "1" : "0"));
            //content.Add("Tab: " + selectTab);
            //content.Add("Toàn màn hình: " + (fullScreen ? "1" : "0"));
            File.WriteAllLines(fileSetting, content);
        }

        public void changeSettingColor(string name, int indexColorLight, int indexColorDark, int indexColorSelectPiece, int indexColorRecomendMove, int indexColorRecommendCapture, int indexColorPrevMoved, int indexColorDesMoved, int indexColorHint, int typePiece)
        {
            this.name = name;
            this.indexColorLight = indexColorLight;
            this.indexColorDark = indexColorDark;
            this.indexColorSelectPiece = indexColorSelectPiece;
            this.indexColorRecomendMove = indexColorRecomendMove;
            this.indexColorRecommendCapture = indexColorRecommendCapture;
            this.indexColorPrevMoved = indexColorPrevMoved;
            this.indexColorDesMoved = indexColorDesMoved;
            this.indexColorHint = indexColorHint;
            this.typePiece = typePiece;
            saveChanges();
        }
        //public void changeSettingRegime(int indexTypeGame, int indexRegime, string board, string abilities, bool startWhiteTurn, int countNoPawnNoCapture, int countMoveOverall)
        //{
        //    this.indexTypeGame = indexTypeGame;
        //    this.indexRegime = indexRegime;
        //    this.board = board;
        //    this.abilities = abilities;
        //    this.startWhiteTurn = startWhiteTurn;
        //    this.countNoPawnNoCapture = countNoPawnNoCapture;
        //    this.countMoveOverall = countMoveOverall;
        //    saveChanges();
        //}

        //public void changeSettingReverse(bool isReverse)
        //{
        //    this.isReverse = isReverse;

        //    saveChanges();
        //}
        //public void changeSettingTimer(bool startTimer)
        //{
        //    this.startTimer = startTimer;

        //    saveChanges();
        //}
        //public void changeSelectTab(int selectTab)
        //{
        //    this.selectTab = selectTab;
        //    saveChanges();
        //}
        //public void changeNameFileAndLocation(string nameFile, string location, string namePlayer1, string namePlayer2)
        //{
        //    this.nameFile = nameFile;
        //    this.location = location;
        //    this.namePlayer1 = namePlayer1;
        //    this.namePlayer2 = namePlayer2;
        //    saveChanges();
        //}

        //public void changeFullScreen(bool fullScreen)
        //{
        //    this.fullScreen = fullScreen;
        //    saveChanges();
        //}
    }
}
