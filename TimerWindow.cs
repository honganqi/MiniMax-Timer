using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMaxTimer
{
    public partial class TimerWindow : DraggableForm
    {
        MainWindow mainwindow;
        public int selectedscreen;
        public Timer timer1;

        public string locationX;
        public string locationY;
        public string width;
        public string height;
        public Font selectedFont;
        public Font pauseFont;
        public Font endFont;
        public Color fontColor;
        public Color bgColor;
        public string endText;

        public TimerWindow(MainWindow _mainwindow)
        {
            InitializeComponent();
            mainwindow = _mainwindow;
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true
                );
        }

        private void TimerWindow_FormLoad(object sender, EventArgs e)
        {
            timerDisplay.Font = selectedFont;
            timerDisplay.ForeColor = fontColor;
            BackColor = bgColor;
            Location = new Point(int.Parse(locationX), int.Parse(locationY));
            Size = new Size(int.Parse(width), int.Parse(height));
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void TimerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainwindow.timerClass.TimerStop();
            mainwindow.labelTimer.Hide();
            mainwindow.labelActive.Hide();
            mainwindow.btnCloseTimer.Hide();
            mainwindow.btnRestart.Hide();
        }

        private void timerDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mainwindow.txtXPos.Text = Location.X.ToString();
                mainwindow.txtYPos.Text = Location.Y.ToString();
            }
        }

        public void TimerEnd()
        {
            timerDisplay.Text = endText;
        }

        public void UpdateDisplay(Font font, Color color, Color bgcolor, string newtime = null)
        {
            timerDisplay.Font = font;
            timerDisplay.ForeColor = color;
            timerDisplay.BackColor = bgcolor;
            if (newtime != null)
            {
                timerDisplay.Text = newtime;
            }
        }
    }
}
