using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MiniMaxTimer
{
    public partial class MainWindow : Form
    {
        Font selectedFont;
        bool firstopen;
        public static TimerWindow timerWindow = new TimerWindow();
        public MainWindow()
        {
            InitializeComponent();
            firstopen = true;
            txtHours.MaxLength = 2;
            txtMinutes.MaxLength = 2;
            txtSeconds.MaxLength = 2;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Hide();

            // Set window location
            if (string.IsNullOrEmpty(txtXPos.Text.Trim()) && (Properties.Settings.Default.WindowLocation != null)) txtXPos.Text = Properties.Settings.Default.WindowLocation.X.ToString();
            if (string.IsNullOrEmpty(txtYPos.Text.Trim()) && (Properties.Settings.Default.WindowLocation != null)) txtYPos.Text = Properties.Settings.Default.WindowLocation.Y.ToString();
            if (string.IsNullOrEmpty(txtWidth.Text.Trim()) && (Properties.Settings.Default.WindowSize != null)) txtWidth.Text = Properties.Settings.Default.WindowSize.Width.ToString();
            if (string.IsNullOrEmpty(txtHeight.Text.Trim()) && (Properties.Settings.Default.WindowSize != null)) txtHeight.Text = Properties.Settings.Default.WindowSize.Height.ToString();

            timerWindow = new TimerWindow
            {
                Location = new Point(int.Parse(txtXPos.Text), int.Parse(txtYPos.Text)),
                Size = new Size(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text)),
                locationXPass = txtXPos.Text,
                locationYPass = txtYPos.Text,
                sizeWidthPass = txtWidth.Text,
                sizeHeightPass = txtHeight.Text,
                fontPass = fontDialog1.Font,
                TopMost = chkOnTop.Checked,
                endTextPass = txtEndText.Text,
                fontColorPass = fontDialog1.Color,
                bgColorPass = bgColorDialog.Color
            };

            if (chkFullscreen.Checked == true)
            {
                Screen[] screens = Screen.AllScreens;
                timerWindow.selectedscreen = slctScreenList.SelectedIndex;
                SetFormLocation(timerWindow, screens[slctScreenList.SelectedIndex]);
                timerWindow.WindowState = FormWindowState.Maximized;
            } else
            {
                timerWindow.WindowState = FormWindowState.Normal;
            }
            timerWindow.Show();
        }

        public void UpdateValues(string width, string height, string xpos, string ypos, bool firstopentemp)
        {
            if (timerWindow.WindowState != FormWindowState.Maximized)
            {
                txtWidth.Text = width;
                txtHeight.Text = height;
                txtXPos.Text = xpos;
                txtYPos.Text = ypos;
            }
            else
            {
                txtWidth.Text = timerWindow.sizeWidthPass;
                txtHeight.Text = timerWindow.sizeHeightPass;
                txtXPos.Text = timerWindow.locationXPass;
                txtYPos.Text = timerWindow.locationYPass;
            }
            firstopen = firstopentemp;
            this.Show();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
            Application.Exit();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            txtHours.Text = Properties.Settings.Default.hours.ToString("00");
            txtMinutes.Text = Properties.Settings.Default.minutes.ToString("00");
            txtSeconds.Text = Properties.Settings.Default.seconds.ToString("00");
            txtEndText.Text = Properties.Settings.Default.endText;

            chkOnTop.Checked = Properties.Settings.Default.alwaysOnTop;
            chkFullscreen.Checked = Properties.Settings.Default.fullscreen;

            this.Location = Properties.Settings.Default.sourceLocation;
            this.Size = Properties.Settings.Default.sourceSize;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));

                Font startFont = (Font)converter.ConvertFromString(Properties.Settings.Default.font);
                fontDialog1.Font = startFont;
                btnFont.Text = string.Format("Font: {0}", startFont.Name);
                btnFont.Font = new Font(startFont.FontFamily, 8);
                btnFont.ForeColor = Properties.Settings.Default.fontColor;
                fontDialog1.Color = Properties.Settings.Default.fontColor;

            bgColorDialog.Color = Properties.Settings.Default.bgColor;
            btnFont.BackColor = bgColorDialog.Color;

            if (firstopen == true)
            {
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

                ListScreens();
            } else
            {
                ListScreens();
                if (chkFullscreen.Checked == true)
                    slctScreenList.Visible = true;
                    slctScreenList.SelectedIndex = timerWindow.selectedscreen;
            }


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

        private void Button2_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            fontDialog1.ShowColor = true;
            if (Properties.Settings.Default.fontColor != null)
            {
                fontDialog1.Color = Properties.Settings.Default.fontColor;
            } else
            {
                fontDialog1.Color = Color.FromName("White");
            }
            
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                selectedFont = fontDialog1.Font;
                // Set TextBox properties.
                btnFont.Text = string.Format("Font: {0}", selectedFont.Name);
                btnFont.Font = new Font(selectedFont.FontFamily, 8);
                btnFont.ForeColor = fontDialog1.Color;
            }
        }


        private void SetFormLocation(Form form, Screen screen)
        {
            form.StartPosition = FormStartPosition.Manual;
            // first method
            Rectangle bounds = screen.Bounds;
            form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            // second method
            //Point location = screen.Bounds.Location;
            //Size size = screen.Bounds.Size;

            //form.Left = location.X;
            //form.Top = location.Y;
            //form.Width = size.Width;
            //form.Height = size.Height;
        }


        private void SaveSettings()
        {
            if (string.IsNullOrEmpty(txtXPos.Text.Trim()) && (Properties.Settings.Default.WindowLocation != null)) txtXPos.Text = Properties.Settings.Default.WindowLocation.X.ToString();
            if (string.IsNullOrEmpty(txtYPos.Text.Trim()) && (Properties.Settings.Default.WindowLocation != null)) txtYPos.Text = Properties.Settings.Default.WindowLocation.Y.ToString();
            if (string.IsNullOrEmpty(txtWidth.Text.Trim()) && (Properties.Settings.Default.WindowSize != null)) txtWidth.Text = Properties.Settings.Default.WindowSize.Width.ToString();
            if (string.IsNullOrEmpty(txtHeight.Text.Trim()) && (Properties.Settings.Default.WindowSize != null)) txtHeight.Text = Properties.Settings.Default.WindowSize.Height.ToString();

            Properties.Settings.Default.WindowLocation = new Point(int.Parse(txtXPos.Text), int.Parse(txtYPos.Text));
            Properties.Settings.Default.WindowSize = new Size(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text));
            Properties.Settings.Default.sourceLocation = this.Location;
            Properties.Settings.Default.sourceSize = this.Size;
            Properties.Settings.Default.hours = int.Parse(txtHours.Text);
            Properties.Settings.Default.minutes = int.Parse(txtMinutes.Text);
            Properties.Settings.Default.seconds = int.Parse(txtSeconds.Text);
            Properties.Settings.Default.alwaysOnTop = chkOnTop.Checked;
            Properties.Settings.Default.fullscreen = chkFullscreen.Checked;
            Properties.Settings.Default.selectedscreen = slctScreenList.SelectedIndex;
            Properties.Settings.Default.endText = txtEndText.Text;
            Properties.Settings.Default.fontColor = fontDialog1.Color;
            Properties.Settings.Default.bgColor = bgColorDialog.Color;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            selectedFont = fontDialog1.Font;
            string fontString = converter.ConvertToString(selectedFont);
            Properties.Settings.Default.font = fontString;


            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

        }

        private void BtnBgColor_Click(object sender, EventArgs e)
        {
            DialogResult bgColorResult = bgColorDialog.ShowDialog();
            if (bgColorResult == DialogResult.OK)
            {
                Color bgColor = bgColorDialog.Color;
                btnFont.BackColor = bgColor;
            }
        }

        private void ListScreens()
        {
            int screenID = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                /*
                // For each screen, add the screen properties to a list box.
                listBox1.Items.Add("Device Name: " + screen.DeviceName);
                listBox1.Items.Add("Bounds: " + screen.Bounds.ToString());
                listBox1.Items.Add("Type: " + screen.GetType().ToString());
                listBox1.Items.Add("Working Area: " + screen.WorkingArea.ToString());
                listBox1.Items.Add("Primary Screen: " + screen.Primary.ToString());
                */

                string screenName = screen.DeviceName.Replace(@"\\.\", "");
                slctScreenList.Items.Add(screenName + ": " + screen.Bounds.Width.ToString() + "x" + screen.Bounds.Height.ToString());

                if (screen.Primary == true)
                {
                    slctScreenList.SelectedIndex = screenID;
                }

                screenID++;
            }
        }

    }

}
