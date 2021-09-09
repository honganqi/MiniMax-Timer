using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace MiniMaxTimer
{
    public partial class TimerWindow : DraggableForm
    {
        public string locationXPass;
        public string locationYPass;
        public string sizeWidthPass;
        public string sizeHeightPass;
        public Font fontPass;
        public string endTextPass;
        public Color fontColorPass;
        public Color bgColorPass;
        public int selectedscreen;
        private bool timerStatus;
        private System.Windows.Forms.Timer timer1;

        public TimerWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private int hours;
        private int minutes;
        private int seconds;
        private string hoursString;
        private string minutesString;
        private string secondsString;

        private void TimerWindow_FormLoad(object sender, EventArgs e)
        {
            timerDisplay.Font = fontPass;
            timerDisplay.ForeColor = fontColorPass;
            this.BackColor = bgColorPass;
            this.Location = new Point(int.Parse(locationXPass), int.Parse(locationYPass));
            this.Size = new Size(int.Parse(sizeWidthPass), int.Parse(sizeHeightPass));
            timerInitialize();
            timerStart();
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                seconds--;
                secondsString = seconds.ToString("00");
            }
            else
            {
                if (minutes > 0)
                {
                    minutes--;
                    seconds = 59;
                    minutesString = minutes.ToString("00") + ":";
                    secondsString = seconds.ToString("00");
                }
                else
                {
                    if (hours > 0)
                    {
                        hours--;
                        minutes = 59;
                        seconds = 59;
                        hoursString = hours.ToString("00") + ":";
                        minutesString = minutes.ToString("00") + ":";
                        secondsString = seconds.ToString("00");

                    }
                    else
                    {
                        timer1.Stop();
                        if (endTextPass != "")
                            secondsString = endTextPass;
                    }
                }
            }
            timerDisplay.Text = hoursString + minutesString + secondsString;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MainWindow mainwindow = new MainWindow();
                mainwindow.UpdateValues(this.Size.Width.ToString(), this.Size.Height.ToString(), this.Location.X.ToString(), this.Location.Y.ToString(), false);
                this.Close();
            }
        }

        private void timerStart()
        {
            timer1.Start();
            timerStatus = true;

        }

        private void timerDisplay_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (timerStatus == false)
                {
                    timerStart();
                }
                else
                {
                    timer1.Stop();
                    timerStatus = false;
                }
            } else
            {
                timer1.Stop();
                timerStatus = false;
                timerInitialize();
            }
        }

        private void timerDisplay_DoubleClick(object sender, EventArgs e)
        {
            timer1.Stop();
            timerInitialize();
            timerStart();
        }

        private void timerInitialize()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second

            hours = Properties.Settings.Default.hours;
            minutes = Properties.Settings.Default.minutes;
            seconds = Properties.Settings.Default.seconds;

            if (hours > 0)
            {
                hoursString = hours.ToString("00") + ":";
            }
            else
            {
                hoursString = "";
            }
            if (minutes > 0)
            {
                minutesString = minutes.ToString("00") + ":";
            }
            else
            {
                minutesString = "";
            }
            if ((seconds > 0) || ((seconds == 0) && ((minutes > 0) || (hours > 0))))
            {
                secondsString = seconds.ToString("00");
            }
            else
            {
                secondsString = "";
            }
            timerDisplay.Text = hoursString + minutesString + secondsString;
        }
    }
}
