using System.Drawing;
using System.Windows.Forms;

namespace HAChess_BetterAtChess
{
    class PagedList
    {
        public delegate void SendPageNumber(int pageNumber);
        public SendPageNumber sendPageNumber;
        public int countPages;
        private int maxPagesShow;
        private int maxItem1Page;
        private Button[] btnPages;
        private Panel pnPages;
        private Size sizePage;
        private int farPage = 10;
        private int currentBar = 1;
        private Color backColorSelect, foreColorSelect;
        private Color backColorUnSelect, foreColorUnSelect;
        public int currentPageNumber;
        public int countItem;
        public PagedList(Panel pnPages, int countPages, int maxItem1Page, int maxPagesShow, Color backColorSelect, Color foreColorSelect, Color backColorUnSelect, Color foreColorUnSelect)
        {
            this.pnPages = pnPages;
            this.maxItem1Page = maxItem1Page;
            this.maxPagesShow = maxPagesShow;
            this.backColorSelect = backColorSelect;
            this.foreColorSelect = foreColorSelect;
            this.backColorUnSelect = backColorUnSelect;
            this.foreColorUnSelect = foreColorUnSelect;
            initPagedList(countPages);
        }
        public PagedList(Panel pnPages, int maxItem1Page, int maxPagesShow, Color backColorSelect, Color foreColorSelect, Color backColorUnSelect, Color foreColorUnSelect)
        {
            this.pnPages = pnPages;
            this.maxItem1Page = maxItem1Page;
            this.maxPagesShow = maxPagesShow;
            this.backColorSelect = backColorSelect;
            this.foreColorSelect = foreColorSelect;
            this.backColorUnSelect = backColorUnSelect;
            this.foreColorUnSelect = foreColorUnSelect;
        }

        public void initPagedList(int count, int first = -1)
        {
            countItem = count;
            countPages = ((count - 1) / maxItem1Page) + 1;
            btnPages = new Button[countPages];
            sizePage = new Size((pnPages.Width - farPage * (maxPagesShow + 1)) / maxPagesShow, pnPages.Height - farPage * 2);
            for (int i = 0; i < countPages; i++)
            {
                btnPages[i] = new Button()
                {
                    Size = sizePage,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = backColorUnSelect,
                    ForeColor = foreColorUnSelect,
                    Text = (i + 1).ToString(),
                    Cursor = Cursors.Hand,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                };
                btnPages[i].MouseClick += selectPage;
            }
            if (first != -1 && countPages != 0)
            {
                if (first > countPages)
                {
                    if (first == 1)
                    {
                        changeCurrentBar();
                        currentPageNumber = 1;
                    }
                    else
                    {
                        first--;
                        changeCurrentBar((first - 1) / maxPagesShow + 1);
                        currentBar = first;
                        btnPages[first - 1].BackColor = backColorSelect;
                        btnPages[first - 1].ForeColor = foreColorSelect;
                        currentPageNumber = first;
                    }
                }
                else
                {
                    changeCurrentBar((first - 1) / maxPagesShow + 1);
                    currentBar = first;
                    btnPages[first - 1].BackColor = backColorSelect;
                    btnPages[first - 1].ForeColor = foreColorSelect;
                    currentPageNumber = first;
                }
            }
            else
            {
                changeCurrentBar();
                currentPageNumber = 1;
            }
        }

        public void changeCurrentBar(int barNumber = 1)
        {
            if (barNumber < 1 || countPages < barNumber)
            {
                return;
            }

            pnPages.Controls.Clear();
            int startIndex = (barNumber - 1) * maxPagesShow;

            Point location = new Point(pnPages.Width / 2 - (sizePage.Width * maxPagesShow + farPage * (maxPagesShow - 1)) / 2, pnPages.Height / 2 - sizePage.Height / 2);
            int max = startIndex + maxPagesShow;
            if (max > countPages)
            {
                max = countPages;
            }
            for (int i = startIndex; i < max; i++)
            {
                btnPages[i].Location = location;
                pnPages.Controls.Add(btnPages[i]);
                location.X += sizePage.Width + farPage;
            }
            currentBar = barNumber;
            clearSelectPage();
        }

        public void clearSelectPage()
        {
            int start = (currentBar - 1) * maxPagesShow;
            int count = start + maxPagesShow;
            if (count > countPages)
            {
                count = countPages;
            }
            for (int i = start; i < count; i++)
            {
                btnPages[i].BackColor = backColorUnSelect;
                btnPages[i].ForeColor = foreColorUnSelect;
            }
        }

        public void selectPage(int pageNumber)
        {
            if (pageNumber > countPages)
            {
                return;
            }
            int tmp;
            if (pageNumber % maxPagesShow == 0)
            {
                tmp = pageNumber / maxPagesShow;
            }
            else
            {
                tmp = pageNumber / maxPagesShow + 1;
            }
            if (currentBar != tmp)
            {
                changeCurrentBar(tmp);
            }
            else
            {
                clearSelectPage();
            }
            btnPages[pageNumber - 1].BackColor = backColorSelect;
            btnPages[pageNumber - 1].ForeColor = foreColorSelect;
            currentPageNumber = pageNumber;
            if (sendPageNumber != null)
            {
                sendPageNumber(currentPageNumber);
            }
        }

        private void selectPage(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int pageNumber = int.Parse(((Control)sender).Text);
            if (pageNumber == currentPageNumber)
            {
                return;
            }
            selectPage(pageNumber);
        }

        public void prevPage()
        {
            if (countPages == 1)
            {
                return;
            }
            if (currentPageNumber == 1)
            {
                selectPage(countPages);
            }
            else
            {
                selectPage(currentPageNumber - 1);
            }
        }
        public void nextPage()
        {
            if (countPages == 1)
            {
                return;
            }
            if (currentPageNumber == countPages)
            {
                selectPage(1);
            }
            else
            {
                selectPage(currentPageNumber + 1);
            }
        }

        public void startPage()
        {
            if (currentPageNumber == 1)
            {
                return;
            }
            selectPage(1);
        }

        public void lastPage()
        {
            if (currentPageNumber == countPages)
            {
                return;
            }
            selectPage(countPages);
        }
    }
}
