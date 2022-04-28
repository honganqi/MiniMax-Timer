using System;
using System.Windows.Forms;

namespace MiniMaxTimer
{
    public class TimerClass
    {
        long totaltime = 0;
        public int hours = 0;
        public int minutes = 0;
        public int seconds = 0;
        public int milliseconds = 0;
        public string hoursString;
        public string minutesString;
        public string secondsString;
        public string millisecondsString;
        public bool timerStatus;
        public bool secondsOnStart = false;
        public bool minutesOnStart = false;
        public bool hoursOnStart = false;

        public Timer timer1;
        public MainWindow mainwindow;

        public void TimerInitialize(MainWindow _mainwindow)
        {
            mainwindow = _mainwindow;
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = 60; // 60fps, no use using larger number except on 14400000000hz monitors

            try
            {
                hours = int.Parse(mainwindow.txtHours.Text.Trim());
            }
            catch
            {
                hours = 0;
                mainwindow.txtHours.Text = "00";
            }
            try
            {
                minutes = int.Parse(mainwindow.txtMinutes.Text.Trim());
            }
            catch
            {
                minutes = 0;
                mainwindow.txtMinutes.Text = "00";
            }
            try
            {
                seconds = int.Parse(mainwindow.txtSeconds.Text.Trim());
            }
            catch
            {
                seconds = 0;
                mainwindow.txtSeconds.Text = "00";
            }

            totaltime = ((hours * 60 * 60) + (minutes * 60) + (seconds)) * 1000;
            if ((hours > 0) || (hoursOnStart)) hoursString = hours.ToString("00") + ":";
            if ((minutes > 0) || (minutesOnStart)) minutesString = minutes.ToString("00") + ":";
            if ((seconds > 0) || (secondsOnStart)) secondsString = seconds.ToString("00");
            millisecondsString = "." + milliseconds.ToString("000");
            milliseconds = (int)(totaltime % 1000);
            seconds = (int)Math.Ceiling((double)(totaltime / 1000)) % 60;
            minutes = (int)Math.Ceiling((double)(totaltime / 1000 / 60)) % 60;
            hours = (int)Math.Ceiling((double)(totaltime / 1000 / 60 / 60)) % 24;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            totaltime -= timer1.Interval;
            if (totaltime > 59)
            {
                hours = (int)Math.Ceiling((double)(totaltime / 1000 / 60 / 60)) % 24;
                minutes = (int)Math.Ceiling((double)(totaltime / 1000 / 60)) % 60;
                seconds = (int)Math.Ceiling((double)(totaltime / 1000)) % 60;
                milliseconds = (int)(totaltime % 1000);

                if (secondsOnStart)
                {
                    secondsString = seconds.ToString("00");
                }
                else
                {
                    secondsString = "";
                }
                if (minutesOnStart)
                {
                    minutesString = minutes.ToString("00") + ":";
                }
                else
                {
                    minutesString = "";
                }
                if (hoursOnStart)
                {
                    hoursString = hours.ToString("00") + ":";
                }
                else
                {
                    hoursString = "";
                }
                millisecondsString = "." + milliseconds.ToString("000");
                MainWindow.timerWindow.timerDisplay.Text = hoursString + minutesString + secondsString;
                mainwindow.labelTimer.Text = hoursString + minutesString + secondsString + millisecondsString;
            }
            else
            {
                timer1.Stop();
                mainwindow.TimerEnd();
            }

        }

        public void TimerStart()
        {
            timer1.Start();
            timerStatus = true;
            mainwindow.TimerStart();
        }

        public void TimerStop()
        {
            timer1.Stop();
            timerStatus = false;
            mainwindow.TimerStop();
        }
    }
}
