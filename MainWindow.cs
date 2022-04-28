using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net.Http;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;
using System.Media;

namespace MiniMaxTimer
{
    public partial class MainWindow : Form
    {
        public Assembly imageAssembly = Assembly.GetExecutingAssembly();

        public static TimerWindow timerWindow;
        public TimerClass timerClass = new();
        Font selectedFont;
        Color selectedColor;
        Color selectedBgColor;
        Font pauseFont;
        Color pauseColor;
        Color pauseBgColor;
        Font endFont;
        Color endColor;
        Color endBgColor;
        Point lastLocation;
        string soundPath;

        public bool updateAvailable = false;
        string updateurl = "https://raw.githubusercontent.com/honganqi/MiniMax-Timer/main/latest.json";
        string downloadURL = "";

        public MainWindow()
        {
            InitializeComponent();

            Stream thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.sflogo.png");
            Bitmap thumbBitmap = new Bitmap(thumbStream);
            imgSF.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.youtube.png");
            thumbBitmap = new Bitmap(thumbStream);
            imgYoutube.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.twitch.png");
            thumbBitmap = new Bitmap(thumbStream);
            imgTwitch.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.exit.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnClose.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.min.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnMinimize.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.start.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnStart.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.restart.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnRestart.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.close.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnCloseTimer.BackgroundImage = thumbBitmap;

            string currentVerString = Application.ProductVersion;
            List<string> currentVersionSplit = currentVerString.Split('.').ToList();
            if (currentVersionSplit[3] == "0") currentVersionSplit.RemoveAt(3);
            if (currentVersionSplit[2] == "0") currentVersionSplit.RemoveAt(2);
            labelVerNum.Text = "v" + string.Join(".", currentVersionSplit) + " by honganqi";

            txtHours.MaxLength = 2;
            txtMinutes.MaxLength = 2;
            txtSeconds.MaxLength = 2;

            timerWindow = new(this);
            CheckUpdate(updateurl);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ListScreens();
            if (chkFullscreen.Checked == true)
                slctScreenList.Visible = true;
            slctScreenList.SelectedIndex = timerWindow.selectedscreen;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitAsk = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (exitAsk == DialogResult.No);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
            Application.Exit();
        }

