namespace MiniMaxTimer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkOnTop = new System.Windows.Forms.CheckBox();
            this.chkFullscreen = new System.Windows.Forms.CheckBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndText = new System.Windows.Forms.TextBox();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.bgColorDialog = new System.Windows.Forms.ColorDialog();
            this.labelSeparator = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.slctScreenList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(48, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Timer Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(48, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Timer Location";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.Location = new System.Drawing.Point(205, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(246, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(303, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = ":";
            // 
            // chkOnTop
            // 
            this.chkOnTop.AutoSize = true;
            this.chkOnTop.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkOnTop.Location = new System.Drawing.Point(367, 162);
            this.chkOnTop.Name = "chkOnTop";
            this.chkOnTop.Size = new System.Drawing.Size(122, 23);
            this.chkOnTop.TabIndex = 11;
            this.chkOnTop.Text = "Always On Top";
            this.chkOnTop.UseVisualStyleBackColor = true;
            // 
            // chkFullscreen
            // 
            this.chkFullscreen.AutoSize = true;
            this.chkFullscreen.BackColor = System.Drawing.SystemColors.Control;
            this.chkFullscreen.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkFullscreen.Location = new System.Drawing.Point(367, 108);
            this.chkFullscreen.Name = "chkFullscreen";
            this.chkFullscreen.Size = new System.Drawing.Size(91, 23);
            this.chkFullscreen.TabIndex = 12;
            this.chkFullscreen.Text = "Fullscreen";
            this.chkFullscreen.UseVisualStyleBackColor = false;
            this.chkFullscreen.CheckedChanged += new System.EventHandler(this.ChkFullscreen_CheckedChanged);
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtHours.Location = new System.Drawing.Point(205, 44);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(37, 34);
            this.txtHours.TabIndex = 1;
            this.txtHours.Text = "00";
            this.txtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHours.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMinutes.Location = new System.Drawing.Point(260, 44);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(37, 34);
            this.txtMinutes.TabIndex = 2;
            this.txtMinutes.Text = "00";
            this.txtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinutes.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // txtSeconds
            // 
            this.txtSeconds.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSeconds.Location = new System.Drawing.Point(319, 44);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(37, 34);
            this.txtSeconds.TabIndex = 3;
            this.txtSeconds.Text = "00";
            this.txtSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSeconds.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWidth.Location = new System.Drawing.Point(205, 103);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(63, 30);
            this.txtWidth.TabIndex = 4;
            this.txtWidth.Text = "width";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWidth.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHeight.Location = new System.Drawing.Point(293, 103);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(63, 30);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.Text = "height";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeight.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // txtXPos
            // 
            this.txtXPos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXPos.Location = new System.Drawing.Point(205, 157);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.Size = new System.Drawing.Size(63, 30);
            this.txtXPos.TabIndex = 6;
            this.txtXPos.Text = "X";
            this.txtXPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtXPos.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // txtYPos
            // 
            this.txtYPos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYPos.Location = new System.Drawing.Point(293, 157);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.Size = new System.Drawing.Size(63, 30);
            this.txtYPos.TabIndex = 7;
            this.txtYPos.Text = "Y";
            this.txtYPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYPos.Enter += new System.EventHandler(this.TextBox_Enter);
            // 
            // btnFont
            // 
            this.btnFont.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnFont.Location = new System.Drawing.Point(205, 317);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(205, 34);
            this.btnFont.TabIndex = 13;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label6.Location = new System.Drawing.Point(49, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Text when timer ends";
            // 
            // txtEndText
            // 
            this.txtEndText.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtEndText.Location = new System.Drawing.Point(205, 397);
            this.txtEndText.Name = "txtEndText";
            this.txtEndText.Size = new System.Drawing.Size(205, 25);
            this.txtEndText.TabIndex = 15;
            // 
            // btnBgColor
            // 
            this.btnBgColor.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBgColor.Location = new System.Drawing.Point(205, 356);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(205, 34);
            this.btnBgColor.TabIndex = 17;
            this.btnBgColor.Text = "Background Color";
            this.btnBgColor.UseVisualStyleBackColor = true;
            this.btnBgColor.Click += new System.EventHandler(this.BtnBgColor_Click);
            // 
            // labelSeparator
            // 
            this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSeparator.Location = new System.Drawing.Point(53, 277);
            this.labelSeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSeparator.Name = "labelSeparator";
            this.labelSeparator.Size = new System.Drawing.Size(426, 2);
            this.labelSeparator.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Shortcuts";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(53, 464);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(426, 2);
            this.label8.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 518);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Left-click:      Start/Continue";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Right-click:    Restart";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 558);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(227, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Double-click: Restart and Continue";
            // 
            // slctScreenList
            // 
            this.slctScreenList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slctScreenList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.slctScreenList.FormattingEnabled = true;
            this.slctScreenList.Location = new System.Drawing.Point(367, 158);
            this.slctScreenList.Name = "slctScreenList";
            this.slctScreenList.Size = new System.Drawing.Size(156, 25);
            this.slctScreenList.TabIndex = 76;
            this.slctScreenList.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 604);
            this.Controls.Add(this.slctScreenList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelSeparator);
            this.Controls.Add(this.btnBgColor);
            this.Controls.Add(this.txtEndText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.txtYPos);
            this.Controls.Add(this.txtXPos);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.chkFullscreen);
            this.Controls.Add(this.chkOnTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "MiniMax Timer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkOnTop;
        private System.Windows.Forms.CheckBox chkFullscreen;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndText;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.ColorDialog bgColorDialog;
        private System.Windows.Forms.Label labelSeparator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox slctScreenList;
    }
}

