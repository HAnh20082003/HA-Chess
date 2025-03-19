using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    class General
    {
        public static string nameApp = "HA Chess 2023";
        public static string folderImage = "assets/imgs/";
        public static List<Color> colors = getColors();
        private bool isDragging = false;
        private Point dragOffset;
        Form form;
        public static (bool, string) openFileDialog(string title, string filter)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = title,
                Filter = filter,
                Multiselect = false,
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                return (true, open.FileName);
            }
            return (false, null);
        }

        public static List<Color> getColors()
        {
            colors = new List<Color>();
            Array tmp = Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in tmp)
            {
                Color color = Color.FromKnownColor(knowColor);
                colors.Add(color);
            }
            return colors;
        }
        public static (Color, Color) getColorByIndex((int, int) indexColor)
        {
            (Color, Color) colorBoard = (colors[0], colors[0]);
            for (int i = 0; i < colors.Count; i++)
            {
                if (i == indexColor.Item1)
                {
                    colorBoard.Item1 = colors[i];
                }
                if (i == indexColor.Item2)
                {
                    colorBoard.Item2 = colors[i];
                }
            }
            return colorBoard;
        }
        public static (int, int) getIndexByColor((Color, Color) color)
        {
            (int, int) indexColor = (0, 0);
            for (int i = 0; i < colors.Count; i++)
            {
                if (colors[i] == color.Item1)
                {
                    indexColor.Item1 = i;
                }
                if (colors[i] == color.Item2)
                {
                    indexColor.Item2 = i;
                }
            }
            return indexColor;
        }
        public static Color getColorByIndex(int indexColor)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                if (i == indexColor)
                {
                    return colors[i];
                }
            }
            return colors[0];
        }
        public static int getIndexByColor(Color color)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                if (colors[i] == color)
                {
                    return i;
                }
            }
            return 0;
        }

        public static string getDecimal(int number, int count)
        {
            int length = count - number.ToString().Length;
            if (length <= 0)
            {
                return number.ToString();
            }
            string tmp = number.ToString();
            for (int i = 0; i < length; i++)
            {
                tmp = "0" + tmp;
            }
            return tmp;
        }


        public static int converStrTimeToSecond(string time)
        {
            string[] tmp = time.Split(':');
            int hour = int.Parse(tmp[0]);
            int minites = int.Parse(tmp[1]);
            int second = int.Parse(tmp[2]);
            return hour * 60 * 60 + minites * 60 + second;
        }

        public static void addToolTip(Control c, string title)
        {
            ToolTip tt = new ToolTip()
            {
                IsBalloon = false,
            };
            tt.SetToolTip(c, title);
        }

        public static Image getImageByName(string name)
        {
            return Image.FromFile(folderImage + name + ".png");
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragOffset = e.Location;
            }
        }
        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = form.Location;
                newLocation.X += e.X - dragOffset.X;
                newLocation.Y += e.Y - dragOffset.Y;
                form.Location = newLocation;
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        public void addEventMovingForm(Form frm)
        {
            form = frm;
            form.MouseDown += form_MouseDown;
            form.MouseMove += form_MouseMove;
            form.MouseUp += form_MouseUp;
        }
        public void addEventMovingControlForForm(Control c)
        {
            c.MouseDown += form_MouseDown;
            c.MouseMove += form_MouseMove;
            c.MouseUp += form_MouseUp;
        }
        public static void changePanelForm(Panel pn, Form frm)
        {
            pn.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pn.Controls.Add(frm);
            frm.Show();
        }

        public static void addFullMoving(Form form, List<Control> controls)
        {
            General formMoving = new General();
            formMoving.addEventMovingForm(form);
            foreach (Control c in controls)
            {
                formMoving.addEventMovingControlForForm(c);
            }
        }

        public static string formatSizeText(string text, double size)
        {
            int count = 0;
            string rs = "";
            foreach (var ch in text)
            {
                rs += ch;
                count++;
                if (count == size)
                {
                    rs += Environment.NewLine;
                    count = 0;
                }
            }
            return rs;
        }
    }
}