        // BUTTONS
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timerClass.timerStatus)
            {
                SaveSettings();

                if (chkDisplaySeconds.Checked) timerClass.secondsOnStart = true;
                if (chkDisplayMinutes.Checked) timerClass.minutesOnStart = true;
                if (chkDisplayHours.Checked) timerClass.hoursOnStart = true;

                OpenTimerWindow();
                timerWindow.timerDisplay.Text = timerClass.hoursString + timerClass.minutesString + timerClass.secondsString;
                labelTimer.Text = timerClass.hoursString + timerClass.minutesString + timerClass.secondsString + timerClass.millisecondsString;

                timerWindow.Show();
                timerClass.TimerStart();
                btnStart.Text = "PAUSE";
                btnRestart.Enabled = true;
                btnCloseTimer.Enabled = true;
            }
            else
            {
                timerClass.TimerStop();
                btnStart.Text = "START";
            }

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            timerClass.TimerStop();
            timerClass.TimerInitialize(this);
            timerClass.TimerStart();
        }

        private void btnCloseTimer_Click(object sender, EventArgs e)
        {
            CloseTimer();
        }

        private void ChkFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullscreen.Checked == true)
            {
                txtWidth.Enabled = false;
                txtHeight.Enabled = false;
                txtXPos.Enabled = false;
                txtYPos.Enabled = false;
                slctScreenList.Visible = true;
            }
            else
            {
                txtWidth.Enabled = true;
                txtHeight.Enabled = true;
                txtXPos.Enabled = true;
                txtYPos.Enabled = true;
                slctScreenList.Visible = false;
            }
        }

        private void SetFormLocation(Form form, Screen screen)
        {
            form.StartPosition = FormStartPosition.Manual;
            Rectangle bounds = screen.Bounds;
            form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }



        // APP FUNCTIONS
        private void OpenTimerWindow()
        {
            bool timerIsOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "TimerWindow")
                    timerIsOpen = true;
            }

            if (!timerIsOpen)
            {
                timerWindow = new TimerWindow(this)
                {
                    Location = new Point(int.Parse(txtXPos.Text), int.Parse(txtYPos.Text)),
                    Size = new Size(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text)),
                    locationX = txtXPos.Text,
                    locationY = txtYPos.Text,
                    width = txtWidth.Text,
                    height = txtHeight.Text,
                    selectedFont = selectedFont,
                    pauseFont = pauseFont,
                    endFont = endFont,
                    TopMost = chkOnTop.Checked,
                    endText = txtEndText.Text,
                    fontColor = selectedColor,
                    bgColor = selectedBgColor,
                };
                timerClass.TimerInitialize(this);
                labelActive.Show();
            }

            if (chkFullscreen.Checked == true)
            {
                Screen[] screens = Screen.AllScreens;
                timerWindow.selectedscreen = slctScreenList.SelectedIndex;
                SetFormLocation(timerWindow, screens[slctScreenList.SelectedIndex]);
                timerWindow.WindowState = FormWindowState.Maximized;
            }
            else
            {
                timerWindow.WindowState = FormWindowState.Normal;
            }
            labelTimer.Show();
        }

        public void TimerStart()
        {
            Stream thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.pause.png");
            Bitmap thumbBitmap = new Bitmap(thumbStream);
            btnStart.BackgroundImage = thumbBitmap;
            labelActive.Text = "ACTIVE";
            labelActive.ForeColor = Color.ForestGreen;
            btnRestart.Show();
            btnCloseTimer.Show();
            timerWindow.UpdateDisplay(selectedFont, selectedColor, selectedBgColor);
        }

        public void TimerStop()
        {
            Stream thumbStream = imageAssembly.GetManifestResourceStream("MiniMaxTimer.img.start.png");
            Bitmap thumbBitmap = new Bitmap(thumbStream);
            btnStart.BackgroundImage = thumbBitmap;
            labelActive.Text = "PAUSED";
            labelActive.ForeColor = Color.Crimson;
            btnStart.Text = "START";
            timerWindow.UpdateDisplay(pauseFont, pauseColor, pauseBgColor);
        }

        public void TimerEnd()
        {
            labelActive.Text = "END";
            labelActive.ForeColor = Color.Crimson;
            labelTimer.Hide();
            timerWindow.UpdateDisplay(endFont, endColor, endBgColor);
            if ((soundPath != "") && File.Exists(soundPath))
            {
                using (var soundPlayer = new SoundPlayer(soundPath))
                {
                    soundPlayer.Play(); // can also use soundPlayer.PlaySync()
                }
            }
            timerWindow.TimerEnd();
        }

        public void CloseTimer()
        {
            timerClass.TimerStop();
            timerWindow.Close();
            TimerStop();
            btnRestart.Hide();
            btnCloseTimer.Hide();
        }

        private void SaveSettings()
        {
            if (string.IsNullOrEmpty(txtXPos.Text.Trim()) && (Properties.Settings.Default.WindowLocation != null)) txtXPos.Text = Properties.Settings.Default.WindowLocation.X.ToString();
            if (string.IsNullOrEmpty(txtYPos.Text.Trim()) && (Properties.Settings.Default.WindowLocation != null)) txtYPos.Text = Properties.Settings.Default.WindowLocation.Y.ToString();
            if (string.IsNullOrEmpty(txtWidth.Text.Trim()) && (Properties.Settings.Default.WindowSize != null)) txtWidth.Text = Properties.Settings.Default.WindowSize.Width.ToString();
            if (string.IsNullOrEmpty(txtHeight.Text.Trim()) && (Properties.Settings.Default.WindowSize != null)) txtHeight.Text = Properties.Settings.Default.WindowSize.Height.ToString();

            Properties.Settings.Default.WindowLocation = new Point(int.Parse(txtXPos.Text), int.Parse(txtYPos.Text));
            Properties.Settings.Default.WindowSize = new Size(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text));
            Properties.Settings.Default.sourceLocation = Location;
            Properties.Settings.Default.hours = int.Parse(txtHours.Text);
            Properties.Settings.Default.minutes = int.Parse(txtMinutes.Text);
            Properties.Settings.Default.seconds = int.Parse(txtSeconds.Text);
            Properties.Settings.Default.alwaysOnTop = chkOnTop.Checked;
            Properties.Settings.Default.fullscreen = chkFullscreen.Checked;
            Properties.Settings.Default.selectedscreen = slctScreenList.SelectedIndex;
            Properties.Settings.Default.endText = txtEndText.Text;
            Properties.Settings.Default.fontColor = selectedColor;
            Properties.Settings.Default.bgColor = selectedBgColor;
            Properties.Settings.Default.displayHours = chkDisplayHours.Checked;
            Properties.Settings.Default.displayMinutes = chkDisplayMinutes.Checked;
            Properties.Settings.Default.displaySeconds = chkDisplaySeconds.Checked;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            Properties.Settings.Default.font = selectedFont;
            Properties.Settings.Default.fontColor = selectedColor;
            Properties.Settings.Default.bgColor = selectedBgColor;
            Properties.Settings.Default.pauseFont = pauseFont;
            Properties.Settings.Default.pauseColor = pauseColor;
            Properties.Settings.Default.pauseBgColor = pauseBgColor;
            Properties.Settings.Default.endFont = endFont;
            Properties.Settings.Default.endColor = endColor;
            Properties.Settings.Default.endBgColor = endBgColor;

            Properties.Settings.Default.soundPath = soundPath;


            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

        }

        private void LoadSettings()
        {
            txtHours.Text = Properties.Settings.Default.hours.ToString("00");
            txtMinutes.Text = Properties.Settings.Default.minutes.ToString("00");
            txtSeconds.Text = Properties.Settings.Default.seconds.ToString("00");
            txtEndText.Text = Properties.Settings.Default.endText;

            chkOnTop.Checked = Properties.Settings.Default.alwaysOnTop;
            chkFullscreen.Checked = Properties.Settings.Default.fullscreen;
            chkDisplayHours.Checked = Properties.Settings.Default.displayHours;
            chkDisplayMinutes.Checked = Properties.Settings.Default.displayMinutes;
            chkDisplaySeconds.Checked = Properties.Settings.Default.displaySeconds;

            Location = Properties.Settings.Default.sourceLocation;
            lastLocation = Location;


            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));

            selectedFont = Properties.Settings.Default.font;
            selectedColor = Properties.Settings.Default.fontColor;
            selectedBgColor = Properties.Settings.Default.bgColor;
            labelPreview.Text = string.Format("Font: {0}", selectedFont.Name);
            labelPreview.Font = new Font(selectedFont.FontFamily, 8);
            labelPreview.ForeColor = selectedColor;
            labelPreview.BackColor = selectedBgColor;

            pauseFont = Properties.Settings.Default.pauseFont;
            pauseColor = Properties.Settings.Default.pauseColor;
            pauseBgColor = Properties.Settings.Default.pauseBgColor;
            labelPreviewPause.Text = string.Format("Font: {0}", pauseFont.Name);
            labelPreviewPause.Font = new Font(pauseFont.FontFamily, 8);
            labelPreviewPause.ForeColor = pauseColor;
            labelPreviewPause.BackColor = pauseBgColor;

            endFont = Properties.Settings.Default.endFont;
            endColor = Properties.Settings.Default.endColor;
            endBgColor = Properties.Settings.Default.endBgColor;
            labelPreviewEnd.Text = string.Format("Font: {0}", endFont.Name);
            labelPreviewEnd.Font = new Font(endFont.FontFamily, 8);
            labelPreviewEnd.ForeColor = endColor;
            labelPreviewEnd.BackColor = endBgColor;

            // Set window location
            if (Properties.Settings.Default.WindowLocation != null)
            {
                txtXPos.Text = Properties.Settings.Default.WindowLocation.X.ToString();
                txtYPos.Text = Properties.Settings.Default.WindowLocation.Y.ToString();
            }

            // Set window size
            if (Properties.Settings.Default.WindowSize != null)
            {
                txtWidth.Text = Properties.Settings.Default.WindowSize.Width.ToString();
                txtHeight.Text = Properties.Settings.Default.WindowSize.Height.ToString();
            }

            soundPath = Properties.Settings.Default.soundPath.Trim();
            
            if (!File.Exists(soundPath) && (soundPath != ""))
            {
                MessageBox.Show("The sound file \"" + soundPath + "\" could not be found. Please specify another file if you want to play a sound after the timer ends.");
                labelSound.Hide();
                soundPath = "";
            }
            else if (soundPath != "")
            {
                labelSound.Text = soundPath;
                labelSound.Show();
                ToolTip soundtip = new();
                soundtip.SetToolTip(labelSound, soundPath);
            }
        }

        private void ListScreens()
        {
            int screenID = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                string screenName = screen.DeviceName.Replace(@"\\.\", "");
                slctScreenList.Items.Add(screenName + ": " + screen.Bounds.Width.ToString() + "x" + screen.Bounds.Height.ToString());
                if (screen.Primary == true)
                    slctScreenList.SelectedIndex = screenID;
                screenID++;
            }
        }

        public void MoveWindow(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - lastLocation.X;
                int dy = e.Location.Y - lastLocation.Y;
                Location = new Point(Location.X + dx, Location.Y + dy);
            }
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        public void GetUpdate()
        {
            if (downloadURL != "") System.Diagnostics.Process.Start(downloadURL);
        }

        public async void CheckUpdate(string url)
        {
            List<string> onlineVer = new();
            List<string> currentVer = new();
            var client = new HttpClient();
            var request = client.GetAsync(url);

            Task timeout = Task.Delay(3000);
            await Task.WhenAny(timeout, request);

            try
            {
                HttpResponseMessage response = request.Result;
                if (response.IsSuccessStatusCode)
                {
                    var page = response.Content.ReadAsStringAsync();
                    var queryResult = Newtonsoft.Json.JsonConvert.DeserializeObject<VersionClass>(page.Result);

                    if ((queryResult != null) && (queryResult.ReleaseDate != null))
                    {
                        DateTime releaseDate = DateTime.Parse(queryResult.ReleaseDate).ToUniversalTime();
                        string onlineVerString = queryResult.Version;
                        string currentVerString = Application.ProductVersion;
                        downloadURL = queryResult.DownloadURL;
                        if (onlineVerString.CompareTo(currentVerString) > 0)
                        {
                            List<string> versionSplit = onlineVerString.Split('.').ToList();
                            if (versionSplit[3] == "0") versionSplit.RemoveAt(3);
                            if (versionSplit[2] == "0") versionSplit.RemoveAt(2);
                            onlineVer.Add(string.Join(".", versionSplit));
                            onlineVer.Add(releaseDate.ToLocalTime().ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern));
                            btnUpdateNotif.Text = "v" + onlineVer[0] + " is now available!\nGET IT NOW!";
                            if (queryResult.Description != "")
                            {
                                ToolTip updateTooltip = new();
                                updateTooltip.SetToolTip(btnUpdateNotif, "Download from: " + queryResult.DownloadURL + "\n\n" + queryResult.Description);
                            }

                            versionSplit = new(currentVerString.Split('.').ToList());
                            if (versionSplit[3] == "0") versionSplit.RemoveAt(3);
                            if (versionSplit[2] == "0") versionSplit.RemoveAt(2);
                            currentVer.Add(string.Join(".", versionSplit));
                            currentVer.Add(releaseDate.ToLocalTime().ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern));
                            btnUpdateNotif.Show();
                        }
                    }
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.NotFound:
                            throw new Exception("The update file was not found on the server.");
                        case System.Net.HttpStatusCode.BadRequest:
                            throw new Exception("");
                        case System.Net.HttpStatusCode.InternalServerError:
                            throw new Exception("");
                        case System.Net.HttpStatusCode.MethodNotAllowed:
                            throw new Exception("");
                        case System.Net.HttpStatusCode.Forbidden:
                            throw new Exception("");
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        public class VersionClass
        {
            [Newtonsoft.Json.JsonProperty("release_date")]
            public string ReleaseDate { get; set; }

            [Newtonsoft.Json.JsonProperty("version")]
            public string Version { get; set; }
            [Newtonsoft.Json.JsonProperty("download_url")]
            public string DownloadURL { get; set; }
            [Newtonsoft.Json.JsonProperty("description")]
            public string Description { get; set; }
        }



        // UI CUSTOMIZATION
        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontdialog = new FontDialog
            {
                ShowColor = true,
            };
            if (Properties.Settings.Default.fontColor != null)
            {
                fontdialog.Color = Properties.Settings.Default.fontColor;
            }
            else
            {
                fontdialog.Color = Color.FromName("White");
            }

            DialogResult result = fontdialog.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                selectedFont = fontdialog.Font;
                selectedColor = fontdialog.Color;
                labelPreview.Font = new Font(selectedFont.FontFamily, 8);
                labelPreview.Text = string.Format("Font: {0}", selectedFont.Name);
                labelPreview.ForeColor = fontdialog.Color;
            }
        }

        private void BtnBgColor_Click(object sender, EventArgs e)
        {
            ColorDialog colordialog = new();
            DialogResult bgColorResult = colordialog.ShowDialog();
            if (bgColorResult == DialogResult.OK)
            {
                selectedBgColor = colordialog.Color;
                labelPreview.BackColor = selectedBgColor;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnLoadSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Sound Files (*.wav)|*.wav",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelSound.Text = ofd.FileName;
                labelSound.Show();
                soundPath = ofd.FileName;
            }
        }

        private void btnFontPause_Click(object sender, EventArgs e)
        {
            FontDialog fontdialog = new FontDialog
            {
                ShowColor = true,
            };
            if (Properties.Settings.Default.pauseColor != null)
            {
                fontdialog.Color = Properties.Settings.Default.pauseColor;
            }
            else
            {
                fontdialog.Color = Color.FromName("White");
            }

            DialogResult result = fontdialog.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                pauseFont = fontdialog.Font;
                pauseColor = fontdialog.Color;
                labelPreviewPause.Font = pauseFont;
                labelPreviewPause.Text = string.Format("Font: {0}", pauseFont.Name);
                labelPreviewPause.ForeColor = fontdialog.Color;
            }
        }

        private void btnBgColorPause_Click(object sender, EventArgs e)
        {
            ColorDialog colordialog = new();
            DialogResult bgColorResult = colordialog.ShowDialog();
            if (bgColorResult == DialogResult.OK)
            {
                pauseBgColor = colordialog.Color;
                labelPreviewPause.BackColor = pauseBgColor;
            }
        }

        private void btnFontEnd_Click(object sender, EventArgs e)
        {
            FontDialog fontdialog = new FontDialog
            {
                ShowColor = true,
            };
            if (Properties.Settings.Default.endColor != null)
            {
                fontdialog.Color = Properties.Settings.Default.endColor;
            }
            else
            {
                fontdialog.Color = Color.FromName("White");
            }

            DialogResult result = fontdialog.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                endFont = fontdialog.Font;
                endColor = fontdialog.Color;
                labelPreviewEnd.Font = endFont;
                labelPreviewEnd.Text = string.Format("Font: {0}", endFont.Name);
                labelPreviewEnd.ForeColor = fontdialog.Color;
            }
        }   

        private void btnBgColorEnd_Click(object sender, EventArgs e)
        {
            ColorDialog colordialog = new();
            DialogResult bgColorResult = colordialog.ShowDialog();
            if (bgColorResult == DialogResult.OK)
            {
                endBgColor = colordialog.Color;
                labelPreviewEnd.BackColor = endBgColor;
            }
        }


        // SOCIALS
        private void imgYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtube.com/honganqi");
        }

        private void imgTwitch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitch.tv/honganqi");
        }

        private void imgSF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/p/minimax-timer/");
        }

        private void btnUpdateNotif_Click(object sender, EventArgs e)
        {
            GetUpdate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }

}
